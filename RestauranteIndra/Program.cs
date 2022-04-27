using RestauranteIndra.Models;

namespace RestauranteIndra
{
    class Program
    {
        static void Main(string[] args)
        {
            //string logoIndra = "  ██╗███╗   ██╗██████╗ ██████╗  █████╗ \n  ██║████╗  ██║██╔══██╗██╔══██╗██╔══██╗\n  ██║██╔██╗ ██║██║  ██║██████╔╝███████║\n  ██║██║╚██╗██║██║  ██║██╔══██╗██╔══██║\n  ██║██║ ╚████║██████╔╝██║  ██║██║  ██║\n  ╚═╝╚═╝  ╚═══╝╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝\n\n";
            string logoIndra = "███╗   ███╗    ███████╗    ███╗   ██╗    ██╗   ██╗\n████╗ ████║    ██╔════╝    ████╗  ██║    ██║   ██║\n██╔████╔██║    █████╗      ██╔██╗ ██║    ██║   ██║\n██║╚██╔╝██║    ██╔══╝      ██║╚██╗██║    ██║   ██║\n██║ ╚═╝ ██║    ███████╗    ██║ ╚████║    ╚██████╔╝\n╚═╝     ╚═╝    ╚══════╝    ╚═╝  ╚═══╝     ╚═════╝ \n";
            string pizzaFoto = "   //'---.._\n   ||  (_) _'-._\n   ||   _ (_)   '-.\n   ||  (_)   __..-'\n    \\__..--''";
            string cervejaFoto = "     _.._..,_,_\n    (          )\n     ]~,'-.-~~[\n   .=])' (;  ([\n   | ]:: '    [\n   '=]): .)  ([\n     |:: '    |\n      ~~----~~";
            string tortaFrangoFoto = "            (\n             )\n        __..---..__\n    ,-='  /  |  \\  `=-.\n   :--..___________..--;\n    \\.,_____________,./ ";
            string sanduicheFoto = "        .----------''''''-.\n       /  .      '     .   \\ \n      /        '    .      /|\n     /      .             \\ /\n    / ' .       .     .  || |\n   /.___________    '    / //\n   |._          '------'| /|\n   '.............______.-' /\n   | -.                  |/\n   `\"\"\"\"\"\"\"\"\"\"\"\"\"-.....-'\n";

            Ingrediente massaDeTrigo = new ("Massa de farinha de trigo", 180);
            Ingrediente alcool = new ("Álcool", true, 15);
            Ingrediente frangoDesfiado = new ("Frango Desfiado", 200);
            Ingrediente ovo = new ("Ovo frito", 40);
            Ingrediente calabresa = new ("Calabresa", 16);
            Ingrediente queijo = new ("Queijo", 40);
            Ingrediente agua = new ("Água",true,300);

            Prato pizza = new ("Fatia de Pizza", pizzaFoto);
            pizza.AdicionarIngrediente(massaDeTrigo);
            pizza.AdicionarIngrediente(calabresa);
            pizza.AdicionarIngrediente(queijo);

            Prato copoDeCerveja = new ("Copo de cerveja", cervejaFoto);
            copoDeCerveja.AdicionarIngrediente(alcool);
            copoDeCerveja.AdicionarIngrediente(agua);

            Prato tortaDeFrango = new ("Torta de Frango",tortaFrangoFoto);
            tortaDeFrango.AdicionarIngrediente(massaDeTrigo);
            tortaDeFrango.AdicionarIngrediente(frangoDesfiado);
            tortaDeFrango.AdicionarIngrediente(ovo);

            Prato sanduiche = new("Sanduiche", sanduicheFoto);
            sanduiche.AdicionarIngrediente(massaDeTrigo);
            sanduiche.AdicionarIngrediente(queijo);
            sanduiche.AdicionarIngrediente(ovo);

            Pedido cardapio = new();
            cardapio.AdicionarPrato(pizza);
            cardapio.AdicionarPrato(sanduiche);
            cardapio.AdicionarPrato(copoDeCerveja);
            cardapio.AdicionarPrato(tortaDeFrango);


            int opcaoAdicionar;
            int opcao;

            Pedido seuPedido = new();

        Navegacao:
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("\n" + logoIndra);
                    Console.WriteLine("Bem Vindo ao RESTAURANTE INDRA!");
                    Console.WriteLine("\nEscolha alguma das opções abaixo");
                    Console.WriteLine(" 1 - Ver Cardápio");
                    Console.WriteLine(" 2 - Adicionar Prato ao Pedido");
                    Console.WriteLine(" 3 - Efetuar Pagamento");
                    Console.WriteLine(" 4 - Ver Pedido");
                    Console.WriteLine(" 5 - Zerar Pedido");
                    Console.WriteLine(" 6 - Sair...\n");
                    
                    try
                    {

                        opcao = Convert.ToInt32(Console.ReadLine());
                    }
                    catch(Exception ex)
                    {
                        opcao = 0;
                    }

                } while (opcao < 1 || opcao > 6);
            }

            switch (opcao)
            {
                case 1:
                    {
                        Console.Clear();
                        Console.WriteLine("\n==---- Cardápio Indra --==\n");
                        Console.WriteLine(cardapio);
                        Console.WriteLine("==---- ---- ---- ---- --==");
                        goto CardapioEAdicionar;
                    }
                case 2:
                    {
                        Console.Clear();
                        goto CardapioEAdicionar;
                    }
                case 3:
                    {                        
                        if(seuPedido.CalcularPrecoTotal() == 0)
                        {
                            Console.WriteLine("Seu pedido está vazio, adicione algum prato!\n");
                            Thread.Sleep(1000);
                            goto Navegacao;
                        }

                        Console.Clear();
                        Console.WriteLine("Seu pedido -->");
                        Console.WriteLine(seuPedido);
                        Console.WriteLine(String.Format("Valor Total do Pedido: {0}\n", seuPedido.CalcularPrecoTotal()));
                        goto EfetuarPagamento;
                    }
                case 4:
                    {
                        if (seuPedido.CalcularPrecoTotal() == 0)
                        {
                            Console.WriteLine("Seu pedido está vazio, adicione algum prato!\n");
                            Thread.Sleep(1000);
                            goto Navegacao;
                        }

                        Console.Clear();
                        Console.WriteLine("Seu pedido -->");
                        Console.WriteLine(seuPedido);
                        Console.WriteLine(String.Format("Valor Total do Pedido: {0}\n", seuPedido.CalcularPrecoTotal()));
                        Console.WriteLine("Pressione Enter para voltar ao menu...");
                        Console.ReadLine();
                        goto Navegacao;
                    }
                case 5:
                    {
                        if (seuPedido.CalcularPrecoTotal() == 0)
                        {
                            Console.WriteLine("Seu pedido está vazio, adicione algum prato!\n");
                            Thread.Sleep(1000);
                            goto Navegacao;
                        }

                        Console.Clear();
                        seuPedido.ZerarPedido();
                        Console.WriteLine("Pedido Zerado.");
                        goto Navegacao;
                    }
                case 6:
                    {
                        Console.WriteLine("\nObrigado pela preferência!");
                        Thread.Sleep(1000);
                        return;
                    }
            }

            CardapioEAdicionar:
            {
                do
                {
                    Console.WriteLine("\nQual prato você deseja?");
                    Console.WriteLine(" 1 - Fatia de Pizza");
                    Console.WriteLine(" 2 - Sanduiche");
                    Console.WriteLine(" 3 - Copo de Cerveja");
                    Console.WriteLine(" 4 - Torta de Frango");
                    Console.WriteLine(" 5 - Voltar ao menu.\n");

                    try
                    {
                        opcaoAdicionar = Convert.ToInt32(Console.ReadLine());
                    }catch (Exception ex)
                    {
                        opcaoAdicionar = 0;
                    }

                    

                } while (opcaoAdicionar < 1 || opcaoAdicionar > 5);

                switch (opcaoAdicionar)
                {
                    case 1:
                        {
                            seuPedido.AdicionarPrato(pizza);
                            Console.WriteLine("\nFatia de Pizza Adicionada...");
                            Thread.Sleep(1000);
                            goto Navegacao;
                        }
                    case 2:
                        {
                            seuPedido.AdicionarPrato(sanduiche);
                            Console.WriteLine("\nSanduíche Adicionado...");
                            Thread.Sleep(1000);
                            goto Navegacao;
                        }
                    case 3:
                        {
                            seuPedido.AdicionarPrato(copoDeCerveja);
                            Console.WriteLine("\nCopo de Cerveja Adicionado...");
                            Thread.Sleep(1000);
                            goto Navegacao;
                        }
                    case 4:
                        {
                            seuPedido.AdicionarPrato(tortaDeFrango);
                            Console.WriteLine("\nTorta de Frango Adicionada...");
                            Thread.Sleep(1000);
                            goto Navegacao;
                        }
                    case 5:
                        {
                            Console.Clear();
                            goto Navegacao;
                        }
                }
            }

            EfetuarPagamento:
            {
                Console.WriteLine("Pagamento efetuado!");
                Console.WriteLine("\nObrigado pela preferência!");
                Console.ReadLine();
                return;
            }
        }
    }
}