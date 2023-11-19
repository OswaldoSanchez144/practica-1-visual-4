using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica_1_visual_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            desactivarcontroles();
        }
        private double monto;
        
        private void activarcontroles()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            button1.Enabled = false;

            button2.Enabled = true;
            button3.Enabled = true;

        }

        private void desactivarcontroles()
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            button1.Enabled = true;

            button2.Enabled = false;
            button3.Enabled = false;
        }
            
        private void button1_Click(object sender, EventArgs e)
        {
            string cliente;
            //Leer los datos
            cliente = textBox1.Text;
            monto = Convert.ToDouble(textBox2.Text);

            if (monto>0)
            {
                activarcontroles();
            }
            else
            {
                MessageBox.Show("El monto debe ser mayor o igual que cero","Gestion de ahorros",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double leer (string mensaje)
        {
            double cantidad;
            cantidad = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("ingrese monto a" + mensaje,"Gestion de ahorros","0",100,0));
            return cantidad;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double deposito;
            deposito = leer("Depositar");
            monto = monto + deposito;
            listBox1.Items.Add(deposito);
            mostrar();
        }
        private void mostrar()
        {
            textBox3.Text = Convert.ToString(monto);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double retiro;
            retiro = leer("Retirar");

            //Evaluamos
            if (retiro <= monto)
            {
                monto = monto - retiro;
                listBox2.Items.Add(retiro); 
                mostrar();
            }
            else
            {
                MessageBox.Show("La cantidad de retiro es mayor al monto disponible","Gestion de ahorros",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3 .Clear();
            listBox1.Items.Clear();
            listBox2 .Items.Clear();
            desactivarcontroles();
        }
    }
}
