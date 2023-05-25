using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio1_win_forms
{
    internal class Pessoa
    {
        private string nome;
        private string telefone;
        private string cidade;
        private string rg;
        private string cpf;

        public Pessoa(string nome, string telefone, string cidade, string rg, string cpf)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.cidade = cidade;
            this.rg = rg;
            this.cpf = cpf;
        }

        public string Nome
        {
            get { return nome; }
            set { if (String.IsNullOrEmpty(value)) nome = value; }
        }

        public string Telefone
        {
            get { return telefone; }
            set { if (String.IsNullOrEmpty(value)) telefone = value; }
        }

        public string Cidade
        {
            get { return cidade; }
            set { if (String.IsNullOrEmpty(value)) cidade = value; }
        }

        public string RG
        {
            get { return rg; }
            set { if (String.IsNullOrEmpty(value)) rg = value; }
        }

        public string CPF
        {
            get { return cpf; }
            set { if (String.IsNullOrEmpty(value)) cpf = value; }
        }

        public override string ToString()
        {
            return $"Pessoa: {Nome} - " +
                $"{Telefone} - " +
                $"{Cidade} - " +
                $"{RG} - " +
                $"{CPF}";
        }
    }
}
