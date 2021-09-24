using System;
using System.ComponentModel.DataAnnotations;

namespace CoreApp.Models
{
    public class eDanhGiaCVTuanModel
    {
        public eDanhGiaCVTuanModel()
        {

        }

        public eDanhGiaCVTuanModel(int idCongViecTuan,int idTuan, string tenTuan, KhoiLuongModel KhoiLuongModel, TienDoModel TienDoModel, ChatLuongTuanModel ChatLuongTuanModel, string nhanXetTuan)
        {
            this.idCongViecTuan = idCongViecTuan;
            this.idTuan = idTuan;
            this.tenTuan = tenTuan;
            this.KhoiLuongModel = KhoiLuongModel;
            this.TienDoModel = TienDoModel;
            this.ChatLuongTuanModel = ChatLuongTuanModel;
            this.nhanXetTuan = nhanXetTuan;
        }

        public int idCongViecTuan { get; set; }

        public int idTuan { get; set; }

        public string tenTuan { get; set; }


        [UIHint("clientKhoiLuong")]
        public KhoiLuongModel KhoiLuongModel { get; set; }

        [UIHint("clientTienDo")]
        public TienDoModel TienDoModel { get; set; }

        [UIHint("clientTuanModel")]
        public ChatLuongTuanModel ChatLuongTuanModel { get; set; }

        public string nhanXetTuan { get; set; }
    }
}
