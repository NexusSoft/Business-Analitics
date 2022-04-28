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
    public partial class Frm_Paises : DevExpress.XtraEditors.XtraForm
    {
        public int Opcion { get; set; }
        public string vc_codigo_pai { get;  set; }
        public string vv_nombre_pai { get;  set; }

        public Frm_Paises()
        {
            InitializeComponent();
        }

        private void Frm_Productos_Shown(object sender, EventArgs e)
        {
            dtgValEstibas.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            dtgValEstibas.OptionsSelection.EnableAppearanceFocusedCell = false;
            lblProveedor.Caption = "Pais:";
            CargarProductos();
        }
        private void CargarProductos()
        {
            CLS_Pais sel = new CLS_Pais();
            
            sel.MtdSeleccionarPais();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    dtgEstibas.DataSource = sel.Datos;
                }
            }
        }

        private void btnSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CLS_Parametros ins = new CLS_Parametros();
            ins.c_codigo_pai = vc_codigo_pai;
            ins.v_nombre_pai = vv_nombre_pai;
            ins.MtdProductoAPEAM_Insert();
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
                foreach (int i in this.dtgValEstibas.GetSelectedRows())
                {
                    DataRow row = this.dtgValEstibas.GetDataRow(i);
                    vc_codigo_pai = row["c_codigo_pai"].ToString();
                    vv_nombre_pai = row["v_nombre_pai"].ToString();
                    lblProveedor.Caption = string.Format("Estiba: {0}", vc_codigo_pai);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}