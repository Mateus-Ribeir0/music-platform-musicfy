using Musicfy.Menus;
using Musicfy.Modelos;

Banda LinkinPark = new Banda("Linkin Park");
LinkinPark.AdicionarNota(new Avaliacao(10));
LinkinPark.AdicionarNota(new Avaliacao(8));
LinkinPark.AdicionarNota(new Avaliacao(6));
LinkinPark.AdicionarAlbumManualmente("Meteora");
LinkinPark.AdicionarAlbumManualmente("Aurora");
LinkinPark.AdicionarMusicaManualmente(LinkinPark,"In the end",152,"Meteora");
LinkinPark.AdicionarMusicaManualmente(LinkinPark, "Numb", 842,"Aurora");
Banda GreenDay = new("Green Day");
GreenDay.AdicionarNota(new Avaliacao(10));
GreenDay.AdicionarNota(new Avaliacao(10));
GreenDay.AdicionarNota(new Avaliacao(9));
GreenDay.AdicionarAlbumManualmente("American Idiot");
GreenDay.AdicionarMusicaManualmente(GreenDay, "Basket case", 148, "American Idiot");
Banda Oasis = new("Oasis");
Oasis.AdicionarNota(new Avaliacao(10));
Oasis.AdicionarNota(new Avaliacao(10));
Oasis.AdicionarNota(new Avaliacao(9));
Oasis.AdicionarAlbumManualmente("Best of the best");

Dictionary<string, Banda> bandasRegistradas = new();
bandasRegistradas.Add(LinkinPark.Nome, LinkinPark);
bandasRegistradas.Add(GreenDay.Nome, GreenDay);
bandasRegistradas.Add(Oasis.Nome, Oasis);

Dictionary<int, Menu> opcoes = new();
opcoes.Add(1, new MenuRegistrarMusica());
opcoes.Add(2, new MenuRegistrarAlbum());
opcoes.Add(3, new MenuRegistrarBanda());
opcoes.Add(4, new AvaliarMusica());
opcoes.Add(5, new AvaliarAlbum());
opcoes.Add(6, new MenuAvaliarBanda());
opcoes.Add(7, new MenuMostrarBandas());
opcoes.Add(8, new MenuMostrarMusicas());
opcoes.Add(9, new MenuExibirDetalhes());
opcoes.Add(-1, new MenuSair());

void ExibirLogo()
{
    Console.WriteLine(@"
███╗░░░███╗██╗░░░██╗░██████╗██╗░█████╗░███████╗██╗░░░██╗
████╗░████║██║░░░██║██╔════╝██║██╔══██╗██╔════╝╚██╗░██╔╝
██╔████╔██║██║░░░██║╚█████╗░██║██║░░╚═╝█████╗░░░╚████╔╝░
██║╚██╔╝██║██║░░░██║░╚═══██╗██║██║░░██╗██╔══╝░░░░╚██╔╝░░
██║░╚═╝░██║╚██████╔╝██████╔╝██║╚█████╔╝██║░░░░░░░░██║░░░
╚═╝░░░░░╚═╝░╚═════╝░╚═════╝░╚═╝░╚════╝░╚═╝░░░░░░░░╚═╝░░░
");
    Console.WriteLine("Seja bem-vindo ao Musicfy");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma musica");
    Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
    Console.WriteLine("Digite 3 para registrar uma banda");
    Console.WriteLine("Digite 4 para avaliar uma musica");
    Console.WriteLine("Digite 5 para avaliar um album");
    Console.WriteLine("Digite 6 para avaliar uma banda");
    Console.WriteLine("Digite 7 para mostrar todas as bandas");
    Console.WriteLine("Digite 8 para mostrar todas as musicas registradas");
    Console.WriteLine("Digite 9 para exibir os detalhes de uma banda");



    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
    {
        Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];
        menuASerExibido.Executar(bandasRegistradas);// se ´pr exemplo for do avaliar o executar vai ser sobrescrito e vai executar a function
        if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();// para voltar de um menu para o menu principal ele mostre as opções
    } 
    else
    {
        Console.WriteLine("Opção inválida");
    }
}

ExibirOpcoesDoMenu();
