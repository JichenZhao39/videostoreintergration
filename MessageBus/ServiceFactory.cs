﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace MessageBus
{
    public class ServiceFactory
    {


        public static T GetService<T>(String pAddress)
        {
            return GetChannelFactory<T>(pAddress).CreateChannel();
        }

        private static ChannelFactory<T1> GetChannelFactory<T1>(string pHandlerAddress)
        {
            Binding lBinding;
            if (pHandlerAddress.Contains("net.tcp"))
            {
                lBinding = new NetTcpBinding();
            }
            else if (pHandlerAddress.Contains("net.msmq"))
            {
                lBinding = new NetMsmqBinding(NetMsmqSecurityMode.None) { Durable = true };
            }
            else
            {
                throw new Exception("Unrecognized address type");
            }
            EndpointAddress myEndpoint = new EndpointAddress(pHandlerAddress);
            ChannelFactory<T1> myChannelFactory = new ChannelFactory<T1>(lBinding, myEndpoint);
            return myChannelFactory;
        }
    }
}
