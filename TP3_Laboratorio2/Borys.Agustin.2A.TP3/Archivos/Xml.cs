using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda los datos recibidos en un archivo .xml
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                TextWriter escritorXml = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo);
                xml.Serialize(escritorXml, datos);
                escritorXml.Close();
                return true;
            }
            catch(ArchivosException)
            {
                return false;
            }
        }
        /// <summary>
        /// Lee los datos de un archivo .xml y se los pasa al parametro indicado
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                TextReader lectorXml = new StringReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo);
                datos = (T)xml.Deserialize(lectorXml);
                lectorXml.Close();
                return true;
            }
            catch(ArchivosException)
            {
                datos = default(T);
                return false;
            }
        }
    }
}
