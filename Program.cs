using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jokenpo
{
    class Program
    {
        static void Main(string[] args)
        {
            TelaInicial();
            
            // Nome do Jogador
            Console.Write("Nome do jogador: ");
            var nomeJogador = Console.ReadLine().Trim(); Thread.Sleep(1000); Console.Clear();
            nomeJogador = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nomeJogador.ToLower());
            
            if (nomeJogador == "") nomeJogador = "Jogador Nº 1";
            
            Console.WriteLine($"A partida já vai começar!"); Thread.Sleep(2000); Console.Clear();

            string num = "0"; var jogadaAdversario = ""; int vitoriasComputador = 0; int vitoriasJogador = 0; int contadorEmpate = 0;
            int numeroPartidas = 0;

            while (num != "1")
            {
                string num2 = "0";
                while (num2 != "1")
                {
                    // Jogada do Adversário
                    Console.WriteLine($"{nomeJogador} faça sua jogada!");
                    Console.WriteLine("\n[1] Pedra");
                    Console.WriteLine("[2] Papel");
                    Console.WriteLine("[3] Tesoura");

                    Console.Write("\nDigite sua opção: ");
                    int escolhaDoJogador = Convert.ToInt16(Console.ReadLine());

                    if (escolhaDoJogador > 0 && escolhaDoJogador < 4)
                    {
                        if (escolhaDoJogador == 1)
                        {
                            jogadaAdversario = "Pedra";
                            Console.Clear();
                            break;
                        }
                        if (escolhaDoJogador == 2)
                        {
                            jogadaAdversario = "Papel";
                            Console.Clear();
                            break;
                        }
                        if (escolhaDoJogador == 3)
                        {
                            jogadaAdversario = "Tesoura";
                            Console.Clear();
                            break;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"{nomeJogador} opção inválida, tente novamente.");
                        Thread.Sleep(2000); 
                        Console.Clear();
                    }
                }

                // Jogada do Computador
                Random rnd = new Random();
                string[] itens = { "Pedra", "Papel", "Tesoura" };
                int fIndex = rnd.Next(itens.Length);
                var jogadaComputador = itens[fIndex];

                Jokenpo();

                Console.WriteLine($"Computador escolheu {jogadaComputador}.");
                Console.WriteLine($"\n{nomeJogador} escolheu {jogadaAdversario}.");
                Thread.Sleep(3000); Console.Clear();

                // Comparador de Jogadas
                if (jogadaAdversario == jogadaComputador)
                {
                    Console.WriteLine("Empate!");
                    contadorEmpate++;
                }
                else
                {
                    if (jogadaAdversario == "Pedra" && jogadaComputador == "Papel")
                    {
                        Console.WriteLine("Papel embrulha Pedra");
                        Console.WriteLine("\nComputador venceu!");
                        vitoriasComputador++;
                    }
                    else if (jogadaAdversario == "Papel" && jogadaComputador == "Pedra")
                    {
                        Console.WriteLine("Papel embrulha Pedra");
                        Console.WriteLine($"\n{nomeJogador} venceu!");
                        vitoriasJogador++;
                    }
                    else if (jogadaAdversario == "Pedra" && jogadaComputador == "Tesoura")
                    {
                        Console.WriteLine("Pedra quebra Tesoura");
                        Console.WriteLine($"\n{nomeJogador} venceu!");
                        vitoriasJogador++;
                    }
                    else if (jogadaAdversario == "Tesoura" && jogadaComputador == "Pedra")
                    {
                        Console.WriteLine("Pedra quebra Tesoura");
                        Console.WriteLine("\nComputador venceu!");
                        vitoriasComputador++;
                    }
                    else if (jogadaAdversario == "Papel" && jogadaComputador == "Tesoura")
                    {
                        Console.WriteLine("Tesoura corta Papel");
                        Console.WriteLine("\nComputador venceu!");
                        vitoriasComputador++;
                    }
                    else if (jogadaAdversario == "Tesoura" && jogadaComputador == "Papel")
                    {
                        Console.WriteLine("Tesoura corta Papel");
                        Console.WriteLine($"\n{nomeJogador} venceu!");
                        vitoriasJogador++;
                    }
                }
                Thread.Sleep(4000); Console.Clear();
                
                Console.WriteLine($"{nomeJogador} quer continuar a jogar?");
                Console.Write($"Digite S ou N: ");
                num = Console.ReadLine().ToString().Trim().ToUpper();
                if (num == "N")
                {
                    Thread.Sleep(1000); Console.Clear();
                    Console.WriteLine("Resultado do Jokenpô\n"); Thread.Sleep(1000);
                    Console.WriteLine($"Nº de partidas: {numeroPartidas+1}."); Thread.Sleep(1000);
                    Console.WriteLine($"Vitórias do Computador: {vitoriasComputador}."); Thread.Sleep(1000);
                    Console.WriteLine($"Vitórias do {nomeJogador}: {vitoriasJogador}."); Thread.Sleep(1000);
                    Console.WriteLine($"Empates: {contadorEmpate}."); Thread.Sleep(4000);

                    Console.Clear(); Console.WriteLine("Fechando jogo...");
                    Thread.Sleep(2000); Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear(); Thread.Sleep(1000);
                    Console.WriteLine($"{nomeJogador} o jogo irá recomeçar..."); Thread.Sleep(2000);
                    numeroPartidas++;
                    Console.Clear(); Thread.Sleep(2000);
                }
            }
            Console.ReadLine();
        }

        static void TelaInicial()
        {
            Console.WriteLine("#*#*#*#*#*#*#");
            Console.Write("  Jo"); Thread.Sleep(1000);
            Console.Write("ken"); Thread.Sleep(1000);
            Console.WriteLine("pô!");
            Console.WriteLine("#*#*#*#*#*#*#");
            Thread.Sleep(2000); Console.Clear();
        }

        static void Jokenpo()
        {
            Console.WriteLine("--------------");
            Console.Write("  Jo"); Thread.Sleep(1000);
            Console.Write("ken"); Thread.Sleep(1000);
            Console.WriteLine("pô!");
            Console.WriteLine("--------------");
            Thread.Sleep(1000); Console.Clear();
        }
    }
}
