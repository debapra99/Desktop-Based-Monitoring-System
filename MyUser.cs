using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class MyUser
    {
        public string Email { get; set; }
        public string Nama { get; set; }
        public string Telepon { get; set; }
        public string Password { get; set; }

        

        private static string error = "Masukkan Nama dan Password anda";

        public static void ShowError()
        {
            System.Windows.Forms.MessageBox.Show(error);
        }

        public static bool IsEqual(MyUser user1, MyUser user2)
        {
            if (user1 == null || user2 == null) { return false; }

            if( user1.Nama != user2.Nama)
            {
                error = "Nama atau Password anda salah";
                return false; 

            }

            else if (user1.Password != user2.Password)
            {
                error = "Nama atau Password anda salah";
                return false;
            }
            return true;
        }   
    }
}
