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
    public partial class FormAdminModifUser : Form
    {
        private DatabaseFormation database = new DatabaseFormation();
        private Utilisateur _user;
        public Utilisateur user
        {
            get
            {
                return _user;
            }

            set
            {
                _user = value;
            }
        }
        public FormAdminModifUser(Utilisateur monuser)
        {
            InitializeComponent();
            database.ConnectDB();

            user = monuser;

        }

        private void FormAdminModifUser_Load(object sender, EventArgs e)
        {
            textBox1.Text = user.Ndc;
            textBox2.Text = user.Level.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.UpdateUser(user.Id, textBox1.Text, Convert.ToInt32(textBox2.Text));

            MessageBox.Show("Modifications prises en compte");
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
