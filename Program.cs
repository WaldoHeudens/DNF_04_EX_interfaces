// Interfaces: definitie, meerdere interfaces implementeren en een
// default interface member.

// Dankzij de interface kunnen we verschillende types door elkaar behandelen.
IAfspeelbaar[] afspeellijst =
[
    new Nummer("Clair de Lune"),
    new Podcast("Aflevering 12"),
];

foreach (IAfspeelbaar item in afspeellijst)
{
    Console.WriteLine(item.KorteInfo());
    item.Speel();
}

// Enkel wat downloadbaar is, kan je downloaden. We testen dat met een type check.
foreach (IAfspeelbaar item in afspeellijst)
{
    if (item is IDownloadbaar downloadbaar)
    {
        downloadbaar.Download();
    }
}

// Een interface beschrijft wat een type moet kunnen, niet hoe.
interface IAfspeelbaar
{
    string Titel { get; }

    void Speel();

    // Een default interface member: een method met een standaardimplementatie
    // in de interface zelf. Types die de interface implementeren, hoeven ze
    // niet te herschrijven, maar mogen dat wel.
    string KorteInfo() => $"Afspeelbaar: {Titel}";
}

// Een tweede interface. Een klasse mag er meerdere tegelijk implementeren.
interface IDownloadbaar
{
    void Download();
}

// Nummer implementeert twee interfaces.
class Nummer : IAfspeelbaar, IDownloadbaar
{
    public Nummer(string titel) => Titel = titel;

    public string Titel { get; }

    public void Speel() => Console.WriteLine($"Nummer speelt: {Titel}");

    public void Download() => Console.WriteLine($"Nummer downloaden: {Titel}");
}

// Podcast implementeert enkel IAfspeelbaar en overschrijft de default member.
class Podcast : IAfspeelbaar
{
    public Podcast(string titel) => Titel = titel;

    public string Titel { get; }

    public void Speel() => Console.WriteLine($"Podcast speelt: {Titel}");

    public string KorteInfo() => $"Podcast-aflevering: {Titel}";
}
