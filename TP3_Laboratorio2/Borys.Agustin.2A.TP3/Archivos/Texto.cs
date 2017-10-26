using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda los datos recibidos en un archivo de texto .txt indicado por el usuario
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo, false);
                escritor.WriteLine(datos);
                escritor.Close();
                return true;
            }
            catch(ArchivosException)
            {
                return false;
            }

        }
        /// <summary>
        /// Lee y guarda los datos de un archivo de texto indicado por el usuario en la variable recibida
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool leer(string archivo, out string datos)
        {
            try
            {
                StreamReader lector = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo);
                datos = lector.ReadToEnd();
                lector.Close();
                return true;
            }
            catch (ArchivosException)
            {
                datos = "";
                return false;
            }
        }
    }
}
