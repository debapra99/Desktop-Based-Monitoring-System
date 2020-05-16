using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "KAjSZyGu9BbJeHscNyCVzSKnloCF91kNRWMuHYaP",
            BasePath = "https://idpassword-8d768.firebaseio.com/"

        };

        IFirebaseClient client;

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(ifc);
            }

            catch
            {
                MessageBox.Show("Please check your internet connection");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lineShape1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnregis_Click(object sender, EventArgs e)
        {
            #region Condition
            if (string.IsNullOrWhiteSpace(txtemail.Text) &&
                string.IsNullOrWhiteSpace(txtnama.Text) &&
                string.IsNullOrWhiteSpace(txttelepon.Text) &&
                string.IsNullOrWhiteSpace(txtpass.Text) &&
                string.IsNullOrWhiteSpace(txtrepass.Text))
            {
                MessageBox.Show("Tolong lengkapi formulir yang kosong");
                return;
            }
            #endregion

            MyUser user = new MyUser()
            {

                Email = txtemail.Text,
                Nama = txtnama.Text,
                Telepon = txttelepon.Text,
                Password = txtpass.Text
            };
            SetResponse set = client.Set(@"Users/" + txtnama.Text, user);
            MyUser ReUser = set.ResultAs<MyUser>();

            MyUser CurUser = new MyUser()
            {
                Nama = txtnama.Text,
                Email = txtemail.Text,
                Telepon = txttelepon.Text,
                Password = txtpass.Text


            };
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 MainForm = new Form1();
            MainForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtnama_Enter(object sender, EventArgs e)
        {
            if (txtnama.Text == "Username")
            {
                txtnama.Text = "";
                txtnama.ForeColor = Color.LightGray;
            }
            
        }

        private void txtnama_Leave(object sender, EventArgs e)
        {
            if (txtnama.Text == "")
            {
                txtnama.Text = "Username";
                txtnama.ForeColor = Color.LightGray;
            }
        }

        private void txtemail_Enter(object sender, EventArgs e)
        {
            if (txtemail.Text == "Email")
            {
                txtemail.Text = "";
                txtemail.ForeColor = Color.LightGray;
            }
        }

        private void txtemail_Leave(object sender, EventArgs e)
        {
            if (txtemail.Text == "")
            {
                txtemail.Text = "Email";
                txtemail.ForeColor = Color.LightGray;
            }
        }

        private void txtnomor_Enter(object sender, EventArgs e)
        {
            if ( txttelepon.Text == "Nomor Telepon")
            {
                txttelepon.Text = "";
                txttelepon.ForeColor = Color.LightGray;
            }
        }

        private void txtnomor_Leave(object sender, EventArgs e)
        {
            if (txttelepon.Text == "")
            {
                txttelepon.Text = "Nomor Telepon";
                txttelepon.ForeColor = Color.LightGray;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "Password")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "Password";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void txtrepass_Enter(object sender, EventArgs e)
        {
            if (txtrepass.Text == "Masukkan Kembali Password")
            {
                txtrepass.Text = "";
                txtrepass.ForeColor = Color.LightGray;
                txtrepass.UseSystemPasswordChar = true;
            }
        }

        private void txtrepass_Leave(object sender, EventArgs e)
        {
            if (txtrepass.Text == "")
            {
                txtrepass.Text = "Masukkan Kembali Password";
                txtrepass.ForeColor = Color.LightGray;
                txtrepass.UseSystemPasswordChar = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtrepass_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
