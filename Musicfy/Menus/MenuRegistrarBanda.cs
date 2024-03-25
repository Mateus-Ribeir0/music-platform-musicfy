using Musicfy.Modelos;

namespace Musicfy.Menus;

internal class MenuRegistrarBanda : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda banda = new Banda(nomeDaBanda);
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.WriteLine($"A banda {nomeDaBanda} já foi registrada anteriormente. Você será direcionado ao menu principal.");
        }
        else
        {
         bandasRegistradas.Add(nomeDaBanda, banda);
         Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        }
        Thread.Sleep(4000);
        Console.Clear();
    }
}
