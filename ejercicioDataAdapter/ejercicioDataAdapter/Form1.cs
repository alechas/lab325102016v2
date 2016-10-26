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

namespace ejercicioDataAdapter
{
    public partial class Form1 : Form
    {
        private SqlConnection _miConexion;
        private SqlDataAdapter _da;
        private DataSet _ds;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Instanciar la conexión
            this._miConexion = new SqlConnection(Properties.Settings.Default.connDBAdapter);

            this._ds = new DataSet();

            //SqlCommand comando = new SqlCommand();
            //comando.CommandText = "Select * from Clientes";
            //comando.Connection = this._miConexion;
            //this._da = new SqlDataAdapter(comando);//asi le estoy pasando el selectCommand

            //Que la tabla ocupe todo el data grid
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            

            this._da = new SqlDataAdapter("Select * from Clientes",this._miConexion);//asi le estoy pasando el selectCommand
            
        }

        private void cargarFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this._da.Fill(this._ds, "Clientes");

                this.dataGridView1.DataSource = this._ds.Tables["Clientes"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
