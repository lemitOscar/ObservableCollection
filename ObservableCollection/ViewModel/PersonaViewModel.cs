using System;
using System.Collections.Generic;
using System.Text;

namespace ObservableCollection.ViewModel
{
    using ObservableCollection.Model;
    using ObservableCollection.Servicio;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class PersonaViewModel : PersonaModel
    {
        public ObservableCollection<PersonaModel> Personas { get; set; }
        PersonaServicio servicio = new PersonaServicio();
        PersonaModel modelo;
        public PersonaViewModel()
        {
            Personas = servicio.Consultar();
            GuardarCommad = new Command(async()=>await Guardar(),()=>!IsBusy);
            //le digo que es asyncrono y va a espera a guardar siempre y cuando isbusy no este ocupado
            ModificarCommand = new Command(async () => await Modificar(), () => !IsBusy);
            EliminarCommand = new Command(async () => await Eliminar(), () => !IsBusy);
            LimpiarCommand = new Command(limpiar,()=>!IsBusy);
        }
        public Command GuardarCommad { get; set; }
        public Command ModificarCommand { get; set; }
        public Command EliminarCommand { get; set; }
        public Command LimpiarCommand { get; set; }

        private async Task Guardar()
        {
            IsBusy = true;
            Guid Idpersona = Guid.NewGuid();//cadena unica
            modelo = new PersonaModel()//creo un nuevo modelo
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Edad = Edad,
                Id = Idpersona.ToString()

            };
            servicio.Guardar(modelo);
            await Task.Delay(2000);
            IsBusy = false;
        }

        //
        private async Task Modificar()
        {
            IsBusy = true;

            modelo = new PersonaModel()//creo un nuevo modelo
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Edad = Edad,
                Id = Id

            };
            servicio.Modificar(modelo);
            await Task.Delay(2000);
            IsBusy = false;
        }
        //
        private async Task Eliminar()
        {
            IsBusy = true;
            servicio.Eliminar(Id);
            await Task.Delay(2000);
            IsBusy = false;
        }

        private void limpiar()
        {
            Nombre = "";
            Apellido = "";
            Edad = 0;
            Id = "";
        }
    }
}
