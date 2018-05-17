using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace MessageBus.Interfaces
{
    [ServiceContract]
    public interface ISubscriptionService
    {
        [OperationContract]
        void Subscribe(String pTopic, String pCallerAddress);

        [OperationContract]
        void Unsubscribe(String pTopic, String pCallerAddress);
    }
}
