using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea_1
{
    public partial class Form1 : Form
    {
        Procesos pro = new Procesos();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string texto = pro.ExtraerIniciales(textBox1.Text);
            int numero1 = Int32.Parse(textBox2.Text);
            int numero2 = Int32.Parse(textBox5.Text);
            textBox4.Text = ("" + texto);
            textBox7.Text = (""+pro.CalculoMinimo(numero1,numero2));
            textBox8.Text = ("" + pro.CalculoMaximo(numero1, numero2));
        }
    }
}
