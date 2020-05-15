using System;
using System.Collections.Generic;

using System.Text;

namespace ObservableCollection.Model
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class PersonaModel : INotifyPropertyChanged
    {
        #region Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string Propernombre = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Propernombre));
        }
        #endregion


        #region Properties
        //control de carga
        private bool isBusy=false;


        public bool IsBusy
        {
            get { return isBusy=false; }
            set { isBusy = value;
                OnPropertyChanged();
            }
        }




        private string id;
        public string Id
        {
            get { return id; }
            set { id = value;
                OnPropertyChanged();
            }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NombreCompleto));
            }
        }

        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NombreCompleto));
            }
        }
        private int edad;

        public int Edad
        {
            get { return edad; }
            set { edad = value;
                OnPropertyChanged();
            }
        }

        private string nombreCompleto;

        public string NombreCompleto
        {
            get { return $"{Nombre} {Apellido}"; }//concatenacion
            set { nombreCompleto = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Mensaje));
            }
        }

        private string mensaje;

        public string Mensaje
        {
            get { return $"tu nombre es {NombreCompleto}"; }
          
        }
        #endregion


    }
}
