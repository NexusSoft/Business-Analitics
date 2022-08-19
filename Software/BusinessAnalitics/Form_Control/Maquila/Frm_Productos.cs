using CapaDeDatos;
using DevExpress.XtraEditors;
using System;
using System.Data;

namespace Business_Analitics
{
    public partial class Frm_Productos : DevExpress.XtraEditors.XtraForm
    {
        public int Opcion { get; set; }
        public string vc_codigo_pro { get; set; }
        public string vv_nombre_pro { get; set; }

        public Frm_Productos()
        {
            InitializeComponent();
        }

        private void Frm_Productos_Shown(object sender, EventArgs e)
        {
            dtgValEstibas.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            dtgValEstibas.OptionsSelection.EnableAppearanceFocusedCell = false;
            lblProveedor.Caption = "Producto:";
            CargarProductos();
        }
        private void CargarProductos()
        {
            CLS_Productos sel = new CLS_Productos();

            sel.MtdSeleccionarProductos();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    dtgEstibas.DataSource = sel.Datos;
                }
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
        private void btnSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(vc_codigo_pro))
            {
                CLS_Parametros ins = new CLS_Parametros();
                ins.c_codigo_mat = vc_codigo_pro;
                ins.v_nombre_mat = vv_nombre_pro;
                ins.c_codigo_tmat = DosCeros(Opcion.ToString());
                ins.MtdProductoMaterial_Insert();
                if (!ins.Exito)
                {
                    XtraMessageBox.Show(ins.Mensaje);
                }
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("No se ha seleccionado producto");
            }
        }

        private void dtgEstibas_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValEstibas.GetSelectedRows())
                {
                    DataRow row = this.dtgValEstibas.GetDataRow(i);
                    vc_codigo_pro = row["c_codigo_pro"].ToString();
                    vv_nombre_pro = row["v_nombre_pro"].ToString();
                    lblProveedor.Caption = string.Format("Estiba: {0}", vc_codigo_pro);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}