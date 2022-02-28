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
using DevExpress.XtraGrid.Views.Grid;

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

        public string vIdRegistro { get; private set; }
        public string vVolumen { get; private set; }
        public string vVenta { get; private set; }
        public bool PrimeraEdicion { get; private set; }

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
            //CLS_Categoria Clase2 = new CLS_Categoria();
            //Clase2.MtdSeleccionarCategoria();
            //if (Clase2.Exito)
            //{
            //    cmb_EditCategoria.DisplayMember = "Nombre_Categoria";
            //    cmb_EditCategoria.ValueMember = "Id_Categoria";
            //    //repositoryItemGridLookUpEdit1.e = Valor;
            //    cmb_EditCategoria.DataSource = Clase2.Datos;
            //}
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
        public void CargarTotalesPais()
        {
            CLS_Pais Clase = new CLS_Pais();
            Clase.Fecha = dtFecha.DateTime.Year.ToString() + DosCeros(dtFecha.DateTime.Month.ToString()) + DosCeros(dtFecha.DateTime.Day.ToString());
            Clase.MtdSeleccionarPaisInventario();
            if (Clase.Exito)
            {
                dtgPais_Inventario.DataSource = Clase.Datos;
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

            gridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn17.DisplayFormat.FormatString = "n0";
            gridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridColumn18.DisplayFormat.FormatString = "c0";
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
            if (Ins.Exito)
            {
                CargarTamanio();
                CargarInventario_Ventas();
                CargarTotalesPais();
                textId.Text = string.Empty;
                XtraMessageBox.Show("Se ha insertado los registros con exito");
            }
        }

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
            textId.Text = string.Empty;
            CargarInventario_Ventas();
            CargarTotalesPais();
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

        private void dtgTamanio_EditorKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!this.dtgValTamanio.IsLastVisibleRow)
                    this.dtgValTamanio.MoveNext();
                else
                    this.dtgValTamanio.MoveFirst();
            }
        }

        private void dtgVal_Inventario_Ventas_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgVal_Inventario_Ventas.GetSelectedRows())
                {
                    DataRow row = dtgVal_Inventario_Ventas.GetDataRow(i);
                    vIdRegistro = row["Id_Registro"].ToString();
                    vVolumen = row["Volumen"].ToString();
                    vVenta = row["Venta"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void dtgVal_Inventario_Ventas_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!PrimeraEdicion)
            {
                GridView gv = sender as GridView;
                CLS_Inventario_Ventas Ins = new CLS_Inventario_Ventas();
                Ins.Id_Registro = vIdRegistro;
                Ins.Fecha = string.Empty;
                Ins.Id_Pais = string.Empty;
                Ins.Id_Tratamiento = string.Empty;
                Ins.Id_Categoria = string.Empty;
                Ins.Id_Tamanio = string.Empty;
                Ins.Usuario = UsuariosLogin.Trim();

                if (e.Column.FieldName == "Volumen")
                {
                    PrimeraEdicion = true;
                    decimal v_Volumen = 0;
                    Decimal.TryParse(gv.GetRowCellValue(e.RowHandle, gv.Columns["Volumen"]).ToString(), style, culture, out v_Volumen);
                    Ins.Volumen = v_Volumen;
                    decimal vVentas = 0;
                    Decimal.TryParse(vVenta, style, culture, out vVentas);
                    Ins.Venta = vVentas;
                    Ins.MtdInsertarInventario_Ventas();
                    if (!Ins.Exito)
                    {
                        XtraMessageBox.Show(Ins.Mensaje);
                    }

                }
                if (e.Column.FieldName == "Venta")
                {
                    PrimeraEdicion = true;
                    decimal v_Volumen = 0;
                    Decimal.TryParse(vVolumen, style, culture, out v_Volumen);
                    Ins.Volumen = v_Volumen;
                    decimal vVentas = 0;
                    Decimal.TryParse(gv.GetRowCellValue(e.RowHandle, gv.Columns["Venta"]).ToString(), style, culture, out vVentas);
                    Ins.Venta = vVentas;
                    Ins.MtdInsertarInventario_Ventas();
                    if (!Ins.Exito)
                    {
                        XtraMessageBox.Show(Ins.Mensaje);
                    }
                }
                PrimeraEdicion = false;
            }
        }

        private void btnHistorial_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmHistorialInventario frm = new FrmHistorialInventario();
            frm.ShowDialog();
        }
    }
}