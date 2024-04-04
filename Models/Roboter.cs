namespace Roboclash.Models;

public class Roboter
{
    public string Name { get; set; } = default!;
    public int Energie {  get; set; }
    public Waffe? Waffe { get; set; }
    public Schild? Schild { get; set; }
}
