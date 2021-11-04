using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CapaDeDatos;

namespace Business_Analitics
{
    public partial class Frm_BuscarHuerta : DevExpress.XtraEditors.XtraForm
    {
        public string IdHuerta { get; set; }
        public string Huerta { get; set; }
        public Frm_BuscarHuerta()
        {
            InitializeComponent();
        }

        private void dtgHuertas_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValHuertas.GetSelectedRows())
                {
                    DataRow row = this.dtgValHuertas.GetDataRow(i);
                    IdHuerta = row["c_codigo_hue"].ToString();
                    Huerta = row["v_nombre_hue"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void Frm_BuscarHuerta_Shown(object sender, EventArgs e)
        {
            CargarHuertas();
            dtgValHuertas.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValHuertas.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValHuertas.OptionsSelection.MultiSelect = true;
            dtgValHuertas.OptionsView.ShowGroupPanel = false;
            dtgValHuertas.OptionsBehavior.AutoPopulateColumns = true;
            dtgValHuertas.OptionsView.ColumnAutoWidth = true;
            dtgValHuertas.BestFitColumns();
        }
        void CargarHuertas()
        {
            dtgHuertas.DataSource = null;
            CLS_Huerta Clase = new CLS_Huerta();
            Clase.MtdSeleccionarHuerta();
            if (Clase.Exito)
            {
                dtgHuertas.DataSource = Clase.Datos;
            }
        }
    }
}