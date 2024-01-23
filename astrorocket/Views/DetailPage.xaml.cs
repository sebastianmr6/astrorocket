using astrorocket;

namespace astrorocket.Views;

public partial class DetailPage : ContentPage
{
	public DetailPage(Mission selectedMission)
	{
		InitializeComponent();

        // Aqu� puedes usar selectedMission como necesites
        // Por ejemplo, estableciendo el contexto de enlace (BindingContext) para mostrar los detalles
        BindingContext = selectedMission;
    }
}