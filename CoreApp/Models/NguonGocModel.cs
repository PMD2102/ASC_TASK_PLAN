using System;
namespace CoreApp.Models
{
    public class NguonGocModel
    {
        public NguonGocModel()
        {

        }


        public NguonGocModel(int giaTriNguonGoc, string tenNguonGoc)
        {
            this.giaTriNguonGoc = giaTriNguonGoc;
            this.tenNguonGoc = tenNguonGoc;
        }

        public int giaTriNguonGoc { get; set; }

        public string tenNguonGoc { get; set; }
    }
}
