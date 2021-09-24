using System;
using CoreApp.Models;

namespace CoreApp.Service
{
    public interface IACL_NguoiDungService
    {
        public bool CheckACLNguoiDung(string username, string password);

        public AclNguoiDung GetAclNguoiDung(string username);

        public NsNhanSu GetNhanSu(string idNhanSu);
    }
}