using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace realizar_inscricao_QSW
{
    internal class Turmas
    {
        public string Professor { get; set; }
        public string Horarios { get; set; }
        public string LocalAula { get; set; }

        public Turmas()
        {
            
        }

        public Turmas(string professor, string horarios, string localAula)
        {
            Professor = professor;
            Horarios = horarios;
            LocalAula = localAula;
        }

        public string ObterInformacoes()
        {
            return $"Professor: {Professor}\nHorários: {Horarios}\nLocal de Aula: {LocalAula}";
        }
    }
}
