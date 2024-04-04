namespace Roboclash.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Task.Run(async () =>
            {
                await Assets.LadeAusruestungAsync();
            });
        }
    }

}
