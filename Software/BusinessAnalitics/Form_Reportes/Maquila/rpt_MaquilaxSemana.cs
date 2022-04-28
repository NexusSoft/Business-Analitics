using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Business_Analitics
{
    public partial class rpt_MaquilaxSemana : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_MaquilaxSemana()
        {
            InitializeComponent();
        }

        private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
