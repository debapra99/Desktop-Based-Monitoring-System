using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
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

        private void Form1_Load(object sender, EventArgs e)
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

        private void txtemail_Enter(object sender, EventArgs e)
        {
            if (txtnama.Text == "USERNAME")
            {
                txtnama.Text = "";
                txtnama.ForeColor = Color.LightGray;
            }
        }

        private void txtemail_Leave(object sender, EventArgs e)
        {
            if (txtnama.Text == "")
            {
                txtnama.Text = "USERNAME";
                txtnama.ForeColor = Color.LightGray;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "PASSWORD")
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
                txtpass.Text = "PASSWORD";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            #region Condition
            if (string.IsNullOrWhiteSpace(txtnama.Text) &&
                string.IsNullOrWhiteSpace(txtpass.Text))
            {
                MessageBox.Show("Nama atau Password anda salah");
                return;
            }
            #endregion

            FirebaseResponse res = client.Get(@"Users/" + txtnama.Text);
            MyUser ReUser = res.ResultAs<MyUser>();

            MyUser CurUser = new MyUser()
            {
                Nama = txtnama.Text,
                Password = txtpass.Text
            };

            if (MyUser.IsEqual(ReUser, CurUser))
            {
                this.Hide();
                Dashboard mainForm = new Dashboard();
                mainForm.Show();
            }
            else
            {
                MyUser.ShowError();
            }
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form3 mainForm = new Form3();
            mainForm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtnama_enter(object sender, EventArgs e)
        {

        }

        private void txtnama_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "NAMA";
                txtpass.ForeColor = Color.LightGray;
            }
        }

        private void txtemail_Enter_1(object sender, EventArgs e)
        {
            if(txtnama.Text == "EMAIL")
            {
                txtnama.Text = "";
                txtpass.ForeColor = Color.LightGray;
            }
        }

        private void txtemail_Leave_1(object sender, EventArgs e)
        {
            if(txtnama.Text == "")
            {
                txtnama.Text = "EMAIL";
                txtpass.ForeColor = Color.LightGray;
            }
        }
    }
}

