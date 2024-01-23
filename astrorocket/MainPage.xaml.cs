using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;

namespace astrorocket
{
    public class Mission
    {
        public string Icon { get; set; }
        public string mission_name { get; set; }
        public string launch_year { get; set; }
    }

    public partial class MainPage : ContentPage
    {
        public List<Mission> Missions { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Missions = new List<Mission>();
            BindingContext = this; // Configura el contexto de datos como la página actual
            LoadLaunchData();
        }

        private async void LoadLaunchData()
        {
            string url = "https://api.spacexdata.com/v2/launches";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into Mission objects
                    Missions = JsonConvert.DeserializeObject<List<Mission>>(responseBody);

                    // Notify the UI that the data has changed
                    OnPropertyChanged(nameof(Missions));
                }
                catch (Exception ex)
                {
                    // Handle any errors here
                    // ...
                }
            }
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Mission selectedMission)
            {
                // Navega a la página de detalles con los datos de la misión seleccionada
                await Navigation.PushAsync(new Views.DetailPage(selectedMission));
            }
        }

        // Clase Mission que representa una misión espacial

    }
}
