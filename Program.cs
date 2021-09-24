using System;

namespace PromptGames
{
    class Program
    {
        enum Jokenpo{Pedra = 1, Papel, Tesoura};

        static void Main(string[] args)
        {
         bool saiu = false;
         int menu = 0;
          do{
            Console.Clear();
            ShowMenu();
            menu = int.Parse(Console.ReadLine());
            switch(menu){
                default:
                    do{
                        Console.Write("ERRO! Digite o valor corretamente: ");
                        menu = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }while(menu<=0 || menu>4);
                break;

                case 1:
                 PvIA();
                break;

                case 2:
                 PvP();
                break;
                
                case 3:
                 Adivinhacao();
                break;

                case 4:
                 Console.Clear();
                 saiu = true;
                break;
            }
          }while(saiu!=true);
        }
        static void ShowMenu(){
            Console.WriteLine("======================================");
            Console.WriteLine("- - - Jogos de CMD - - -");
            Console.WriteLine("[1] JoKenPo (VS IA)\n[2] JoKenPo (PvP)\n[3] Jogo do número\n[4] Sair");
            Console.WriteLine("======================================");
        }
        
        static void Choose(){
            Console.WriteLine("================");
            Console.WriteLine("ESCOLHA: ");
            Console.WriteLine("[1] Pedra\n[2] Papel\n[3] Tesoura");
            Console.WriteLine("================");
        }

        static int IAPlay(){
            Random rd = new Random();
            int IANumber = rd.Next(1,3);
            return(IANumber);
        }
        static void PvIA(){
         int P1Number = 0,IANum = 0;
         int P1Points = 0, IAPoints = 0;
         bool J1Win = false;
         string resposta = "S";

            while(resposta == "S" || resposta ==  "s"){

                    Console.Clear();
                    Choose();
                    P1Number = int.Parse(Console.ReadLine());
                    Console.Clear();
                    while(P1Number<1 || P1Number>3){
                        Console.Write("Escolha um número válido: ");
                        P1Number = int.Parse(Console.ReadLine());
                    }
                    IANum = IAPlay();
                    if(IANum == P1Number){
                        Console.WriteLine("Ocorreu um empate! ");
                        Console.WriteLine("");
                        Console.WriteLine((Jokenpo)P1Number + " X " + (Jokenpo)IANum);
                        Console.WriteLine("===================================");
                        Console.WriteLine("PONTOS DO JOGADOR 1: " + P1Points);
                        Console.WriteLine("PONTOS DA I.A: " + IAPoints);
                    }
                    else{
                        J1Win = Winner(P1Number, IANum, J1Win);

                        if(J1Win == true){
                        Console.WriteLine("O JOGADOR 1 VENCEU! ");
                        Console.WriteLine((Jokenpo)P1Number + " X " + (Jokenpo)IANum);
                        P1Points++;
                        Console.WriteLine("===================================");
                        Console.WriteLine("PONTOS DO JOGADOR 1: " + P1Points);
                        Console.WriteLine("PONTOS DA I.A: " + IAPoints);
                        }
                        else{
                        Console.WriteLine("A I.A VENCEU! ");
                        Console.WriteLine((Jokenpo)P1Number + " X " + (Jokenpo)IANum);
                        IAPoints++;
                        Console.WriteLine("===================================");
                        Console.WriteLine("PONTOS DO JOGADOR 1: " + P1Points);
                        Console.WriteLine("PONTOS DA I.A: " + IAPoints);
                        }

                        }
                        Console.WriteLine("===================================");
                        Console.Write("Deseja continuar? [S/N]: ");
                        resposta = Console.ReadLine();
                    }
                    Console.Clear();

                    Console.WriteLine("===================================");
                    Console.WriteLine("PONTUAÇÃO FINAL DOS JOGADORES: ");
                    Console.WriteLine("JOGADOR 1: " + P1Points);
                    Console.WriteLine("I.A : " + IAPoints);
                    Console.WriteLine("===================================");
                    Console.ReadKey();
        }
        static void PvP(){
            int P1Number = 0, P2Number = 0, P1Points = 0, P2Points = 0;
            bool J1Win = false;
            string resposta = "s";

            while(resposta == "S" || resposta ==  "s"){

                    Console.Clear();
                    Console.WriteLine("= PLAYER 1 =");
                    Choose();
                    P1Number = int.Parse(Console.ReadLine());
                    while(P1Number<1 || P1Number>3){
                        Console.Write("Escolha um número válido: ");
                        P1Number = int.Parse(Console.ReadLine());
                    }
                    Console.Clear();
                    Console.WriteLine("= PLAYER 2 =");
                    Choose();
                    P2Number = int.Parse(Console.ReadLine());
                    while(P2Number<1 || P2Number>3){
                        Console.Write("Escolha um número válido: ");
                        P2Number = int.Parse(Console.ReadLine());
                    }

                    if(P2Number == P1Number){
                        Console.WriteLine("Ocorreu um empate! ");
                        Console.WriteLine("");
                        Console.WriteLine((Jokenpo)P1Number + " X " + (Jokenpo)P2Number);
                        Console.WriteLine("===================================");
                        Console.WriteLine("PONTOS DO JOGADOR 1: " + P1Points);
                        Console.WriteLine("PONTOS DO JOGADOR 2: " + P2Points);
                    }
                    else{
                        J1Win = Winner(P1Number, P2Number, J1Win);

                        if(J1Win == true){
                        Console.WriteLine("O JOGADOR 1 VENCEU! ");
                        Console.WriteLine((Jokenpo)P1Number + " X " + (Jokenpo)P2Number);
                        P1Points++;
                        Console.WriteLine("===================================");
                        Console.WriteLine("PONTOS DO JOGADOR 1: " + P1Points);
                        Console.WriteLine("PONTOS DO JOGADOR 2: " + P2Points);
                        }
                        else{
                        Console.WriteLine("O JOGADOR 2 VENCEU! ");
                        Console.WriteLine((Jokenpo)P1Number + " X " + (Jokenpo)P2Number);
                        P2Points++;
                        Console.WriteLine("===================================");
                        Console.WriteLine("PONTOS DO JOGADOR 1: " + P1Points);
                        Console.WriteLine("PONTOS DO JOGADOR 2: " + P2Points);
                        }

                        }
                        Console.WriteLine("===================================");
                        Console.Write("Deseja continuar? [S/N]: ");
                        resposta = Console.ReadLine();
                    }
                    Console.Clear();

                    Console.WriteLine("===================================");
                    Console.WriteLine("PONTUAÇÃO FINAL DOS JOGADORES: ");
                    Console.WriteLine("JOGADOR 1: " + P1Points);
                    Console.WriteLine("JOGADOR 2: " + P2Points);
                    Console.WriteLine("===================================");
                    Console.ReadKey();
        }
        static void  Adivinhacao(){
            Console.Clear();
            string resposta = "s";
            int PlayerNumber = 0, TentativasRestantes = 9, Tentativas = 1;
            Random RandNum = new Random();
            int PCNumber = RandNum.Next(1,100);
            while(resposta == "s" || resposta == "S"){

                while(TentativasRestantes>=0){
                    Console.Write("Digite um número: ");
                    PlayerNumber = int.Parse(Console.ReadLine());
                    Console.Clear();

                    if(PlayerNumber>PCNumber){
                        Console.WriteLine("==================");
                        Console.WriteLine("Você está chutando alto.");
                        Console.WriteLine("Tentativas restantes: " + TentativasRestantes);
                        Console.WriteLine("==================");
                        Tentativas++;
                    }
                    else if(PlayerNumber<PCNumber){
                        Console.WriteLine("==================");
                        Console.WriteLine("Você está chutando baixo.");
                        Console.WriteLine("Tentativas restantes: " + TentativasRestantes);
                        Console.WriteLine("==================");
                        Tentativas++;
                    }
                    else if(PlayerNumber==PCNumber){
                        Console.WriteLine("==================");
                        Console.WriteLine("Você acertou! O número era " + PlayerNumber + ".");
                        Console.WriteLine("TENTATIVAS: " + Tentativas);
                        Console.WriteLine("==================");
                        TentativasRestantes = -999;
                    }

                    if(TentativasRestantes==0){
                        Console.Clear();
                        Console.WriteLine("==========================================");
                        Console.WriteLine("Suas tentativas acabaram, você perdeu.");
                        Console.WriteLine("==========================================");
                    }
                    TentativasRestantes--;
                
                }
                Console.Write("Deseja continuar? [S/N]: ");
                resposta = Console.ReadLine();
                Console.Clear();
                PCNumber = RandNum.Next(1,100);
                TentativasRestantes = 9;
                Tentativas = 1;
            }

        }

        static bool Winner(int x, int y, bool J1Win){

            if(x == 1 && y == 3){
                J1Win = true;
            }
            else if(y == 1 && x == 3){
                J1Win = false;
            }
            else if(x == 2 && y == 1){
                J1Win = true;
            }
            else if(y == 2 && x == 1){
                J1Win = false;
            }
            else if(x == 3 && y == 2){
                J1Win = true;
            }
            else if(y == 3 && x == 2){
                J1Win = false;
            }
            return(J1Win);
        }
        
    }
}
