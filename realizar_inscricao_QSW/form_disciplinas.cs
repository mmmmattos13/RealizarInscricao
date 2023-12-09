using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using NUnit.Framework.Legacy;

namespace realizar_inscricao_QSW
{
    public partial class form_disciplinas : Form
    {

        private Aluno aluno;
        private List<Turmas> turmasMetodologias;
        private List<Turmas> turmasGestaoProjetos;
        private List<Turmas> turmasDesenvolvimentoWeb;
        private List<Turmas> turmasProjetoSistemas1;
        private List<Turmas> turmasServicosRede;
        private List<Turmas> turmasQualidadeSoftware;
        private List<Aluno> ListaDeAlunos = new List<Aluno>();

        private bool gestaoProjetosTurma1Selected = false;
        private bool gestaoProjetosTurma2Selected = false;

        private bool metodologiasTurma1Selected = false;
        private bool metodologiasTurma2Selected = false;
        private bool metodologiasTurma3Selected = false;

        private bool ps1Turma1Selected = false;
        private bool ps1Turma2Selected = false;

        private bool qswTurma1Selected = false;
        private bool qswTurma2Selected = false;

        private bool webTurma1Selected = false;
        private bool webTurma2Selected = false;

        private bool servicosRedesTurma1Selected = false;
        private bool servicosRedesTurma2Selected = false;
        private bool servicosRedesTurma3Selected = false;

        public form_disciplinas()
        {
            InitializeComponent();
        }

        private void form_disciplinas_Load(object sender, EventArgs e)
        {
            aluno = new Aluno("João Silva", "Análise e Desenvolvimento de Sistemas", "BP123456", 0, 0.0);

            turmasMetodologias = new List<Turmas>
            {
                new Turmas("Prof. Souza", "Segunda e Quarta às 10h", "Sala01"),
                //new Turmas("Prof. Lima", "Terça e Quinta às 14h", "Sala02"),
                //new Turmas("Prof. Oliveira", "Segunda e Sexta às 16h", "Sala03")
            };

            turmasGestaoProjetos = new List<Turmas>
            {
                new Turmas("Prof. Armando", "Segunda e Quarta às 8h", "Sala04"),
                //new Turmas("Prof. Algo", "Terça e Quinta às 10h", "Sala05"),
                //new Turmas("Prof. Jota", "Quarta e Sexta às 14h", "Sala06")
            };

            turmasDesenvolvimentoWeb = new List<Turmas>
            {
                new Turmas("Prof. Luiz", "Segunda e Quarta às 10h", "Sala07"),
                //new Turmas("Prof. Edu", "Terça e Quinta às 14h", "Sala08"),
                //new Turmas("Prof. Roberto", "Quarta e Sexta às 16h", "Sala09")
            };

            turmasProjetoSistemas1 = new List<Turmas>
            {
                new Turmas("Prof. Ofelios", "Segunda e Quarta às 8h", "Sala10"),
                //new Turmas("Prof. Marcos", "Terça e Quinta às 10h", "Sala11"),
                //new Turmas("Prof. Thomas", "Quarta e Sexta às 14h", "Sala12")
            };

            turmasServicosRede = new List<Turmas>
            {
                new Turmas("Prof. Gustavo", "Segunda e Quarta às 10h", "Sala13"),
                //new Turmas("Prof. Romulo", "Terça e Quinta às 14h", "Sala14"),
                //new Turmas("Prof. Itamar", "Quarta e Sexta às 16h", "Sala15")
            };

            turmasQualidadeSoftware = new List<Turmas>
            {
                new Turmas("Prof. Pedro", "Segunda e Quarta às 8h", "Sala16"),
                //new Turmas("Prof. Romero", "Terça e Quinta às 10h", "Sala17"),
                //new Turmas("Prof. Daniel", "Quarta e Sexta às 14h", "Sala18")
            };
        }

        [SetUp]
        private bool VerificarConflitoHorarios(List<Turmas> turmasSelecionadas, Turmas novaTurma)
        {
            foreach (var turmaSelecionada in turmasSelecionadas)
            {
                if (TurmasConflitam(turmaSelecionada, novaTurma))
                {
                    MessageBox.Show($"Conflito de horários entre {turmaSelecionada.Professor} e {novaTurma.Professor}.", "Conflito de Horários");
                    return true;
                }
            }

            return false;
        }



        [SetUp]
        private bool TurmasConflitam(Turmas turma1, Turmas turma2)
        {
            return turma1.Horarios == turma2.Horarios;
        }

        
        private void btnValidarInscricao_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            int disciplinasSelecionadas = 0;

            richTextBox1.AppendText(aluno.ObterInformacoes() + "\n\n");

            List<Turmas> turmasSelecionadas = new List<Turmas>();

            disciplinasSelecionadas += AdicionarInformacoesMatTurmasSelecionadas(richTextBox1, turmasSelecionadas);

            TAG_TRANSPORTE.RESUMO_INSCRICAO = richTextBox1.Text;

            if (disciplinasSelecionadas > 4)
            {
                MessageBox.Show("Você só pode se matricular em até 4 disciplinas distintas.", "Limite Excedido");
                ResetarFormulario();
                return;
            }

            if (VerificarConflitoHorarios(turmasSelecionadas))
            {
                ResetarFormulario();
                return;
            }
        }

        [SetUp]
        private int AdicionarInformacoesMatTurmasSelecionadas(RichTextBox richTextBox, List<Turmas> turmasSelecionadas)
        {
            int disciplinasSelecionadas = 0;

            disciplinasSelecionadas += AdicionarInformacoesTurmas(richTextBox, "Gestão de Projetos", turmasGestaoProjetos, gestaoProjetosTurma1Selected || gestaoProjetosTurma2Selected, turmasSelecionadas);
            disciplinasSelecionadas += AdicionarInformacoesTurmas(richTextBox, "Metodologias", turmasMetodologias, metodologiasTurma1Selected || metodologiasTurma2Selected || metodologiasTurma3Selected, turmasSelecionadas);
            disciplinasSelecionadas += AdicionarInformacoesTurmas(richTextBox, "Projeto de Sistemas 1", turmasProjetoSistemas1, ps1Turma1Selected || ps1Turma2Selected, turmasSelecionadas);
            disciplinasSelecionadas += AdicionarInformacoesTurmas(richTextBox, "Serviços de Rede", turmasServicosRede, servicosRedesTurma1Selected || servicosRedesTurma2Selected || servicosRedesTurma3Selected, turmasSelecionadas);
            disciplinasSelecionadas += AdicionarInformacoesTurmas(richTextBox, "Desenvolvimento Web", turmasDesenvolvimentoWeb, webTurma1Selected || webTurma2Selected, turmasSelecionadas);
            disciplinasSelecionadas += AdicionarInformacoesTurmas(richTextBox, "Qualidade de Software", turmasQualidadeSoftware, qswTurma1Selected || qswTurma2Selected, turmasSelecionadas);

            return disciplinasSelecionadas;
        }

        [SetUp]
        private int AdicionarInformacoesTurmas(RichTextBox richTextBox, string disciplina, List<Turmas> turmas, bool turmaSelecionada, List<Turmas> turmasSelecionadas)
        {
            int disciplinasSelecionadas = 0;

            if (turmaSelecionada)
            {
                richTextBox.AppendText($"{disciplina}:\n");

                foreach (var turma in turmas)
                {
                    richTextBox.AppendText($"- {turma.Professor}, Horário: {turma.Horarios}, Local: {turma.LocalAula}\n");

                    turmasSelecionadas.Add(turma);
                }

                richTextBox.AppendText("\n");

                disciplinasSelecionadas++;
            }

            return disciplinasSelecionadas;
        }

        [SetUp]
        private bool VerificarConflitoHorarios(List<Turmas> turmasSelecionadas)
        {
            HashSet<string> horarios = new HashSet<string>();

            foreach (var turma in turmasSelecionadas)
            {
                if (!horarios.Add(turma.Horarios))
                {
                    MessageBox.Show($"Conflito de horários entre as turmas selecionadas.", "Conflito de Horários");
                    return true;
                }
            }

            return false;
        }

        private void ExibirInformacoesAluno()
        {
            string informacoesAluno = aluno.ObterInformacoes();
            MessageBox.Show(informacoesAluno, "Informações do Aluno");
        }

        private void ExibirInformacoesMatTurmasSelecionadas()
        {
            string mensagem = "Matérias/Turmas Selecionadas:\n";

            if (gestaoProjetosTurma1Selected)
            {
                mensagem += "Gestão de Projetos - Turma 1\n";
            }

            if (gestaoProjetosTurma2Selected)
            {
                mensagem += "Gestão de Projetos - Turma 2\n";
            }

            if (metodologiasTurma1Selected)
            {
                mensagem += "Metodologias - Turma 1\n";
            }

            if (metodologiasTurma2Selected)
            {
                mensagem += "Metodologias - Turma 2\n";
            }

            if (metodologiasTurma3Selected)
            {
                mensagem += "Metodologias - Turma 3\n";
            }

            if (ps1Turma1Selected)
            {
                mensagem += "Projeto de Sistemas 1 - Turma 1\n";
            }

            if (ps1Turma2Selected)
            {
                mensagem += "Projeto de Sistemas 1 - Turma 2\n";
            }

            if (qswTurma1Selected)
            {
                mensagem += "Qualidade de Software - Turma 1\n";
            }

            if (qswTurma2Selected)
            {
                mensagem += "Qualidade de Software - Turma 2\n";
            }

            if (webTurma1Selected)
            {
                mensagem += "Desenvolvimento Web - Turma 1\n";
            }

            if (webTurma2Selected)
            {
                mensagem += "Desenvolvimento Web - Turma 2\n";
            }

            if (servicosRedesTurma1Selected)
            {
                mensagem += "Serviços de Rede - Turma 1\n";
            }

            if (servicosRedesTurma2Selected)
            {
                mensagem += "Serviços de Rede - Turma 2\n";
            }

            if (servicosRedesTurma3Selected)
            {
                mensagem += "Serviços de Rede - Turma 3\n";
            }

            MessageBox.Show(mensagem, "Matérias/Turmas Selecionadas");
        }

        #region CheckBox
        private void cbGestaoProjetosTurma1_CheckedChanged(object sender, EventArgs e)
        {
            gestaoProjetosTurma1Selected = cbGestaoProjetosTurma1.Checked;
        }

        private void cbGestaoProjetosTurma2_CheckedChanged(object sender, EventArgs e)
        {
            gestaoProjetosTurma2Selected = cbGestaoProjetosTurma2.Checked;
        }

        private void cbMetodologiasTurma1_CheckedChanged(object sender, EventArgs e)
        {
            metodologiasTurma1Selected = cbMetodologiasTurma1.Checked;
        }

        private void cbMetodologiasTurma2_CheckedChanged(object sender, EventArgs e)
        {
            metodologiasTurma2Selected = cbMetodologiasTurma2.Checked;
        }

        private void cbMetodologiasTurma3_CheckedChanged(object sender, EventArgs e)
        {
            metodologiasTurma3Selected = cbMetodologiasTurma3.Checked;
        }

        private void cbPS1Turma1_CheckedChanged(object sender, EventArgs e)
        {
            ps1Turma1Selected = cbPS1Turma1.Checked;
        }

        private void cbPS1Turma2_CheckedChanged(object sender, EventArgs e)
        {
            ps1Turma2Selected = cbPS1Turma2.Checked;
        }

        private void cbQSWTurma1_CheckedChanged(object sender, EventArgs e)
        {
            qswTurma1Selected = cbQSWTurma1.Checked;
        }

        private void cbQSWTurma2_CheckedChanged(object sender, EventArgs e)
        {
            qswTurma2Selected = cbQSWTurma2.Checked;
        }

        private void cbWEBTurma1_CheckedChanged(object sender, EventArgs e)
        {
            webTurma1Selected = cbWEBTurma1.Checked;
        }

        private void cbWEBTurma2_CheckedChanged(object sender, EventArgs e)
        {
            webTurma2Selected = cbWEBTurma2.Checked;
        }

        private void cbServicosRedesTurma1_CheckedChanged(object sender, EventArgs e)
        {
            servicosRedesTurma1Selected = cbServicosRedesTurma1.Checked;
        }

        private void cbServicosRedesTurma2_CheckedChanged(object sender, EventArgs e)
        {
            servicosRedesTurma2Selected = cbServicosRedesTurma2.Checked;
        }

        private void cbServicosRedesTurma3_CheckedChanged(object sender, EventArgs e)
        {
            servicosRedesTurma3Selected = cbServicosRedesTurma3.Checked;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A sua inscrição foi confirmada com sucesso!");
            ResetarFormulario();
        }

        private void ResetarFormulario()
        {
            cbGestaoProjetosTurma1.Checked = false;
            cbGestaoProjetosTurma2.Checked = false;
            cbMetodologiasTurma1.Checked = false;
            cbMetodologiasTurma2.Checked = false;
            cbMetodologiasTurma3.Checked = false;
            cbPS1Turma1.Checked = false;
            cbPS1Turma2.Checked = false;
            cbQSWTurma1.Checked = false;
            cbQSWTurma2.Checked = false;
            cbWEBTurma1.Checked = false;
            cbWEBTurma2.Checked = false;
            cbServicosRedesTurma1.Checked = false;
            cbServicosRedesTurma2.Checked = false;
            cbServicosRedesTurma3.Checked = false;

            gestaoProjetosTurma1Selected = false;
            gestaoProjetosTurma2Selected = false;
            metodologiasTurma1Selected = false;
            metodologiasTurma2Selected = false;
            metodologiasTurma3Selected = false;
            ps1Turma1Selected = false;
            ps1Turma2Selected = false;
            qswTurma1Selected = false;
            qswTurma2Selected = false;
            webTurma1Selected = false;
            webTurma2Selected = false;
            servicosRedesTurma1Selected = false;
            servicosRedesTurma2Selected = false;
            servicosRedesTurma3Selected = false;

            richTextBox1.Clear();
        }
        private string ObterInformacoesTodasTurmas()
        {
            StringBuilder mensagem = new StringBuilder();

            mensagem.AppendLine("Turmas de Metodologias:");
            mensagem.AppendLine(ObterInformacoesTurmas(turmasMetodologias));

            mensagem.AppendLine("Turmas de Gestão de Projetos:");
            mensagem.AppendLine(ObterInformacoesTurmas(turmasGestaoProjetos));

            mensagem.AppendLine("Turmas de Desenvolvimento Web:");
            mensagem.AppendLine(ObterInformacoesTurmas(turmasDesenvolvimentoWeb));

            mensagem.AppendLine("Turmas de Projeto de Sistemas 1:");
            mensagem.AppendLine(ObterInformacoesTurmas(turmasProjetoSistemas1));

            mensagem.AppendLine("Turmas de Serviços de Rede:");
            mensagem.AppendLine(ObterInformacoesTurmas(turmasServicosRede));

            mensagem.AppendLine("Turmas de Qualidade de Software:");
            mensagem.AppendLine(ObterInformacoesTurmas(turmasQualidadeSoftware));

            return mensagem.ToString();
        }

        private string ObterInformacoesTurmas(List<Turmas> turmas)
        {
            StringBuilder mensagem = new StringBuilder();

            foreach (var turma in turmas)
            {
                mensagem.AppendLine($"- Professor: {turma.Professor}, Horário: {turma.Horarios}, Local: {turma.LocalAula}");
            }

            return mensagem.ToString();
        }


        private void btnVisualizarDadosDasTurmas_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ObterInformacoesTodasTurmas(), "Informações de Turmas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        [Test]
        public void VerificarConflitoHorarios_DeveRetornarTrueSeHouverConflito()
        {
            // Arrange
            var form = new form_disciplinas();
            var turma1 = new Turmas("Prof. A", "Segunda às 10h", "Sala01");
            var turma2 = new Turmas("Prof. B", "Segunda às 10h", "Sala02");

            // Act
            var result = form.VerificarConflitoHorarios(new List<Turmas> { turma1 }, turma2);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void VerificarConflitoHorarios_DeveRetornarFalseSeNaoHouverConflito()
        {
            // Arrange
            var form = new form_disciplinas();
            var turma1 = new Turmas("Prof. A", "Segunda às 10h", "Sala01");
            var turma2 = new Turmas("Prof. B", "Terça às 14h", "Sala02");

            // Act
            var result = form.VerificarConflitoHorarios(new List<Turmas> { turma1 }, turma2);

            // Assert
            Assert.That(result, Is.False);
        }


        [Test]
        public void AdicionarInformacoesMatTurmasSelecionadas_DeveRetornarQuantidadeCorreta()
        {
            // Arrange
            var form = new form_disciplinas();
            var richTextBox = new RichTextBox();
            var turmasSelecionadas = new List<Turmas>();

            // Act
            var result = form.AdicionarInformacoesMatTurmasSelecionadas(richTextBox, turmasSelecionadas);

            // Assert
            Assert.Equals(0, result);
        }

        [Test]
        public void TurmasConflitam_DeveRetornarTrueSeHorariosConflitam()
        {
            // Arrange
            var form = new form_disciplinas();
            var turma1 = new Turmas("Prof. A", "Segunda às 10h", "Sala01");
            var turma2 = new Turmas("Prof. B", "Segunda às 10h", "Sala02");

            // Act
            var result = form.TurmasConflitam(turma1, turma2);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void TurmasConflitam_DeveRetornarFalseSeHorariosNaoConflitam()
        {
            // Arrange
            var form = new form_disciplinas();
            var turma1 = new Turmas("Prof. A", "Segunda às 10h", "Sala01");
            var turma2 = new Turmas("Prof. B", "Terça às 14h", "Sala02");

            // Act
            var result = form.TurmasConflitam(turma1, turma2);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void AdicionarInformacoesTurmas_DeveRetornarQuantidadeCorreta()
        {
            // Arrange
            var form = new form_disciplinas();
            var richTextBox = new RichTextBox();
            var turmas = new List<Turmas>
            {
                new Turmas("Prof. A", "Segunda às 10h", "Sala01"),
                new Turmas("Prof. B", "Terça às 14h", "Sala02")
            };
            var turmasSelecionadas = new List<Turmas>();

            // Act
            var result = form.AdicionarInformacoesTurmas(richTextBox, "Disciplina", turmas, true, turmasSelecionadas);

            // Assert
            Assert.Equals(2, result);
            Assert.Equals(2, turmasSelecionadas.Count);
        }

        [Test]
        public void VerificarConflitoHorarios_DeveMostrarMensagemQuandoHouverConflito()
        {
            // Arrange
            var form = new form_disciplinas();
            var turma1 = new Turmas("Prof. A", "Segunda às 10h", "Sala01");
            var turma2 = new Turmas("Prof. B", "Segunda às 10h", "Sala02");
            var turmasSelecionadas = new List<Turmas> { turma1, turma2 };

            // Act and Assert
            var ex = Assert.Throws<AssertionException>(() => form.VerificarConflitoHorarios(turmasSelecionadas));
            StringAssert.Contains("Conflito de horários entre as turmas selecionadas.", ex.Message);
        }

        [Test]
        public void VerificarConflitoHorarios_NaoDeveMostrarMensagemQuandoNaoHouverConflito()
        {
            // Arrange
            var form = new form_disciplinas();
            var turma1 = new Turmas("Prof. A", "Segunda às 10h", "Sala01");
            var turma2 = new Turmas("Prof. B", "Terça às 14h", "Sala02");
            var turmasSelecionadas = new List<Turmas> { turma1, turma2 };

            // Act
            Assert.DoesNotThrow(() => form.VerificarConflitoHorarios(turmasSelecionadas));
        }

    }
}
