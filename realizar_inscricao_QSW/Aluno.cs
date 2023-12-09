using System;

namespace realizar_inscricao_QSW
{
    public class Aluno
    {
        public string Nome { get; set; } = "Joao Silva";
        public string Curso { get; set; } = "Análise e Desenvolvimento de Sistemas";
        public string Matricula { get; set; } = "BP123456";
        public double Nota { get; set; } = 0.0;

        public static Aluno AlunoPadrao => new Aluno("Joao Silva", "Análise e Desenvolvimento de Sistemas", "BP123456", 0, 0.0);


        public Aluno()
        {
            
        }

        public Aluno(string nome, string curso, string matricula, int idade, double nota)
        {
            Nome = nome;
            Curso = curso;
            Matricula = matricula;
            Nota = nota;
        }

        public string ObterInformacoes()
        {
            return $"Nome: {Nome}\nCurso: {Curso}\nMatrícula: {Matricula}\nNota: {Nota}";
        }

        public bool EstaAprovado(double notaMinima = 6.0)
        {
            return Nota >= notaMinima;
        }
    }
}
