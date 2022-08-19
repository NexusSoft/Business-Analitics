using CapaDeDatos;
using System;

namespace Business_Analitics
{
    public partial class FrmHistorialInventario : DevExpress.XtraEditors.XtraForm
    {
        public FrmHistorialInventario()
        {
            InitializeComponent();
        }
        public string DosCeros(string sVal)
        {
            string str = "";
            if (sVal.Length == 1)
            {
                return (str = "0" + sVal);
            }
            return sVal;
        }
        private void btnComparacion_Click(object sender, EventArgs e)
        {
            CLS_Inventario_Ventas sel = new CLS_Inventario_Ventas();
            sel.FechaInicio = dtFecha1.DateTime.Year.ToString() + DosCeros(dtFecha1.DateTime.Month.ToString()) + DosCeros(dtFecha1.DateTime.Day.ToString());
            sel.FechaFin = dtFecha2.DateTime.Year.ToString() + DosCeros(dtFecha2.DateTime.Month.ToString()) + DosCeros(dtFecha2.DateTime.Day.ToString());
            sel.MtdSeleccionarInventario_Historico();
            if (sel.Exito)
            {
                dtgHistorico.DataSource = sel.Datos;
            }
        }

        private void FrmHistorialInventario_Load(object sender, EventArgs e)
        {
            dtgValHistorico.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValHistorico.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValHistorico.OptionsSelection.MultiSelect = true;
            dtgValHistorico.OptionsView.ShowGroupPanel = false;
            dtgValHistorico.OptionsBehavior.AutoPopulateColumns = true;
            dtgValHistorico.OptionsView.ColumnAutoWidth = true;
            dtgValHistorico.BestFitColumns();
            gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn3.DisplayFormat.FormatString = "n0";
            gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn4.DisplayFormat.FormatString = "c0";
            dtFecha1.DateTime = DateTime.Now;
            dtFecha2.DateTime = DateTime.Now;
        }
    }
}