using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bromeroS6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
       
        
        public Registro()
        {
            InitializeComponent();
        }

      

        private void bntRegresar_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new MainPage());
        }

        private void bntInsertar_Clicked(object sender, EventArgs e)
        {
            try { 
            WebClient cliente = new WebClient();
            var parametros=new System.Collections.Specialized.NameValueCollection();
            parametros.Add("codigo", txtCodigo.Text);
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
            cliente.UploadValues("http://192.168.100.9/uisrael2023/post.php", "POST", parametros);
            DisplayAlert("Alerta", "Dato Ingresado", "Salir");
            }
            catch  (Exception ex)
            {

                DisplayAlert("", ex.Message, "cerrar");
            }

        }
    }
}