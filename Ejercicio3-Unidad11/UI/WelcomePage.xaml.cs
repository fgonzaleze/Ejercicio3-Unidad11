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
        // Navegar a la página principal con pestañas (TabsPage)
        await Navigation.PushAsync(new TabsPage());
    }
}