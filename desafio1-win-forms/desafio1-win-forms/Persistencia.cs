using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio1_win_forms
{
    internal class Persistencia
    {
        public static void popularListaPessoasArquivo(string nomeArquivo, List<Pessoa> listaPessoas)
        {
            try
            {
                StreamReader leitor = new StreamReader(nomeArquivo, Encoding.UTF8);
                List<String> dadosArquivo = new List<String>();

                do
                {
                    string linha = leitor.ReadLine();
                    dadosArquivo.Add(linha);
                } while (!leitor.EndOfStream);

                leitor.Close();

                for (int i = 0; i < dadosArquivo.Count; i++)
                {
                    if (dadosArquivo[i][0] == 'Z')
                    {
                        string[] dadosPessoa = dadosArquivo[i].Split("-");

                        if ((i + 1 < dadosArquivo.Count &&
                        dadosArquivo[i + 1][0] != 'Y') ||
                        (i + 1 == dadosArquivo.Count))
                        {
                            Pessoa pessoa = new Pessoa(dadosPessoa[1], dadosPessoa[2],
                               dadosPessoa[3], dadosPessoa[4], dadosPessoa[5]);

                            listaPessoas.Add(pessoa);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static void popularListaAlunosArquivo(string nomeArquivo, List<Aluno> listaAlunos)
        {
            try
            {
                StreamReader leitor = new StreamReader(nomeArquivo, Encoding.UTF8);
                List<String> dadosArquivo = new List<String>();

                do
                {
                    string linha = leitor.ReadLine();
                    dadosArquivo.Add(linha);
                } while (!leitor.EndOfStream);

                leitor.Close();

                for (int i = 0; i < dadosArquivo.Count; i++)
                {
                    if (dadosArquivo[i][0] == 'Z')
                    {
                        string[] dadosPessoa = dadosArquivo[i].Split("-");

                        if (i + 1 < dadosArquivo.Count &&
                        dadosArquivo[i + 1][0] == 'Y')
                        {
                            string[] dadosAluno = dadosArquivo[i + 1].Split("-");

                            Aluno aluno = new Aluno(dadosPessoa[1], dadosPessoa[2],
                                dadosPessoa[3], dadosPessoa[4], dadosPessoa[5],
                                int.Parse(dadosAluno[1]),
                                new Curso(int.Parse(dadosAluno[2]), dadosAluno[3]));

                            listaAlunos.Add(aluno);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static List<String> dadosDoArquivo(string nomeArquivo)
        {
            List<String> dadosArquivo = new List<String>();

            try
            {
                StreamReader leitor = new StreamReader(nomeArquivo, Encoding.UTF8);
                
                do
                {
                    string linha = leitor.ReadLine();
                    dadosArquivo.Add(linha);
                } while (!leitor.EndOfStream);

                leitor.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            return dadosArquivo;
        }
    }
}
