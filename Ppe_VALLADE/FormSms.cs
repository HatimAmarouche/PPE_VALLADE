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
    public partial class FormSms : MetroForm
    {
        private DatabaseFormation database = new DatabaseFormation();
        private Participant _inscrit;

        public Participant inscrit
        {
            get
            {
                return _inscrit;
            }

            set
            {
                _inscrit = value;
            }
        }
        public FormSms(Participant moninscrit)
        {
            InitializeComponent();
            database.ConnectDB();
            inscrit = moninscrit;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = richTextBox1.Text;
            Sms.Send(msg, inscrit.Numero);
            MessageBox.Show("Sms envoyé");
            this.Close();
        }
    }
}
