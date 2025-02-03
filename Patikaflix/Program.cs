class Program
{
    static void Main()
    {
        List<Dizi> diziler = new List<Dizi>();
        string devam;

        do
        {
            Console.Write("Dizi Adı: ");
            string ad = Console.ReadLine();

            Console.Write("Dizi Türü: ");
            string tur = Console.ReadLine();

            Console.Write("Yönetmen: ");
            string yonetmen = Console.ReadLine();

            Console.Write("Bölüm Sayısı: ");
            int bolumSayisi = int.Parse(Console.ReadLine());

            Console.Write("IMDB Puanı: ");
            double imdbPuani = double.Parse(Console.ReadLine());

            diziler.Add(new Dizi(ad, tur, yonetmen, bolumSayisi, imdbPuani));

            Console.Write("Yeni bir dizi eklemek ister misiniz? (E/H): ");
            devam = Console.ReadLine().ToUpper();
        } while (devam == "E");

        List<KisaltılmışDizi> komediDizileri = diziler
            .Where(d => d.Tur.ToLower() == "komedi")
            .Select(d => new KisaltılmışDizi(d.Ad, d.Tur, d.Yonetmen))
            .OrderBy(d => d.Ad)
            .ThenBy(d => d.Yonetmen)
            .ToList();

        Console.WriteLine("\nKomedi Dizileri Listesi:");
        foreach (var dizi in komediDizileri)
        {
            Console.WriteLine($"Ad: {dizi.Ad}, Tür: {dizi.Tur}, Yönetmen: {dizi.Yonetmen}");
        }
    }
}

class Dizi
{
    public string Ad { get; set; }
    public string Tur { get; set; }
    public string Yonetmen { get; set; }
    public int BolumSayisi { get; set; }
    public double ImdbPuani { get; set; }

    public Dizi(string ad, string tur, string yonetmen, int bolumSayisi, double imdbPuani)
    {
        Ad = ad;
        Tur = tur;
        Yonetmen = yonetmen;
        BolumSayisi = bolumSayisi;
        ImdbPuani = imdbPuani;
    }
}

class KisaltılmışDizi
{
    public string Ad { get; set; }
    public string Tur { get; set; }
    public string Yonetmen { get; set; }

    public KisaltılmışDizi(string ad, string tur, string yonetmen)
    {
        Ad = ad;
        Tur = tur;
        Yonetmen = yonetmen;
    }
}
