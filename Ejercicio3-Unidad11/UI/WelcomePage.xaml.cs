namespace Ejercicio3_Unidad11.UI;
using Microsoft.Maui.Controls;


public partial class WelcomePage : ContentPage
{
	public WelcomePage()
	{
		InitializeComponent();
	}


    private async void OnNavigateButtonClicked(object sender, EventArgs e)
    {
        // Navegar a la p�gina principal con pesta�as (TabsPage)
        await Navigation.PushAsync(new TabsPage());
    }
}