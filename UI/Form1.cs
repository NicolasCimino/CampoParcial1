using BLL.BLLServices;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UI.UIExceptions;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try 
            {
                CargarComboBox();
                CargarGrid();
            } catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        #region Funciones
        public void CargarComboBox() 
        {
            DataSet ds = new DataSet();
            ds = TipoBoletoServices.Current.GetAll();
            comboBox1.DataSource = ds;
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.ValueMember = "TipoBoleto_ID";
            comboBox1.DisplayMember = "Tipo";
        }
       
        public void CargarGrid()
        {
            List<Boleto> boletos = BoletoServices.Current.ListarTodos();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Numero","Numero");
            dataGridView1.Columns.Add("Fecha de Emision", "Fecha de Emision");
            dataGridView1.Columns.Add("Fecha de Salida", "Fecha de Salida");
            dataGridView1.Columns.Add("Fecha de LLegada", "Fecha de LLegada");
            dataGridView1.Columns.Add("Tipo de Boleto", "Tipo de Boleto");
            dataGridView1.Columns.Add("Valor", "Valor");
            foreach(Boleto b in boletos)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    b.Numero,
                    b.FechaEmision.ToShortDateString(),
                    b.FechaSalida.ToShortDateString(),
                    b.CalcularRegreso().ToShortDateString(),
                    (b.TipoBoletoID == (int)TipoBoleto.tipos.Turista) ? TipoBoleto.tipos.Turista.ToString() : TipoBoleto.tipos.Ejecutivo.ToString(),
                    b.CalcularCosto()
                });
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(comboBox1.SelectedValue == null) { throw new ErrorIngresoDatos("Tipo de boleto"); }
                if(numericUpDown1.Value < 1) { throw new Exception("Cantidad de dias"); }
                if(monthCalendar1.SelectionRange == null) { throw new Exception("Fecha de salida"); }
               
                if ((int)comboBox1.SelectedValue == (int)TipoBoleto.tipos.Turista)
                {
                    Turista turista = new Turista();
                    turista.FechaSalida = monthCalendar1.SelectionRange.Start.Date;
                    turista.TiempoEnDias = (int)numericUpDown1.Value;
                    turista.FechaEmision = System.DateTime.Now;
                    turista.TipoBoletoID = (int)comboBox1.SelectedValue;
                    BoletoServices.Current.Agregar(turista);
                }
                if ((int)comboBox1.SelectedValue == (int)TipoBoleto.tipos.Ejecutivo)
                {
                    Ejecutivo ejecutivo = new Ejecutivo();
                    ejecutivo.FechaSalida = monthCalendar1.SelectionRange.Start.Date;
                    ejecutivo.TiempoEnDias = (int)numericUpDown1.Value;
                    ejecutivo.FechaEmision = System.DateTime.Now;
                    ejecutivo.TipoBoletoID = (int)comboBox1.SelectedValue;
                    BoletoServices.Current.Agregar(ejecutivo);
                }
                CargarGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
    }
}
