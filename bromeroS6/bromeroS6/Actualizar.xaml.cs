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
    public partial class Actualizar : ContentPage
    {
        public Actualizar(int codigo, string nombre, string apellido, int edad)
        {
            InitializeComponent();
            string codigoE= codigo.ToString();
            string edadE= edad.ToString();
            txtCodigo.Text = codigoE;
            txtNombre.Text = nombre;    
            txtApellido.Text = apellido;    
            txtEdad.Text = edadE;    
        }

        private void bntInsertar_Clicked(object sender, EventArgs e)
        {
            try { 
            WebClient cliente = new WebClient();
            var parametros=new System.Collections.Specialized.NameValueCollection();
               
                cliente.UploadValues("http://192.168.100.9/uisrael2023/post.php?codigo="+txtCodigo.Text+"&nombre=" + txtNombre.Text + "&apellido="  +txtApellido.Text + "&edad=" +txtEdad.Text, "PUT", parametros);
            DisplayAlert("Alerta", "Dato Actualizado", "Salir");
                Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex) {
                DisplayAlert("Alerta", ex.Message, "Salir");

              }
        }

        private void bntEliminar_Clicked(object sender, EventArgs e)
        {

            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            byte[] del = cliente.UploadValues("http://192.168.100.9/uisrael2023/post.php?codigo=" + txtCodigo.Text , "DELETE", parametros);
            var eliminar=System.Text.ASCIIEncoding.UTF8.GetString(del);
            DisplayAlert("Alerta", "Dato Eliminado", "Salir");
            Navigation.PushAsync(new MainPage());
        }

        private void bntRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}