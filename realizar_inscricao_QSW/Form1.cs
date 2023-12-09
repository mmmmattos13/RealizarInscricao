using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace realizar_inscricao_QSW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnInscricaoDisciplinas_Click(object sender, EventArgs e)
        {
            form_disciplinas f_disiciplinas = new form_disciplinas();
            f_disiciplinas.TopLevel = false;
            panel2.Controls.Add(f_disiciplinas);
            f_disiciplinas.BringToFront();
            f_disiciplinas.Show();
        }


        private void btnVisualizarInscricoes_Click(object sender, EventArgs e)
        {

            form_visualizar_inscricao f_visualizar_inscricao = new form_visualizar_inscricao();
            f_visualizar_inscricao.TopLevel = false;
            panel2.Controls.Add(f_visualizar_inscricao);
            f_visualizar_inscricao.BringToFront();
            f_visualizar_inscricao.Show();
        }

    }
}
