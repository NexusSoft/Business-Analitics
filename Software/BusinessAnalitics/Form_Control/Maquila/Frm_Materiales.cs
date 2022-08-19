using CapaDeDatos;
using DevExpress.XtraEditors;
using System;
using System.Data;

namespace Business_Analitics
{
    public partial class Frm_Materiales : DevExpress.XtraEditors.XtraForm
    {
        public int v_Opcion { get; set; }
        public string vc_codigo_mat { get; set; }
        public Frm_Materiales()
        {
            InitializeComponent();
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
        private void Frm_Materiales_Shown(object sender, EventArgs e)
        {
            dtgValMaterial.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValMaterial.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValMaterial.OptionsSelection.MultiSelect = true;
            dtgValMaterial.OptionsView.ShowGroupPanel = false;
            CargarMaterial();
        }

        private void btnAgregarMaterial_Click(object sender, EventArgs e)
        {
            Frm_Productos frm = new Frm_Productos();
            frm.Opcion = v_Opcion;
            frm.ShowDialog();
            CargarMaterial();
        }
        private void CargarMaterial()
        {
            CLS_Parametros sel = new CLS_Parametros();
            sel.c_codigo_tmat = DosCeros(v_Opcion.ToString());
            sel.MtdSeleccionarParametroMaterial();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    dtgMaterial.DataSource = sel.Datos;
                }
            }
            else
            {
                XtraMessageBox.Show(sel.Mensaje);
            }
        }

        private void btnQuitarMaterial_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(vc_codigo_mat))
            {
                CLS_Parametros del = new CLS_Parametros();
                del.c_codigo_mat = vc_codigo_mat;
                del.c_codigo_tmat = DosCeros(v_Opcion.ToString());
                del.MtdProductoMaterial_Delete();
                if (del.Exito)
                {
                    CargarMaterial();
                    XtraMessageBox.Show("se ha eliminado el dato con exito");
                }
                else
                {
                    XtraMessageBox.Show(del.Mensaje);
                }
            }
            else
            {
                XtraMessageBox.Show("No se ha seleccionado material para quitar");
            }

        }

        private void dtgMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValMaterial.GetSelectedRows())
                {
                    DataRow row = this.dtgValMaterial.GetDataRow(i);
                    vc_codigo_mat = row["c_codigo_mat"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}