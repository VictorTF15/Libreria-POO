using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Biblioteca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bibliotecaDataSet.Libros' Puede moverla o quitarla según sea necesario.
            this.librosTableAdapter.Fill(this.bibliotecaDataSet.Libros);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Libro libro = new Libro
            {
                Titulo = textBox1.Text,
                Autor = textBox2.Text,
                Año = int.Parse(textBox3.Text)
            };
            libro.Insertar();
            MessageBox.Show("Libro guardado correctamente.");
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas eliminar este libro?" , "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes) 
            {
                int id = int.Parse(textBox4.Text);
                Libro libro = new Libro();
                libro.Eliminar(id);
                MessageBox.Show("Libro eliminado correctamente.");
                MostrarDatos();
            }
        }
    }
}
