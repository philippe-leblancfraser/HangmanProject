using System.Runtime.Serialization;

namespace GamingService.DataType
{
    [DataContract]
    public class Response
    {
        [DataMember(Name="count")]
        public int Count { get; set; }
    }
}
