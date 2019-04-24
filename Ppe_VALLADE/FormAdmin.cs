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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAdminAjoutFormation formAdminAjoutFormation = new FormAdminAjoutFormation();

            formAdminAjoutFormation.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAdminAjoutParticipant formAdminAjoutParticipant = new FormAdminAjoutParticipant();

            formAdminAjoutParticipant.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAdminAjoutUtilisateur formAdminAjoutUtilisateur = new FormAdminAjoutUtilisateur();

            formAdminAjoutUtilisateur.ShowDialog();
        }
    }
}
