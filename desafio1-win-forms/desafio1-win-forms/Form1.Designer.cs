namespace desafio1_win_forms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelPrincipal = new Label();
            labelLista = new Label();
            textBoxListaDeDadosDoArquivo = new TextBox();
            labelQuantPessoas = new Label();
            labelQuantAlunos = new Label();
            buttonMostrarArquivo = new Button();
            buttonListarCursos = new Button();
            buttonContagem = new Button();
            buttonLimpar = new Button();
            textBoxPessoas = new TextBox();
            textBoxAlunos = new TextBox();
            SuspendLayout();
            // 
            // labelPrincipal
            // 
            labelPrincipal.AutoSize = true;
            labelPrincipal.Location = new Point(12, 20);
            labelPrincipal.Name = "labelPrincipal";
            labelPrincipal.Size = new Size(231, 15);
            labelPrincipal.TabIndex = 0;
            labelPrincipal.Text = "Desafio 1 - Arquivos com pessoas e alunos";
            labelPrincipal.Click += label1_Click;
            // 
            // labelLista
            // 
            labelLista.AutoSize = true;
            labelLista.Location = new Point(385, 20);
            labelLista.Name = "labelLista";
            labelLista.Size = new Size(73, 15);
            labelLista.TabIndex = 1;
            labelLista.Text = "Informações";
            labelLista.Click += label2_Click;
            // 
            // textBoxListaDeDadosDoArquivo
            // 
            textBoxListaDeDadosDoArquivo.BackColor = SystemColors.InactiveBorder;
            textBoxListaDeDadosDoArquivo.Enabled = false;
            textBoxListaDeDadosDoArquivo.Location = new Point(385, 38);
            textBoxListaDeDadosDoArquivo.Multiline = true;
            textBoxListaDeDadosDoArquivo.Name = "textBoxListaDeDadosDoArquivo";
            textBoxListaDeDadosDoArquivo.ScrollBars = ScrollBars.Vertical;
            textBoxListaDeDadosDoArquivo.Size = new Size(547, 222);
            textBoxListaDeDadosDoArquivo.TabIndex = 2;
            // 
            // labelQuantPessoas
            // 
            labelQuantPessoas.AutoSize = true;
            labelQuantPessoas.Location = new Point(12, 209);
            labelQuantPessoas.Name = "labelQuantPessoas";
            labelQuantPessoas.Size = new Size(141, 15);
            labelQuantPessoas.TabIndex = 3;
            labelQuantPessoas.Text = "Total de objetos Pessoa: 0\r\n";
            labelQuantPessoas.Click += labelQuantPessoas_Click;
            // 
            // labelQuantAlunos
            // 
            labelQuantAlunos.AutoSize = true;
            labelQuantAlunos.Location = new Point(207, 209);
            labelQuantAlunos.Name = "labelQuantAlunos";
            labelQuantAlunos.Size = new Size(137, 15);
            labelQuantAlunos.TabIndex = 4;
            labelQuantAlunos.Text = "Total de objetos Aluno: 0";
            // 
            // buttonMostrarArquivo
            // 
            buttonMostrarArquivo.Location = new Point(12, 115);
            buttonMostrarArquivo.Name = "buttonMostrarArquivo";
            buttonMostrarArquivo.Size = new Size(75, 41);
            buttonMostrarArquivo.TabIndex = 5;
            buttonMostrarArquivo.Text = "Mostrar arquivo";
            buttonMostrarArquivo.UseVisualStyleBackColor = true;
            buttonMostrarArquivo.Click += buttonListarTodos_Click;
            // 
            // buttonListarCursos
            // 
            buttonListarCursos.Location = new Point(93, 115);
            buttonListarCursos.Name = "buttonListarCursos";
            buttonListarCursos.Size = new Size(75, 41);
            buttonListarCursos.TabIndex = 6;
            buttonListarCursos.Text = "Listar Cursos";
            buttonListarCursos.UseVisualStyleBackColor = true;
            buttonListarCursos.Click += buttonListarCursos_Click;
            // 
            // buttonContagem
            // 
            buttonContagem.Location = new Point(174, 115);
            buttonContagem.Name = "buttonContagem";
            buttonContagem.Size = new Size(75, 41);
            buttonContagem.TabIndex = 7;
            buttonContagem.Text = "Contagem";
            buttonContagem.UseVisualStyleBackColor = true;
            buttonContagem.Click += buttonContagem_Click;
            // 
            // buttonLimpar
            // 
            buttonLimpar.Location = new Point(255, 115);
            buttonLimpar.Name = "buttonLimpar";
            buttonLimpar.Size = new Size(75, 41);
            buttonLimpar.TabIndex = 8;
            buttonLimpar.Text = "Limpar";
            buttonLimpar.UseVisualStyleBackColor = true;
            buttonLimpar.Click += buttonLimpar_Click;
            // 
            // textBoxPessoas
            // 
            textBoxPessoas.BackColor = SystemColors.InactiveBorder;
            textBoxPessoas.Enabled = false;
            textBoxPessoas.Location = new Point(12, 236);
            textBoxPessoas.Multiline = true;
            textBoxPessoas.Name = "textBoxPessoas";
            textBoxPessoas.ScrollBars = ScrollBars.Vertical;
            textBoxPessoas.Size = new Size(156, 222);
            textBoxPessoas.TabIndex = 9;
            textBoxPessoas.TextChanged += textBoxPessoas_TextChanged;
            // 
            // textBoxAlunos
            // 
            textBoxAlunos.BackColor = SystemColors.InactiveBorder;
            textBoxAlunos.Enabled = false;
            textBoxAlunos.Location = new Point(207, 236);
            textBoxAlunos.Multiline = true;
            textBoxAlunos.Name = "textBoxAlunos";
            textBoxAlunos.ScrollBars = ScrollBars.Vertical;
            textBoxAlunos.Size = new Size(156, 222);
            textBoxAlunos.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(957, 480);
            Controls.Add(textBoxAlunos);
            Controls.Add(textBoxPessoas);
            Controls.Add(buttonLimpar);
            Controls.Add(buttonContagem);
            Controls.Add(buttonListarCursos);
            Controls.Add(buttonMostrarArquivo);
            Controls.Add(labelQuantAlunos);
            Controls.Add(labelQuantPessoas);
            Controls.Add(textBoxListaDeDadosDoArquivo);
            Controls.Add(labelLista);
            Controls.Add(labelPrincipal);
            Name = "Form1";
            Text = "Desafio 1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPrincipal;
        private Label labelLista;
        private TextBox textBoxListaDeDadosDoArquivo;
        private Label labelQuantPessoas;
        private Label labelQuantAlunos;
        private Button buttonMostrarArquivo;
        private Button buttonListarCursos;
        private Button buttonContagem;
        private Button buttonLimpar;
        private TextBox textBoxPessoas;
        private TextBox textBoxAlunos;
    }
}