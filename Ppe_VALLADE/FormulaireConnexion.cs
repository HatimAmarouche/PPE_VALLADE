
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;

namespace Ppe_VALLADE
{
    public partial class FormulaireConnexion : MetroForm
    {
        public Utilisateur laconnexion = new Utilisateur();
        DateTime datetoday = DateTime.Now;
        private DatabaseFormation database = new DatabaseFormation();
        public FormulaireConnexion()
        {
            InitializeComponent();
            database.ConnectDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (database.Connexion(textBox1.Text, textBox2.Text).Count() == 1)
            {

                List<Utilisateur> maconnexion = database.Connexion(textBox1.Text, textBox2.Text);

                foreach (Utilisateur uneconnexion in maconnexion)

                {
                    laconnexion = uneconnexion;
                }

                var timeco = (datetoday - laconnexion.Date_co).TotalHours;

                if (laconnexion.Date_co == null || timeco >= 24)
                {
                    laconnexion.Date_co = datetoday;
                    database.InsertDateCo(laconnexion.Id, laconnexion.Date_co);

                    if (laconnexion.Level == 1)
                    {
                        this.Hide();
                        FormUtilisateur UtilisateurForm = new FormUtilisateur();
                        UtilisateurForm.Show();

                    }

                    else if (laconnexion.Level == 2)
                    {
                        this.Hide();
                        FormGest1 GestionnaireForm = new FormGest1();
                        GestionnaireForm.Show();
                    }

                    else if (laconnexion.Level == 3)
                    {
                        this.Hide();
                        FormAdmin FormAdmin = new FormAdmin();
                        FormAdmin.Show();
                    }

                }

           /*     else if (laconnexion.Nbtentative > 6 && timeco <= 24 && laconnexion.Etat == 1)
                {

                    MessageBox.Show("Votre compte est bloqué. Vous devez attendre une action de l'administrateur pour ensuite réinitialiser votre mot de passe");
                    int monetat = 1;
                    database.UpdateEtat(laconnexion.Id, monetat);
                }

                else if(laconnexion.Nbtentative > 6 && timeco <= 24 && laconnexion.Etat == 0)
                {
                    MessageBox.Show("L'administrateur a réinitialisé votre compte vous devez maintenant réinitialiser votre mot de passe");
                }*/

                else
                {
                    if (laconnexion.Level == 1)
                    {
                        this.Hide();
                        FormUtilisateur UtilisateurForm = new FormUtilisateur();
                        UtilisateurForm.ShowDialog();

                    }

                    else if (laconnexion.Level == 2)
                    {
                        this.Hide();
                        FormGest1 GestionnaireForm = new FormGest1();
                        GestionnaireForm.ShowDialog();
                    }

                    else if (laconnexion.Level == 3)
                    {
                        this.Hide();
                        FormAdmin FormAdmin = new FormAdmin();
                        FormAdmin.ShowDialog();
                    }
                }
                
             
            }

            else
            {

                MessageBox.Show("Erreur d'authentification");
                database.IncrementationNbTentative(textBox1.Text);

            }

            }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                FormMotDePassePerdu formMotDePassePerdu = new FormMotDePassePerdu();
                formMotDePassePerdu.ShowDialog();

        }
    }
}

