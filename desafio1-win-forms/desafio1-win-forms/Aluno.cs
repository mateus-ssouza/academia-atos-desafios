using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio1_win_forms
{
    internal class Aluno : Pessoa
    {
        private int matricula;
        private Curso curso;

        public Aluno(string nome, string telefone,
            string cidade, string rg, string cpf,
            int matricula, Curso curso) : base(nome, telefone, cidade, rg, cpf)
        {
            this.matricula = matricula;
            this.curso = curso;
        }

        public int Matricula
        {
            get { return this.matricula; }
            set { if (value > 0) this.matricula = value; }
        }

        public Curso Curso
        {
            get { return this.curso; }
            set { if (value != null) curso = value; }
        }

        public string mostrarAlunoCurso()
        {
            return $"{Nome}: {Curso.Nome}";
        }

        public override string ToString()
        {
            return $"Aluno: {Nome} - " +
                $"{Telefone} - " +
                $"{Cidade} - " +
                $"{RG} - " +
                $"{CPF} - " +
                $"{Matricula} - " +
                $"{Curso.Codigo} - " +
                $"{Curso.Nome}";
        }
    }
}
