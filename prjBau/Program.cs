using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBau
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Bau bau1 = new Bau(true, false, 100);
                Bau bau2 = new Bau(true, false, 50);
                Bau bau3 = new Bau(true, false, 25);

                Item item1 = new Item("Chave1", 1);
                Item item2 = new Item("Chave2", 1);
                Item item3 = new Item("Chave3", 1);
                Item item4 = new Item("Poção", 10);

                Player player = new Player("Carlos", 80, item4, 0);

                List<Item> itens = new List<Item>();
                itens.Add(item4);
                itens.Add(item1);
                itens.Add(item2);
                itens.Add(item3);

                List<Bau> baus = new List<Bau>();
                baus.Add(bau1);
                baus.Add(bau2);
                baus.Add(bau3);

                int i = 0;
                Random rand = new Random();
                int valorRandom = 0;


                while (i != 1)
                {
                    valorRandom = rand.Next(0, 3);

                    Console.WriteLine("---------------------------------------------------------------------");
                    Console.WriteLine("Quantidade de HP: " + player.GetVida() + "  || Quantidade de Moedas: " + player.GetMoedas());

                    Console.WriteLine("Existem 3 baús na sua frente, qual você quer abrir? (digite 1, 2, 3 ou nenhum)");

                    Console.WriteLine("Escolha um baú: ");
                    string NumeroBau = Console.ReadLine().ToUpper();

                    while (NumeroBau != "1" && NumeroBau != "2" && NumeroBau != "3" && NumeroBau != "NENHUM")
                    {
                        Console.WriteLine("digite '1', '2' ou '3'");
                        NumeroBau = Console.ReadLine();
                    }

                    if(NumeroBau == "NENHUM")
                    {
                        Console.WriteLine("Você não quis abrir nenhum baú");
                        return;
                    }

                    Console.WriteLine("Caminhando para o baú você encontrou um item, deseja pegá-lo? (digite 'S' ou 'N')");

                    if (valorRandom == 0)
                    {
                        Console.WriteLine("Item: Poção");
                    }
                    else
                    {
                        Console.WriteLine($"Item: Chave {valorRandom}");
                    }

                    string pegarItem = Console.ReadLine().ToUpper();

                    while (pegarItem != "S" && pegarItem != "N")
                    {
                        Console.WriteLine("digite 'S' ou 'N' para pegar o item");
                        pegarItem = Console.ReadLine().ToUpper();
                    }

                    if(pegarItem == "S")
                    {
                        player.item = itens[valorRandom];
                        Console.WriteLine("Item pego!");
                    }
                    else
                    {
                        Console.WriteLine("Você deixou o item");
                    }

                    Console.WriteLine("Você está perto do baú " + NumeroBau + ". Deseja abri-lo? (digite 'ABRIR' ou 'SAIR')");
                    string acao = Console.ReadLine().ToUpper();

                    while (acao != "ABRIR" && acao != "SAIR")
                    {
                        Console.WriteLine("digite 'ABRIR' ou 'SAIR'");
                        acao = Console.ReadLine().ToUpper();
                    }

                    if (acao == "ABRIR")
                    {                        
                        string fraseBaus = baus[int.Parse(NumeroBau) - 1].tentarAbrir().Substring(0,11);

                        if(fraseBaus == "Ta trancado")
                        {
                            Console.WriteLine("Este baú está trancado, deseja tentar abri-lo? (digite 'S' ou 'N')");
                            string confirmacao = Console.ReadLine().ToUpper();

                            while (confirmacao != "S" && confirmacao != "N")
                            {
                                Console.WriteLine("Responda com 'S' ou 'N'");
                                confirmacao = Console.ReadLine().ToUpper();
                            }

                            if (confirmacao == "S")
                            {
                                string fra = player.tentarAbrir(NumeroBau.ToString());

                                if(fra == "Abrindo")
                                {
                                    Console.WriteLine(baus[int.Parse(NumeroBau) - 1].abrirBau());
                                    player.SetMoedas((baus[int.Parse(NumeroBau) - 1]).ValorMoedas + player.GetMoedas());
                                }

                                if(fra == "Sem chave")
                                {
                                    Console.WriteLine("Você não possui a chave desse baú");
                                }
                            }
                        }
                        else
                        {
                            if(fraseBaus == "Abrindo baú")
                            {
                                player.SetMoedas(player.GetMoedas() + baus[int.Parse(NumeroBau) - 1].ValorMoedas);
                                Console.WriteLine(fraseBaus);
                            }
                            else
                            {
                                Console.WriteLine(baus[int.Parse(NumeroBau) - 1].tentarAbrir());
                            }
                        }                       
                    }
                    else
                    {
                        Console.WriteLine("Você voltou para a sala dos 3 baús");
                    }

                    if (player.GetVida() < 100)
                    {
                        if (player.item != null)
                        {
                            if (player.item.Nome == "Poção")
                            {
                                string checarVida = player.GetVida().ToString();

                                if (checarVida != "100")
                                {
                                    Console.WriteLine("Você possui " + player.GetVida() + " de hp e possui uma poção em seu inventário: ");
                                    Console.WriteLine("Você quer usar a poção? (digite 'S' ou 'N')");
                                    string resposta = Console.ReadLine().ToUpper();

                                    while (resposta != "S" && resposta != "N")
                                    {
                                        Console.WriteLine("digite 'S' ou 'N'");
                                        resposta = Console.ReadLine().ToUpper();
                                    }

                                    if (resposta == "S")
                                    {
                                        player.usaPocao();
                                        Console.WriteLine("Sua vida agora está em " + player.GetVida() + " hp");
                                    }
                                }

                            }
                        }

                    }

                }
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
