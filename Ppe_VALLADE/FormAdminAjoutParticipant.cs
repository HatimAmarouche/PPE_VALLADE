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
    public partial class FormAdminAjoutParticipant : Form
    {
        private DatabaseFormation database = new DatabaseFormation();
        public FormAdminAjoutParticipant()
        {
            InitializeComponent();
            database.ConnectDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nom = textBox1.Text;
            string prenom = textBox2.Text;

            database.CreateParticipant(nom, prenom);
            this.DialogResult = DialogResult.OK;
        }
    }
}
