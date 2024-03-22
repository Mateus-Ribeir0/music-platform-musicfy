namespace Musicfy.Modelos;

internal class Banda:IAvaliavel
{
    private List<Album> albuns = new List<Album>();
    private List<Musica> musicas = new List<Musica>();
    private List<String> musicasConcat = new List<String>();
    private List<Avaliacao> notas = new List<Avaliacao>();

    public Banda(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; }
    public int DuracaoTotal => musicas.Sum(m => m.Duracao);
    public double Media
    {
        get
        {
            if (notas.Count == 0) return 0;
            else return notas.Average(a => a.Nota);
        }
    }
    public List<Album> Albuns => albuns; //uma lista publica referenciando uma privada
    public List<Musica> Musicas => musicas; //uma lista publica referenciando uma privada
    public List<String> MusicasConcat => musicasConcat; //uma lista publica referenciando uma privada

    public void AdicionarAlbum(Album album) 
    { 
        albuns.Add(album);
    }

    public void AdicionarMusica(Musica musica)
    {
        musicas.Add(musica);
    }

    public void AdicionarNota(Avaliacao nota)
    {
        notas.Add(nota);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia da banda {Nome}");
        foreach (Album album in albuns)
        {
            Console.WriteLine($"Álbum: {album.Nome} ({DuracaoTotal})");
        }
    }
    public void AdicionarAlbumManualmente(string nome)
    {
        Album novoAlbum = new Album(nome);

        albuns.Add(novoAlbum);
    }
    public void AdicionarMusicaManualmente(Banda artista,string nome,int duracao,String album)
    {
        Musica novaMusica = new Musica(artista,nome,duracao,album);

        musicas.Add(novaMusica);
    }
    public void ExibirMusicasDoAlbum(Album album)
    {
        
        Console.WriteLine($"Lista de músicas do álbum {album.Nome}:\n");
        var musicaUnica = musicas.Where(m => m.Album == album.Nome);
        foreach (var musica in musicaUnica)
        {
            Console.WriteLine($"- {musica.Nome}, duração:{musica.Duracao}");
        }
        Console.WriteLine($"\nPara ouvir este álbum inteiro você precisa de {musicaUnica.Sum(m => m.Duracao)}");
    }

}