using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfToDbTournamentGenerator
{
    [DataContract]
    public class Player
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public int Speed { get; set; }
        [DataMember]
        public int Strength { get; set; }
        [DataMember]
        public int Skill { get; set; }
    }
}
