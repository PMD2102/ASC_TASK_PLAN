using System;
namespace CoreApp.Models
{
    public class ChatLuongThangModel
    {
        public ChatLuongThangModel()
        {

        }

        public ChatLuongThangModel(int giaTriChatLuongThang, string tenChatLuongThang)
        {
            this.giaTriChatLuongThang = giaTriChatLuongThang;
            this.tenChatLuongThang = tenChatLuongThang;
        }

        public int giaTriChatLuongThang { get; set; }

        public string tenChatLuongThang { get; set; }
    }
}
