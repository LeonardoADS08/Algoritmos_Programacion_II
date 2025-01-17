
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using System.Collections.Generic;

namespace RnPG_Program
{
    [Serializable]
    class Nombres
    {
        private string _nombre, _apellido;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value.Trim(); }
        }
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value.Trim(); }
        }

        public Nombres()
        {
            _nombre = _apellido = "";
        }

        public Nombres(string nombre, string apellido)
        {
            _nombre = nombre;
            _apellido = apellido;
        }
    }

    [Serializable]
    class Persona : Nombres
    {
        private Nombres _nombre;
        private int _edad;


        public int Edad
        {
            get { return _edad; }
            set { _edad = value; }
        }

        public Persona()
        {
            _nombre = new Nombres();
            _edad = 0;
        }

        public Persona(string nombre, string apellido, int edad)
        {
            _nombre = new Nombres(nombre, apellido);
            _edad = edad;
        }

        string DatosPersona()
        {
            return "Nombre: " + _nombre.Nombre + " " + _nombre.Apellido + ", " + _edad.ToString() + " años.";
        }

    }

    class SerializadorWrite<T>
    {
        string _name = "";
        Stream stream;
        IFormatter formatter;

        public SerializadorWrite(string Name)
        {
            _name = Name;
            stream = new FileStream(Name + ".data", FileMode.Append, FileAccess.Write, FileShare.None);
            formatter = new BinaryFormatter();
        }

        public void Write(T data)
        {
            formatter.Serialize(stream, data);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Persona test = new Persona("Leonardo", "Arteaga", 19);
            SerializadorWrite<Persona> personaDB = new SerializadorWrite<Persona>("PersonasDB");
            personaDB.Write(test);

        }
    }
}
