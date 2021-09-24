using CoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace CoreApp.Service
{
    public class ACL_NguoiDungService : IACL_NguoiDungService
    {
        public bool CheckACLNguoiDung(string username, string password)
        {
            using (var context = new ASC_TASK_PLANNINGContext())
            {
                var user = context.AclNguoiDungs.Where(u => u.Username.Equals(username)).FirstOrDefault();
                if (user != null)
                {
                    if (user.Password.Equals(password))
                        return true;
                    else
                        return false;
                }
                else
                    return false;

            }
        }

        public AclNguoiDung GetAclNguoiDung(string username)
        {
            using (var context = new ASC_TASK_PLANNINGContext())
            {
                var aclNguoiDung = context.AclNguoiDungs.Where(nguoiDung => nguoiDung.Username.Equals(username)).FirstOrDefault();
                return aclNguoiDung;
            }
        }

        public NsNhanSu GetNhanSu(string idNhanSu)
        {
            using (var context = new ASC_TASK_PLANNINGContext())
            {
                int idNS = Convert.ToInt32(idNhanSu);
                var nhanSu = context.NsNhanSus.Where(ns => ns.Id == idNS).FirstOrDefault();
                return nhanSu;
            }
        }
    }
}