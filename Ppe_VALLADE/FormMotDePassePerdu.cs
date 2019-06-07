
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
    public partial class FormMotDePassePerdu : Form
    {

        private DatabaseFormation database = new DatabaseFormation();
        public Utilisateur laconnexion = new Utilisateur();
        public FormMotDePassePerdu()
        {
            InitializeComponent();
            database.ConnectDB();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if (database.NdcUtilisateur(textBox3.Text).Count > 0)
            {
                List<Utilisateur> maconnexion = database.NdcUtilisateur(textBox3.Text);
             
                foreach (Utilisateur uneconnexion in maconnexion)

                {
                    laconnexion = uneconnexion;
                }

                if (laconnexion.Etat == 0)
                {
                    if (textBox1.Text == textBox2.Text)
                    {
                        database.UpdateMdp(laconnexion.Id, SHA.MakeMD5Hash(textBox1.Text));
                        MessageBox.Show("Votre mot de passe est désormais modifié");
                    }

                    else
                    {
                        MessageBox.Show("Vos mots de passe ne sont pas identiques");
                    }
                }
                else if(laconnexion.Etat != 0)
                {
                    MessageBox.Show("Votre compte n'a pas encore été réinitialisé par un administrateur vous ne pouvez pas réinitialiser votre mot de passe");
                }
                    

               
            }
            else
            {
                MessageBox.Show("Ce nom d'utilisateur n'existe pas");
            }
        }
    }
}
