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

namespace Business_Analitics
{
    public partial class Frm_ConfigCalibres : DevExpress.XtraEditors.XtraForm
    {
        public string UsuariosLogin { get; internal set; }

        public Frm_ConfigCalibres()
        {
            InitializeComponent();
        }

        private void Frm_ConfigCalibres_Shown(object sender, EventArgs e)
        {
            CargarTipoCorte(string.Empty);
            CargarConfiguracion();
            txt_Calibre.Visible = false;
            txt_Calibre.Text = string.Empty;
            txt_Calibre.Tag = string.Empty;
        }
        private void CargarTipoCorte(string Valor)
        {
            CLS_ConfigTipoC_Tamanio obtener = new CLS_ConfigTipoC_Tamanio();
            obtener.MtdSeleccionarTipoCorte();
            if (obtener.Exito)
            {
                if (obtener.Datos.Rows.Count > 0)
                {
                    cmbTipoCorte.Properties.DisplayMember = "v_nombre_tipocorte"; 
                    cmbTipoCorte.Properties.ValueMember = "c_codigo_tipocorte";
                    cmbTipoCorte.EditValue = Valor;
                    cmbTipoCorte.Properties.DataSource = obtener.Datos;
                }
            }
        }
        private void CargarTamanio(string Valor)
        {
            CLS_ConfigTipoC_Tamanio obtener = new CLS_ConfigTipoC_Tamanio();
            obtener.c_codigo_tipocorte = cmbTipoCorte.EditValue.ToString();
            obtener.MtdSeleccionarTamanios();
            if (obtener.Exito)
            {
                if (obtener.Datos.Rows.Count > 0)
                {
                    cmbCalibre.Properties.DisplayMember = "v_nombre_tam"; 
                    cmbCalibre.Properties.ValueMember = "c_codigo_tam";
                    cmbCalibre.EditValue = Valor;
                    cmbCalibre.Properties.DataSource = obtener.Datos;
                }
            }
        }

        private void cmbTipoCorte_EditValueChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(cmbTipoCorte.EditValue.ToString()))
            {
                CargarTamanio(string.Empty);
            }
        }
        private void CargarConfiguracion()
        {
            CLS_ConfigTipoC_Tamanio obtener = new CLS_ConfigTipoC_Tamanio();
            obtener.MtdSeleccionarTipoCorte_Tamanio();
            if (obtener.Exito)
            {
                if (obtener.Datos.Rows.Count > 0)
                {
                    dtgCortesTamanio.DataSource = obtener.Datos;
                }
            }
        }
        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if( !string.IsNullOrEmpty(cmbTipoCorte.EditValue.ToString())&& !string.IsNullOrEmpty(cmbCalibre.EditValue.ToString()))
            {
                CLS_ConfigTipoC_Tamanio ins = new CLS_ConfigTipoC_Tamanio();
                ins.c_codigo_tam = cmbCalibre.EditValue.ToString();
                ins.v_nombre_tam = cmbCalibre.Text;
                ins.c_codigo_tipocorte = cmbTipoCorte.EditValue.ToString();
                ins.v_nombre_tipocorte = cmbTipoCorte.Text;
                ins.Id_Usuario = UsuariosLogin;
                ins.MtdInsertarTipoCorte_Tamanio();
                if(ins.Exito)
                {
                    XtraMessageBox.Show("Se guardo el registro con exito");
                    CargarTamanio(string.Empty);
                }
                else
                {
                    XtraMessageBox.Show(ins.Mensaje);
                }
            }
            CargarConfiguracion();
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbTipoCorte.EditValue.ToString()) && !string.IsNullOrEmpty(txt_Calibre.Tag.ToString()))
            {
                DialogResult dialogResult = MessageBox.Show("Deseas eliminar el registro seleccionado", "Eliminación de registros", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    CLS_ConfigTipoC_Tamanio ins = new CLS_ConfigTipoC_Tamanio();
                    ins.c_codigo_tam = txt_Calibre.Tag.ToString();
                    ins.c_codigo_tipocorte = cmbTipoCorte.EditValue.ToString();
                    ins.MtdEliminarTipoCorte_Tamanio();
                    if (ins.Exito)
                    {
                        XtraMessageBox.Show("Se elimino el registro con exito");
                        btnLimpiar.PerformClick();
                        CargarConfiguracion();
                    }
                    else
                    {
                        XtraMessageBox.Show(ins.Mensaje);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("No se ha seleccionado registro");
            }
        }

        private void dtgCortesTamanio_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CargarTipoCorte(string.Empty);
            txt_Calibre.Visible = false;
            txt_Calibre.Text = string.Empty;
            txt_Calibre.Tag = string.Empty;
        }

        private void dtgCortesTamanio_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValCortesTamanio.GetSelectedRows())
                {
                    DataRow row = this.dtgValCortesTamanio.GetDataRow(i);
                    CargarTipoCorte(row["c_codigo_tipocorte"].ToString());
                    txt_Calibre.Visible = true;
                    txt_Calibre.Tag = row["c_codigo_tam"].ToString();
                    txt_Calibre.Text = row["v_nombre_tam"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}