﻿using System;
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
    public partial class Form1 : Form
    {
        private DatabaseFormation database = new DatabaseFormation();

        public Form1()
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

            Form2 form2 = new Form2(maformation, masession);
            form2.ShowDialog();


            //En fonction de la formation et de la session choisie ouvre le form 2 en conséquence
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Formation maformation = (Formation)comboBox1.SelectedItem;
            dataGridView1.DataSource = database.MesSessions(maformation.id.ToString());
            dataGridView1.Columns[0].Visible = false;

            //Charger les sessions quand la formation change
        }
    }

}