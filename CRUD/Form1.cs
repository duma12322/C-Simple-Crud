using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            MessageBox.Show("Conectado");

            dataGridView1.DataSource = llenar_grid();
        }
        public DataTable llenar_grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM ALUMNO";
            SqlCommand cmd = new SqlCommand(consulta,Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt); 
            return dt;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "INSERT INTO ALUMNO (CODIGO, NOMBRES, APELLIDOS, DIRECCION) VALUES (@CODIGO,@NOMBRES,@APELLIDOS, @DIRECCION)";
            SqlCommand cmd1 = new SqlCommand (insertar, Conexion.Conectar());
            cmd1.Parameters.AddWithValue("@CODIGO", txtCodigo.Text);
            cmd1.Parameters.AddWithValue("@NOMBRES", txtNombres.Text);
            cmd1.Parameters.AddWithValue("@APELLIDOS", txtApellidos.Text);
            cmd1.Parameters.AddWithValue("@DIRECCION", txtDireccion.Text);

            cmd1.ExecuteNonQuery();

            MessageBox.Show("Agregado exitosamente");

            dataGridView1.DataSource = llenar_grid();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "UPDATE ALUMNO SET CODIGO=@CODIGO,NOMBRES=@NOMBRES,APELLIDOS=@APELLIDOS, DIRECCION=@DIRECCION WHERE CODIGO=@CODIGO";
            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());
            cmd2.Parameters.AddWithValue("@CODIGO", txtCodigo.Text);
            cmd2.Parameters.AddWithValue("@NOMBRES", txtNombres.Text);
            cmd2.Parameters.AddWithValue("@APELLIDOS", txtApellidos.Text);
            cmd2.Parameters.AddWithValue("@DIRECCION", txtDireccion.Text);

            cmd2.ExecuteNonQuery();

            MessageBox.Show("Actualizado exitosamente");

            dataGridView1.DataSource = llenar_grid();

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtNombres.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtApellidos.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            }
            catch
            {
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "DELETE FROM ALUMNO WHERE CODIGO=@CODIGO";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar());
            cmd3.Parameters.AddWithValue("@CODIGO", txtCodigo.Text);
           

            cmd3.ExecuteNonQuery();

            MessageBox.Show("Eliminado exitosamente");

            dataGridView1.DataSource = llenar_grid();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtDireccion.Clear();
            txtCodigo.Focus();

        }
    }
}
