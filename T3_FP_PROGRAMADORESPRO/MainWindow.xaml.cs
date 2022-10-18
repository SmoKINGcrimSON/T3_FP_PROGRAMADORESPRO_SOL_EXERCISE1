using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using T3_FP_PROGRAMADORESPRO.Clases;

namespace T3_FP_PROGRAMADORESPRO
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            p_combobox_mascotaDueno.ItemsSource = P_dueno.P_duenosLista;
            p_button_duenoRegistro.Click += RegistrarDueno;
            p_button_mascotaRegistro.Click += RegistrarMascota;
            p_button_mascotaBucar.Click += MascotasCoincidentes;
        }
        //
        private void RegistrarDueno(object sender, EventArgs e)
        {
            if(p_textbox_duenoNombre.Text == new string(' ', p_textbox_duenoNombre.Text.Length) || p_textbox_duenoDireccion.Text == new string(' ', p_textbox_duenoDireccion.Text.Length)
                || p_textbox_duenoTelefono.Text == new string(' ', p_textbox_duenoTelefono.Text.Length))
            {
                p_textblock_duenoAgregado.Text = "No se pudo añadir al dueño.";
                return;
            }
            string nombre = null;
            string direccion = null;
            string telefono = null;
            nombre = p_textbox_duenoNombre.Text;
            direccion = p_textbox_duenoDireccion.Text;
            telefono = p_textbox_duenoTelefono.Text;
            P_dueno tempDueno = new P_dueno(nombre, direccion, telefono);
            P_dueno.AgregarDueno(tempDueno);
            p_textblock_duenoAgregado.Text = "¡Añadido Exitosamente!";
        }
        //
        private void RegistrarMascota(object sender, EventArgs e)
        {
            if(p_textbox_mascotaNombre.Text == new string(' ', p_textbox_mascotaNombre.Text.Length) || p_textbox_mascotaRaza.Text == new string(' ', p_textbox_mascotaRaza.Text.Length))
            {
                p_textblock_mascotaAgregada.Text = "No se pudo añadir a la mascota";
                return;
            }
            string nombre = null;
            string raza = null;
            P_dueno dueno = null;
            byte edad = 0;
            try
            {
                nombre = p_textbox_mascotaNombre.Text;
                raza = p_textbox_mascotaRaza.Text;
                dueno = (P_dueno) p_combobox_mascotaDueno.SelectedItem;
                edad = byte.Parse(p_textbox_mascotaEdad.Text);
            }
            catch(Exception ex)
            {
                p_textblock_mascotaAgregada.Text = ex.Message;
            }
            P_mascota tempMascota = new P_mascota(nombre, edad, raza, dueno);
            P_mascota.AgregarMascota(tempMascota);
            p_textblock_mascotaAgregada.Text = "¡Mascota agregada exitosamente!";
        }
        //
        private void MascotasCoincidentes(object sender, EventArgs e)
        {
            if(p_txtbox_mascotaBuscarNombre.Text == new string(' ', p_txtbox_mascotaBuscarNombre.Text.Length))
            {
                p_txtblock_mensajeMascotaEncontrada.Text = "Cadena vacía, introduce un nombre para iniciar la búsqueda.";
                return;
            }
            int mascotasEncontradas = BuscarMascota(P_mascota.P_mascotasLista, p_txtbox_mascotaBuscarNombre.Text);
            if (mascotasEncontradas == 0)
            {
                p_txtblock_mensajeMascotaEncontrada.Text = "Ningún nombre de ninguna mascota coincide con el texto de la búsqueda.";
                p_img_mascotaBusqueda.Source = new BitmapImage(new Uri("Images/PetShopLogoTwo.png", UriKind.Relative));
            }
            else
            {
                p_txtblock_mensajeMascotaEncontrada.Text = $"{mascotasEncontradas} coincidencias con el nombre buscado, hay mascotas con este nombre registradas.";
                p_img_mascotaBusqueda.Source = new BitmapImage(new Uri("Images/PetShopLogo.png", UriKind.Relative));
            }
        }
        //
        private int BuscarMascota(ObservableCollection<P_mascota> listMascotas, string nombreMascota, int indice = 0, int coincidenciaMascotas = 0)
        {
            if (indice >= listMascotas.Count)
            {
                return coincidenciaMascotas;
            }
            if (string.Equals(listMascotas[indice].P_nombre, nombreMascota, StringComparison.InvariantCultureIgnoreCase)){
                coincidenciaMascotas++;
            }
            return BuscarMascota(listMascotas, nombreMascota, indice + 1, coincidenciaMascotas);
        }
    }
}
