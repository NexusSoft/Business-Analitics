using CapaDeDatos;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Business_Analitics
{
    public partial class Frm_Relacion_Acumulada : DevExpress.XtraEditors.XtraForm
    {
        public string UsuariosLogin { get; set; }
        public string IdPerfil { get; set; }
        private static Frm_Relacion_Acumulada m_FormDefInstance;
        public static Frm_Relacion_Acumulada DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Relacion_Acumulada();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        public Frm_Relacion_Acumulada()
        {
            InitializeComponent();
        }
        private void MakeTablaDetallado()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column;
            table.Reset();

            // DataRow row;
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Id_Cosecha";
            column.AutoIncrement = false;
            column.Caption = "Id_Cosecha";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "EstibadeSeleccion";
            column.AutoIncrement = false;
            column.Caption = "EstibadeSeleccion";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Huerta";
            column.AutoIncrement = false;
            column.Caption = "Huerta";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Semana";
            column.AutoIncrement = false;
            column.Caption = "Semana";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(DateTime);
            column.ColumnName = "RecepcionFecha";
            column.AutoIncrement = false;
            column.Caption = "RecepcionFecha";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "KilosFacturados";
            column.AutoIncrement = false;
            column.Caption = "KilosFacturados";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "KilosRecibidos";
            column.AutoIncrement = false;
            column.Caption = "KilosRecibidos";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "Preciokg";
            column.AutoIncrement = false;
            column.Caption = "Preciokg";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "TotalaPagar";
            column.AutoIncrement = false;
            column.Caption = "TotalaPagar";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "TotalaPagarUSD";
            column.AutoIncrement = false;
            column.Caption = "TotalaPagarUSD";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "TotalCorte";
            column.AutoIncrement = false;
            column.Caption = "TotalCorte";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "TotalCorteUSD";
            column.AutoIncrement = false;
            column.Caption = "TotalCorteUSD";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "TotalAcarreo";
            column.AutoIncrement = false;
            column.Caption = "TotalAcarreo";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "TotalAcarreoUSD";
            column.AutoIncrement = false;
            column.Caption = "TotalAcarreoUSD";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "SemanaTC";
            column.AutoIncrement = false;
            column.Caption = "SemanaTC";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "TipoCambio";
            column.AutoIncrement = false;
            column.Caption = "TipoCambio";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgCortesDetallado.DataSource = table;
        }
        private void MakeTablaAcumulado()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column;
            table.Reset();

            // DataRow row;
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Id_Cosecha";
            column.AutoIncrement = false;
            column.Caption = "Id_Cosecha";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "EstibadeSeleccion";
            column.AutoIncrement = false;
            column.Caption = "EstibadeSeleccion";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Huerta";
            column.AutoIncrement = false;
            column.Caption = "Huerta";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Semana";
            column.AutoIncrement = false;
            column.Caption = "Semana";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);



            column = new DataColumn();
            column.DataType = typeof(DateTime);
            column.ColumnName = "RecepcionFecha";
            column.AutoIncrement = false;
            column.Caption = "RecepcionFecha";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "KilosFacturados";
            column.AutoIncrement = false;
            column.Caption = "KilosFacturados";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "KilosRecibidos";
            column.AutoIncrement = false;
            column.Caption = "KilosRecibidos";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "Preciokg";
            column.AutoIncrement = false;
            column.Caption = "Preciokg";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "TotalaPagar";
            column.AutoIncrement = false;
            column.Caption = "TotalaPagar";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "TotalaPagarUSD";
            column.AutoIncrement = false;
            column.Caption = "TotalaPagarUSD";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "TotalCorte";
            column.AutoIncrement = false;
            column.Caption = "TotalCorte";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "TotalCorteUSD";
            column.AutoIncrement = false;
            column.Caption = "TotalCorteUSD";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "TotalAcarreo";
            column.AutoIncrement = false;
            column.Caption = "TotalAcarreo";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "TotalAcarreoUSD";
            column.AutoIncrement = false;
            column.Caption = "TotalAcarreoUSD";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "SemanaTC";
            column.AutoIncrement = false;
            column.Caption = "SemanaTC";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "TipoCambio";
            column.AutoIncrement = false;
            column.Caption = "TipoCambio";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgCorteAcumulado.DataSource = table;
        }
        private void Frm_Relacion_Acumulada_Shown(object sender, EventArgs e)
        {
            gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn8.DisplayFormat.FormatString = "$ ###,###0.00";
            gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn9.DisplayFormat.FormatString = "$ ###,###0.00";
            gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn10.DisplayFormat.FormatString = "$ ###,###0.00";
            gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn11.DisplayFormat.FormatString = "$ ###,###0.00";
            gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn12.DisplayFormat.FormatString = "$ ###,###0.00";
            gridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn27.DisplayFormat.FormatString = "$ ###,###0.00";
            gridColumn28.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn28.DisplayFormat.FormatString = "$ ###,###0.00";
            gridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn18.DisplayFormat.FormatString = "$ ###,###0.00";
            gridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn19.DisplayFormat.FormatString = "$ ###,###0.00";
            gridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn20.DisplayFormat.FormatString = "$ ###,###0.00";
            gridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn21.DisplayFormat.FormatString = "$ ###,###0.00";
            gridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn22.DisplayFormat.FormatString = "$ ###,###0.00";
            gridColumn23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn23.DisplayFormat.FormatString = "$ ###,###0.00";
            gridColumn24.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn24.DisplayFormat.FormatString = "$ ###,###0.00";
            dt_FechaDesde.DateTime = DateTime.Now;
            dt_FechaHasta.DateTime = DateTime.Now;
            MakeTablaDetallado();
            MakeTablaAcumulado();
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
        void AcumularCortes(DataTable datos)
        {

            decimal TotalaPagar = 0;
            decimal TotalCorte = 0;
            decimal TotalAcarreo = 0;

            decimal TotalaPagarUSD = 0;
            decimal TotalCorteUSD = 0;
            decimal TotalAcarreoUSD = 0;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                string Id_Cosecha = datos.Rows[i]["Id_Cosecha"].ToString().Trim();
                string EstibadeSeleccion = datos.Rows[i]["EstibadeSeleccion"].ToString().Trim();
                string Huerta = datos.Rows[i]["Huerta"].ToString().Trim();
                string Semana = datos.Rows[i]["Semana"].ToString().Trim();
                string RecepcionFecha = datos.Rows[i]["RecepcionFecha"].ToString().Trim();
                string KilosFacturados = datos.Rows[i]["KilosFacturados"].ToString().Trim();
                string KilosRecibidos = datos.Rows[i]["KilosRecibidos"].ToString().Trim();
                decimal Preciokg = Convert.ToDecimal(datos.Rows[i]["Preciokg"].ToString().Trim());
                TotalaPagar += Convert.ToDecimal(datos.Rows[i]["TotalaPagar"].ToString().Trim());
                TotalCorte += Convert.ToDecimal(datos.Rows[i]["TotalCorte"].ToString().Trim());
                TotalAcarreo += Convert.ToDecimal(datos.Rows[i]["TotalAcarreo"].ToString().Trim());
                string SemanaTC = datos.Rows[i]["SemanaTC"].ToString().Trim();
                decimal TipoCambio = Convert.ToDecimal(datos.Rows[i]["TipoCambio"].ToString().Trim());
                TotalaPagarUSD += Convert.ToDecimal(datos.Rows[i]["TotalaPagarUSD"].ToString().Trim());
                TotalCorteUSD += Convert.ToDecimal(datos.Rows[i]["TotalCorteUSD"].ToString().Trim());
                TotalAcarreoUSD += Convert.ToDecimal(datos.Rows[i]["TotalAcarreoUSD"].ToString().Trim());

                CreatNewRowCorte(Id_Cosecha, EstibadeSeleccion, Huerta, Semana, RecepcionFecha, KilosFacturados
                , KilosRecibidos, Preciokg, TotalaPagar, TotalCorte, TotalAcarreo, SemanaTC, TipoCambio,
                TotalaPagarUSD, TotalCorteUSD, TotalAcarreoUSD);
            }

        }
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            CLS_Cosecha_Reportes sel = new CLS_Cosecha_Reportes();
            sel.Fecha_Inicio = dt_FechaDesde.DateTime.Year.ToString() + DosCero(dt_FechaDesde.DateTime.Month.ToString()) + DosCero(dt_FechaDesde.DateTime.Day.ToString());
            sel.Fecha_Fin = dt_FechaHasta.DateTime.Year.ToString() + DosCero(dt_FechaHasta.DateTime.Month.ToString()) + DosCero(dt_FechaHasta.DateTime.Day.ToString());
            sel.MtdSelecccionarRelacionAcumulada();
            if (sel.Exito)
            {
                dtgCortesDetallado.DataSource = sel.Datos;
                AcumularCortes(sel.Datos);
            }
        }
        private void CreatNewRowCorte(string Id_Cosecha, string EstibadeSeleccion, string Huerta, string Semana, string RecepcionFecha, string KilosFacturados
            , string KilosRecibidos, decimal Preciokg, decimal TotalaPagar, decimal TotalCorte, decimal TotalAcarreo, string SemanaTC, decimal TipoCambio,
            decimal TotalaPagarUSD, decimal TotalCorteUSD, decimal TotalAcarreoUSD)
        {
            dtgValCorteAcumulado.AddNewRow();
            int rowHandle = dtgValCorteAcumulado.GetRowHandle(dtgValCorteAcumulado.DataRowCount);
            if (dtgValCorteAcumulado.IsNewItemRow(rowHandle))
            {
                dtgValCorteAcumulado.SetRowCellValue(rowHandle, dtgValCorteAcumulado.Columns["Id_Cosecha"], Id_Cosecha);
                dtgValCorteAcumulado.SetRowCellValue(rowHandle, dtgValCorteAcumulado.Columns["EstibadeSeleccion"], EstibadeSeleccion);
                dtgValCorteAcumulado.SetRowCellValue(rowHandle, dtgValCorteAcumulado.Columns["Huerta"], Huerta);
                dtgValCorteAcumulado.SetRowCellValue(rowHandle, dtgValCorteAcumulado.Columns["Semana"], Semana);
                dtgValCorteAcumulado.SetRowCellValue(rowHandle, dtgValCorteAcumulado.Columns["RecepcionFecha"], RecepcionFecha);
                dtgValCorteAcumulado.SetRowCellValue(rowHandle, dtgValCorteAcumulado.Columns["KilosFacturados"], KilosFacturados);
                dtgValCorteAcumulado.SetRowCellValue(rowHandle, dtgValCorteAcumulado.Columns["KilosRecibidos"], KilosRecibidos);
                dtgValCorteAcumulado.SetRowCellValue(rowHandle, dtgValCorteAcumulado.Columns["Preciokg"], Preciokg);
                dtgValCorteAcumulado.SetRowCellValue(rowHandle, dtgValCorteAcumulado.Columns["TotalaPagar"], TotalaPagar);
                dtgValCorteAcumulado.SetRowCellValue(rowHandle, dtgValCorteAcumulado.Columns["TotalCorte"], TotalCorte);
                dtgValCorteAcumulado.SetRowCellValue(rowHandle, dtgValCorteAcumulado.Columns["TotalAcarreo"], TotalAcarreo);
                dtgValCorteAcumulado.SetRowCellValue(rowHandle, dtgValCorteAcumulado.Columns["SemanaTC"], SemanaTC);
                dtgValCorteAcumulado.SetRowCellValue(rowHandle, dtgValCorteAcumulado.Columns["TipoCambio"], TipoCambio);
                dtgValCorteAcumulado.SetRowCellValue(rowHandle, dtgValCorteAcumulado.Columns["TotalaPagarUSD"], TotalaPagarUSD);
                dtgValCorteAcumulado.SetRowCellValue(rowHandle, dtgValCorteAcumulado.Columns["TotalCorteUSD"], TotalCorteUSD);
                dtgValCorteAcumulado.SetRowCellValue(rowHandle, dtgValCorteAcumulado.Columns["TotalAcarreoUSD"], TotalAcarreoUSD);
            }
        }

        private void dt_FechaDesde_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void dt_FechaHasta_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dt_FechaDesde.DateTime = DateTime.Now;
            dt_FechaHasta.DateTime = DateTime.Now;
            dtgCorteAcumulado.DataSource = null;
            dtgCortesDetallado.DataSource = null;
            MakeTablaDetallado();
            MakeTablaAcumulado();
        }

        private void dt_FechaDesde_EditValueChanged(object sender, EventArgs e)
        {
            DateTime Fecha = dt_FechaDesde.DateTime;
            int Semana = CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(Fecha, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            txtSemana.EditValue = Semana;
        }

        private void btnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {
                if (dtgValCorteAcumulado.RowCount > 0)
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
                                    dtgValCorteAcumulado.ExportToXls(exportFilePath);
                                    break;
                                case ".xlsx":
                                    dtgValCorteAcumulado.ExportToXlsx(exportFilePath);
                                    break;
                                case ".rtf":
                                    dtgValCorteAcumulado.ExportToRtf(exportFilePath);
                                    break;
                                case ".pdf":
                                    dtgValCorteAcumulado.ExportToPdf(exportFilePath);
                                    break;
                                case ".html":
                                    dtgValCorteAcumulado.ExportToHtml(exportFilePath);
                                    break;
                                case ".mht":
                                    dtgValCorteAcumulado.ExportToMht(exportFilePath);
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
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
            {
                if (dtgValCortesDetallado.RowCount > 0)
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
                                    dtgValCortesDetallado.ExportToXls(exportFilePath);
                                    break;
                                case ".xlsx":
                                    dtgValCortesDetallado.ExportToXlsx(exportFilePath);
                                    break;
                                case ".rtf":
                                    dtgValCortesDetallado.ExportToRtf(exportFilePath);
                                    break;
                                case ".pdf":
                                    dtgValCortesDetallado.ExportToPdf(exportFilePath);
                                    break;
                                case ".html":
                                    dtgValCortesDetallado.ExportToHtml(exportFilePath);
                                    break;
                                case ".mht":
                                    dtgValCortesDetallado.ExportToMht(exportFilePath);
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

        }
    }
}