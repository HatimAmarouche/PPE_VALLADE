
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ppe_VALLADE
{
    public partial class FormulaireConnexion : Form
    {
        private DatabaseFormation database = new DatabaseFormation();
        public FormulaireConnexion()
        {
            InitializeComponent();
            database.ConnectDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string level = database.Connexion(textBox1.Text, textBox2.Text);

            if(level == "1")
            {
                this.Hide();

                UtilisateurForm UtilisateurForm = new UtilisateurForm();
                UtilisateurForm.ShowDialog();

            }

            else if(level == "2")
            {
                this.Hide();

                Form1 GestionnaireForm = new Form1();
                GestionnaireForm.ShowDialog();
            }

            else if(level =="3")
            {
                this.Hide();

                FormAdmin FormAdmin = new FormAdmin();
                FormAdmin.ShowDialog();
            }

            else
            {
                MessageBox.Show("Connexion échouée");
            }
        }

    }
}
