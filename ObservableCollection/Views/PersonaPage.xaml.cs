using ObservableCollection.Model;
using ObservableCollection.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ObservableCollection.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonaPage : ContentPage
    {
        PersonaViewModel contexto = new PersonaViewModel();
        public PersonaPage()
        {
            InitializeComponent();
            LvPersonas.ItemSelected += LvPersonas_ItemSelected;
            BindingContext = contexto;
        }

        private void LvPersonas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem !=null)
            {
                PersonaModel modelo = (PersonaModel)e.SelectedItem;//el item selecciona se trata como modelo
                contexto.Nombre = modelo.Nombre;
                contexto.Apellido = modelo.Apellido;
                contexto.Edad = modelo.Edad;
                contexto.Id = modelo.Id;
            }
        }
    }
}