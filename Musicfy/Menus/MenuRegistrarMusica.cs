using Musicfy.Modelos;

namespace Musicfy.Menus;

internal class MenuRegistrarMusica : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro de musicas");
        Console.Write("Digite o nome da banda que deseja adicionar a musica: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Banda banda = bandasRegistradas[nomeDaBanda];

            Console.Write("Agora digite do álbum o qual esta musica pertence: ");
            string tituloAlbum = Console.ReadLine()!;
            if (banda.Albuns.Any(a => a.Nome.Equals(tituloAlbum)))
            {
                Album album = banda.Albuns.First(a => a.Nome.Equals(tituloAlbum));
                Console.Write($"Digite o nome da musica que deseja adicionar: ");
                string tituloMusica = Console.ReadLine()!;
                Banda bandas = bandasRegistradas[nomeDaBanda];
                Console.Write($"Digite quantos segundos a musica {tituloMusica} possuí: ");
                int tempo = int.Parse(Console.ReadLine()!);
                bandas.AdicionarMusica(new Musica(bandas, tituloMusica, tempo,tituloAlbum));
                Console.WriteLine($"A musica '{tituloMusica}' de {nomeDaBanda} foi registrado com sucesso!");
                Thread.Sleep(4000);
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"O album de nome {tituloAlbum} não foi encontrado.");
                Thread.Sleep(4000);
                Console.Clear();
            }
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
