using astrorocket;

namespace astrorocket.Views;

public partial class DetailPage : ContentPage
{
	public DetailPage(Mission selectedMission)
	{
		InitializeComponent();

        // Aquí puedes usar selectedMission como necesites
        // Por ejemplo, estableciendo el contexto de enlace (BindingContext) para mostrar los detalles
        BindingContext = selectedMission;
    }
}