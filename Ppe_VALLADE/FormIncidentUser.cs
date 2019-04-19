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
    public partial class FormIncidentUser : Form
       
    {
        private DatabaseFormation database = new DatabaseFormation();
        public FormIncidentUser()
        {
            InitializeComponent();
            database.ConnectDB();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            
               
           
        }
    }
}
