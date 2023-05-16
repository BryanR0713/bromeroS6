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

namespace bromeroS6
{
    public partial class MainPage : ContentPage
    {
        private string Url = "http://192.168.100.9/uisrael2023/post.php";
        private readonly HttpClient cliente= new HttpClient();
        private ObservableCollection<bromeroS6.Estudiante> post;
        public MainPage()
        {
            InitializeComponent();
            obtener();
        }
        public async void obtener() {
            var content = await cliente.GetStringAsync(Url);
            List<bromeroS6.Estudiante> posts = JsonConvert.DeserializeObject<List<bromeroS6.Estudiante>>(content);
            post = new ObservableCollection<Estudiante>(posts);
            lista.ItemsSource = post;

        }

        private void bntRegresar_Clicked(object sender, EventArgs e)
        {
            var mensaje = "Bienvenido";
            DependencyService.Get<Mensaje>().longalert(mensaje);
            Navigation.PushAsync(new Registro());
        
        }

        private async void lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var estudiante = (Estudiante)e.SelectedItem;
            var codigo = estudiante.codigo;
            var nombre = estudiante.nombre;
            var apellido = estudiante.apellido;
            var edad = estudiante.edad;
           Navigation.PushAsync(new Actualizar(codigo, nombre, apellido, edad));

        }
    }
}
