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
        private DataSet _dataSet;
        private SqlDataAdapter _dataAdapter;
        private SqlCommand _Select;
        private SqlCommand _Insert;
        private SqlCommand _Update;
        private SqlCommand _Delete;
        private SqlConnection _Connection;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Instanciar la conexión
            this._Connection = new SqlConnection(Properties.Settings.Default.connDBAdapter);

            this._dataSet = new DataSet();

            //SqlCommand comando = new SqlCommand();
            //comando.CommandText = "Select * from Clientes";
            //comando.Connection = this._Connection;
            //this._dataAdaptertaAdapter = new SqlDataAdapter(comando);//asi le estoy pasando el selectCommand

            //Que la tabla ocupe todo el data grid
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



            this._dataAdapter = new SqlDataAdapter("Select * from Clientes", this._Connection);//asi le estoy pasando el selectCommand

        }

        private void cargarFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this._dataAdapter.Fill(this._dataSet, "Clientes");

                this.dataGridView1.DataSource = this._dataSet.Tables["Clientes"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
