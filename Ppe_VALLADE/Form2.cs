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
            textBox2.Text = session.datedebut.ToString();
            textBox3.Text = session.datefin.ToString();

            dataGridView2.DataSource = database.MesParticipants();
            lesparticipants = database.MesParticipants();
            lesinscrits = database.MesInscrits(session.id.ToString());
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                Participant le_participant = (Participant)row.DataBoundItem;
                lesparticipants.Remove(le_participant);
                lesinscrits.Add(le_participant);
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lesinscrits;

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = lesparticipants;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                Participant le_participant = (Participant)row.DataBoundItem;
                lesinscrits.Remove(le_participant);
                lesparticipants.Remove(le_participant);

                dataGridView2.DataSource = null;
                dataGridView2.DataSource = lesparticipants;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lesinscrits;
            }

          

            
        }
    }

}
