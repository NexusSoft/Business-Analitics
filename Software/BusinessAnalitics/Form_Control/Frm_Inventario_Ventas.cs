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
using DevExpress.XtraEditors.Mask;
using System.Globalization;

namespace Business_Analitics
{
    public partial class Frm_Inventario_Ventas : DevExpress.XtraEditors.XtraForm
    {
        public NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        public CultureInfo culture = CultureInfo.CreateSpecificCulture("es-MX");
        public string UsuariosLogin { get; set; }
        public Frm_Inventario_Ventas()
        {
            InitializeComponent();
        }
        private static Frm_Inventario_Ventas m_FormDefInstance;
        public static Frm_Inventario_Ventas DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Inventario_Ventas();
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
        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            textId.Text = string.Empty;
            dtFecha.DateTime = DateTime.Now;
            CargarInventario_Ventas();
            CargarPais(null);
            CargarTratamiento(null);
            CargarTamanio();
            CargarCategoria(null);
            
        }

        private void CargarPais(string Valor)
        {
            CLS_Pais Clase = new CLS_Pais();
            Clase.MtdSeleccionarPais();
            if (Clase.Exito)
            {
                cmb_Pais.EditValue = null;
                cmb_Pais.Properties.DisplayMember = "Nombre_Pais";
                cmb_Pais.Properties.ValueMember = "Id_Pais";
                cmb_Pais.EditValue = Valor;
                cmb_Pais.Properties.DataSource = Clase.Datos;
            }
        }
        public void CargarTratamiento(string Valor)
        {
            CLS_Tratamiento Clase = new CLS_Tratamiento();
            Clase.MtdSeleccionarTratamiento();
            if (Clase.Exito)
            {
                cmb_Tratamiento.Properties.DisplayMember = "Nombre_Tratamiento";
                cmb_Tratamiento.Properties.ValueMember = "Id_Tratamiento";
                cmb_Tratamiento.EditValue = Valor;
                cmb_Tratamiento.Properties.DataSource = Clase.Datos;
            }
        }
        public void CargarTamanio()
        {
            CLS_Tamanio Clase = new CLS_Tamanio();
            Clase.MtdSeleccionarTamanio();
            if (Clase.Exito)
            {
                dtgTamanio.DataSource = Clase.Datos;
            }
        }
        public void CargarTamanioId(string vId_Tamanio)
        {
            CLS_Tamanio Clase = new CLS_Tamanio();
            Clase.Id_Registro = textId.Text;
            Clase.Id_Tamanio = vId_Tamanio;
            Clase.MtdSeleccionarTamanioId();
            if (Clase.Exito)
            {
                dtgTamanio.DataSource = Clase.Datos;
            }
        }
        public void CargarCategoria(string Valor)
        {
            CLS_Categoria Clase = new CLS_Categoria();
            Clase.MtdSeleccionarCategoria();
            if (Clase.Exito)
            {
                cmb_Categoria.Properties.DisplayMember = "Nombre_Categoria";
                cmb_Categoria.Properties.ValueMember = "Id_Categoria";
                cmb_Categoria.EditValue = Valor;
                cmb_Categoria.Properties.DataSource = Clase.Datos;
            }
        }
        public void CargarInventario_Ventas()
        {
            CLS_Inventario_Ventas Clase = new CLS_Inventario_Ventas();
            Clase.Fecha = dtFecha.DateTime.Year.ToString() + DosCeros(dtFecha.DateTime.Month.ToString()) + DosCeros(dtFecha.DateTime.Day.ToString());
            Clase.MtdSeleccionarInventario_Ventas();
            if (Clase.Exito)
            {
                dtg_Inventario_Ventas.DataSource = Clase.Datos;
            }
        }
        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea eliminar el dato seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {
                if (textId.Text.Trim().Length > 0)
                {
                    EliminarEmpresas();
                }
                else
                {
                    XtraMessageBox.Show("Es necesario seleccionar una Empresa.");
                }

            }
        }
        private void EliminarEmpresas()
        {
            CLS_Inventario_Ventas Empresas = new CLS_Inventario_Ventas();
            Empresas.Id_Registro = textId.Text.Trim();
            Empresas.MtdEliminarInventario_Ventas();
            if (Empresas.Exito)
            {
                XtraMessageBox.Show("Se ha Eliminado el registro con exito");
                btnLimpiar.PerformClick();
            }
            else
            {
                XtraMessageBox.Show(Empresas.Mensaje);
            }
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void Frm_Inventario_Ventas_Shown(object sender, EventArgs e)
        {
            LimpiarCampos();
            dtgVal_Inventario_Ventas.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgVal_Inventario_Ventas.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgVal_Inventario_Ventas.OptionsSelection.MultiSelect = true;
            dtgVal_Inventario_Ventas.OptionsView.ShowGroupPanel = false;
            dtgVal_Inventario_Ventas.OptionsBehavior.AutoPopulateColumns = true;
            dtgVal_Inventario_Ventas.OptionsView.ColumnAutoWidth = true;
            dtgVal_Inventario_Ventas.BestFitColumns();
            gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn10.DisplayFormat.FormatString = "n0";
            gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn11.DisplayFormat.FormatString = "c0";

            gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn14.DisplayFormat.FormatString = "n0";
            gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn15.DisplayFormat.FormatString = "c0";
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CamposVacios())
            {
                InsertarEmpresas();
            }
        }
        private void InsertarEmpresas()
        {
            CLS_Inventario_Ventas Ins = new CLS_Inventario_Ventas();
            Ins.Id_Registro = textId.Text.Trim();
            Ins.Fecha = dtFecha.DateTime.Year.ToString() + DosCeros(dtFecha.DateTime.Month.ToString()) + DosCeros(dtFecha.DateTime.Day.ToString());
            Ins.Id_Pais = cmb_Pais.EditValue.ToString();
            Ins.Id_Tratamiento = cmb_Tratamiento.EditValue.ToString();
            Ins.Id_Categoria = cmb_Categoria.EditValue.ToString();
            Ins.Usuario = UsuariosLogin.Trim();
            int x = 1;
            for (int i = 0; i < dtgValTamanio.DataRowCount; i++)
            {
                Ins.Id_Tamanio = dtgValTamanio.GetRowCellValue(i, dtgValTamanio.Columns["Id_Tamanio"]).ToString();
                decimal vVolumen = 0;
                Decimal.TryParse(dtgValTamanio.GetRowCellValue(i, dtgValTamanio.Columns["Inventario"]).ToString(), style, culture, out vVolumen);
                Ins.Volumen = vVolumen;
                decimal vVentas = 0;
                Decimal.TryParse(dtgValTamanio.GetRowCellValue(i, dtgValTamanio.Columns["Ventas"]).ToString(), style, culture, out vVentas);
                Ins.Venta = vVentas;
                Ins.MtdInsertarInventario_Ventas();
                if (!Ins.Exito)
                {
                    XtraMessageBox.Show(Ins.Mensaje);
                    break;
                    
                }
            }
            if(Ins.Exito)
            {
                CargarTamanio();
                CargarInventario_Ventas();
                XtraMessageBox.Show("Se ha insertado los registros con exito");
            }
        }
        //private void GuardarNPrecios()
        //{
        //    Costeo artprecio = new Costeo();
        //    artprecio.ArticuloCodigo = txtCodigo.Text.Trim();
        //    artprecio.PreciosUltimoDetallesIde = dtgValPrecios.RowCount;
        //    artprecio.MtdInsertarPrecios();
        //    if (artprecio.Exito)
        //    {
        //        if (artprecio.Datos.Rows.Count > 0)
        //        {
        //            int vPreciosId = Convert.ToInt32(artprecio.Datos.Rows[0][0].ToString());
        //            int x = 1;
        //            for (int i = 0; i < dtgValPrecios.DataRowCount; i++)
        //            {
        //                Costeo artprecioUp = new Costeo();
        //                artprecioUp.PreciosId = vPreciosId;
        //                artprecioUp.PreciosDetallesIde = x;
        //                artprecioUp.TarifaId = Convert.ToInt32(dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["TarifaId"]).ToString());
        //                decimal vDetallesPreciosVentaImporte = 0;
        //                Decimal.TryParse(dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["DetallesPreciosVentaImporte"]).ToString(), style, culture, out vDetallesPreciosVentaImporte);
        //                artprecioUp.DetallesPreciosVentaImporte = vDetallesPreciosVentaImporte;
        //                decimal vDetallesPreciosVenta = 0;
        //                Decimal.TryParse(dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["DetallesPreciosVenta"]).ToString(), style, culture, out vDetallesPreciosVenta);
        //                artprecioUp.DetallesPreciosVenta = vDetallesPreciosVenta;
        //                decimal vDetallesPreciosUtilidad = 0;
        //                Decimal.TryParse(dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["DetallesPreciosUtilidad"]).ToString(), style, culture, out vDetallesPreciosUtilidad);
        //                artprecioUp.DetallesPreciosUtilidad = vDetallesPreciosUtilidad;
        //                decimal vDetallesPreciosUMarginal = 0;
        //                Decimal.TryParse(dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["DetallesPreciosUMarginal"]).ToString(), style, culture, out vDetallesPreciosUMarginal);
        //                artprecioUp.DetallesPreciosUMarginal = vDetallesPreciosUMarginal;
        //                decimal vDetallesPreciosMinimo = 0;
        //                Decimal.TryParse(dtgValPrecios.GetRowCellValue(i, dtgValPrecios.Columns["DetallesPreciosMinimo"]).ToString(), style, culture, out vDetallesPreciosMinimo);
        //                artprecioUp.DetallesPreciosMinimo = vDetallesPreciosMinimo;
        //                x++;
        //                artprecioUp.MtdInsertarPreciosDetalles();
        //                if (!artprecioUp.Exito)
        //                {
        //                    XtraMessageBox.Show(artprecioUp.Mensaje);
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        XtraMessageBox.Show(artprecio.Mensaje);
        //    }

        //}
        private Boolean CamposVacios()
        {
            Boolean valor = true;
            try
            {
                if (!string.IsNullOrEmpty(cmb_Pais.EditValue.ToString()))
                {
                    if (!string.IsNullOrEmpty(cmb_Tratamiento.EditValue.ToString()))
                    {
                        if (!string.IsNullOrEmpty(cmb_Categoria.EditValue.ToString()))
                        {
                            valor = false;
                        }
                        else
                        {
                            XtraMessageBox.Show("No se ha seleccionado Categoria");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("No se ha seleccionado Tratamiento");
                    }
                }
                else
                {
                    XtraMessageBox.Show("No se ha seleccionado Pais");
                }
                return valor;
            }
            catch (Exception)
            {
                return valor;
            }
        }

        private void dtFecha_EditValueChanged(object sender, EventArgs e)
        {
            CargarInventario_Ventas();
        }

        private void dtg_Inventario_Ventas_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dtgVal_Inventario_Ventas.RowCount > 0)
                {
                    foreach (int i in this.dtgVal_Inventario_Ventas.GetSelectedRows())
                    {
                        DataRow row = this.dtgVal_Inventario_Ventas.GetDataRow(i);
                        textId.Text = row["Id_Registro"].ToString();
                        CargarPais(row["Id_Pais"].ToString());
                        CargarTratamiento(row["Id_Tratamiento"].ToString());
                        CargarCategoria(row["Id_Categoria"].ToString());
                        CargarTamanioId(row["Id_Tamanio"].ToString());
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