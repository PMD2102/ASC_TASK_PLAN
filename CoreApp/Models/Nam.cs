using System;
namespace CoreApp.Models
{
    public class Nam
    {
        public Nam()
        {

        }

        public Nam(int nam, string tenNam)
        {
            this.nam = nam;
            this.tenNam = tenNam;
        }
        public int nam { get; set; }
        public string tenNam { get; set; }
    }
}
