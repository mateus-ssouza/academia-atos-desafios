namespace desafio1_win_forms
{
    public partial class Form1 : Form
    {
        string path = "../../../dados.dat";
        List<Pessoa> pessoas = new List<Pessoa>();
        List<Aluno> alunos = new List<Aluno>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labelQuantPessoas_Click(object sender, EventArgs e)
        {

        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            labelQuantPessoas.Text = "Total de objetos Pessoa: 0";
            labelQuantAlunos.Text = "Total de objetos Aluno: 0";
            labelLista.Text = "Informações";
            textBoxListaDeDadosDoArquivo.Text = "";
            textBoxPessoas.Text = "";
            textBoxAlunos.Text = "";
            pessoas.Clear();
            alunos.Clear();
        }

        private void buttonContagem_Click(object sender, EventArgs e)
        {
            pessoas.Clear();
            alunos.Clear();
            textBoxPessoas.Text = "";
            textBoxAlunos.Text = "";

            Persistencia.popularListaPessoasArquivo(path, pessoas);
            Persistencia.popularListaAlunosArquivo(path, alunos);

            labelQuantPessoas.Text = $"Total de objetos Pessoa: {pessoas.Count}";
            labelQuantAlunos.Text = $"Total de objetos Aluno: {alunos.Count}";

            foreach (var p in pessoas)
            {
                textBoxPessoas.AppendText($"- {p.Nome}{Environment.NewLine}");
            }

            foreach (var a in alunos)
            {
                textBoxAlunos.AppendText($"- {a.Nome}{Environment.NewLine}");
            }
        }

        private void buttonListarTodos_Click(object sender, EventArgs e)
        {
            textBoxListaDeDadosDoArquivo.Text = "";

            List<String> dadosArquivo = Persistencia.dadosDoArquivo(path);
            labelLista.Text = "Dados existentes no arquivo";

            foreach (var d in dadosArquivo)
            {
                textBoxListaDeDadosDoArquivo.AppendText($"{d}{Environment.NewLine}");
            }
        }

        private void buttonListarCursos_Click(object sender, EventArgs e)
        {
            textBoxListaDeDadosDoArquivo.Text = "";
            alunos.Clear();

            Persistencia.popularListaAlunosArquivo(path, alunos);
            labelLista.Text = "Lista de alunos e seus cursos";

            foreach (var a in alunos)
            {
                textBoxListaDeDadosDoArquivo.AppendText($"--> {a.Nome.ToUpper()} - {a.Curso.Nome.ToUpper()}{Environment.NewLine}");
            }
        }

        private void textBoxPessoas_TextChanged(object sender, EventArgs e)
        {

        }
    }
}