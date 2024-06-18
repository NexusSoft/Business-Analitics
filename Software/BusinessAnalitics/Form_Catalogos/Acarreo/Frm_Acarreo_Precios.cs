using CapaDeDatos;
using DevExpress.CodeParser.VB;
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
using DevExpress.Utils;

namespace BusinessAnalitics.Form_Catalogos.Acarreo
{
    public partial class Frm_Acarreo_Precios : DevExpress.XtraEditors.XtraForm
    {
        public Boolean PaSel { get; set; }
        public string IdPerfil { get; set; }
        public string UsuariosLogin { get; set; }
        public string c_codigo_est { get; set; }
        NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        CultureInfo provider = new CultureInfo("es-MX");
        private static Frm_Acarreo_Precios m_FormDefInstance;
        public static Frm_Acarreo_Precios DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Acarreo_Precios();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public Frm_Acarreo_Precios()
        {
            InitializeComponent();
        }
 
        void CargarPrecios()
        {
            dtgAcarreoPrecios.DataSource = null;
            CLS_EmpresasAcarreo Empresas = new CLS_EmpresasAcarreo();

            Empresas.MtdSeleccionarEmpresasPrecios();
            if (Empresas.Exito)
            {
                dtgAcarreoPrecios.DataSource = Empresas.Datos;
            }
        }
        private void Frm_Acarreo_Precios_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
            CargarPrecios();
            dtgValAcarreoPrecios.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValAcarreoPrecios.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValAcarreoPrecios.OptionsSelection.EnableAppearanceFocusedRow = false;
            gridColumn11.DisplayFormat.FormatType = FormatType.Numeric;
            gridColumn11.DisplayFormat.FormatString = "n2";
            gridColumn12.DisplayFormat.FormatType = FormatType.Numeric;
            gridColumn12.DisplayFormat.FormatString = "c2";
            gridColumn13.DisplayFormat.FormatType = FormatType.Numeric;
            gridColumn13.DisplayFormat.FormatString = "c2";
            gridColumn14.DisplayFormat.FormatType = FormatType.Numeric;
            gridColumn14.DisplayFormat.FormatString = "c2";
        }

        private void LimpiarCampos()
        {
            CargarZonas("01");
            CargarEstados("16");
            CargarCiudad(null);
            txt_Id.Text = string.Empty;
            txt_km.Text = "0";
            txt_Rabon.Text = "0";
            txt_Torton.Text = "0";
            txt_Contenedor.Text = "0";
            cmb_ciudad.Properties.DataSource = null;
        }

        private void CargarZonas(string Valor)
        {
            CLS_EmpresasAcarreo obtener = new CLS_EmpresasAcarreo();
            obtener.MtdSeleccionarEmpresasZonas();
            if (obtener.Exito)
            {
                if (obtener.Datos.Rows.Count > 0)
                {
                    cmb_zona.Properties.DisplayMember = "v_nombre_zona";
                    cmb_zona.Properties.ValueMember = "Id_EmpresaAcarreo_Zona";
                    cmb_zona.EditValue = Valor;
                    cmb_zona.Properties.DataSource = obtener.Datos;
                }
            }
        }
        private void CargarEstados(string Valor)
        {
            CLS_EmpresasAcarreo obtener = new CLS_EmpresasAcarreo();
            obtener.MtdSeleccionarEmpresasEstado();
            if (obtener.Exito)
            {
                if (obtener.Datos.Rows.Count > 0)
                {
                    cmb_estado.Properties.DisplayMember = "v_nombre_est";
                    cmb_estado.Properties.ValueMember = "c_codigo_est";
                    cmb_estado.EditValue = Valor;
                    cmb_estado.Properties.DataSource = obtener.Datos;
                }
            }
        }
        private void CargarCiudad(string Valor)
        {
            CLS_EmpresasAcarreo obtener = new CLS_EmpresasAcarreo();
            obtener.c_codigo_est = c_codigo_est;
            obtener.MtdSeleccionarEmpresasCiudad();
            if (obtener.Exito)
            {
                if (obtener.Datos.Rows.Count > 0)
                {
                    cmb_ciudad.Properties.DisplayMember = "v_nombre_ciu";
                    cmb_ciudad.Properties.ValueMember = "c_codigo_ciu";
                    cmb_ciudad.EditValue = Valor;
                    cmb_ciudad.Properties.DataSource = obtener.Datos;
                }
            }
        }

        private void cmb_estado_EditValueChanged(object sender, EventArgs e)
        {
            if(cmb_estado.EditValue!=null)
            {
                c_codigo_est= cmb_estado.EditValue.ToString();
                CargarCiudad(null);
            }
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarCampos();
        }

        bool ValidaDatos()
        {
            Boolean is_valido = true;
            if(cmb_zona.EditValue!=null) 
            {
                if (cmb_estado.EditValue != null)
                {
                    if (cmb_ciudad.EditValue != null)
                    {
                        is_valido = true;
                    }
                    else
                    {
                        XtraMessageBox.Show("no se ha seleccionado una ciudad");
                    }
                }
                else
                {
                    XtraMessageBox.Show("No se ha seleccionado un estado");
                }
            }
            else
            {
                XtraMessageBox.Show("No se ha seleccionado una zona");
            }
            return is_valido;
        }
        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(ValidaDatos())
            {
                InsertarEmpresaPrecios();
            }
        }
        private void InsertarEmpresaPrecios()
        {
            CLS_EmpresasAcarreo Empresas = new CLS_EmpresasAcarreo();
            Empresas.Id_EmpresaAcarreo_Precios = txt_Id.Text.Trim();
            Empresas.Id_EmpresaAcarreo_Zona = cmb_zona.EditValue.ToString();
            Empresas.c_codigo_est = cmb_estado.EditValue.ToString();
            Empresas.v_nombre_est = cmb_estado.Text.Trim();
            Empresas.c_codigo_ciu = cmb_ciudad.EditValue.ToString();
            Empresas.v_nombre_ciu = cmb_ciudad.Text.Trim();
            Empresas.Km = decimal.Parse(txt_km.Text.Trim(),style,provider);
            Empresas.Rabon = decimal.Parse(txt_Rabon.Text.Trim(), style, provider);
            Empresas.Torton = decimal.Parse(txt_Torton.Text.Trim(), style, provider);
            Empresas.Contenedor = decimal.Parse(txt_Contenedor.Text.Trim(), style, provider);

            Empresas.MtdInsertarEmpresasPrecios();
            if (Empresas.Exito)
            {
                CargarPrecios();
                LimpiarCampos();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
            }
            else
            {
                XtraMessageBox.Show(Empresas.Mensaje);
            }
        }
        private void EliminarPrecio()
        {
            CLS_EmpresasAcarreo Empresas = new CLS_EmpresasAcarreo();
            Empresas.Id_EmpresaAcarreo_Precios = txt_Id.Text.Trim();
            Empresas.MtdEliminarEmpresasPrecios();
            if (Empresas.Exito)
            {
                CargarPrecios();
                LimpiarCampos();
                XtraMessageBox.Show("Se ha Eliminado el registro con exito");
            }
            else
            {
                XtraMessageBox.Show(Empresas.Mensaje);
            }
        }
        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea eliminar el dato seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {
                if (txt_Id.Text.Trim().Length > 0)
                {
                    EliminarPrecio();
                }
                else
                {
                    XtraMessageBox.Show("Es necesario seleccionar una Zona.");
                }
            }
        }

        private void dtgAcarreoPrecios_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValAcarreoPrecios.GetSelectedRows())
                {
                    DataRow row = this.dtgValAcarreoPrecios.GetDataRow(i);
                    txt_Id.Text = row["Id_EmpresaAcarreo_Precios"].ToString();
                    CargarZonas(row["Id_EmpresaAcarreo_Zona"].ToString());
                    CargarEstados(row["c_codigo_est"].ToString());
                    //textNombre.Text = row["v_nombre_est"].ToString();
                    CargarCiudad(row["c_codigo_ciu"].ToString());
                    //textNombre.Text = row["v_nombre_ciu"].ToString();
                    txt_km.Text = row["Km"].ToString();
                    txt_Rabon.Text = row["Rabon"].ToString();

                    txt_Torton.Text = row["Torton"].ToString();
                    txt_Contenedor.Text = row["Contenedor"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}