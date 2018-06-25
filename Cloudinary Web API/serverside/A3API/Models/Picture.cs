using System;
namespace A3API.Models
{
    public class Picture
    {
        public Picture(){
            
        }
        public Picture(string stuid, string url)
        {
            StudentId = stuid;
            URL = url;
        }
        public long id { set; get; }
        public string StudentId { set; get; }
        public string URL { set; get; }
    }
}
