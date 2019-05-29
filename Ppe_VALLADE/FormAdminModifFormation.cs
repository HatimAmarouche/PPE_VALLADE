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
    public partial class FormAdminModifFormation : Form
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

        public FormAdminModifFormation(Formation maformation)
        {
            InitializeComponent();
            database.ConnectDB();

            formation = maformation;
        }

        private void FormAdminModifFormation_Load(object sender, EventArgs e)
        {
            textBox1.Text = formation.Niveau.ToString();
            textBox2.Text = formation.Nom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
          //  if(textBox1.Text)

            database.UpdateFormation(formation.Id, Convert.ToInt32(textBox1.Text), textBox2.Text);

            MessageBox.Show("Modifications prises en compte");
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
