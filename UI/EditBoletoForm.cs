using BLL.BLLExceptions;
using BLL.BLLServices;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class EditBoletoForm : Form
    {
        int numBoleto;
        public EditBoletoForm()
        {
            InitializeComponent();
        }

        public EditBoletoForm(int i )
        {
            InitializeComponent();
            numBoleto = i;
        }

        private void EditBoletoForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = numBoleto.ToString();
            try
            {
                Boleto b = BoletoServices.Current.GetBoleto(numBoleto);
                monthCalendar1.SetDate(b.FechaSalida.Date);
                numericUpDown1.Value = b.TiempoEnDias;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }

            
        }
    }
}
