using System;
using System.ComponentModel.DataAnnotations;

namespace CoreApp.Models
{
    public class eDanhGiaCVThangModel
    {
        public eDanhGiaCVThangModel()
        {

        }

        public eDanhGiaCVThangModel(int idThang, string tenThang, KhoiLuongModel KhoiLuongModel, TienDoModel TienDoModel, ChatLuongThangModel ChatLuongThangModel, string nhanXetThang)
        {
            this.idThang = idThang;
            this.tenThang = tenThang;
            this.KhoiLuongModel = KhoiLuongModel;
            this.TienDoModel = TienDoModel;
            this.ChatLuongThangModel = ChatLuongThangModel;
            this.nhanXetThang = nhanXetThang;
        }

        public int idThang { get; set; }

        public string tenThang { get; set; }

        [UIHint("clientKhoiLuong")]
        public KhoiLuongModel KhoiLuongModel { get; set; }

        [UIHint("clientTienDo")]
        public TienDoModel TienDoModel { get; set; }

        [UIHint("clientThangModel")]
        public ChatLuongThangModel ChatLuongThangModel { get; set; }

        public string nhanXetThang { get; set; }

    }
}
