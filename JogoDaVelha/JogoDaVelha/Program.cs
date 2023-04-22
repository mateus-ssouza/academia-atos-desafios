namespace JogoDaVelha
{
    internal class Program
    {
        // Função para exibir o menu
        public static void menuJogo()
        {
            Console.WriteLine("***********************");
            Console.WriteLine("*    JOGO DA VELHA    *");
            Console.WriteLine("*---------------------*");
            Console.WriteLine("* 1 - J1 VS J2        *");
            Console.WriteLine("* 2 - J1 VS COMP      *");
            Console.WriteLine("* 0 - SAIR            *");
            Console.WriteLine("***********************");
        }

        // Função para exibir o menu do modo de jogo
        public static void modoJogo()
        {
            Console.WriteLine("***********************");
            Console.WriteLine("*     J1 VS COMP      *");
            Console.WriteLine("*---------------------*");
            Console.WriteLine("* 1 - FÁCIL           *");
            Console.WriteLine("* 2 - DIFÍCIL         *");
            Console.WriteLine("* 0 - VOLTAR          *");
            Console.WriteLine("***********************");
        }

        // Função para exibir no fim da aplicação
        public static void fimAplicacao()
        {
            Console.WriteLine("************************");
            Console.WriteLine("*   FIM DA APLICAÇÃO   *");
            Console.WriteLine("************************");
        }

        // Função para inicializar o tabuleiro com caracteres com espaços
        public static void inicializarTabuleiro(char[,] tab)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
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
                Console.WriteLine($"{i + 1} | {tab[i, 0]} | {tab[i, 1]} | {tab[i, 2]} |");
                if ((i + 1) < 3) Console.WriteLine("  +---+---+---+");

            }
            Console.WriteLine("  +-----------+");
            Console.WriteLine();
        }

        // Função para realizar as jogadas do usuário no tabuleiro
        public static void realizarJogada(char[,] tab, char jogadorAtual)
        {
            bool jogadaValida = false;

            Console.Write($"VEZ DO JOGADOR {jogadorAtual}");

            while (!jogadaValida)
            {
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

        // Função para o realizar as jogadas do COMP no modo fácil
        public static void realizarJogadaCompFacil(char[,] tab)
        {
            char maquina = 'X';
            bool jogadaValida = false;
            Random random = new Random();

            while (!jogadaValida)
            {
                int linha = random.Next(3);
                int coluna = random.Next(3);

                if (linha >= 0 && linha <= 2 && coluna >= 0 && coluna <= 2 && tab[linha, coluna] == ' ')
                {
                    tab[linha, coluna] = maquina;
                    jogadaValida = true;
                }
            }
        }

        // Função para o realizar as jogadas do COMP no modo difícil
        public static void realizarJogadaCompDificil(char[,] tab)
        {
            char maquina = 'X';
            bool jogadaValida = false;

            while (!jogadaValida)
            {
                int[] jogada = avaliarTabuleiroComp(tab);
                int linha = jogada[0];
                int coluna = jogada[1];

                if (linha >= 0 && linha <= 2 && coluna >= 0 && coluna <= 2 && tab[linha, coluna] == ' ')
                {
                    tab[linha, coluna] = maquina;
                    jogadaValida = true;
                }
            }
        }

        // Função para máquina no modo difícil avaliar o tabuleiro e determinar sua jogada
        public static int[] avaliarTabuleiroComp(char[,] tab)
        {
            Random random = new Random();
            char maquina = 'X';
            char jogador = 'O';
            int[] jogada = new int[2];
            int cont = 0;

            // Laço para verificar se o tabuleiro está vazio
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                if (tab[i, 0] == ' ' && tab[i, 1] == ' ' && tab[i, 2] == ' ') cont += 3;
            }

            // Caso tabuleiro esteja vazio, a máquina joga aleatoriamente em algum dos
            // extremos do tabuleiro
            if (cont == 9)
            {
                do
                {
                    jogada[0] = random.Next(3);
                    jogada[1] = random.Next(3);
                } while (jogada[0] == 1 || jogada[1] == 1);

                return jogada;
            }

            // Laço para verificar se é possível vencer na próxima jogada
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (tab[i, j] == ' ')
                    {
                        tab[i, j] = maquina;

                        if (verificarJogo(tab, maquina))
                        {
                            jogada[0] = i;
                            jogada[1] = j;
                            tab[i, j] = ' ';
                            return jogada;
                        }
                        tab[i, j] = ' ';
                    }
                }
            }

            // Laço para verificar se o jogador pode vencer na próxima jogada
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (tab[i, j] == ' ')
                    {
                        tab[i, j] = jogador;

                        if (verificarJogo(tab, jogador))
                        {
                            jogada[0] = i;
                            jogada[1] = j;
                            tab[i, j] = ' ';
                            return jogada;
                        }
                        tab[i, j] = ' ';
                    }
                }
            }

            // Flag auxiliar se o laço abaixo entrou em alguma condicional
            bool flag = true;
            bool extremoOposto = false;

            // Laço para a máquina jogar novamente pelo os extremos opostos
            do
            {
                if (tab[0, 0] == maquina || tab[2, 2] == maquina)
                {
                    if (tab[2, 2] == maquina)
                    {
                        jogada[0] = 0;
                        jogada[1] = 0;
                    }
                    else
                    {
                        jogada[0] = 2;
                        jogada[1] = 2;
                    }

                    flag = false;
                    if (tab[jogada[0], jogada[1]] == ' ') extremoOposto = true;
                    else extremoOposto = false;
                }

                else if (tab[0, 2] == maquina || tab[2, 0] == maquina)
                {
                    if (tab[2, 0] == maquina)
                    {
                        jogada[0] = 0;
                        jogada[1] = 2;
                    }
                    else
                    {
                        jogada[0] = 0;
                        jogada[1] = 2;
                    }

                    flag = false;

                    if (tab[jogada[0], jogada[1]] == ' ') extremoOposto = true;
                    else extremoOposto = false;
                }

            } while (tab[jogada[0], jogada[1]] != ' ' && flag);

            if (extremoOposto) return jogada;

            bool extremos = false;
            // Verifica se a máquina pode jogar pelo os extremos
            if ((tab[0, 0] == maquina || tab[2, 2] == maquina) && (tab[0, 2] == ' ' || tab[2, 0] == ' '))
            {
                do
                {
                    jogada[0] = random.Next(3);
                    jogada[1] = random.Next(3);
                } while (jogada[0] == 1 || jogada[1] == 1 || jogada[0] == jogada[1]);

                if (tab[jogada[0], jogada[1]] == ' ') extremos = true;
                else extremos = false;
            }
            else if ((tab[0, 2] == maquina || tab[2, 0] == maquina) && (tab[0, 0] == ' ' || tab[2, 2] == ' '))
            {
                do
                {
                    jogada[0] = random.Next(3);
                    jogada[1] = random.Next(3);
                } while (jogada[0] == 1 || jogada[1] == 1 || jogada[0] != jogada[1]);


                if (tab[jogada[0], jogada[1]] == ' ') extremos = true;
                else extremos = false;
            }

            if (extremos) return jogada;

            // Joga em uma posição aleatória
            do
            {
                jogada[0] = random.Next(3);
                jogada[1] = random.Next(3);
            } while (tab[jogada[0], jogada[1]] != ' ');

            return jogada;
        }

        // Função para verificar tem vencedor na rodada
        public static bool verificarJogo(char[,] tab, char jogador)
        {
            int contDiagonalPrincipal = 0;
            int contDiagonalSecundaria = 0;

            for (int i = 0; i < tab.GetLength(0); i++)
            {
                // Verificando as linhas do tabuleiro
                if (tab[i, 0] == jogador && tab[i, 1] == jogador && tab[i, 2] == jogador)
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

        // Função para executar o jogo
        public static void executarJogo(int modoJogo = 1)
        {
            char[,] tabuleiro = new char[3, 3];
            char jogador = 'X';
            bool iniciarJogo = false;
            bool temVencedor = true;

            inicializarTabuleiro(tabuleiro);

            while (!iniciarJogo)
            {
                mostraTabuleiro(tabuleiro);

                switch (modoJogo)
                {
                    case 1:
                        realizarJogada(tabuleiro, jogador);
                        break;
                    case 2:
                        if (jogador == 'X') realizarJogadaCompFacil(tabuleiro);
                        else realizarJogada(tabuleiro, jogador);
                        break;
                    case 3:
                        if (jogador == 'X') realizarJogadaCompDificil(tabuleiro);
                        else realizarJogada(tabuleiro, jogador);
                        break;
                }
                iniciarJogo = verificarJogo(tabuleiro, jogador);

                // Enquanto o jogo não for finalizado, mudar o jogador a cada rodada
                if (!iniciarJogo) jogador = jogador == 'X' ? 'O' : 'X';

                // Caso não haja mais jogadas disponiveis e jogo não foi finalizado
                if (!temJogadaDisponivel(tabuleiro) && !iniciarJogo)
                {
                    string opcaoPartida;
                    Console.Clear();
                    Console.WriteLine("FIM DE JOGO!! HOUVE UM EMPATE!");
                    mostraTabuleiro(tabuleiro);
                    Console.Write("\nDeseja reiniciar a partida? (S) - SIM ou Qualquer caractere - NÃO: ");
                    opcaoPartida = Console.ReadLine().ToUpper();

                    // Reiniciar a partida
                    if (opcaoPartida.Equals("S"))
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
                Console.WriteLine("\nPressione ENTER para voltar ao menu inicial...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("JOGO FINALIZADO!\n");
                mostraTabuleiro(tabuleiro);
                Console.WriteLine("\nPressione ENTER para voltar ao menu inicial...");
                Console.ReadLine();
            }
        }

        public static void Main(string[] args)
        {
            char opcaoMenu = ' ';
            // Menu de opções para o jogo
            do
            {
                menuJogo();

                Console.Write("\nDigite sua opção: ");
                opcaoMenu = char.Parse(Console.ReadLine());

                switch (opcaoMenu)
                {
                    // Jogador VS Jogador
                    case '1':
                        Console.Clear();
                        executarJogo();
                        break;
                    // Jogador VS Máquina
                    case '2':
                        Console.Clear();
                        modoJogo();

                        Console.Write("\nDigite sua opção: ");
                        char opcaoModo = char.Parse(Console.ReadLine());

                        switch (opcaoModo)
                        {
                            case '1':
                                Console.Clear();
                                executarJogo(2);
                                break;

                            case '2':
                                Console.Clear();
                                executarJogo(3);
                                break;

                            default:
                                break;
                        }
                        break;

                    default:
                        break;
                }
                Console.Clear();
            }
            while (opcaoMenu == '1' || opcaoMenu == '2');

            fimAplicacao();
        }
    }
}