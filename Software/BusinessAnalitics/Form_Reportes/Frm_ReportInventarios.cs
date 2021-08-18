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
using System.Diagnostics;

namespace Business_Analitics
{
    public partial class Frm_ReportInventarios : DevExpress.XtraEditors.XtraForm
    {
        public string UsuariosLogin { get; set; }
        public Frm_ReportInventarios()
        {
            InitializeComponent();
        }
        private static Frm_ReportInventarios m_FormDefInstance;
        public static Frm_ReportInventarios DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_ReportInventarios();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
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
        private void btnComparar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CLS_Reporte_Inventario_Ventas sel = new CLS_Reporte_Inventario_Ventas();
            sel.Fecha1= dtFecha1.DateTime.Year.ToString() + DosCeros(dtFecha1.DateTime.Month.ToString()) + DosCeros(dtFecha1.DateTime.Day.ToString());
            sel.Fecha2= dtFecha2.DateTime.Year.ToString() + DosCeros(dtFecha2.DateTime.Month.ToString()) + DosCeros(dtFecha2.DateTime.Day.ToString());
            sel.MtdSeleccionarInventario();
            if(sel.Exito)
            {
                if(sel.Datos.Rows.Count>0)
                {
                    dtgReporte.DataSource = sel.Datos;
                }
                else
                {
                    XtraMessageBox.Show("¡No existen datos para mostrar!");
                }
            }
        }

        private void Frm_ReportInventarios_Shown(object sender, EventArgs e)
        {
            dtFecha1.DateTime = DateTime.Now;
            dtFecha2.DateTime = DateTime.Now;
            dtgValReporte.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValReporte.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValReporte.OptionsSelection.MultiSelect = true;
            dtgValReporte.OptionsView.ShowGroupPanel = false;
            dtgValReporte.OptionsBehavior.AutoPopulateColumns = true;
            dtgValReporte.OptionsView.ColumnAutoWidth = true;
            dtgValReporte.BestFitColumns();
            gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn5.DisplayFormat.FormatString = "n0";
            gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn6.DisplayFormat.FormatString = "p";
            gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn7.DisplayFormat.FormatString = "n0";
            gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn8.DisplayFormat.FormatString = "p";
            gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn9.DisplayFormat.FormatString = "p";
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dtgReporte.DataSource = null;
            dtFecha1.DateTime = DateTime.Now;
            dtFecha2.DateTime = DateTime.Now;
        }

        private void btnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dtgValReporte.RowCount > 0)
            {
                xtraSaveFileDialog1.ShowDialog();
                if (xtraSaveFileDialog1.FileName.Length > 0)
                {
                    dtgReporte.ExportToXlsx(xtraSaveFileDialog1.FileName + ".xlsx");
                    Process.Start(xtraSaveFileDialog1.FileName + ".xlsx");
                }
            }
            else
            {
                XtraMessageBox.Show("No existen registros para exportar");
            }
        }
    }
}