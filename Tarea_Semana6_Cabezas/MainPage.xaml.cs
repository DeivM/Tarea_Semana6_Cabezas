using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tarea_Semana6_Cabezas
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.1.8/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Tarea_Semana6_Cabezas.Ws.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
        }


        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<Tarea_Semana6_Cabezas.Ws.Datos> posts = JsonConvert.DeserializeObject<List<Tarea_Semana6_Cabezas.Ws.Datos>>(content);
            _post = new ObservableCollection<Tarea_Semana6_Cabezas.Ws.Datos>(posts);

            MListView.ItemsSource = _post;
        }

        private async void btnInsertar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Post());
        }

        private async void MListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = (ListView)sender;
            Tarea_Semana6_Cabezas.Ws.Datos cl = (Tarea_Semana6_Cabezas.Ws.Datos)lv.SelectedItem;
            await Navigation.PushModalAsync(new Actualizar(cl.codigo, cl.nombre, cl.apellido, cl.edad));
        }
    }
}
