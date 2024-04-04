using Roboclash.Models;

namespace Roboclash.Views;

public partial class Arena : ContentPage
{
    public Roboter Roboter { get; set; } = default!;
    public Arena()
    {
        InitializeComponent();
    }

    private void InitialisiereSpieler()
    {
        Roboter = new Roboter()
        {
            Name = "Smasher",
            Energie = 100,
        };

    }
}