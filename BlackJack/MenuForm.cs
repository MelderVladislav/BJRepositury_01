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
        public MenuForm()
        {
            InitializeComponent();
        }

        private void TwoPlayersBtn_Click(object sender, EventArgs e)
        {
            form = new Form1(2);
            form.Show();
        }

        private void ThreePlayersBtn_Click(object sender, EventArgs e)
        {
            form = new Form1(3);
            form.Show();
        }

        private void FourPlayersBtn_Click(object sender, EventArgs e)
        {
            form = new Form1(4);
            form.Show();
        }
    }
}
