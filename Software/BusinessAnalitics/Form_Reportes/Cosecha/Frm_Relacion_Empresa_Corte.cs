using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeDatos;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Business_Analitics
{
    public partial class Frm_Relacion_Empresa_Corte : DevExpress.XtraEditors.XtraForm
    {
        public string UsuariosLogin { get; set; }
        public string IdPerfil { get; set; }
        List<string> Lista = new List<string>();
        Excel.Application oXL;
        Excel._Workbook oWB;
        Excel._Worksheet oSheet;
        Excel.Range oRng;

        private static Frm_Relacion_Empresa_Corte m_FormDefInstance;
        public static Frm_Relacion_Empresa_Corte DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Relacion_Empresa_Corte();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        public string vId_Cosecha { get; set; }
        public string vNombreTemporada { get; set; }
        public string vSemanaCorte { get; set; }
        public string vRangoFechas { get; set; }
        public string vFechaLiquidacion { get; set; }
        public string vfoliofactura { get; set; }
        public decimal vtotalfacturas { get; set; }
        public int filaanterior { get; set; }
        public Frm_Relacion_Empresa_Corte()
        {
            InitializeComponent();
        }

        private void dt_FechaDesde_EditValueChanged(object sender, EventArgs e)
        {
            DateTime Fecha = dt_FechaDesde.DateTime;
            int Semana = CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(Fecha, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            
        }

        private void Frm_Relacion_de_Fruta_Shown(object sender, EventArgs e)
        {
            CargarAccesos();
            dt_FechaDesde.DateTime = DateTime.Now;
            dt_FechaHasta.DateTime = DateTime.Now;
            dtgValEmpresaCorte.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValEmpresaCorte.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValEmpresaCorte.OptionsSelection.MultiSelect = true;
            dtgValEmpresaCorte.OptionsView.ShowGroupPanel = false;
            dtgValEmpresaCorte.OptionsBehavior.AutoPopulateColumns = true;
            dtgValEmpresaCorte.OptionsView.ColumnAutoWidth = true;
            dtgValEmpresaCorte.BestFitColumns();

            gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn6.DisplayFormat.FormatString = "$ ###,###0.00";
            gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn7.DisplayFormat.FormatString = "###,###0";
            gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn8.DisplayFormat.FormatString = "###,###0";
            gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn9.DisplayFormat.FormatString = "###,###0";
            gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn10.DisplayFormat.FormatString = "###,###0";
            gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn11.DisplayFormat.FormatString = "###,###0";
            gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn12.DisplayFormat.FormatString = "$ ###,###0.00";
            gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn13.DisplayFormat.FormatString = "$ ###,###0.00";
            gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn14.DisplayFormat.FormatString = "$ ###,###0.00";
            bandedGridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            bandedGridColumn15.DisplayFormat.FormatString = "$ ###,###0.00";
            bandedGridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            bandedGridColumn19.DisplayFormat.FormatString = "$ ###,###0.00";
            bandedGridColumn23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            bandedGridColumn23.DisplayFormat.FormatString = "$ ###,###0.00";
            bandedGridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            bandedGridColumn27.DisplayFormat.FormatString = "$ ###,###0.00";
            bandedGridColumn33.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            bandedGridColumn33.DisplayFormat.FormatString = "$ ###,###0.00";
            bandedGridColumn34.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            bandedGridColumn34.DisplayFormat.FormatString = "$ ###,###0.00";
            bandedGridColumn35.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            bandedGridColumn35.DisplayFormat.FormatString = "$ ###,###0.00";
            bandedGridColumn36.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            bandedGridColumn36.DisplayFormat.FormatString = "$ ###,###0.00";
            bandedGridColumn37.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            bandedGridColumn37.DisplayFormat.FormatString = "$ ###,###0.00";

            chk_Empresa.Checked= true;
            chk_Huerta.Checked= true;
            chk_Kilos.Checked= true;
            chk_FKilos.Checked= true;
            chk_FDia.Checked= true;
            chk_FApoyo.Checked = true;
            chk_FSalida.Checked= true;
            chkTotales.Checked = true;
        }

        string TemporadaReport(string str)
        {
            string strTemporada = string.Empty;
            CLS_Temporada sel = new CLS_Temporada();
            sel.c_codigo_tem = str;
            sel.MtdSeleccionarTemporada();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    strTemporada = sel.Datos.Rows[0]["v_nombre_tem"].ToString();
                }
            }
            return strTemporada;
        }
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            CLS_Cosecha_Reportes sel = new CLS_Cosecha_Reportes();
            sel.Fecha_Inicio = dt_FechaDesde.DateTime.Year.ToString() + DosCero(dt_FechaDesde.DateTime.Month.ToString()) + DosCero(dt_FechaDesde.DateTime.Day.ToString());
            sel.Fecha_Fin = dt_FechaHasta.DateTime.Year.ToString() + DosCero(dt_FechaHasta.DateTime.Month.ToString()) + DosCero(dt_FechaHasta.DateTime.Day.ToString());
            sel.MtdSelecccionarRelacionEmpresaCorte();
            if (sel.Exito)
            {
                dtgEmpresaCorte.DataSource = sel.Datos;
                dtgValEmpresaCorte.BestFitColumns();
            }
        }
        private void CargarAccesos()
        {
            CLS_Perfiles_Pantallas Clase = new CLS_Perfiles_Pantallas();
            Clase.Id_Perfil = IdPerfil;
            Clase.MtdSeleccionarAccesosPermisos();
            if (Clase.Exito)
            {

                for (int x = 0; x < Clase.Datos.Rows.Count; x++)
                {
                    Lista.Add(Clase.Datos.Rows[x][0].ToString());
                }
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }
        private Boolean TieneAcceso(String valor)
        {
            foreach (string x in Lista)
            {
                if (x == valor)
                {
                    return true;
                }

            }
            return false;
        }
        private void dtgFrutaCortada_DoubleClick(object sender, EventArgs e)
        {
            if (TieneAcceso("015"))
            {
                try
                {
                    foreach (int i in this.dtgValEmpresaCorte.GetSelectedRows())
                    {
                        DataRow row = this.dtgValEmpresaCorte.GetDataRow(i);
                        vId_Cosecha = row["Id_Cosecha"].ToString();
                    }


                    Frm_Cosecha Ventana = new Frm_Cosecha();
                    Frm_Cosecha.DefInstance.MdiParent = Frm_Cosecha.DefInstance.MdiParent;
                    Frm_Cosecha.DefInstance.UsuariosLogin = UsuariosLogin;

                    Frm_Cosecha.DefInstance.CargarCosecha();
                    Frm_Cosecha.DefInstance.ShowDialog();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [015]");
            }
        }

        private void btnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bandedGridView1.RowCount > 0)
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                    if (saveDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        string exportFilePath = saveDialog.FileName;
                        string fileExtenstion = new System.IO.FileInfo(exportFilePath).Extension;

                        switch (fileExtenstion)
                        {
                            case ".xls":
                                dtgValEmpresaCorte.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                dtgValEmpresaCorte.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                dtgValEmpresaCorte.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                dtgValEmpresaCorte.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                dtgValEmpresaCorte.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                dtgValEmpresaCorte.ExportToMht(exportFilePath);
                                break;
                            default:
                                break;
                        }

                        if (System.IO.File.Exists(exportFilePath))
                        {
                            try
                            {
                                //Try to open the file and let windows decide how to open it.
                                System.Diagnostics.Process.Start(exportFilePath);
                            }
                            catch
                            {
                                String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                                MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("No se ha consultado cortes");
            }
        }
        private string DosCero(string sVal)
        {
            string str = "";
            if (sVal.Length == 1)
            {
                return (str = "0" + sVal);
            }
            return sVal;
        }
        private void chk_Huerta_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Huerta.Checked==true)
            {
                ban_Huerta.Visible = true;
            }
            else
            {
                ban_Huerta.Visible = false;
            }
        }

        private void chk_Empresa_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Empresa.Checked == true)
            {
                ban_Empresa.Visible = true;
            }
            else
            {
                ban_Empresa.Visible = false;
            }
        }

        private void chk_Kilos_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Kilos.Checked == true)
            {
                ban_Kilos.Visible = true;
            }
            else
            {
                ban_Kilos.Visible = false;
            }
        }

        private void chk_FKilos_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_FKilos.Checked == true)
            {
                ban_FKilos.Visible = true;
            }
            else
            {
                ban_FKilos.Visible = false;
            }
        }

        private void chk_FDia_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_FDia.Checked == true)
            {
                ban_FDia.Visible = true;
            }
            else
            {
                ban_FDia.Visible = false;
            }
        }

        private void chk_FApoyo_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_FApoyo.Checked == true)
            {
                ban_FApoyo.Visible = true;
            }
            else
            {
                ban_FApoyo.Visible = false;
            }
        }

        private void chk_FSalida_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_FSalida.Checked == true)
            {
                ban_FSalida.Visible = true;
            }
            else
            {
                ban_FSalida.Visible = false;
            }
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dt_FechaDesde.DateTime = DateTime.Now;
            dt_FechaHasta.DateTime = DateTime.Now;
            dtgEmpresaCorte.DataSource = null;
            chk_Empresa.Checked = true;
            chk_Huerta.Checked = true;
            chk_Kilos.Checked = true;
            chk_FKilos.Checked = true;
            chk_FDia.Checked = true;
            chk_FApoyo.Checked = true;
            chk_FSalida.Checked = true;
        }

        private void chkTotales_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTotales.Checked == true)
            {
                ban_Totales.Visible = true;
            }
            else
            {
                ban_Totales.Visible = false;
            }
        }
    }
}