using Roboclash.Models;
using System.Collections.ObjectModel;

namespace Roboclash.Views;

public partial class Assets : ContentPage
{
    public static ObservableCollection<Waffe> WaffenStatic { get; set; } = new ObservableCollection<Waffe>();
    public ObservableCollection<Waffe> Waffen => WaffenStatic;
    public static ObservableCollection<Schild> SchildeStatic { get; set; } = new ObservableCollection<Schild>();
    public ObservableCollection<Schild> Schilde => SchildeStatic;
    private const string AusruestungDateiName = "Ausruestung.txt";
    public Assets()
    {
        InitializeComponent();

        BindingContext = this;

        WaffenListView.SetBinding(ListView.ItemsSourceProperty, "Waffen");
        SchildeListView.SetBinding(ListView.ItemsSourceProperty, "Schilde");
    }

    public static async Task LadeAusruestungAsync()
    {
        using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(AusruestungDateiName);
        using StreamReader reader = new StreamReader(fileStream);
        string ausruestungString = await reader.ReadToEndAsync();

        WaffenStatic.Clear();
        SchildeStatic.Clear();

        string[] lines = ausruestungString.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine($"Zeilen in {AusruestungDateiName}: {lines.Length}");

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].Trim();

            Console.WriteLine($"Zeile {i + 1}: \"{line}\"");

            if (line.StartsWith("//"))
            {
                continue;
            }
            string[] parts = line.Split(';');

            //Name
            string name = parts[0];

            //Kosten
            int kosten = int.Parse(parts[1]);

            //Typ
            Ausruestungstyp typ = (Ausruestungstyp)int.Parse(parts[2]);

            //Elementtyp
            Elementtyp elementtyp = (Elementtyp)int.Parse(parts[3]);

            //Schaden/Resistenz
            int kraft = int.Parse(parts[4]);

            //Schaden/Resistenz
            switch (typ)
            {
                case Ausruestungstyp.Waffe:
                    {
                        WaffenStatic.Add(new Waffe() { Name = name, Kosten = kosten, Typ = typ, Elementtyp = elementtyp, Kraft = kraft });
                        break;
                    }
                case Ausruestungstyp.Schild:
                    {
                        SchildeStatic.Add(new Schild() { Name = name, Kosten = kosten, Typ = typ, Elementtyp = elementtyp, Kraft = kraft });
                        break;
                    }
            }
            Console.WriteLine($"{i}: Ausrüstung geladen: {name} (Typ {typ})");
        }
    }
}