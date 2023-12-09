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
    public partial class form_visualizar_inscricao : Form
    {
        public form_visualizar_inscricao()
        {
            InitializeComponent();
        }

        private void form_visualizar_inscricao_Load(object sender, EventArgs e)
        {

        }

        private void txtBuscarMatricula_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && txtBuscarMatricula.Text != "")
            {
                if (txtBuscarMatricula.Text == "BP123456")
                {
                    if (TAG_TRANSPORTE.RESUMO_INSCRICAO != "")
                    {
                        richTextBox1.Text = TAG_TRANSPORTE.RESUMO_INSCRICAO;
                    }
                    else
                    {
                        richTextBox1.Text = "Não foram encontradas inscirções em turmas para a matricula digitada";
                    }
                }
            }
        }
    }
}
