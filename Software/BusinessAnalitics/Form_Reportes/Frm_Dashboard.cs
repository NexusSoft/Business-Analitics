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
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DashboardCommon;
using DevExpress.DataAccess.Sql;
using System.IO;
using DevExpress.XtraBars.Ribbon;
using DevExpress.DashboardWin.Bars;

namespace Business_Analitics
{
    public partial class Frm_Dashboard : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Dashboard()
        {
            InitializeComponent();
        }

        private void Frm_Dashboard_Shown(object sender, EventArgs e)
        {
            string path = @"C:\Dashboard";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            dashboardDesigner1.ConfigureDataConnection += dashboardDesigner1_ConfigureDataConnection;
            dashboardDesigner1.LoadDashboard("C:/Dashboard/Dashboard.xml");
        }

        private void dashboardDesigner1_ConfigureDataConnection(object sender, DashboardConfigureDataConnectionEventArgs e)
        {
            if (e.DataSourceName == "Origen de datos SQL 1")
            {
                MsSqlConnectionParameters parameters = e.ConnectionParameters as MsSqlConnectionParameters;
                if (parameters != null)
                {
                    MSRegistro RegOut = new MSRegistro();
                    Crypto DesencriptarTexto = new Crypto();
                    parameters.ServerName=DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "Server"));
                    parameters.UserName = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "User"));
                    parameters.Password = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "Password"));
                    parameters.DatabaseName = DesencriptarTexto.Desencriptar(RegOut.GetSetting("ConexionSQL", "DBase"));
                }
            }
        }
    }
}