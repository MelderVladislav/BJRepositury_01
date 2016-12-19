using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlackJack.BjServiceClient;

namespace BlackJack
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            bool check1 = logIn.TextLength !=0 && passwordTrue.TextLength!=0 && passwordConfirm.TextLength!=0;
            bool check2 = passwordTrue.Text.Equals(passwordConfirm.Text);
            if (check1 && check2)
            {
                BjContractClient addClient = new BjContractClient();
                addClient.AddUser(logIn.Text,passwordTrue.Text);
                addClient.Close();
                MessageBox.Show("Регистрация прошла успешно");
                this.Close();
            }
        }
    }
}
