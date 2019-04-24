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
    public partial class FormAdminAjoutFormation : Form
    {
        private DatabaseFormation database = new DatabaseFormation();
        public FormAdminAjoutFormation()
        {
            InitializeComponent();
            database.ConnectDB();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int niveau = Convert.ToInt32(textBox1.Text);
            string nom = textBox2.Text;

            database.CreateFormation(niveau, nom);
            this.DialogResult = DialogResult.OK;
            
        }
    }
}
