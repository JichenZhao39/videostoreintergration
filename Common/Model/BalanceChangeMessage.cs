using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Common.Model
{
    [DataContract]
    public class BalanceChangeMessage : Message
    {
        [DataMember]
        public string Item { get; set; }

        [DataMember]
        public double Balance { get; set; }
    }
}
