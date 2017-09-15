using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraApp
{
    public partial class Form1 : Form
    {
        private Numero _numero1;
        private Numero _numero2;
        private Calculadora _operar;
        

        public Form1()
        {
            InitializeComponent();
            lblResulado.Text = "0";
            cmbOperacion.Items.Insert(0, "+");
            cmbOperacion.Items.Insert(1, "-");
            cmbOperacion.Items.Insert(2, "*");
            cmbOperacion.Items.Insert(3, "/");
            cmbOperacion.SelectedItem = "+";
            cmbOperacion.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            lblResulado.Text = "0";
        }


        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string operador;
            double resultado;
            _numero1 = new Numero(txtNumero1.Text.ToString());
            _numero2 = new Numero(txtNumero2.Text.ToString());
            _operar = new Calculadora();
            operador = _operar.ValidarOperador(cmbOperacion.Text);
            resultado = _operar.Operar(_numero1, _numero2, operador);
            lblResulado.Text = resultado.ToString();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
