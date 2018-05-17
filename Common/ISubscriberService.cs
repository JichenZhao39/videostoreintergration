using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Common.Model;

namespace Common
{
    [ServiceContract]
    public interface ISubscriberService
    {
        [OperationContract(IsOneWay = true)]
        void PublishToSubscriber(Message pMessage);
    }
}
