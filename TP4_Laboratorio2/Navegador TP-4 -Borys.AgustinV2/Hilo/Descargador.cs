using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    //Delegados
    public delegate void Downloading(int progress);
    public delegate void DownloadingComplete(string html); 
    public class Descargador
    {
        private string html;
        private Uri direccion;

        public event Downloading descargando;
        public event DownloadingComplete descargaCompleta;

        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }
        /// <summary>
        /// Inicio de Descarga a partir de una direccion Web
        /// </summary>
        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WebClientDownloadProgressChanged);
                cliente.DownloadStringCompleted += new DownloadStringCompletedEventHandler(WebClientDownloadCompleted);
                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Progreso de descarga. Lanza el evento de descarga en progreso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.descargando(e.ProgressPercentage);
        }
        /// <summary>
        /// Descarga Completa. Lanza el evento de Descarga completa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this.html = e.Result;
                descargaCompleta(e.Result);
            }
            catch(Exception exc)
            {
                this.descargaCompleta(exc.Message);
            }
        }
    }
}
