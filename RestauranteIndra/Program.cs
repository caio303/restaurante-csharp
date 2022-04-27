using RestauranteIndra.Models;

namespace RestauranteIndra
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Console.WriteLine("Bem Vindo ao RESTAURANTE INDRA!\n");

            int opcaoAdicionar;
            int opcao;

            Pedido seuPedido = new();

        Navegacao:
            {
                do
                {
                    Console.WriteLine("\nEscolha alguma das opções abaixo");
                    Console.WriteLine(" 1 - Ver Cardápio");
                    Console.WriteLine(" 2 - Adicionar Prato ao Pedido");
                    Console.WriteLine(" 3 - Efetuar Pagamento");
                    Console.WriteLine(" 4 - Ver Pedido");
                    Console.WriteLine(" 5 - Zerar Pedido");
                    Console.WriteLine(" 6 - Sair...\n");
                    opcao = Convert.ToInt32(Console.ReadLine());

                } while (opcao < 1 || opcao > 6);
            }

            switch (opcao)
            {
                case 1:
                    {
                        Console.WriteLine("==---- Cardápio Indra --==\n");
                        Console.WriteLine(cardapio);
                        Console.WriteLine("==---- ---- ---- ---- --==");
                        goto CardapioEAdicionar;
                    }
                case 2:
                    {
                        goto CardapioEAdicionar;
                    }
                case 3:
                    {
                        Console.WriteLine("Seu pedido -->");
                        Console.WriteLine(seuPedido);
                        if(seuPedido.CalcularPrecoTotal() == 0)
                        {
                            Console.WriteLine("Adicione algum prato!");
                            goto Navegacao;
                        }
                        Console.WriteLine(String.Format("Valor Total do Pedido: {0}\n", seuPedido.CalcularPrecoTotal()));
                        goto EfetuarPagamento;
                    }
                case 4:
                    {
                        Console.WriteLine("Seu pedido -->");
                        Console.WriteLine(seuPedido);
                        Console.WriteLine(String.Format("Valor Total: {0}", seuPedido.CalcularPrecoTotal()));
                        goto Navegacao;
                    }
                case 5:
                    {
                        seuPedido.ZerarPedido();
                        Console.WriteLine("Pedido Zerado.");
                        goto Navegacao;
                    }
                case 6:
                    {
                        Console.WriteLine("\nObrigado pela preferência!");
                        Console.ReadLine();
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
                    opcaoAdicionar = Convert.ToInt32(Console.ReadLine());

                } while (opcaoAdicionar < 1 || opcaoAdicionar > 5);

                switch (opcaoAdicionar)
                {
                    case 1:
                        {
                            seuPedido.AdicionarPrato(pizza);
                            Console.WriteLine("\nFatia de Pizza Adicionada...");
                            goto Navegacao;
                        }
                    case 2:
                        {
                            seuPedido.AdicionarPrato(sanduiche);
                            Console.WriteLine("\nSanduíche Adicionado...");
                            goto Navegacao;
                        }
                    case 3:
                        {
                            seuPedido.AdicionarPrato(copoDeCerveja);
                            Console.WriteLine("\nCopo de Cerveja Adicionado...");
                            goto Navegacao;
                        }
                    case 4:
                        {
                            seuPedido.AdicionarPrato(tortaDeFrango);
                            Console.WriteLine("\nTorta de Frango Adicionada...");
                            goto Navegacao;
                        }
                    case 5:
                        {
                            goto Navegacao;
                        }
                }
            }

            EfetuarPagamento:
            {
                Console.WriteLine(String.Format("Pagamento de {0] reais efetuado!",seuPedido.CalcularPrecoTotal()));
                Console.WriteLine("\nObrigado pela preferência!");
                Console.ReadLine();
                return;
            }
        }
    }
}