using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MsOnline.Models
{
    [DataContract]
    public class GameObject
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string JSONstring { get; set; }
        [DataMember]
        public int users_id { get; set; }
        
        public GameObject(int id, string jSONstring, int users_id)
        {
            this.id = id;
            this.JSONstring = jSONstring;
            this.users_id = users_id;
        }
    }
}