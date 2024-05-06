using Business_Analitics;
using CapaDeDatos;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessAnalitics
{
    public partial class Frm_Acarreo_Zona : DevExpress.XtraEditors.XtraForm
    {
        public Boolean PaSel { get; set; }
        public string IdPerfil { get; set; }
        public string UsuariosLogin { get; set; }
        private static Frm_Acarreo_Zona m_FormDefInstance;
        public static Frm_Acarreo_Zona DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Acarreo_Zona();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        public Frm_Acarreo_Zona()
        {
            InitializeComponent();
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            textId.Text = string.Empty;
            textNombre.Text = string.Empty;
        }
        private void InsertarEmpresaZona()
        {
            CLS_EmpresasAcarreo Empresas = new CLS_EmpresasAcarreo();
            Empresas.Id_EmpresaAcarreo_Zona = textId.Text.Trim();
            Empresas.v_nombre_zona = textNombre.Text.Trim();
            
            Empresas.MtdInsertarEmpresasZonas();
            if (Empresas.Exito)
            {
                CargarZonas();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Empresas.Mensaje);
            }
        }
        private void CargarZonas()
        {
            dtgZonas.DataSource = null;
            CLS_EmpresasAcarreo Empresas = new CLS_EmpresasAcarreo();

            Empresas.MtdSeleccionarEmpresasZonas();
            if (Empresas.Exito)
            {
                dtgZonas.DataSource = Empresas.Datos;
            }
        }
        private void EliminarZona()
        {
            CLS_EmpresasAcarreo Empresas = new CLS_EmpresasAcarreo();
            Empresas.Id_EmpresaAcarreo_Zona = textId.Text.Trim();
            Empresas.MtdEliminarEmpresasZonas();
            if (Empresas.Exito)
            {
                CargarZonas();
                XtraMessageBox.Show("Se ha Eliminado el registro con exito");
                LimpiarCampos();
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
                if (textId.Text.Trim().Length > 0)
                {
                    EliminarZona();
                }
                else
                {
                    XtraMessageBox.Show("Es necesario seleccionar una Zona.");
                }
            }
        }

        private void Frm_Acarreo_Zona_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarZonas();
            LimpiarCampos();
            dtgValZonas.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValZonas.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValZonas.OptionsSelection.EnableAppearanceFocusedRow = false;
        }

        private void dtgZonas_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValZonas.GetSelectedRows())
                {
                    DataRow row = this.dtgValZonas.GetDataRow(i);
                    textId.Text = row["Id_EmpresaAcarreo_Zona"].ToString();
                    textNombre.Text = row["v_nombre_zona"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textNombre.Text != string.Empty)
            {
                InsertarEmpresaZona();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre a la Zona.");
            }
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}