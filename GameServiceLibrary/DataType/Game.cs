using System.Runtime.Serialization;

namespace GamingService.DataType
{
    [DataContract]
    public class Game
    {
        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name = "summary")]
        public string Summary { get; set; }

    }
}
