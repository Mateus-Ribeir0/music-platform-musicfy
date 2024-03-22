using Musicfy.Modelos;

namespace Musicfy.Menus;

internal class MenuMostrarMusicas : Menu
{
    List<String> MusicasConcat = new List<String>();
    //public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    //{
    //    base.Executar(bandasRegistradas);
    //    ExibirTituloDaOpcao("Exibir todas as musicas registradas");

    //    foreach (var kvp in bandasRegistradas)
    //    {
    //        string nomeDaBanda = kvp.Key;
    //        Banda banda = kvp.Value;
    //        Console.WriteLine(banda.Nome);
    //        Console.WriteLine();
    //        foreach (Album album in banda.Albuns)
    //        {
    //            banda.ConcatenarAlbuns(album);
    //        }
    //        banda.ExibirMusicas();
    //    }

    //    //ExibirMusicas();
    //    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    //    Console.ReadKey();
    //    Console.Clear();
    //}

    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Exibir todas as musicas registradas");

        List <Album> AlbumGeral= new List<Album>();
        List<Musica> MusicaGeral = new List<Musica>();

        foreach (var kvp in bandasRegistradas)
        {
            string nomeDaBanda = kvp.Key;
            Banda banda = kvp.Value;
            AlbumGeral.AddRange(banda.Albuns);
            MusicaGeral.AddRange(banda.Musicas);
        }
        MusicaGeral = MusicaGeral.OrderBy(x => x.Nome).ToList();
        foreach (Musica musica in MusicaGeral)
        {
            Console.WriteLine(musica.Nome);
        }

        //ExibirMusicas();
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
