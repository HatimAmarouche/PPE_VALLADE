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

    public partial class FormAdmin : Form
    {
        private DatabaseFormation database = new DatabaseFormation();
        List<Formation> lesformations = new List<Formation>();
        List<Utilisateur> lesutilisateurs = new List<Utilisateur>();
        List<Session> lesessions = new List<Session>();
        List<Souhait> lesouhaits = new List<Souhait>();
        public FormAdmin()
        {
            InitializeComponent();
            database.ConnectDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAdminAjoutFormation formAdminAjoutFormation = new FormAdminAjoutFormation();

            formAdminAjoutFormation.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Formation maformation = (Formation)comboBox1.SelectedItem;
            FormAdminAjoutSession formAdminAjoutSession = new FormAdminAjoutSession(maformation);

            formAdminAjoutSession.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            FormAdminAjoutUtilisateur formAdminAjoutUtilisateur = new FormAdminAjoutUtilisateur();

            formAdminAjoutUtilisateur.ShowDialog();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = database.MesFormations();
            comboBox1.DisplayMember = "nom";
            comboBox1.ValueMember = "id";

            lesformations = database.MesFormations();
            dataGridView2.DataSource = lesformations; 

            lesutilisateurs = database.MesUtilisateurs();
            dataGridView1.DataSource = lesutilisateurs;

            lesouhaits = database.MesSouhaits();
            dataGridView4.DataSource = lesouhaits;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[3].Visible = false;


        }
        
        private void RefreshSouhait()
        {
            lesouhaits = database.MesSouhaits();
            dataGridView4.DataSource = null;
            dataGridView4.DataSource = database.MesSouhaits();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Formation maformation = (Formation)comboBox1.SelectedItem;
            dataGridView3.DataSource = database.MesSessions(maformation.Id.ToString());
            dataGridView3.Columns[0].Visible = false;
            dataGridView3.Columns[4].Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var monuser = (Utilisateur)dataGridView1.CurrentRow.DataBoundItem;

            FormAdminModifUser formAdminModifUser = new FormAdminModifUser(monuser);

            formAdminModifUser.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var maformation = (Formation)dataGridView2.CurrentRow.DataBoundItem;

            FormAdminModifFormation formAdminModifFormation = new FormAdminModifFormation(maformation);

            formAdminModifFormation.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var maformation = (Formation)comboBox1.SelectedItem;

            var masession = (Session)dataGridView3.CurrentRow.DataBoundItem;

            FormAdminModifSession formAdminModifSession = new FormAdminModifSession(masession, maformation);

            formAdminModifSession.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var formationsupp = (Formation)dataGridView2.CurrentRow.DataBoundItem;

           // database.SuppFormation(formationsupp.Id);

            MessageBox.Show("Formation supprimée");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var sessionsupp = (Session)dataGridView3.CurrentRow.DataBoundItem;

            database.SuppSession(sessionsupp.Id);

            MessageBox.Show("Session supprimée");

        }

        private void button9_Click(object sender, EventArgs e)
        {
            var usersupp = (Utilisateur)dataGridView1.CurrentRow.DataBoundItem;

            database.SuppUtilisateur(usersupp.Id);

            MessageBox.Show("Utilisateur supprimée");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var souhaitsupp = (Souhait)dataGridView4.CurrentRow.DataBoundItem;

            database.SuppSouhait(souhaitsupp.Id);

            RefreshSouhait();

            MessageBox.Show("Souhait refusé");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var souhaitsupp = (Souhait)dataGridView4.CurrentRow.DataBoundItem;

            database.UpdateSouhait(souhaitsupp.Id);
            database.RenseignerIdSession(souhaitsupp.Id_participant, souhaitsupp.Id_session);

            RefreshSouhait();
        }
    }
}
