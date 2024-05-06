using CapaDeDatos;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using System;
using System.Drawing;
using System.Xml;

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

        public DateTime fechaSerie4 { get; private set; }
        public DateTime fechaSerie3 { get; private set; }
        public DateTime fechaSerie2 { get; private set; }
        public DateTime fechaSerie1 { get; private set; }

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
            CargarResumen();
            CargarTotales();
            CargarResumenSerie();
            CargarTotalesSerie();

        }

        private void CargarResumen()
        {
            CLS_Reporte_Inventario_Ventas sel = new CLS_Reporte_Inventario_Ventas();
            sel.Fecha1 = dtFecha1.DateTime.Year.ToString() + DosCeros(dtFecha1.DateTime.Month.ToString()) + DosCeros(dtFecha1.DateTime.Day.ToString());
            sel.Fecha2 = dtFecha2.DateTime.Year.ToString() + DosCeros(dtFecha2.DateTime.Month.ToString()) + DosCeros(dtFecha2.DateTime.Day.ToString());
            gridBand2.Caption = DosCeros(dtFecha1.DateTime.Day.ToString()) + "/" + DosCeros(dtFecha1.DateTime.Month.ToString()) + "/" + dtFecha1.DateTime.Year.ToString();
            gridBand3.Caption = DosCeros(dtFecha2.DateTime.Day.ToString()) + "/" + DosCeros(dtFecha2.DateTime.Month.ToString()) + "/" + dtFecha2.DateTime.Year.ToString();
            sel.MtdSeleccionarInventario();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    dtgReporte.DataSource = sel.Datos;
                    dtgValReporte.CollapseAllGroups();
                    dtgValReporte.ExpandGroupRow(-1);
                }
                else
                {
                    XtraMessageBox.Show("¡No existen datos para mostrar!");
                }
            }
        }
        private void CargarResumenSerie()
        {
            CLS_Reporte_Inventario_Ventas sel = new CLS_Reporte_Inventario_Ventas();
            sel.Fecha1 = fechaSerie1.Year.ToString() + DosCeros(fechaSerie1.Month.ToString()) + DosCeros(fechaSerie1.Day.ToString());
            sel.Fecha2 = fechaSerie2.Year.ToString() + DosCeros(fechaSerie2.Month.ToString()) + DosCeros(fechaSerie2.Day.ToString());
            sel.Fecha3 = fechaSerie3.Year.ToString() + DosCeros(fechaSerie3.Month.ToString()) + DosCeros(fechaSerie3.Day.ToString());
            sel.Fecha4 = fechaSerie4.Year.ToString() + DosCeros(fechaSerie4.Month.ToString()) + DosCeros(fechaSerie4.Day.ToString());
            gridBand14.Caption = DosCeros(fechaSerie1.Day.ToString()) + "/" + DosCeros(fechaSerie1.Month.ToString()) + "/" + fechaSerie1.Year.ToString();
            gridBand15.Caption = DosCeros(fechaSerie2.Day.ToString()) + "/" + DosCeros(fechaSerie2.Month.ToString()) + "/" + fechaSerie2.Year.ToString();
            gridBand19.Caption = DosCeros(fechaSerie3.Day.ToString()) + "/" + DosCeros(fechaSerie3.Month.ToString()) + "/" + fechaSerie3.Year.ToString();
            gridBand20.Caption = DosCeros(fechaSerie4.Day.ToString()) + "/" + DosCeros(fechaSerie4.Month.ToString()) + "/" + fechaSerie4.Year.ToString();
            sel.MtdSeleccionarInventarioSerie();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    dtgReporteSerie.DataSource = sel.Datos;
                    dtgValReporteSerie.CollapseAllGroups();
                    dtgValReporteSerie.ExpandGroupRow(-1);
                }
                else
                {
                    XtraMessageBox.Show("¡No existen datos para mostrar!");
                }
            }
        }
        private void CargarTotales()
        {
            CLS_Reporte_Inventario_Ventas sel = new CLS_Reporte_Inventario_Ventas();
            sel.Fecha1 = dtFecha1.DateTime.Year.ToString() + DosCeros(dtFecha1.DateTime.Month.ToString()) + DosCeros(dtFecha1.DateTime.Day.ToString());
            sel.Fecha2 = dtFecha2.DateTime.Year.ToString() + DosCeros(dtFecha2.DateTime.Month.ToString()) + DosCeros(dtFecha2.DateTime.Day.ToString());
            gridBand6.Caption = DosCeros(dtFecha1.DateTime.Day.ToString()) + "/" + DosCeros(dtFecha1.DateTime.Month.ToString()) + "/" + dtFecha1.DateTime.Year.ToString();
            gridBand7.Caption = DosCeros(dtFecha2.DateTime.Day.ToString()) + "/" + DosCeros(dtFecha2.DateTime.Month.ToString()) + "/" + dtFecha2.DateTime.Year.ToString();
            sel.MtdSeleccionarInventarioTotales();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    dtgReporteT.DataSource = sel.Datos;
                }
                else
                {
                    XtraMessageBox.Show("¡No existen datos para mostrar!");
                }
            }
        }
        private void CargarTotalesSerie()
        {
            CLS_Reporte_Inventario_Ventas sel = new CLS_Reporte_Inventario_Ventas();
            sel.Fecha1 = fechaSerie1.Year.ToString() + DosCeros(fechaSerie1.Month.ToString()) + DosCeros(fechaSerie1.Day.ToString());
            sel.Fecha2 = fechaSerie2.Year.ToString() + DosCeros(fechaSerie2.Month.ToString()) + DosCeros(fechaSerie2.Day.ToString());
            sel.Fecha3 = fechaSerie3.Year.ToString() + DosCeros(fechaSerie3.Month.ToString()) + DosCeros(fechaSerie3.Day.ToString());
            sel.Fecha4 = fechaSerie4.Year.ToString() + DosCeros(fechaSerie4.Month.ToString()) + DosCeros(fechaSerie4.Day.ToString());
            gridBand10.Caption = DosCeros(fechaSerie1.Day.ToString()) + "/" + DosCeros(fechaSerie1.Month.ToString()) + "/" + fechaSerie1.Year.ToString();
            gridBand11.Caption = DosCeros(fechaSerie2.Day.ToString()) + "/" + DosCeros(fechaSerie2.Month.ToString()) + "/" + fechaSerie2.Year.ToString();
            gridBand17.Caption = DosCeros(fechaSerie3.Day.ToString()) + "/" + DosCeros(fechaSerie3.Month.ToString()) + "/" + fechaSerie3.Year.ToString();
            gridBand18.Caption = DosCeros(fechaSerie4.Day.ToString()) + "/" + DosCeros(fechaSerie4.Month.ToString()) + "/" + fechaSerie4.Year.ToString();
            sel.MtdSeleccionarInventarioTotalesSerie();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    dtgReporteTSerie.DataSource = sel.Datos;
                }
                else
                {
                    XtraMessageBox.Show("¡No existen datos para mostrar!");
                }
            }
        }
        private void Frm_ReportInventarios_Shown(object sender, EventArgs e)
        {
            cmbComparar.SelectedIndex = 0;
            DateTime vFecha = FechaMaxima();
            dtFecha1.DateTime = vFecha.AddDays(-1);
            dtFecha2.DateTime = FechaMaxima();
            dtgValReporte.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValReporte.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValReporte.OptionsSelection.MultiSelect = true;
            dtgValReporte.OptionsView.ShowGroupPanel = false;
            dtgValReporte.OptionsBehavior.AutoPopulateColumns = true;
            dtgValReporte.OptionsView.ColumnAutoWidth = true;
            dtgValReporte.BestFitColumns();
            dtgValReporteT.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValReporteT.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValReporteT.OptionsSelection.MultiSelect = true;
            dtgValReporteT.OptionsView.ShowGroupPanel = false;
            dtgValReporteT.OptionsBehavior.AutoPopulateColumns = true;
            dtgValReporteT.OptionsView.ColumnAutoWidth = true;
            dtgValReporteT.BestFitColumns();
            gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn5.DisplayFormat.FormatString = "n0";
            gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridColumn6.DisplayFormat.FormatString = "p1";
            gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn7.DisplayFormat.FormatString = "n0";
            gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn8.DisplayFormat.FormatString = "p1";
            gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn9.DisplayFormat.FormatString = "p1";
            bandedGridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            bandedGridColumn5.DisplayFormat.FormatString = "n0";
            bandedGridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            bandedGridColumn6.DisplayFormat.FormatString = "p1";
            bandedGridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            bandedGridColumn7.DisplayFormat.FormatString = "n0";
            bandedGridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            bandedGridColumn8.DisplayFormat.FormatString = "p1";
            bandedGridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            bandedGridColumn9.DisplayFormat.FormatString = "p1";

            bandedGridColumn26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            bandedGridColumn26.DisplayFormat.FormatString = "n0";
            bandedGridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            bandedGridColumn27.DisplayFormat.FormatString = "p1";
            bandedGridColumn28.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            bandedGridColumn28.DisplayFormat.FormatString = "n0";
            bandedGridColumn29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            bandedGridColumn29.DisplayFormat.FormatString = "p1";

            bandedGridColumn30.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            bandedGridColumn30.DisplayFormat.FormatString = "n0";
            bandedGridColumn31.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            bandedGridColumn31.DisplayFormat.FormatString = "p1";
            bandedGridColumn32.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            bandedGridColumn32.DisplayFormat.FormatString = "n0";
            bandedGridColumn33.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            bandedGridColumn33.DisplayFormat.FormatString = "p1";
            CalcularFechas();
        }
        private void SetBackground()
        {
            dtgReporteT.MainView.BeginUpdate();
            try
            {
                dtgValReporteT.Appearance.EvenRow.BackColor = Color.Transparent;
                dtgValReporteT.Appearance.OddRow.BackColor = Color.Transparent;
                // Specify the grid's background image. 
                dtgReporteT.BackgroundImage = Image.FromFile("c:\\Dashboard\\GodModeOn.gif");
                // Modify the appearance settings used to paint an Empty space. 
                dtgValReporteT.Appearance.Empty.BackColor = Color.Transparent;
                // Modify the group panel's appearance settings. 
                dtgValReporteT.Appearance.GroupPanel.BackColor = Color.FromArgb(100, 62, 109, 185);
                dtgValReporteT.Appearance.EvenRow.BackColor = Color.FromArgb(100, Color.Yellow);

            }
            finally
            {
                // Unlocks the control and repaints it with respect to the changes made. 
                dtgReporteT.MainView.EndUpdate();
            }
            gridView1.RowStyle += gridView1_RowStyle;
        }
        void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.BackColor = Color.FromArgb(100, Color.Red);
        }
        private DateTime FechaMaxima()
        {
            DateTime Fecha = DateTime.Now;
            CLS_Reporte_Inventario_Ventas sel = new CLS_Reporte_Inventario_Ventas();
            sel.MtdSeleccionarFechaMaxima();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    Fecha = Convert.ToDateTime(sel.Datos.Rows[0]["Fecha"].ToString());
                }
            }


            return Fecha;
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dtgReporte.DataSource = null;
            dtgReporteT.DataSource = null;
            DateTime vFecha = FechaMaxima();
            dtFecha1.DateTime = vFecha.AddDays(-1);
            dtFecha2.DateTime = FechaMaxima();
            cmbComparar.SelectedIndex = 0;
            gridBand2.Caption = "Fecha1";
            gridBand3.Caption = "Fecha2";
            gridBand6.Caption = "Fecha1";
            gridBand7.Caption = "Fecha2";
        }
        void dtgValReporteT_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;

            try
            {
                if (e.Column.FieldName == "Concepto")
                {
                    object val1 = view.GetListSourceRowCellValue(e.ListSourceRowIndex1, "Id");
                    object val2 = view.GetListSourceRowCellValue(e.ListSourceRowIndex2, "Id");
                    e.Handled = true;
                    e.Result = System.Collections.Comparer.Default.Compare(val1, val2);
                }
            }
            catch (Exception ee)
            {
                //...
            }

        }
        private void btnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dtgValReporte.RowCount > 0)
            {
                xtraSaveFileDialog1.ShowDialog();
                if (xtraSaveFileDialog1.FileName.Length > 0)
                {
                    //dtgReporte.ExportToXlsx(xtraSaveFileDialog1.FileName + ".xlsx");
                    //Process.Start(xtraSaveFileDialog1.FileName + ".xlsx");
                    ExportarAExcel(xtraSaveFileDialog1.FileName + ".xlsx");
                }
            }
            else
            {
                XtraMessageBox.Show("No existen registros para exportar");
            }
        }

        private void ExportarAExcel(string Ruta)
        {
            PrintingSystemBase printingSystem = new PrintingSystemBase();
            CompositeLinkBase compositeLink = new CompositeLinkBase();
            compositeLink.PrintingSystemBase = printingSystem;
            PrintableComponentLinkBase link1 = new PrintableComponentLinkBase();
            link1.Component = dtgReporteT;
            PrintableComponentLinkBase link2 = new PrintableComponentLinkBase();
            link2.Component = dtgReporte;
            PrintableComponentLinkBase link3 = new PrintableComponentLinkBase();
            link3.Component = dtgReporteTSerie;
            PrintableComponentLinkBase link4 = new PrintableComponentLinkBase();
            link4.Component = dtgReporteSerie;

            compositeLink.Links.Add(link1);
            compositeLink.Links.Add(link2);
            compositeLink.Links.Add(link3);
            compositeLink.Links.Add(link4);
            XlsxExportOptionsEx options = new XlsxExportOptionsEx();
            options.RawDataMode = false;
            options.ExportType = DevExpress.Export.ExportType.DataAware;
            options.ShowColumnHeaders = DevExpress.Utils.DefaultBoolean.True;
            options.AllowConditionalFormatting = DevExpress.Utils.DefaultBoolean.False;
            options.TextExportMode = TextExportMode.Text;
            options.ExportMode = XlsxExportMode.SingleFilePageByPage;
            compositeLink.CreateDocument();
            compositeLink.CreatePageForEachLink();
            compositeLink.ExportToXlsx(Ruta, options);
        }

        private void btnComparacion_Click(object sender, EventArgs e)
        {
            CargarResumen();
            CargarTotales();
            CargarResumenSerie();
            CargarTotalesSerie();
            VerificarDatos();
            ActualizarXML();
            dtgValReporteT.BestFitColumns();
            //SetBackground();
        }

        private void ActualizarXML()
        {
            string Fecha1 = fechaSerie1.Year.ToString() + DosCeros(fechaSerie1.Month.ToString()) + DosCeros(fechaSerie1.Day.ToString());
            string Fecha2 = fechaSerie2.Year.ToString() + DosCeros(fechaSerie2.Month.ToString()) + DosCeros(fechaSerie2.Day.ToString());
            string Fecha3 = fechaSerie3.Year.ToString() + DosCeros(fechaSerie3.Month.ToString()) + DosCeros(fechaSerie3.Day.ToString());
            string Fecha4 = fechaSerie4.Year.ToString() + DosCeros(fechaSerie4.Month.ToString()) + DosCeros(fechaSerie4.Day.ToString());
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Dashboard/Dashboard.xml");
            XmlNodeList itemNodes = doc.SelectNodes("Dashboard/DataSources/SqlDataSource/Query/Parameter");
            foreach (XmlNode itemNode in itemNodes)
            {
                if (itemNode.Attributes["Name"].Value == "@Fecha1")
                {
                    itemNode.InnerText = Fecha1;
                }
                if (itemNode.Attributes["Name"].Value == "@Fecha2")
                {
                    itemNode.InnerText = Fecha2;
                }
                if (itemNode.Attributes["Name"].Value == "@Fecha3")
                {
                    itemNode.InnerText = Fecha3;
                }
                if (itemNode.Attributes["Name"].Value == "@Fecha4")
                {
                    itemNode.InnerText = Fecha4;
                }
            }
            doc.Save(@"C:\Dashboard/Dashboard.xml");
        }

        private void VerificarDatos()
        {
            CLS_Reporte_Inventario_Ventas sel = new CLS_Reporte_Inventario_Ventas();
            sel.Fecha1 = dtFecha1.DateTime.Year.ToString() + DosCeros(dtFecha1.DateTime.Month.ToString()) + DosCeros(dtFecha1.DateTime.Day.ToString());
            sel.Fecha2 = dtFecha2.DateTime.Year.ToString() + DosCeros(dtFecha2.DateTime.Month.ToString()) + DosCeros(dtFecha2.DateTime.Day.ToString());
            sel.MtdSeleccionarFechaValidar();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    if (Convert.ToDecimal(sel.Datos.Rows[0][0].ToString()) == 0 && Convert.ToDecimal(sel.Datos.Rows[0][1].ToString()) == 0)
                    {
                        XtraMessageBox.Show("No existen datos para comparar");
                    }
                    else
                    {
                        if (Convert.ToDecimal(sel.Datos.Rows[0][0].ToString()) == 0)
                        {
                            XtraMessageBox.Show("No existen datos que comparar de la fecha " + dtFecha1.DateTime.ToShortDateString());
                        }
                        if (Convert.ToDecimal(sel.Datos.Rows[0][1].ToString()) == 0)
                        {
                            XtraMessageBox.Show("No existen datos que comparar de la fecha " + dtFecha2.DateTime.ToShortDateString());
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("No existen datos para comparar");
                }
            }
        }

        private void cmbComparar_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularFechas();
        }

        private void CalcularFechas()
        {
            DateTime vFecha = dtFecha2.DateTime;
            try
            {
                switch (cmbComparar.SelectedIndex)
                {
                    case 0:
                        dtFecha1.DateTime = vFecha.AddDays(-1);
                        fechaSerie4 = vFecha;
                        fechaSerie3 = vFecha.AddDays(-1);
                        fechaSerie2 = vFecha.AddDays(-2);
                        fechaSerie1 = vFecha.AddDays(-3);
                        break;
                    case 1:
                        dtFecha1.DateTime = vFecha.AddDays(-3);
                        fechaSerie4 = vFecha;
                        fechaSerie3 = vFecha.AddDays(-3);
                        fechaSerie2 = vFecha.AddDays(-6);
                        fechaSerie1 = vFecha.AddDays(-9);
                        break;
                    case 2:
                        dtFecha1.DateTime = vFecha.AddDays(-7);
                        fechaSerie4 = vFecha;
                        fechaSerie3 = vFecha.AddDays(-7);
                        fechaSerie2 = vFecha.AddDays(-14);
                        fechaSerie1 = vFecha.AddDays(-21);
                        break;
                    case 3:
                        dtFecha1.DateTime = vFecha.AddDays(-14);
                        fechaSerie4 = vFecha;
                        fechaSerie3 = vFecha.AddDays(-14);
                        fechaSerie2 = vFecha.AddDays(-28);
                        fechaSerie1 = vFecha.AddDays(-42);
                        break;
                    case 4:
                        dtFecha1.DateTime = vFecha.AddMonths(-1);
                        fechaSerie4 = vFecha;
                        fechaSerie3 = vFecha.AddMonths(-1);
                        fechaSerie2 = vFecha.AddMonths(-2);
                        fechaSerie1 = vFecha.AddMonths(-3);
                        break;
                    case 5:
                        dtFecha1.DateTime = vFecha.AddYears(-1);
                        fechaSerie4 = vFecha;
                        fechaSerie3 = vFecha.AddYears(-1);
                        fechaSerie2 = vFecha.AddYears(-2);
                        fechaSerie1 = vFecha.AddYears(-3);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnDashboard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dtgValReporte.RowCount > 0)
            {
                Frm_Dashboard frm = new Frm_Dashboard();
                frm.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("No se han cargado datos a comparar");
            }
        }

        private void dtFecha2_EditValueChanged(object sender, EventArgs e)
        {
            CalcularFechas();
        }
    }
}