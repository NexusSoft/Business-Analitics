using CapaDeDatos;
using DevExpress.XtraEditors;
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
    public partial class Frm_ListaPrecios : DevExpress.XtraEditors.XtraForm
    {
        public string ParFechaInicio { get; set; }
        public string ParFechaFin { get; set; }
        public string Id_AcopioPrecios { get; set; }
        public Frm_ListaPrecios()
        {
            InitializeComponent();
        }

        private void Frm_ListaPrecios_Load(object sender, EventArgs e)
        {
            dt_FInicio.DateTime = DateTime.Now;
            dt_FFin.DateTime = DateTime.Now;
            txt_estiba.Text = string.Empty;
            chk_Todas.Checked = true;
        }

        private void chk_Todas_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Todas.Checked == true)
            {
                txt_estiba.Text = string.Empty;
                txt_estiba.Enabled = false;
            }
            else
            {
                txt_estiba.Enabled = true;
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
        private void btnBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DateTime.Compare(Convert.ToDateTime(dt_FInicio.EditValue), Convert.ToDateTime(dt_FFin.EditValue)) <= 0)
            {
                DateTime FInicio = Convert.ToDateTime(dt_FInicio.EditValue.ToString());
                DateTime FFin = Convert.ToDateTime(dt_FFin.EditValue.ToString());
                ParFechaInicio = FInicio.Year.ToString() + "-" + DosCeros(FInicio.Month.ToString()) + "-" + DosCeros(FInicio.Day.ToString()) + " 00:00:00";
                ParFechaFin = FFin.Year.ToString() + "-" + DosCeros(FFin.Month.ToString()) + "-" + DosCeros(FFin.Day.ToString()) + " 23:59:59";
                CLS_AcarreroPrecios sel = new CLS_AcarreroPrecios();
                sel.FechaInicio = ParFechaInicio;
                sel.FechaFin = ParFechaFin;
                sel.Estiba = txt_estiba.Text;
                if (chk_Todas.Checked == true)
                {
                    sel.Todas = 1;
                }
                else
                {
                    sel.Todas = 0;
                }
                sel.MtdSeleccionarAcopioPrecios_Filtro();
                if(sel.Exito)
                {
                    dtgPrecios.DataSource = sel.Datos;
                }
            }
        }

        private void btnSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txt_IdPrecio.Text != string.Empty)
            {
                Id_AcopioPrecios=txt_IdPrecio.Text;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("No se ha seleccionado un precio a modificar");
            }
        }

        private void dtgPrecios_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValPrecios.GetSelectedRows())
                {
                    DataRow row = this.dtgValPrecios.GetDataRow(i);
                    txt_IdPrecio.Text = row["Id_AcopioPrecios"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}