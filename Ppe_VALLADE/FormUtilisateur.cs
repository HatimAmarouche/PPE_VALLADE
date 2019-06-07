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
   
    public partial class FormUtilisateur : Form
    {
        private DatabaseFormation database = new DatabaseFormation();
        List<Session> messessions = new List<Session>();


        public FormUtilisateur()
        {
            InitializeComponent();
            database.ConnectDB();
        }

        private void FormUtilisateur_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = database.MesFormations();
            comboBox1.DisplayMember = "nom";
            comboBox1.ValueMember = "id";


            
            //Charger toutes les formations

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //EN PAUSE
            
            Formation maformation = (Formation)comboBox1.SelectedItem;
            messessions = database.MesSessions(maformation.Id.ToString());

            foreach(Session unesession in messessions)
            {
                monthCalendar1.SetDate(unesession.Datedebut);
                monthCalendar1.AddBoldedDate(unesession.Datedebut);

            }
  
        }
    }
}
