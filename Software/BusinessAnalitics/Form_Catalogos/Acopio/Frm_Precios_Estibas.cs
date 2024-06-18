using CapaDeDatos;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid.Views.Grid;
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

namespace BusinessAnalitics
{
    public partial class Frm_Precios_Estibas : DevExpress.XtraEditors.XtraForm
    {
        public string IdPerfil { get; set; }
        public string UsuariosLogin { get; set; }
        NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        CultureInfo provider = new CultureInfo("es-MX");
        private static Frm_Precios_Estibas m_FormDefInstance;
        public static Frm_Precios_Estibas DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Precios_Estibas();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        public bool PrimeraEdicion { get; set; }
        public Frm_Precios_Estibas()
        {
            InitializeComponent();
        }

        private void MakeTablaPreciosEstiba()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column = new DataColumn();
            table.Reset();

            // DataRow row;

            column.DataType = typeof(string);
            column.ColumnName = "c_codigo_tem";
            column.AutoIncrement = false;
            column.Caption = "Temporada";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "c_codigo_sel";
            column.AutoIncrement = false;
            column.Caption = "Estiba";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "v_nombrehuerta";
            column.AutoIncrement = false;
            column.Caption = "Nombre Huerta";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(DateTime);
            column.ColumnName = "d_fechaRecepcion";
            column.AutoIncrement = false;
            column.Caption = "Fecha Recepcion";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Cajas";
            column.AutoIncrement = false;
            column.Caption = "Cajas";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "n_kgRecepcion";
            column.AutoIncrement = false;
            column.Caption = "Kilos Recepcionados";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "n_kgProcesados";
            column.AutoIncrement = false;
            column.Caption = "Kilos Procesados";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "v_tipocorte";
            column.AutoIncrement = false;
            column.Caption = "Tipo de Corte";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Boolean);
            column.ColumnName = "b_pagocosecha";
            column.AutoIncrement = false;
            column.Caption = "Pago Cosecha";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Boolean);
            column.ColumnName = "b_pagoacarreo";
            column.AutoIncrement = false;
            column.Caption = "Pago Acarreo";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Boolean);
            column.ColumnName = "b_descuentocosecha";
            column.AutoIncrement = false;
            column.Caption = "Descuento Cosecha";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Boolean);
            column.ColumnName = "b_descuentoacarreo";
            column.AutoIncrement = false;
            column.Caption = "Descuento Acarreo";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "v_tipocamion";
            column.AutoIncrement = false;
            column.Caption = "Tipo Unidad";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Boolean);
            column.ColumnName = "b_PagoBanda";
            column.AutoIncrement = false;
            column.Caption = "Pago en Banda";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "n_preciocompra";
            column.AutoIncrement = false;
            column.Caption = "Precio Compra";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgPreciosEstiba.DataSource = table;
        }
        private void Frm_Precios_Estibas_Load(object sender, EventArgs e)
        {
            MakeTablaPreciosEstiba();

            dtgValPreciosEstiba.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            col_NHuerta.Caption = "Nombre " + Environment.NewLine + "Huerta";
            col_FRecepcion.Caption = "Fecha " + Environment.NewLine + "Recepcion";
            col_KRecepcionados.Caption = "Kilos " + Environment.NewLine + "Recepcionados";
            col_KProcesados.Caption = "Kilos " + Environment.NewLine + "Procesados";
            col_TCorte.Caption = "Tipo " + Environment.NewLine + "Corte";

           
            col_PCosecha.Caption = "Pago " + Environment.NewLine + "Cosecha";
            col_PAcarreo.Caption = "Pago " + Environment.NewLine + "Acarreo";
            col_DCosecha.Caption = "Descuento " + Environment.NewLine + "Cosecha";
            col_DAcarreo.Caption = "Descuento " + Environment.NewLine + "Acarreo";
            col_TUnidad.Caption = "Tipo " + Environment.NewLine + "Unidad";
            col_PCompra.Caption = "Precio " + Environment.NewLine + "Compra";


            dtgValPreciosEstiba.OptionsView.BestFitMaxRowCount = 0;
            dtgValPreciosEstiba.BestFitColumns();
            col_Cajas.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col_Cajas.DisplayFormat.FormatString = "n2";
            col_KProcesados.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col_KProcesados.DisplayFormat.FormatString = "n2";
            col_KRecepcionados.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col_KRecepcionados.DisplayFormat.FormatString = "n2";
            col_PCompra.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            col_PCompra.DisplayFormat.FormatString = "c2";
        }

        private void btnActualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CLS_AcarreroPrecios ins = new CLS_AcarreroPrecios();
            ins.MtdInsertarAcopioPrecioEstiba();
            if(ins.Exito)
            {
                XtraMessageBox.Show("se han actualizado las estibas con exito");
            }
            else
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void AgregarAGrid(DataTable datos)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                dtgValPreciosEstiba.AddNewRow();
                int rowHandle = dtgValPreciosEstiba.GetRowHandle(dtgValPreciosEstiba.DataRowCount);
                dtgValPreciosEstiba.SetRowCellValue(rowHandle, dtgValPreciosEstiba.Columns["c_codigo_tem"], datos.Rows[i]["c_codigo_tem"].ToString());
                dtgValPreciosEstiba.SetRowCellValue(rowHandle, dtgValPreciosEstiba.Columns["c_codigo_sel"], datos.Rows[i]["c_codigo_sel"].ToString());
                dtgValPreciosEstiba.SetRowCellValue(rowHandle, dtgValPreciosEstiba.Columns["v_nombrehuerta"], datos.Rows[i]["v_nombrehuerta"].ToString());
                dtgValPreciosEstiba.SetRowCellValue(rowHandle, dtgValPreciosEstiba.Columns["d_fechaRecepcion"], datos.Rows[i]["d_fechaRecepcion"].ToString());
                //dtgValPreciosEstiba.SetRowCellValue(rowHandle, dtgValPreciosEstiba.Columns["col_Temporada"], datos.Rows[i]["Semana"].ToString());
                //dtgValPreciosEstiba.SetRowCellValue(rowHandle, dtgValPreciosEstiba.Columns["col_Temporada"], datos.Rows[i]["Anio"].ToString());
                dtgValPreciosEstiba.SetRowCellValue(rowHandle, dtgValPreciosEstiba.Columns["Cajas"], datos.Rows[i]["Cajas"].ToString());
                dtgValPreciosEstiba.SetRowCellValue(rowHandle, dtgValPreciosEstiba.Columns["n_kgRecepcion"], datos.Rows[i]["n_kgRecepcion"].ToString());
                dtgValPreciosEstiba.SetRowCellValue(rowHandle, dtgValPreciosEstiba.Columns["n_kgProcesados"], datos.Rows[i]["n_kgProcesados"].ToString());
                dtgValPreciosEstiba.SetRowCellValue(rowHandle, dtgValPreciosEstiba.Columns["v_tipocorte"], datos.Rows[i]["v_tipocorte"].ToString());
                dtgValPreciosEstiba.SetRowCellValue(rowHandle, dtgValPreciosEstiba.Columns["b_pagocosecha"], datos.Rows[i]["b_pagocosecha"].ToString());
                dtgValPreciosEstiba.SetRowCellValue(rowHandle, dtgValPreciosEstiba.Columns["b_pagoacarreo"], datos.Rows[i]["b_pagoacarreo"].ToString());
                dtgValPreciosEstiba.SetRowCellValue(rowHandle, dtgValPreciosEstiba.Columns["b_descuentocosecha"], datos.Rows[i]["b_descuentocosecha"].ToString());
                dtgValPreciosEstiba.SetRowCellValue(rowHandle, dtgValPreciosEstiba.Columns["b_descuentoacarreo"], datos.Rows[i]["b_descuentoacarreo"].ToString());
                dtgValPreciosEstiba.SetRowCellValue(rowHandle, dtgValPreciosEstiba.Columns["v_tipocamion"], datos.Rows[i]["v_tipocamion"].ToString());
                dtgValPreciosEstiba.SetRowCellValue(rowHandle, dtgValPreciosEstiba.Columns["b_PagoBanda"], datos.Rows[i]["b_PagoBanda"].ToString());
                dtgValPreciosEstiba.SetRowCellValue(rowHandle, dtgValPreciosEstiba.Columns["n_preciocompra"], datos.Rows[i]["n_preciocompra"].ToString());
            }
            RepositoryItemComboBox _riEditor = new RepositoryItemComboBox();
            _riEditor.Items.AddRange(new string[] { "Rabon", "Torton", "Contenedor","Camioneta" });
            dtgPreciosEstiba.RepositoryItems.Add(_riEditor);
            dtgValPreciosEstiba.Columns["v_tipocamion"].ColumnEdit = _riEditor;
        }
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            CLS_AcarreroPrecios sel = new CLS_AcarreroPrecios();
            sel.Semana = Convert.ToInt32(sp_Semana.EditValue.ToString());
            sel.Anio = Convert.ToInt32(sp_Anio.EditValue.ToString());
            sel.MtdSeleccionarAcopioPreciosEstiba();
            if (sel.Exito)
            {
                dtgPreciosEstiba.DataSource = null;
                MakeTablaPreciosEstiba();
                PrimeraEdicion = true;
                AgregarAGrid(sel.Datos);
                PrimeraEdicion = false;
            }
            else
            {
                XtraMessageBox.Show(sel.Mensaje);
            }
        }

        private void dtgValPreciosEstiba_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!PrimeraEdicion)
            {
                GridView gv = sender as GridView;
                if (e.Column.FieldName == "b_pagocosecha")
                {
                    try
                    {
                        foreach (int i in this.dtgValPreciosEstiba.GetSelectedRows())
                        {
                            CLS_AcarreroPrecios ups = new CLS_AcarreroPrecios();
                            DataRow row = dtgValPreciosEstiba.GetDataRow(i);
                            ups.c_codigo_tem = row["c_codigo_tem"].ToString();
                            ups.c_codigo_sel = row["c_codigo_sel"].ToString();
                            if (row["b_pagocosecha"].ToString() == "True")
                            {
                                ups.b_pagocosecha = 1;
                            }
                            else
                            {
                                ups.b_pagocosecha = 0;
                            }
                            ups.MtdActualizarAcopioPreciosEstiba_b_pagocosecha();
                            if(!ups.Exito)
                            {
                                XtraMessageBox.Show(ups.Mensaje);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                    }
                }
                else if (e.Column.FieldName == "b_pagoacarreo")
                {
                    try
                    {
                        foreach (int i in this.dtgValPreciosEstiba.GetSelectedRows())
                        {
                            CLS_AcarreroPrecios ups = new CLS_AcarreroPrecios();
                            DataRow row = dtgValPreciosEstiba.GetDataRow(i);
                            ups.c_codigo_tem = row["c_codigo_tem"].ToString();
                            ups.c_codigo_sel = row["c_codigo_sel"].ToString();
                            if (row["b_pagoacarreo"].ToString() == "True")
                            {
                                ups.b_pagoacarreo = 1;
                            }
                            else
                            {
                                ups.b_pagoacarreo = 0;
                            }
                            ups.MtdActualizarAcopioPreciosEstiba_b_pagoacarreo();
                            if (!ups.Exito)
                            {
                                XtraMessageBox.Show(ups.Mensaje);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                    }
                }
                else if (e.Column.FieldName == "b_descuentocosecha")
                {
                    try
                    {
                        foreach (int i in this.dtgValPreciosEstiba.GetSelectedRows())
                        {
                            CLS_AcarreroPrecios ups = new CLS_AcarreroPrecios();
                            DataRow row = dtgValPreciosEstiba.GetDataRow(i);
                            ups.c_codigo_tem = row["c_codigo_tem"].ToString();
                            ups.c_codigo_sel = row["c_codigo_sel"].ToString();
                            if (row["b_descuentocosecha"].ToString() == "True")
                            {
                                ups.b_descuentocosecha = 1;
                            }
                            else
                            {
                                ups.b_descuentocosecha = 0;
                            }
                            ups.MtdActualizarAcopioPreciosEstiba_b_descuentocosecha();
                            if (!ups.Exito)
                            {
                                XtraMessageBox.Show(ups.Mensaje);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                    }
                }
                else if (e.Column.FieldName == "b_descuentoacarreo")
                {
                    try
                    {
                        foreach (int i in this.dtgValPreciosEstiba.GetSelectedRows())
                        {
                            CLS_AcarreroPrecios ups = new CLS_AcarreroPrecios();
                            DataRow row = dtgValPreciosEstiba.GetDataRow(i);
                            ups.c_codigo_tem = row["c_codigo_tem"].ToString();
                            ups.c_codigo_sel = row["c_codigo_sel"].ToString();
                            if (row["b_descuentoacarreo"].ToString() == "True")
                            {
                                ups.b_descuentoacarreo = 1;
                            }
                            else
                            {
                                ups.b_descuentoacarreo = 0;
                            }
                            ups.MtdActualizarAcopioPreciosEstiba_b_descuentoacarreo();
                            if (!ups.Exito)
                            {
                                XtraMessageBox.Show(ups.Mensaje);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                    }
                }
                else if (e.Column.FieldName == "b_PagoBanda")
                {
                    try
                    {
                        foreach (int i in this.dtgValPreciosEstiba.GetSelectedRows())
                        {
                            CLS_AcarreroPrecios ups = new CLS_AcarreroPrecios();
                            DataRow row = dtgValPreciosEstiba.GetDataRow(i);
                            ups.c_codigo_tem = row["c_codigo_tem"].ToString();
                            ups.c_codigo_sel = row["c_codigo_sel"].ToString();
                            if (row["b_PagoBanda"].ToString() == "True")
                            {
                                ups.b_PagoBanda = 1;
                                PrimeraEdicion = true;
                                gv.SetRowCellValue(e.RowHandle, gv.Columns["n_preciocompra"], 0);
                                ups.n_preciocompra = Convert.ToDecimal(row["n_preciocompra"].ToString());
                                PrimeraEdicion =false;
                            }
                            else
                            {
                                ups.b_PagoBanda = 0;
                            }
                            ups.MtdActualizarAcopioPreciosEstiba_b_PagoBanda();
                            if (!ups.Exito)
                            {
                                XtraMessageBox.Show(ups.Mensaje);
                            }
                            ups.MtdActualizarAcopioPreciosEstiba_n_preciocompra();
                            if (!ups.Exito)
                            {
                                XtraMessageBox.Show(ups.Mensaje);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                    }
                }
                else if (e.Column.FieldName == "v_tipocamion")
                {
                    try
                    {
                        foreach (int i in this.dtgValPreciosEstiba.GetSelectedRows())
                        {
                            CLS_AcarreroPrecios ups = new CLS_AcarreroPrecios();
                            DataRow row = dtgValPreciosEstiba.GetDataRow(i);
                            ups.c_codigo_tem = row["c_codigo_tem"].ToString();
                            ups.c_codigo_sel = row["c_codigo_sel"].ToString();
                            ups.v_tipocamion = row["v_tipocamion"].ToString();
                            ups.MtdActualizarAcopioPreciosEstiba_v_tipocamion();
                            if (!ups.Exito)
                            {
                                XtraMessageBox.Show(ups.Mensaje);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                    }
                }
                else if (e.Column.FieldName == "n_preciocompra")
                {
                    try
                    {
                        foreach (int i in this.dtgValPreciosEstiba.GetSelectedRows())
                        {
                            CLS_AcarreroPrecios ups = new CLS_AcarreroPrecios();
                            DataRow row = dtgValPreciosEstiba.GetDataRow(i);
                            ups.c_codigo_tem = row["c_codigo_tem"].ToString();
                            ups.c_codigo_sel = row["c_codigo_sel"].ToString();
                            ups.n_preciocompra =Convert.ToDecimal(row["n_preciocompra"].ToString());
                            ups.MtdActualizarAcopioPreciosEstiba_n_preciocompra();
                            if (!ups.Exito)
                            {
                                XtraMessageBox.Show(ups.Mensaje);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btn_Guardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraMessageBox.Show("Se guardaron los datos con exito");
        }
    }
}