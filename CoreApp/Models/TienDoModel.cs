using System;
namespace CoreApp.Models
{
    public class TienDoModel
    {
        public TienDoModel()
        {
        }

        public TienDoModel(int giaTriTienDo, string tenTienDo)
        {
            this.giaTriTienDo = giaTriTienDo;
            this.tenTienDo = tenTienDo;
        }

        public int giaTriTienDo { get; set; }

        public string tenTienDo { get; set; }
    }
}
