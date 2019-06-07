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

namespace Ppe_VALLADE
{
    public partial class FormGest1 : Form
    {
        private DatabaseFormation database = new DatabaseFormation();

        public FormGest1()
        {
            InitializeComponent();
            database.ConnectDB();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = database.MesFormations();
            comboBox1.DisplayMember = "nom";
            comboBox1.ValueMember = "id";     
            //Charger toutes les formations


        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Formation maformation = (Formation)comboBox1.SelectedItem;
            Session masession = (Session)dataGridView1.CurrentRow.DataBoundItem;
            try { 
            FormGest2 form2 = new FormGest2(maformation, masession);
            form2.ShowDialog();
            }
            catch(Exception )
            { }

            //En fonction de la formation et de la session choisie ouvre le form 2 en conséquence
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Formation maformation = (Formation)comboBox1.SelectedItem;
            dataGridView1.DataSource = database.MesSessions(maformation.Id.ToString());
            dataGridView1.Columns[0].Visible = false;

            //Charger les sessions quand la formation change
        }
    }

}
