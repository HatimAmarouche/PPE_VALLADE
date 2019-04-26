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
        List<Participant> lesparticipants = new List<Participant>();
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
            FormAdminAjoutParticipant formAdminAjoutParticipant = new FormAdminAjoutParticipant();

            formAdminAjoutParticipant.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAdminAjoutUtilisateur formAdminAjoutUtilisateur = new FormAdminAjoutUtilisateur();

            formAdminAjoutUtilisateur.ShowDialog();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            lesformations = database.MesFormations();
            dataGridView2.DataSource = lesformations; 

            lesutilisateurs = database.MesUtilisateurs();
            dataGridView1.DataSource = lesutilisateurs;

            lesparticipants = database.MesParticipants();
            dataGridView3.DataSource = lesparticipants;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[3].Visible = false;
            dataGridView3.Columns[0].Visible = false;

        }
    }
}
