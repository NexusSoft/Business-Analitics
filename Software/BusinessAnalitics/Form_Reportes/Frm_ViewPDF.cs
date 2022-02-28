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
    public partial class Frm_ViewPDF : DevExpress.XtraEditors.XtraForm
    {

        public string Id_Cosecha { get; set; }
        public int Id_Archivo { get; set; }
        public Frm_ViewPDF()
        {
            InitializeComponent();
        }

        private void Frm_ViewPDFSalidas_Load(object sender, EventArgs e)
        {
            CLS_Cosecha_Facturas sel = new CLS_Cosecha_Facturas();
            sel.Id_Cosecha = Id_Cosecha;
            sel.Id_Archivo = Id_Archivo;
            sel.MtdSeleccionarCosechaArchivoPDFXMLView();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0 && sel.Datos.Rows[0]["FacturaPDF"] != null)
                {
                    byte[] bytes = (byte[])sel.Datos.Rows[0]["FacturaPDF"];
                    if (bytes.Length>0)
                    {
                    System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewPDF.pdf", bytes);
                        this.pdfViewer1.LoadDocument(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewPDF.pdf");
                    }
                }
            }
            else
            {
                XtraMessageBox.Show(sel.Mensaje);
            }
        }
    }
}