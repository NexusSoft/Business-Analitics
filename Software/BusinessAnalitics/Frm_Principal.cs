using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using CapaDeDatos;

namespace Business_Analitics
{
    public partial class Frm_Principal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Frm_Principal()
        {
            InitializeComponent();
        }

        public string c_codigo_usu { get; internal set; }
        public string IdPerfil { get; internal set; }
        public string UsuariosLogin { get; internal set; }
        List<string> Lista = new List<string>();

        private void CargarAccesos()
        {
            CLS_Perfiles_Pantallas Clase = new CLS_Perfiles_Pantallas();
            Clase.Id_Perfil = IdPerfil;
            Clase.MtdSeleccionarAccesosPermisos();
            if (Clase.Exito)
            {

                for (int x = 0; x < Clase.Datos.Rows.Count; x++)
                {
                    Lista.Add(Clase.Datos.Rows[x][0].ToString());
                }
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }
        private Boolean TieneAcceso(String valor)
        {
            foreach (string x in Lista)
            {
                if (x == valor)
                {
                    return true;
                }

            }
            return false;
        }
        private void btn_Usuario_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("001"))
            {
                Frm_Usuarios Ventana = new Frm_Usuarios();
                Frm_Usuarios.DefInstance.MdiParent = this;
                Frm_Usuarios.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_Usuarios.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [001]");
            }
        }

        private void btn_Perfil_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("002"))
            {
                Frm_Perfiles Ventana = new Frm_Perfiles();
                Ventana.UsuariosLogin = UsuariosLogin;
                Ventana.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [002]");
            }
        }

        private void btn_Permisos_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("003"))
            {
                Frm_Permisos Ventana = new Frm_Permisos();
                Frm_Permisos.DefInstance.MdiParent = this;
                Frm_Permisos.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_Permisos.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [003]");
            }
        }

        private void Frm_Principal_Shown(object sender, EventArgs e)
        {
            CargarAccesos();
        }

        private void Frm_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
            MSRegistro RegIn = new MSRegistro();
            RegIn.SaveSetting("ConexionSQL", "Sking", SkinForm.LookAndFeel.SkinName);
        }

        private void Frm_Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_Pais_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("004"))
            {
                Frm_Pais Ventana = new Frm_Pais(false);
                Ventana.UsuariosLogin = UsuariosLogin;
                Ventana.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [002]");
            }
        }

        private void btn_Estado_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TieneAcceso("005"))
            {
                Frm_Estado Ventana = new Frm_Estado();
                Ventana.UsuariosLogin = UsuariosLogin;
                Ventana.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [002]");
            }
        }
    }
}