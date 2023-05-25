using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio1_win_forms
{
    internal class Curso
    {
        private int codigo;
        private string nome;

        public Curso(int codigo, string nome)
        {
            this.codigo = codigo;
            this.nome = nome;
        }

        public string Nome
        {
            get { return nome; }
            set { if (String.IsNullOrEmpty(value)) nome = value; }
        }

        public int Codigo
        {
            get { return codigo; }
            set { if (value > 0) codigo = value; }
        }
    }
}
