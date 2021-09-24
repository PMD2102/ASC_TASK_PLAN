using System;
namespace CoreApp.Models
{
    public class ChatLuongTuanModel
    {
        public ChatLuongTuanModel()
        {
        }

        public ChatLuongTuanModel(int giaTriChatLuongTuan, string tenChatLuongTuan)
        {
            this.giaTriChatLuongTuan = giaTriChatLuongTuan;
            this.tenChatLuongTuan = tenChatLuongTuan;
        }

        public int giaTriChatLuongTuan { get; set; }

        public string tenChatLuongTuan { get; set; }
    }
}
