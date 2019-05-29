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
    public partial class FormAdminModifSession : Form
    {
        private DatabaseFormation database = new DatabaseFormation();
        private Session _session;
        private Formation _formation;

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

        public FormAdminModifSession(Session masession, Formation maformation)
        {
            InitializeComponent();
            database.ConnectDB();

            session = masession;
            formation = maformation;
        }

        private void FormAdminModifSession_Load(object sender, EventArgs e)
        {
            textBox1.Text = formation.Nom;

            monthCalendar1.SelectionStart = session.Datedebut;
            monthCalendar1.SelectionEnd = session.Datedebut;
            monthCalendar2.SelectionStart = session.Datefin;
            monthCalendar2.SelectionEnd = session.Datefin;

            textBox2.Text = session.Lieu;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.UpdateSession(session.Id, monthCalendar1.SelectionStart, monthCalendar2.SelectionStart, textBox2.Text);

            MessageBox.Show("Modifications prises en compte");
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
