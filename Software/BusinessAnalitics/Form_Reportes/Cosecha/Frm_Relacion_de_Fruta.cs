using CapaDeDatos;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Business_Analitics
{
    public partial class Frm_Relacion_de_Fruta : DevExpress.XtraEditors.XtraForm
    {
        public string UsuariosLogin { get; set; }
        public string IdPerfil { get; set; }
        List<string> Lista = new List<string>();
        Excel.Application oXL;
        Excel._Workbook oWB;
        Excel._Worksheet oSheet;
        Excel.Range oRng;

        private static Frm_Relacion_de_Fruta m_FormDefInstance;
        public static Frm_Relacion_de_Fruta DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Relacion_de_Fruta();
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
        public Frm_Relacion_de_Fruta()
        {
            InitializeComponent();
        }

        private void dt_FechaDesde_EditValueChanged(object sender, EventArgs e)
        {
            DateTime Fecha = dt_FechaDesde.DateTime;
            int Semana = CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(Fecha, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            txtSemana.EditValue = Semana;
        }

        private void Frm_Relacion_de_Fruta_Shown(object sender, EventArgs e)
        {
            CargarAccesos();
            dt_FechaDesde.DateTime = DateTime.Now;
            dt_FechaHasta.DateTime = DateTime.Now;
            dtgValFrutaCortada.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValFrutaCortada.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValFrutaCortada.OptionsSelection.MultiSelect = true;
            dtgValFrutaCortada.OptionsView.ShowGroupPanel = false;
            dtgValFrutaCortada.OptionsBehavior.AutoPopulateColumns = true;
            dtgValFrutaCortada.OptionsView.ColumnAutoWidth = true;
            dtgValFrutaCortada.BestFitColumns();

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
            gridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn21.DisplayFormat.FormatString = "$ ###,###0.00";
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
            sel.MtdSelecccionarRelacionFrutaCortada();
            if (sel.Exito)
            {
                dtgFrutaCortada.DataSource = sel.Datos;
                if (sel.Datos.Rows.Count > 0)
                {
                    vSemanaCorte = sel.Datos.Rows[0]["semana"].ToString();
                    try
                    {
                        vFechaLiquidacion = Convert.ToDateTime(sel.Datos.Rows[0]["Fecha_Pago"].ToString()).ToString("dd MMMM yyyy");

                    }
                    catch
                    {
                    }
                    DateTimeFormatInfo dtinfo = new CultureInfo("es-MX", false).DateTimeFormat;
                    vRangoFechas = "Del " + DosCero(dt_FechaDesde.DateTime.Day.ToString()) + " de " + dtinfo.GetMonthName(dt_FechaDesde.DateTime.Month) + " al " + DosCero(dt_FechaHasta.DateTime.Day.ToString()) + " de " + dtinfo.GetMonthName(dt_FechaHasta.DateTime.Month) + " del " + dt_FechaHasta.DateTime.Year.ToString();
                    vNombreTemporada = TemporadaReport(sel.Datos.Rows[0]["Temporada"].ToString());
                }
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
                    foreach (int i in this.dtgValFrutaCortada.GetSelectedRows())
                    {
                        DataRow row = this.dtgValFrutaCortada.GetDataRow(i);
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
            if (dtgValFrutaCortada.RowCount > 0)
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
                                dtgValFrutaCortada.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                dtgValFrutaCortada.ExportToXlsx(exportFilePath);
                                break;
                            case ".rtf":
                                dtgValFrutaCortada.ExportToRtf(exportFilePath);
                                break;
                            case ".pdf":
                                dtgValFrutaCortada.ExportToPdf(exportFilePath);
                                break;
                            case ".html":
                                dtgValFrutaCortada.ExportToHtml(exportFilePath);
                                break;
                            case ".mht":
                                dtgValFrutaCortada.ExportToMht(exportFilePath);
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
                                XtraMessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            XtraMessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("No se ha consultado cortes");
            }
            //if (dtgValFrutaCortada.RowCount > 0)
            //{
            //    Formato_A();
            //}
            //else
            //{
            //    XtraMessageBox.Show("No se ha consultado cortes");
            //}
        }
        private void Formato_A()
        {
            CreaLibro();
            oSheet = CreaHoja("Semana " + vSemanaCorte);
            Colocar_encabezado(oSheet);
            Colocar_Cortes(oSheet);
        }
        private Excel._Worksheet CreaHoja(string NombreHoja)
        {
            oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;

            oSheet = oWB.ActiveSheet as Excel.Worksheet;
            oSheet.Name = NombreHoja;
            return oSheet;
        }
        private void CreaLibro()
        {
            //Start Excel and get Application object.
            oXL = new Excel.Application();
            oXL.Visible = true;
            oXL.Application.WindowState = Excel.XlWindowState.xlMaximized;
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
        private void Colocar_encabezado(Excel._Worksheet oSheet)
        {
            //Format A1:D1 as bold, vertical alignment = center.
            oRng = oSheet.get_Range("B1", "E1");
            oRng.Merge();
            oRng.Value2 = "GRUPO EXPORTADOR SAN TADEO SA DE CV";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 15;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            oRng.Font.Bold = true;

            oRng = oSheet.get_Range("B2", "E2");
            oRng.Merge();
            oRng.Value2 = "RELACION DE FRUTA CORTADA";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 15;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            oRng.Font.Bold = true;

            oRng = oSheet.get_Range("B3", "E3");
            oRng.Merge();
            oRng.Value2 = "TEMPORADA: " + vNombreTemporada;
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 15;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            oRng.Font.Bold = true;

            oRng = oSheet.get_Range("T1", "V1");
            oRng.Merge();
            oRng.Value2 = "SEMANA DE CORTE: " + vSemanaCorte;
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 15;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
            oRng.Font.Bold = true;

            oRng = oSheet.get_Range("T2", "V2");
            oRng.Merge();
            oRng.Value2 = vRangoFechas;
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 15;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
            oRng.Font.Bold = true;

            oRng = oSheet.get_Range("T3", "V3");
            oRng.Merge();
            oRng.Value2 = "Fecha de Liquidacion: " + vFechaLiquidacion;
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 15;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
            oRng.Font.Bold = true;

            oRng = oSheet.get_Range("B5");
            oRng.Merge();
            oRng.Value2 = "SEMANA DE SERVICIO";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 8.71;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("C5");
            oRng.Merge();
            oRng.Value2 = "FECHA DE PAGO";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 9;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("D5");
            oRng.Merge();
            oRng.Value2 = "FECHA DE CORTE";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 10.57;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("E5");
            oRng.Merge();
            oRng.Value2 = "PRODUCTOR";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 51.86;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("F5");
            oRng.Merge();
            oRng.Value2 = "HUERTA";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 20.14;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("G5");
            oRng.Merge();
            oRng.Value2 = "ESTIBA";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 20.14;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("H5");
            oRng.Merge();
            oRng.Value2 = "PRECIO INICIAL";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 8.14;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("I5");
            oRng.Merge();
            oRng.Value2 = "PRECIO FINAL";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 8.29;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("J5");
            oRng.Merge();
            oRng.Value2 = "KILOS RECIBIDOS";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 9.29;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("K5");
            oRng.Merge();
            oRng.Value2 = "BASCULA PRODUCTOR";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 11.29;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("L5");
            oRng.Merge();
            oRng.Value2 = "DIF. EN BASCULA.";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 8.86;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("M5");
            oRng.Merge();
            oRng.Value2 = "M";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 4.43;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("N5");
            oRng.Merge();
            oRng.Value2 = "KGS. A FACTURAR";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 9.57;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("O5");
            oRng.Merge();
            oRng.Value2 = "IMPORTE A FACTURAR";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 16.14;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("P5");
            oRng.Merge();
            oRng.Value2 = "RETENSION 1.25% (RESICO)";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 15.29;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("Q5");
            oRng.Merge();
            oRng.Value2 = "IMPORTE";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 17.71;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("R5");
            oRng.Merge();
            oRng.Value2 = "OBSERV.";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 30.71;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("S5");
            oRng.Merge();
            oRng.Value2 = "FOLIO FACTURA";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 8.71;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("T5");
            oRng.Merge();
            oRng.Value2 = "FECHA FACTURA";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 10.71;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("U5");
            oRng.Merge();
            oRng.Value2 = "RAZON SOCIAL QUE FACTURA";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 33.57;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("V5");
            oRng.Merge();
            oRng.Value2 = "IMPORTE";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 16.43;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("W5");
            oRng.Merge();
            oRng.Value2 = "FECHA DE PAGO";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 12.57;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("X5");
            oRng.Merge();
            oRng.Value2 = "ACOPIADOR";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 12.57;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("Y5");
            oRng.Merge();
            oRng.Value2 = "MUNICIPIO";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 12.57;
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = 0.399975585192419;
            oRng.Interior.PatternTintAndShade = 0;

            oRng = oSheet.get_Range("B5", "Y5");
            oRng.Borders.Weight = Excel.XlBorderWeight.xlThin;
        }

        private void Colocar_Cortes(Excel._Worksheet oSheet)
        {
            CLS_Cosecha_Reportes sel = new CLS_Cosecha_Reportes();
            sel.Fecha_Inicio = dt_FechaDesde.DateTime.Year.ToString() + DosCero(dt_FechaDesde.DateTime.Month.ToString()) + DosCero(dt_FechaDesde.DateTime.Day.ToString());
            sel.Fecha_Fin = dt_FechaHasta.DateTime.Year.ToString() + DosCero(dt_FechaHasta.DateTime.Month.ToString()) + DosCero(dt_FechaHasta.DateTime.Day.ToString());
            sel.MtdSelecccionarRelacionFrutaCortada();
            if (!sel.Exito)
            {
                XtraMessageBox.Show(sel.Mensaje);
            }

            int Fila = 6;
            vfoliofactura = String.Empty;
            vtotalfacturas = 0;
            int Filainicial = Fila;
            for (int x = 0; x < sel.Datos.Rows.Count; x++)
            {
                oRng = oSheet.get_Range("B" + Fila.ToString());
                oRng.Merge();
                oRng.Value2 = sel.Datos.Rows[x]["semana"].ToString();
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                oRng.Font.Bold = false;
                oRng.NumberFormat = "#,##0";

                oRng = oSheet.get_Range("C" + Fila.ToString());
                oRng.Merge();
                try
                {
                    oRng.Value2 = Convert.ToDateTime(sel.Datos.Rows[x]["Fecha_Pago"].ToString());
                }
                catch
                {
                    oRng.Value2 = "";
                }
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                oRng.Font.Bold = false;
                oRng.NumberFormat = "dd/mm/yyyy";
                oRng.EntireColumn.AutoFit();

                oRng = oSheet.get_Range("D" + Fila.ToString());
                oRng.Merge();
                oRng.Value2 = Convert.ToDateTime(sel.Datos.Rows[x]["RecepcionFecha"].ToString());
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                oRng.Font.Bold = false;
                oRng.NumberFormat = "dd/mm/yyyy";
                oRng.EntireColumn.AutoFit();

                oRng = oSheet.get_Range("E" + Fila.ToString());
                oRng.Value2 = sel.Datos.Rows[x]["Productor"].ToString();
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                oRng.Font.Bold = false;
                oRng.EntireColumn.AutoFit();

                oRng = oSheet.get_Range("F" + Fila.ToString());
                oRng.Value2 = sel.Datos.Rows[x]["Huerta"].ToString();
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                oRng.Font.Bold = false;
                oRng.EntireColumn.AutoFit();

                oRng = oSheet.get_Range("G" + Fila.ToString());
                oRng.NumberFormat = "@";
                oRng.Value2 = "'" + sel.Datos.Rows[x]["EstibadeSeleccion"].ToString();
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                oRng.Font.Bold = false;
                oRng.EntireColumn.AutoFit();

                oRng = oSheet.get_Range("H" + Fila.ToString());
                oRng.Value2 = Convert.ToDecimal(sel.Datos.Rows[x]["PreciokgInicial"].ToString());
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                oRng.Font.Bold = false;
                oRng.NumberFormat = @"_($* #,##0.00_);_($* (#,##0.00);_($* ""-""??_);_(@_)";
                oRng.EntireColumn.AutoFit();

                oRng = oSheet.get_Range("I" + Fila.ToString());
                oRng.Value2 = Convert.ToDecimal(sel.Datos.Rows[x]["Preciokg"].ToString());
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                oRng.Font.Bold = false;
                oRng.NumberFormat = @"_($* #,##0.00_);_($* (#,##0.00);_($* ""-""??_);_(@_)";
                oRng.EntireColumn.AutoFit();

                oRng = oSheet.get_Range("J" + Fila.ToString());
                oRng.Merge();
                oRng.Value2 = sel.Datos.Rows[x]["KilosCortados"].ToString();
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                oRng.Font.Bold = false;
                oRng.NumberFormat = "#,##0";
                oRng.EntireColumn.AutoFit();

                oRng = oSheet.get_Range("K" + Fila.ToString());
                oRng.Merge();
                oRng.Value2 = sel.Datos.Rows[x]["KilosProductor"].ToString();
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                oRng.Font.Bold = false;
                oRng.NumberFormat = "#,##0";
                oRng.EntireColumn.AutoFit();

                oRng = oSheet.get_Range("L" + Fila.ToString());
                oRng.Merge();
                oRng.Value2 = sel.Datos.Rows[x]["KilosDiferencia"].ToString();
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                oRng.Font.Bold = false;
                oRng.NumberFormat = "#,##0";
                oRng.EntireColumn.AutoFit();

                oRng = oSheet.get_Range("M" + Fila.ToString());
                oRng.Merge();
                oRng.Value2 = sel.Datos.Rows[x]["KilosMuestra"].ToString();
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                oRng.Font.Bold = false;
                oRng.NumberFormat = "#,##0";
                oRng.EntireColumn.AutoFit();

                oRng = oSheet.get_Range("N" + Fila.ToString());
                oRng.Merge();
                oRng.Value2 = sel.Datos.Rows[x]["KilosaPagar"].ToString();
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                oRng.Font.Bold = false;
                oRng.NumberFormat = "#,##0";
                oRng.EntireColumn.AutoFit();

                oRng = oSheet.get_Range("O" + Fila.ToString());
                try
                {
                    oRng.Value2 = Convert.ToDecimal(sel.Datos.Rows[x]["Importe_Factura"].ToString());
                }
                catch
                {
                    oRng.Value2 = "0";
                }
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                oRng.Font.Bold = false;
                oRng.NumberFormat = @"_($* #,##0.00_);_($* (#,##0.00);_($* ""-""??_);_(@_)";
                oRng.EntireColumn.AutoFit();

                oRng = oSheet.get_Range("P" + Fila.ToString());
                try
                {
                    oRng.Value2 = Convert.ToDecimal(sel.Datos.Rows[x]["Importe_Retencion"].ToString());
                }
                catch
                {
                    oRng.Value2 = "0";
                }
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                oRng.Font.Bold = false;
                oRng.NumberFormat = @"_($* #,##0.00_);_($* (#,##0.00);_($* ""-""??_);_(@_)";
                oRng.EntireColumn.AutoFit();

                if (vfoliofactura != sel.Datos.Rows[x]["FolioFactura"].ToString() && Fila != 6)
                {
                    filaanterior = Fila - 1;
                    oRng = oSheet.get_Range("V" + Filainicial.ToString(), "V" + filaanterior.ToString());
                    //oRng.Merge();
                    oRng.Value2 = vtotalfacturas;
                    oRng.Font.FontStyle = "Calibri";
                    oRng.Font.Size = 11;
                    oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    oRng.Font.Bold = false;
                    oRng.NumberFormat = @"_($* #,##0.00_);_($* (#,##0.00);_($* ""-""??_);_(@_)";
                    oRng.EntireColumn.AutoFit();
                    Filainicial = Fila;
                    vtotalfacturas = 0;
                }

                oRng = oSheet.get_Range("Q" + Fila.ToString());
                try
                {
                    oRng.Value2 = Convert.ToDecimal(sel.Datos.Rows[x]["Total_Factura"].ToString());
                }
                catch
                {
                    oRng.Value2 = "0";
                }
                try
                {
                    vtotalfacturas += Convert.ToDecimal(sel.Datos.Rows[x]["Total_Factura"].ToString());
                }
                catch
                {
                    vtotalfacturas += 0;
                }
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                oRng.Font.Bold = false;
                oRng.NumberFormat = @"_($* #,##0.00_);_($* (#,##0.00);_($* ""-""??_);_(@_)";
                oRng.EntireColumn.AutoFit();

                oRng = oSheet.get_Range("R" + Fila.ToString());
                oRng.Value2 = sel.Datos.Rows[x]["Observaciones"].ToString();
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 7;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                oRng.Font.Bold = false;
                oRng.WrapText = true;



                oRng = oSheet.get_Range("S" + Fila.ToString());
                oRng.Value2 = sel.Datos.Rows[x]["FolioFactura"].ToString();
                vfoliofactura = sel.Datos.Rows[x]["FolioFactura"].ToString();
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                oRng.Font.Bold = false;
                oRng.EntireColumn.AutoFit();

                oRng = oSheet.get_Range("T" + Fila.ToString());
                oRng.Merge();
                try
                {
                    oRng.Value2 = Convert.ToDateTime(sel.Datos.Rows[x]["Fecha_Factura"].ToString());
                }
                catch
                {
                    oRng.Value2 = string.Empty;
                }
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                oRng.Font.Bold = false;
                oRng.NumberFormat = "dd/mm/yyyy";
                oRng.EntireColumn.AutoFit();

                oRng = oSheet.get_Range("U" + Fila.ToString());
                oRng.Value2 = sel.Datos.Rows[x]["RazonSocial"].ToString();
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                oRng.Font.Bold = false;
                oRng.EntireColumn.AutoFit();

                oRng = oSheet.get_Range("X" + Fila.ToString());
                oRng.Value2 = sel.Datos.Rows[x]["Acopiador"].ToString();
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                oRng.Font.Bold = false;
                oRng.EntireColumn.AutoFit();

                oRng = oSheet.get_Range("Y" + Fila.ToString());
                oRng.Value2 = sel.Datos.Rows[x]["Municipio"].ToString();
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                oRng.Font.Bold = false;
                oRng.EntireColumn.AutoFit();

                Fila++;
            }
            if (vtotalfacturas > 0 && Fila != 6)
            {
                filaanterior = Fila - 1;
                oRng = oSheet.get_Range("V" + Filainicial.ToString(), "V" + filaanterior.ToString());
                oRng.Merge();
                oRng.Value2 = vtotalfacturas;
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oRng.Font.Bold = false;
                oRng.NumberFormat = @"_($* #,##0.00_);_($* (#,##0.00);_($* ""-""??_);_(@_)";
                oRng.EntireColumn.AutoFit();
                Filainicial = Fila;
                vtotalfacturas = 0;
            }

            oRng = oSheet.get_Range("B" + Fila.ToString(), "Y" + Fila.ToString());
            oRng.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
            oRng.Interior.PatternColorIndex = Excel.XlPattern.xlPatternAutomatic;
            oRng.Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent6;
            oRng.Interior.TintAndShade = -0.499984740745262;
            oRng.Interior.PatternTintAndShade = 0;
            oRng.Font.ThemeColor = Excel.XlThemeColor.xlThemeColorDark1;
            oRng.Font.TintAndShade = 0;

            filaanterior = Fila - 1;
            oRng = oSheet.get_Range("N" + Fila.ToString());
            oRng.Formula = "=SUM(N6:" + "N" + filaanterior.ToString() + ")";
            oRng.EntireColumn.AutoFit();

            oRng = oSheet.get_Range("O" + Fila.ToString());
            oRng.Formula = "=SUM(O6:" + "O" + filaanterior.ToString() + ")";
            oRng.EntireColumn.AutoFit();

            oRng = oSheet.get_Range("V" + Fila.ToString());
            oRng.Formula = "=SUM(V6:" + "V" + filaanterior.ToString() + ")";
            oRng.EntireColumn.AutoFit();

            oRng = oSheet.get_Range("A:A");
            oRng.EntireColumn.Hidden = true;

        }

        private void dt_FechaDesde_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void dt_FechaHasta_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}