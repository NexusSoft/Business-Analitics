using CapaDeDatos;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessAnalitics
{
    public partial class Frm_BuscarProforma : DevExpress.XtraEditors.XtraForm
    {
        public string TemActiva { get; private set; }
        public string Id_Manifiesto { get; set; }
        public string v_temporada { get; set; }
        public string v_secuencia { get; set; }
        public string v_ordencorte { get; set; }
        public Frm_BuscarProforma()
        {
            InitializeComponent();
        }
        private void CargarTemporadaActiva()
        {
            CLS_Temporada obtener = new CLS_Temporada();
            obtener.MtdSeleccionarEtiquetaTemporadaActiva();
            if (obtener.Exito)
            {
                if (obtener.Datos.Rows.Count > 0)
                {
                    TemActiva = obtener.Datos.Rows[0][0].ToString();
                }
            }
        }
        private void CargarTemporada(string Valor)
        {
            CLS_Temporada obtener = new CLS_Temporada();
            obtener.MtdSeleccionarEtiquetaTemporada();
            if (obtener.Exito)
            {
                if (obtener.Datos.Rows.Count > 0)
                {
                    CargarComboTemporada(obtener.Datos, Valor);
                }
            }
        }
        private void CargarComboTemporada(DataTable Datos, string Valor)
        {
            cmb_Temporada.Properties.DisplayMember = "c_codigo_tem";
            cmb_Temporada.Properties.ValueMember = "c_codigo_tem";
            cmb_Temporada.EditValue = Valor;
            cmb_Temporada.Properties.DataSource = Datos;
        }

        private void Frm_BuscarManifiesto_Shown(object sender, EventArgs e)
        {
            CargarTemporadaActiva();
            CargarTemporada(TemActiva);
            Cargar_Programa(cmb_Temporada.EditValue.ToString());
            dtgValManifiesto.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValManifiesto.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValManifiesto.OptionsSelection.MultiSelect = true;
            dtgValManifiesto.OptionsView.ShowGroupPanel = false;
            dtgValManifiesto.OptionsBehavior.AutoPopulateColumns = true;
            dtgValManifiesto.OptionsView.ColumnAutoWidth = true;
            dtgValManifiesto.BestFitColumns();
        }
        private void Cargar_Programa(string p)
        {
            CLS_Cargas sel = new CLS_Cargas();
            sel.c_codigo_tem = p;
            sel.MtdSeleccionarCarga();
            if (sel.Exito)
            {
                dtgManifiesto.DataSource = sel.Datos;
            }
        }

        private void dtgManifiesto_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValManifiesto.GetSelectedRows())
                {
                    DataRow row = this.dtgValManifiesto.GetDataRow(i);
                    Id_Manifiesto = row["c_codigo_man"].ToString();
                    v_temporada = row["c_codigo_tem"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
            this.Close();
        }
    }
}