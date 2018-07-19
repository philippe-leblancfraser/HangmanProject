using System;
using System.Runtime.Serialization;

namespace Gaming.GameService.DataType
{
    [DataContract]
    public class Response
    {
        [DataMember(Name="count")]
        public int Count { get; set; }
    }
}
