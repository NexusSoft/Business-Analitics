﻿using System;
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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;

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
            CargarResumen();
            CargarTotales();
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
        private void Frm_ReportInventarios_Shown(object sender, EventArgs e)
        {
            DateTime vFecha = FechaMaxima();
            dtFecha1.DateTime = vFecha.AddDays(-1);
            dtFecha2.DateTime = FechaMaxima();
            cmbComparar.SelectedIndex = 0;
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
            //dtgValReporte.GroupSummary.Clear();
            //GridSummaryItem summaryItemMaxOrderSum = dtgValReporte.GroupSummary.Add(DevExpress.Data.SummaryItemType.Max, "f1Volumen", null, "(Max Order Sum = {MAX Order Sum = {0:n0}})");
        }

        private DateTime FechaMaxima()
        {
            DateTime Fecha= DateTime.Now;
            CLS_Reporte_Inventario_Ventas sel = new CLS_Reporte_Inventario_Ventas();
            sel.MtdSeleccionarFechaMaxima();
            if(sel.Exito)
            {
                if(sel.Datos.Rows.Count>0)
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
            compositeLink.Links.Add(link1);
            compositeLink.Links.Add(link2);
            XlsxExportOptionsEx options = new XlsxExportOptionsEx();
            options.RawDataMode= false;
            options.ExportType = DevExpress.Export.ExportType.DataAware;
            options.ShowColumnHeaders=DevExpress.Utils.DefaultBoolean.True;
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
            VerificarDatos();
        }

        private void VerificarDatos()
        {
            CLS_Reporte_Inventario_Ventas sel = new CLS_Reporte_Inventario_Ventas();
            sel.Fecha1 = dtFecha1.DateTime.Year.ToString() + DosCeros(dtFecha1.DateTime.Month.ToString()) + DosCeros(dtFecha1.DateTime.Day.ToString());
            sel.Fecha2 = dtFecha2.DateTime.Year.ToString() + DosCeros(dtFecha2.DateTime.Month.ToString()) + DosCeros(dtFecha2.DateTime.Day.ToString());
            sel.MtdSeleccionarFechaValidar();
            if(sel.Exito)
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
            DateTime vFecha = dtFecha2.DateTime;
            switch (cmbComparar.SelectedIndex)
            {
                case 0:
                    dtFecha1.DateTime = vFecha.AddDays(-1);
                    break;
                case 1:
                    dtFecha1.DateTime = vFecha.AddDays(-3);
                    break;
                case 2:
                    dtFecha1.DateTime = vFecha.AddDays(-7);
                    break;
                case 3:
                    dtFecha1.DateTime = vFecha.AddDays(-14);
                    break;
                case 4:
                    dtFecha1.DateTime = vFecha.AddMonths(-1);
                    break;
                case 5:
                    dtFecha1.DateTime = vFecha.AddYears(-1);
                    break;
                default:
                    break;
            }
        }

        private void btnDashboard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Dashboard frm = new Frm_Dashboard();
            frm.ShowDialog();
        }
    }
}