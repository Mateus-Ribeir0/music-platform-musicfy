using Musicfy.Modelos;

namespace Musicfy.Menus;

internal class MenuMostrarMusicas : Menu
{

    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Exibir todas as musicas registradas");

        List<Musica> MusicaGeral = new List<Musica>();

        foreach (var kvp in bandasRegistradas)
        {
            string nomeDaBanda = kvp.Key;
            Banda banda = kvp.Value;
            MusicaGeral.AddRange(banda.Musicas);
        }
        MusicaGeral = MusicaGeral.OrderBy(x => x.Nome).ToList();
        foreach (Musica musica in MusicaGeral)
        {
            Console.WriteLine(musica.Nome);
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
