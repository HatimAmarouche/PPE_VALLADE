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
    public partial class FormGestAjoutParticipant : Form
    {
        private DatabaseFormation database = new DatabaseFormation();
        public FormGestAjoutParticipant()
        {
            InitializeComponent();
            database.ConnectDB();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            database.CreateParticipant(textBox1.Text, textBox2.Text, textBox3.Text);
            this.DialogResult = DialogResult.OK;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
