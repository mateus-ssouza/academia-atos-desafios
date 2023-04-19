namespace JogoDaVelha
{
    internal class Program
    {
        // Função para inicializar o tabuleiro com caracteres com espaços
        public static void inicializarTabuleiro(char[,] tab)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for(int j = 0; j < tab.GetLength(1); j++)
                    tab[i, j] = ' ';
            }
        }

        // Função para exibir o tabuleiro
        public static void mostraTabuleiro(char[,] tab) 
        {
            Console.WriteLine("    1   2   3");
            Console.WriteLine("  +-----------+");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i+1} | {tab[i,0]} | {tab[i, 1]} | {tab[i, 2]} |");
                if ((i+1) < 3) Console.WriteLine("  +---+---+---+");

            }
            Console.WriteLine("  +-----------+");
            Console.WriteLine();
        }

        // Função para realizar as jogadas no tabuleiro
        public static void realizarJogada(char[,] tab, char jogadorAtual)
        {
            bool jogadaValida = false;
            
            while (!jogadaValida)
            {
                Console.Write($"VEZ DO JOGADOR {jogadorAtual}");
                
                Console.Write("\n\nDigite a posição no tabuleiro (Ex.: 1-1): ");
                string entrada = Console.ReadLine();
                
                string[] posicao = entrada.Split('-');

                int linha = int.Parse(posicao[0]) - 1;
                int coluna = int.Parse(posicao[1]) - 1;

                if (linha >= 0 && linha <= 2 && coluna >= 0 && coluna <= 2 && tab[linha, coluna] == ' ')
                {
                    tab[linha, coluna] = jogadorAtual;
                    jogadaValida = true;
                }
                else Console.WriteLine("\nJogada inválida, tente novamente!\n");
            }
        }

        // Função para verificar tem vencedor na rodada
        public static bool verificarJogo(char [,] tab, char jogador)
        {
            int contDiagonalPrincipal = 0;
            int contDiagonalSecundaria = 0;

            for (int i = 0; i < tab.GetLength(0); i++) 
            { 
               // Verificando as linhas do tabuleiro
                if (tab[i, 0]  == jogador && tab[i, 1] == jogador && tab[i, 2] == jogador)
                    return true;
                // Verificando as colunas do tabuleiro
                else if (tab[0, i] == jogador && tab[1, i] == jogador && tab[2, i] == jogador)
                    return true;

                if (tab[i, i] == jogador)
                    contDiagonalPrincipal++;
            }

            // Verificando a diagonal principal do tabuleiro
            if (contDiagonalPrincipal == 3) return true;

            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                    if (i + j == 2 && tab[i, j] == jogador) contDiagonalSecundaria++;
            }

            // Verificando a diagonal secundária do tabuleiro
            if (contDiagonalSecundaria == 3) return true;

            return false;
        }

        // Função para verificar se possivel realizar jogadas
        public static bool temJogadaDisponivel(char[,] tab)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                    if (tab[i, j] == ' ')
                        return true;
            }
            return false;
        }
       
        public static void Main(string[] args)
        {
            char[,] tabuleiro = new char[3, 3];
            char jogador = 'X';
            bool iniciarJogo = false;
            bool temVencedor = true;
            inicializarTabuleiro(tabuleiro);


            while (!iniciarJogo)
            {
                mostraTabuleiro(tabuleiro);
                realizarJogada(tabuleiro, jogador);
                iniciarJogo = verificarJogo(tabuleiro, jogador);
                
                // Enquanto o jogo não for finalizado, mudar o jogador a cada rodada
                if(!iniciarJogo) jogador = jogador == 'X' ? 'O': 'X';

                // Caso não haja mais jogadas disponiveis e jogo não foi finalizado
                if (!temJogadaDisponivel(tabuleiro) && !iniciarJogo)
                {
                    string opcao;
                    Console.Clear();
                    Console.WriteLine("FIM DE JOGO!! HOUVE UM EMPATE!");
                    mostraTabuleiro(tabuleiro);
                    Console.Write("\nDeseja reiniciar a partida? S - Sim ou Qualquer coisa para Não: ");
                    opcao = Console.ReadLine().ToUpper();

                    // Reiniciar a partida
                    if (opcao.Equals("S"))
                    {
                        Console.Clear();
                        jogador = 'X';
                        iniciarJogo = false;
                        inicializarTabuleiro(tabuleiro);
                    }
                    else
                    {
                        iniciarJogo = true;
                        temVencedor = false;
                    }

                }
                Console.Clear();
            }

            // Caso a partida tenha um vencedor é exibido o vencedor e o resultado do tabuleiro
            if (temVencedor)
            {
                Console.Clear();
                Console.WriteLine($"FIM DE JOGO!! O JOGADOR VENCEDOR É: {jogador}\n");
                mostraTabuleiro(tabuleiro);
            }
            else
            {
                Console.WriteLine("JOGO FINALIZADO!\n");
                mostraTabuleiro(tabuleiro);
            }
        }
    }
}