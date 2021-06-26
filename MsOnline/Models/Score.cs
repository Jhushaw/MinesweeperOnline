using System.Runtime.Serialization;

namespace MsOnline.Models
{
    [DataContract]
    public class Score
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string time { get; set; }
        [DataMember]
        public int clicks { get; set; }
        [DataMember]
        public string username { get; set; }
        [DataMember]
        public int user_id { get; set; }

        public Score(int id, string time, int clicks, string username, int user_id)
        {
            this.id = id;
            this.time = time;
            this.clicks = clicks;
            this.username = username;
            this.user_id = user_id;
        }
    }
}