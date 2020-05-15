using System;

using System.Text;

namespace ObservableCollection.Servicio
{
    using ObservableCollection.Model;
    using System.Collections.ObjectModel;
    using System.Linq;
    //si estoy consumiendo un servicio rest aqui es donde se hace todo eso
    //incluye tambien las bases de datos o cualquier conexion de terceros
    class PersonaServicio
    {
        public ObservableCollection<PersonaModel> persona { get; set; }//esto es un objeto

        //para crear un constructor solo poner ctor

        public PersonaServicio()//para verificar que exite y no se cree de nuevo
        {
            if (persona == null)
            {
                persona = new ObservableCollection<PersonaModel>();//se inicializa
            }
        }
        //regresar la lista
        public ObservableCollection<PersonaModel> Consultar()
        {
            return persona;
        }

        public void Guardar(PersonaModel modelo)//recibo un modelo y luego lo añado
        {
            persona.Add(modelo);
        }

        public void Modificar(PersonaModel modelo)
        {
            for (int i = 0; i < persona.Count; i++)
            {
                if (persona[i].Id==modelo.Id)
                {
                    persona[i] = modelo;
                }//asigno id para que sea unico un modelo
            }
        }

        public void Eliminar(string idpe)
        {
            //first regresa el primer elemento de una secuencia
            PersonaModel modelo = persona.FirstOrDefault(p => p.Id == idpe);
            persona.Remove(modelo);
        }
    }
}
