using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessageBus.Interfaces;
using Common.Model;
using System.ServiceModel;
using Common;

namespace MessageBus
{
    public class PublisherService : IPublisherService
    {
        public void Publish(Message pMessage)
        {
            foreach (String lHandlerAddress in SubscriptionRegistry.Instance.GetTopicSubscribers(pMessage.Topic))
            {
                ISubscriberService lSubServ = ServiceFactory.GetService<ISubscriberService>(lHandlerAddress);
                lSubServ.PublishToSubscriber(pMessage);
            }
        }

    }
}
