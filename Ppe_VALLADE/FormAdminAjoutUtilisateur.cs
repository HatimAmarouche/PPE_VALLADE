
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using HashageStandard;
using MySql.Data.MySqlClient;


namespace Ppe_VALLADE
{
    public partial class FormAdminAjoutUtilisateur : Form
    {
        private DatabaseFormation database = new DatabaseFormation();
        List<Utilisateur> monuser = new List<Utilisateur>();
        public FormAdminAjoutUtilisateur()
        {
            InitializeComponent();
            database.ConnectDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int level = Convert.ToInt32(textBox1.Text);
            string ndc = textBox2.Text;
            string mdp = SHA.MakeMD5Hash(textBox3.Text);

            monuser = database.NdcUtilisateur(ndc);

            if (monuser.Count > 0)
            {
                MessageBox.Show("Cet identifiant est déjà utilisé");

            }

            else
            {

                database.CreateUser(ndc, mdp, level);

                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
