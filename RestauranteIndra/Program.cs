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

            Pedido pedidoFinal = new();

            pedidoFinal.AdicionarPrato(pizza);
            pedidoFinal.AdicionarPrato(sanduiche);
            pedidoFinal.AdicionarPrato(copoDeCerveja);
            pedidoFinal.AdicionarPrato(tortaDeFrango);


            Console.WriteLine(pedidoFinal);

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}