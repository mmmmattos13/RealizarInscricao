using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace realizar_inscricao_QSW
{
    internal class TAG_TRANSPORTE
    {
        private static string _RESUMO_INSCRICAO;

        public static string RESUMO_INSCRICAO
        {
            get { return _RESUMO_INSCRICAO; }
            set { _RESUMO_INSCRICAO = value; }
        }
    }
}
