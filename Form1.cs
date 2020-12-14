using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeautySalon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (login.Text == "admin" && password.Text == "admin")
            {
                Form2 f2 = new Form2(this);
                f2.Show();
                this.Hide();
            }
            else if (login.Text == "user" && password.Text == "user")
            {
                Form3 f3 = new Form3(this);
                f3.Show();
                this.Hide();
            }   
            else alert.Text = "Неверное имя пользователя или пароль";
        }
    }
}
