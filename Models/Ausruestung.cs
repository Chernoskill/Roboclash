namespace Roboclash.Models;

public class Ausruestung
{
    public string Name { get; set; } = default!;
    public int Kosten { get; set; }
    public Ausruestungstyp Typ { get; set; }
    public int Kraft { get; set; }
}
