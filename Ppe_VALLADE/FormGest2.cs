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
using MySql.Data.MySqlClient;
using DevComponents.DotNetBar.Metro;

namespace Ppe_VALLADE
{
    public partial class FormGest2 : MetroForm
    {
        private DatabaseFormation database = new DatabaseFormation();
        List<Participant> lesparticipants = new List<Participant>();
        List<Participant> lesinscrits = new List<Participant>();
       // List<Incident> lesincidents = new List<Incident>();
        private Formation formation;
        private Session session;

        public Formation Formation
        {
            get
            {
                return formation;
            }
            set
            {
                formation = value;
            }
        }
        public Session Session
        {
            get
            {
                return session;
            }
            set
            {
                session = value;
            }
        }
        public FormGest2(Formation maformation, Session masession)
        {
            InitializeComponent();
            database.ConnectDB();

            formation = maformation;
            session = masession;


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = formation.Nom;
            textBox2.Text = session.Datedebut.ToString();
            textBox3.Text = session.Datefin.ToString();

            lesparticipants = database.MesParticipants();
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.DataSource = lesparticipants;

            lesinscrits = database.MesInscrits(session.Id.ToString());
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if(lesinscrits.Count() > 0)
            { dataGridView1.DataSource = lesinscrits; }
            else
            {
                dataGridView1.Visible = false;
                label4.Visible = true;
            }

            dataGridView1.Columns[0].Visible = false;
            dataGridView2.Columns[0].Visible = false; 
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(label4.Visible == true)
            {
                dataGridView1.Visible = true;
                label4.Visible = false;
            }

            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                var monparticipant = (Participant)dataGridView2.CurrentRow.DataBoundItem;
               // Participant le_participant = (Participant)row.DataBoundItem;

                int Indexparticipant = -1;
                Indexparticipant = lesparticipants.IndexOf(monparticipant);
                if(Indexparticipant>-1)
                {
                lesparticipants.RemoveAt(Indexparticipant);
                lesinscrits.Add(monparticipant);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lesinscrits;

                dataGridView2.DataSource = null;
                dataGridView2.DataSource = lesparticipants;

                database.InsertSouhait(monparticipant.Id, session.Id);
                
                //requete pour inserer un souhait avec id_participant, id_session, accepter à 0
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var moninscrit = (Participant)dataGridView1.CurrentRow.DataBoundItem;
                Participant le_participant = (Participant)row.DataBoundItem;

                int Indexinscrit = -1;
                Indexinscrit = lesinscrits.IndexOf(moninscrit);

                lesinscrits.RemoveAt(Indexinscrit);
                lesparticipants.Add(le_participant);

                dataGridView2.DataSource = null;
                dataGridView2.DataSource = lesparticipants;

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lesinscrits;

                database.UpdateIdSessionParticipant(moninscrit.Id);
                database.SuppSouhait(moninscrit.Id);
            }




        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            var moninscrit = (Participant)dataGridView1.CurrentRow.DataBoundItem;
            FormSms formsms = new FormSms(moninscrit);
            formsms.ShowDialog();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormGestAjoutParticipant formGestAjoutParticipant = new FormGestAjoutParticipant();
            formGestAjoutParticipant.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
       
            FormConvocation formConvocation = new FormConvocation();
            formConvocation.Show();
        }
    }

}
