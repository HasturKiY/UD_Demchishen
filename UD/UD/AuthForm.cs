using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UD
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="admin" && textBox2.Text=="admin")
            {
                DeepForm dpf = new DeepForm();
                dpf.Show();
                Close();
            }
            else
            {
                Close();
            }
        }
    }
}
