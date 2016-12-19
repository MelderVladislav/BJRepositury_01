using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class MenuForm : Form
    {
        Form1 form;
        public string LogIn;
        public MenuForm(string logIn)
        {
            logIn = LogIn;
            InitializeComponent();
            
        }

        private void TwoPlayersBtn_Click(object sender, EventArgs e)
        {
            form = new Form1(2, LogIn);
            form.Show();
        }

        private void ThreePlayersBtn_Click(object sender, EventArgs e)
        {
            form = new Form1(3, LogIn);
            form.Show();
        }

        private void FourPlayersBtn_Click(object sender, EventArgs e)
        {
            form = new Form1(4, LogIn);
            form.Show();
        }
    }
}
