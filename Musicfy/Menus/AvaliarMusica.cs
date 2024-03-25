
using Musicfy.Modelos;

namespace Musicfy.Menus;
internal class AvaliarMusica:Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Avaliar uma musica");
        Console.Write("Digite o nome da banda que deseja avaliar a musica: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Banda banda = bandasRegistradas[nomeDaBanda];

            Console.Write("Agora digite o título do álbum que esta a musica desejada: ");
            string tituloAlbum = Console.ReadLine()!;
            if(banda.Albuns.Any(a=>a.Nome.Equals(tituloAlbum))) 
            {
                Album album = banda.Albuns.First(a => a.Nome.Equals(tituloAlbum));
                Console.Write($"Digite o nome da musica que deseja avaliar do album {tituloAlbum}: ");
                string tituloMusica = Console.ReadLine()!;
                if(banda.Musicas.Any(a => a.Nome.Equals(tituloMusica)))
                {
                    Musica musica = banda.Musicas.First(a => a.Nome.Equals(tituloMusica));
                    Console.WriteLine($"Digite a nota que deseja atribuir a musica '{tituloMusica}': ");
                    Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
                    musica.AdicionarNota(nota);
                    Console.WriteLine($"\nA nota {nota.Nota} foi registrada com sucesso para a musica {tituloMusica}");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"A musica {tituloMusica} ainda não foi registrada.");
                    Thread.Sleep(2000);
                    Console.Clear();
                }

            }
            else
            {
                Console.WriteLine($"O album de nome {tituloAlbum} não foi encontrado.");
                Thread.Sleep(2000);
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
