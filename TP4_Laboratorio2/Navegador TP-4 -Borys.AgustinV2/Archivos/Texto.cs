using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string nombreArchivo;
        public Texto(string archivo)
        {
            this.nombreArchivo = archivo;
        }
        /// <summary>
        /// Guarda los datos pasados por parametro en un archivo.
        /// Duevuelve true si es exitoso, false si no.
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool guardar(string datos)
        {
            try
            {
                StreamWriter writer = new StreamWriter(this.nombreArchivo, true);
                writer.WriteLine(datos);
                writer.Close();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Lee los datos de un archivo y los devuelve a una lista de string pasada por parametro
        /// Devuelve true si es exitoso, false si no.
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool leer(out List<string> datos)
        {
            datos = new List<string>();
            try
            {
                StreamReader reader = new StreamReader(this.nombreArchivo);
                while (!reader.EndOfStream)
                {
                    datos.Add(reader.ReadLine());
                }
                reader.Close();
                return true;
            }
            catch(Exception)
            {
                datos = default(List<string>);
                return false;
            }
        }
    }
}
