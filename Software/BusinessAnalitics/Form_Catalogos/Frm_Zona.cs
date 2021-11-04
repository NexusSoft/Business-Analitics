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
    public partial class Frm_Zona : DevExpress.XtraEditors.XtraForm
    {
        public Boolean PaSel { get; set; }

        public Frm_Zona()
        {
            InitializeComponent();
        }

        public string IdZona { get; set; }
        public string Zona { get; set; }
        public string Id_Usuario { get; set; }

        private void CargarZona()
        {
            dtgZona.DataSource = null;
            CLS_Zona Clase = new CLS_Zona();

            Clase.MtdSeleccionarZona();
            if (Clase.Exito)
            {
                dtgZona.DataSource = Clase.Datos;
            }
        }

        private void InsertarZona()
        {
            CLS_Zona Clase = new CLS_Zona();

            Clase.Id_zona = textId.Text.Trim();
            Clase.Nombre_zona = textNombre.Text.Trim();
            Clase.Id_Usuario = Id_Usuario;
            Clase.MtdInsertarZona();

            if (Clase.Exito)
            {
                CargarZona();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarCultivo()
        {
            CLS_Zona Clase = new CLS_Zona();
            Clase.Id_zona = textId.Text.Trim();
            Clase.MtdEliminarZona();
            if (Clase.Exito)
            {
                CargarZona();
                XtraMessageBox.Show("Se ha Eliminado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void LimpiarCampos()
        {
            textId.Text = "";
            textNombre.Text = "";
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValZona.GetSelectedRows())
                {
                    DataRow row = this.dtgValZona.GetDataRow(i);
                    textId.Text = row["Id_zona"].ToString();
                    textNombre.Text = row["Nombre_zona"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_Zona_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarZona();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textNombre.Text.ToString().Trim().Length > 0)
            {
                InsertarZona();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre de un cultivo.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0)
            {
                EliminarCultivo();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar un cultivo.");
            }
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarCampos();
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IdZona = textId.Text.Trim();
            Zona = textNombre.Text.Trim();
            this.Close();
        }
    }
}