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
    public partial class FormAdminAjoutSession : MetroForm

    {
        private DatabaseFormation database = new DatabaseFormation();
        private Formation _formation;

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

        public FormAdminAjoutSession(Formation maformation)
        {
            InitializeComponent();
            database.ConnectDB();

            formation = maformation;
        }

        private void FormAdminAjoutSession_Load(object sender, EventArgs e)
        {
            textBox2.Text = formation.Nom;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime datedebut = monthCalendar1.SelectionStart;
            DateTime datefin = monthCalendar2.SelectionStart;
            string lieu = textBox1.Text;

            database.CreateSession(datedebut, datefin, formation.Id, lieu);
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
