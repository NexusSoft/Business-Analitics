using CapaDeDatos;
using DevExpress.XtraEditors;
using System;
using System.Data;

namespace Business_Analitics
{
    public partial class Frm_Distribuidor : DevExpress.XtraEditors.XtraForm
    {
        public int Opcion { get; set; }
        public string vc_codigo_dis { get; set; }
        public string vv_nombre_dis { get; set; }

        public Frm_Distribuidor()
        {
            InitializeComponent();
        }

        private void Frm_Productos_Shown(object sender, EventArgs e)
        {
            dtgValDistribuidor.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            dtgValDistribuidor.OptionsSelection.EnableAppearanceFocusedCell = false;
            lblProveedor.Caption = "Distribuidor:";
            CargarDistribuidores();
        }
        private void CargarDistribuidores()
        {
            CLS_Parametros sel = new CLS_Parametros();

            sel.MtdSeleccionarDistribuidor();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    dtgDistribuidor.DataSource = sel.Datos;
                }
            }
        }

        private void btnSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CLS_Parametros ins = new CLS_Parametros();
            ins.c_codigo_dis = vc_codigo_dis;
            ins.v_nombre_dis = vv_nombre_dis;
            ins.MtdDistribuidorSinAPEAM_Insert();
            if (!ins.Exito)
            {
                XtraMessageBox.Show(ins.Mensaje);
            }
            this.Close();
        }

        private void dtgEstibas_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValDistribuidor.GetSelectedRows())
                {
                    DataRow row = this.dtgValDistribuidor.GetDataRow(i);
                    vc_codigo_dis = row["c_codigo_dis"].ToString();
                    vv_nombre_dis = row["v_nombre_dis"].ToString();
                    lblProveedor.Caption = string.Format("Distribuidor: {0}", vc_codigo_dis);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}