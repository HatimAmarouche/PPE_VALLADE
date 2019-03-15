
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
    public partial class FormulaireConnexion : Form
    {
        private DatabaseFormation database = new DatabaseFormation();
        public FormulaireConnexion()
        {
            InitializeComponent();
            database.ConnectDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.ToString()=="root" && textBox2.ToString()=="1234")
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
        }
    }
}
