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
    public partial class Form2 : Form
    {
        private DatabaseFormation database = new DatabaseFormation();
        List<Participant> lesparticipants = new List<Participant>();
        List<Participant> lesinscrits = new List<Participant>();
        List<Incident> lesincidents = new List<Incident>();
        private Formation _formation;
        private Session _session;

        public Formation formation
        {
            get
            {
                return _formation;
            }
            set
            {
                _formation = value;
            }
        }
        public Session session
        {
            get
            {
                return _session;
            }
            set
            {
                _session = value;
            }
        }
        public Form2(Formation maformation, Session masession)
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
            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormIncidentUser formincident = new FormIncidentUser();
            formincident.ShowDialog();

        }
    }

}
