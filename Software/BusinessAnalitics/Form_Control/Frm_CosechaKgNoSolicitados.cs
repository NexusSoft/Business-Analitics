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
    public partial class Frm_CosechaKgNoSolicitados : DevExpress.XtraEditors.XtraForm
    {
        public string c_codigo_tem { get; set; }
        public string c_codigo_sel { get; set; }
        public string c_codigo_rec { get; set; }
        public string v_nombre_tipocorte { get; set; }
        public Frm_CosechaKgNoSolicitados()
        {
            InitializeComponent();
        }
        private void CalcularkilosNoDeseados()
        {
            CLS_CorridaFruta selRec = new CLS_CorridaFruta();
            selRec.c_codigo_tem = c_codigo_tem;
            selRec.c_codigo_sel = c_codigo_sel;
            selRec.c_codigo_rec = c_codigo_rec;
            selRec.MtdSeleccionarRecepcionCorteND();
            if (selRec.Exito)
            {
                dtgRecepcion.DataSource = selRec.Datos;
            }
            else
            {
                XtraMessageBox.Show(selRec.Mensaje);
            }

            CLS_CorridaFruta selExt = new CLS_CorridaFruta();
            selExt.c_codigo_tem = c_codigo_tem;
            selExt.c_codigo_sel = c_codigo_sel;
            selExt.v_nombre_tipocorte = v_nombre_tipocorte;
            selExt.MtdSeleccionarKilosCorteND();
            if (selExt.Exito)
            {
                dtgTamanio.DataSource = selExt.Datos;
            }
            else
            {
                XtraMessageBox.Show(selExt.Mensaje);
            }
        }

        private void Frm_CosechaKgNoSolicitados_Shown(object sender, EventArgs e)
        {
            CalcularkilosNoDeseados();
            gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn5.DisplayFormat.FormatString = "p4";

            dtgValRecepcion.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValRecepcion.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValRecepcion.OptionsSelection.MultiSelect = true;
            dtgValRecepcion.OptionsView.ShowGroupPanel = false;
            dtgValRecepcion.OptionsBehavior.AutoPopulateColumns = true;
            dtgValRecepcion.OptionsView.ColumnAutoWidth = true;
            dtgValRecepcion.BestFitColumns();

            dtgValTamanio.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValTamanio.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValTamanio.OptionsSelection.MultiSelect = true;
            dtgValTamanio.OptionsView.ShowGroupPanel = false;
            dtgValTamanio.OptionsBehavior.AutoPopulateColumns = true;
            dtgValTamanio.OptionsView.ColumnAutoWidth = true;
            dtgValTamanio.BestFitColumns();
        }
    }
}