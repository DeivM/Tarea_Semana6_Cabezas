using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tarea_Semana6_Cabezas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Actualizar : ContentPage
    {
        public Actualizar(int codigo, string nombre, string apellido, int edad)
        {
            InitializeComponent();
            txtEdad.Text = Convert.ToString(edad);
            txtCodigo.Text = Convert.ToString(codigo);
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();

            parametros.Add("codigo", txtCodigo.Text);
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
            cliente.UploadValues("http://192.168.1.8/moviles/post.php?codigo="+ txtCodigo.Text + "&nombre="+ txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text, "PUT", parametros);
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Remove(txtCodigo.Text);
            parametros.Remove(txtNombre.Text);
            parametros.Remove(txtApellido.Text);
            parametros.Remove(txtEdad.Text);
            cliente.UploadValues("http://192.168.1.8/moviles/post.php?codigo=" + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text, "DELETE", parametros);

        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }
    }
}