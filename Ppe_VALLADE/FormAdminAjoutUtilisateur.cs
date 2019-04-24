using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace Ppe_VALLADE
{
    public partial class FormAdminAjoutUtilisateur : Form
    {
        private DatabaseFormation database = new DatabaseFormation();
        public FormAdminAjoutUtilisateur()
        {
            InitializeComponent();
            database.ConnectDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string level = textBox1.Text;
            string ndc = textBox2.Text;
            string mdp = textBox3.Text;

            database.CreateUser(ndc, mdp, level);

            this.DialogResult = DialogResult.OK;
        }
    }
}
