
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
           
           List<Utilisateur> maconnexion = database.Connexion(textBox1.Text, textBox2.Text);

            foreach(Utilisateur uneconnexion in maconnexion)
            {
                laconnexion = uneconnexion;
            }

            var timeco = (datetoday - laconnexion.Date_co).TotalHours;

            if (laconnexion.Date_co == null)
            {
                laconnexion.Date_co = datetoday;
            }

            else if(timeco >= 24)
            {
                laconnexion.Date_co = datetoday;
                database.InsertDateCo(laconnexion.Id, laconnexion.Date_co);
            }

            if(laconnexion.Nbtentative > 6 && timeco <= 24)
            {
                MessageBox.Show("Votre compte est bloqué. Veuillez rénitialiser votre mot de passe");
            }



            if (database.Connexion(textBox1.Text, textBox2.Text).Count() == 1)
            {

                if (laconnexion.Level == 1)

                {
                    this.Hide();

                    UtilisateurForm UtilisateurForm = new UtilisateurForm();
                    UtilisateurForm.ShowDialog();

                }

                else if (laconnexion.Level == 2)
                {
                    this.Hide();

                    Form1 GestionnaireForm = new Form1();
                    GestionnaireForm.ShowDialog();
                }

                else if (laconnexion.Level == 3)
                {
                    this.Hide();

                    FormAdmin FormAdmin = new FormAdmin();
                    FormAdmin.ShowDialog();
                }
            }

            else
            {
                int nbtentative = laconnexion.Nbtentative;
             //   MessageBox.Show("Mauvais login ou mot de passe. Il vous reste plus que" + tentativerestante.ToString() + "restantes");
                database.IncrementationNbTentative(textBox1.Text);
                
            }
            
        }

    }
}
