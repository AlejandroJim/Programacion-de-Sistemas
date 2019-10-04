using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_Semana_3
{
    public partial class Form1 : Form
    {
        //Coleccion 
        List<Empleado> ListaEmpleado;
        //Instancia de la clase empleado 
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ArmarTabla();
            CargarProvincias();
            txtSalariosAla.Text=SumaSalarios("Alajuela").ToString();
        }

        public void ArmarTabla()
        {
            Empleado empleado = new Empleado();
            int contador = 0;
            //aqui se define la coleccion de lista del empleado
            //ademas de Variables necesarias para el trabajo del programa
            this.ListaEmpleado = new List<Empleado>();
            string linea;
            //lectura del Archivo externo 
            System.IO.StreamReader archivo = new System.IO.StreamReader(@"C:\Users\Alejandro.AlejandroJim\Downloads\nomina.txt");
            while ((linea = archivo.ReadLine()) != null)
            {
                //llenar los campos de clase con los datos de la lista 
               
                empleado.IdPersona = Convert.ToString(linea.Split(';')[0].ToString());
                empleado.NombrePersona = Convert.ToString(linea.Split(';')[1].ToString());
                empleado.Salario = Convert.ToDouble(linea.Split(';')[2].ToString());
                empleado.TipoNomina = Convert.ToString(linea.Split(';')[3].ToString());
                empleado.Sector = Convert.ToString(linea.Split(';')[4].ToString());

                //agregar datos a la coleccion 
                this.ListaEmpleado.Add(empleado);
                this.Tabla.Text = this.Tabla.Text + linea.Replace(';', ' ') + "\n";

                //Aumentar el contador 
                contador++;
            }
            archivo.Close();
        }

        //Funcion para Obtener todos los salarios de Cualquier Provincia 
        public double SumaSalarios(String Provincia)
        {
            //Define el resulto como un double para trabajarlo 
            double resultado = 0;
            //Saca los datos de la lista 
            IEnumerable<double> Query = from temp in this.ListaEmpleado
                                        where temp.Sector == Provincia
                                        select temp.Salario;
            //Captura los salarios de cada una de las personas de la tabla
            foreach (double acum in Query)
            {
                resultado +=acum;
            }
            //retorna el resultado 
            
            return resultado;
        }

        //Aqui se cargar las provincias a la tabla 
        public void CargarProvincias()
        {
            ComboProvincias.Items.Add("");
            ComboProvincias.Items.Add("San Jose");
            ComboProvincias.Items.Add("Alajuela");
            ComboProvincias.Items.Add("Heredia");
            ComboProvincias.Items.Add("Cartago");
            ComboProvincias.Items.Add("Limon");
            ComboProvincias.Items.Add("Puntarenas");
            ComboProvincias.Items.Add("Guanacaste");
        }

        //Procedimiento Para agrupar las provincias 
        private void ComboProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Se limpia la tabla 
            this.Tabla.Text = "";
            //Comprube que haya una provincia seleccioanda en el combo box 
            if (ComboProvincias.SelectedText != "")
            {
                //Agrupa las provincias en la tabla principal 
                var Query =
                    from emp in this.ListaEmpleado
                    group emp by emp.Sector[4]
                    into temp
                    select temp;
                foreach (var empleado in Query)
                {
                    this.Tabla.Text += "sector" + "\n";
                    foreach (var temp in empleado)
                    {
                        this.Tabla.Text += temp.IdPersona + ", " + temp.NombrePersona + ", " + temp.Salario + ", " + temp.TipoNomina + ", " + temp.Sector + "\n";
                    }

                }
            }
            else
            {
                ArmarTabla();
            }
        }
            
    }
}
