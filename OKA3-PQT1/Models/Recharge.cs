using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using OKA3_PQT1.Models;

namespace OKA3_PQT1.Models
{
    public class Recharge
    {
        BanHangDBEntities database = new BanHangDBEntities();
        public bool checkPass(string pass, int mauser)
        {
            var user = database.USERS.Where(s => s.MaUser == mauser).FirstOrDefault();
            if (pass != user.MatKhau)
            {
                return false;
            }
            return true;
        }
    }
}