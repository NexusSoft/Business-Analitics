namespace Business_Analitics
{
    partial class Frm_Materiales
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Materiales));
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.dtgMaterial = new DevExpress.XtraGrid.GridControl();
            this.dtgValMaterial = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnQuitarMaterial = new DevExpress.XtraEditors.SimpleButton();
            this.btnAgregarMaterial = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.dtgMaterial);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl3.Size = new System.Drawing.Size(516, 431);
            this.panelControl3.TabIndex = 6;
            // 
            // dtgMaterial
            // 
            this.dtgMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgMaterial.Location = new System.Drawing.Point(7, 7);
            this.dtgMaterial.MainView = this.dtgValMaterial;
            this.dtgMaterial.Name = "dtgMaterial";
            this.dtgMaterial.Size = new System.Drawing.Size(502, 417);
            this.dtgMaterial.TabIndex = 0;
            this.dtgMaterial.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgValMaterial});
            this.dtgMaterial.Click += new System.EventHandler(this.dtgMaterial_Click);
            // 
            // dtgValMaterial
            // 
            this.dtgValMaterial.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn7});
            this.dtgValMaterial.GridControl = this.dtgMaterial;
            this.dtgValMaterial.Name = "dtgValMaterial";
            this.dtgValMaterial.OptionsView.ShowFooter = true;
            this.dtgValMaterial.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Nombre Material";
            this.gridColumn5.FieldName = "v_nombre_mat";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Codigo Material";
            this.gridColumn7.FieldName = "c_codigo_mat";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            // 
            // btnQuitarMaterial
            // 
            this.btnQuitarMaterial.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitarMaterial.ImageOptions.Image")));
            this.btnQuitarMaterial.Location = new System.Drawing.Point(108, 8);
            this.btnQuitarMaterial.Name = "btnQuitarMaterial";
            this.btnQuitarMaterial.Size = new System.Drawing.Size(90, 42);
            this.btnQuitarMaterial.TabIndex = 13;
            this.btnQuitarMaterial.Text = "Quitar";
            this.btnQuitarMaterial.Click += new System.EventHandler(this.btnQuitarMaterial_Click);
            // 
            // btnAgregarMaterial
            // 
            this.btnAgregarMaterial.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarMaterial.ImageOptions.Image")));
            this.btnAgregarMaterial.Location = new System.Drawing.Point(12, 8);
            this.btnAgregarMaterial.Name = "btnAgregarMaterial";
            this.btnAgregarMaterial.Size = new System.Drawing.Size(90, 42);
            this.btnAgregarMaterial.TabIndex = 12;
            this.btnAgregarMaterial.Text = "Agregar";
            this.btnAgregarMaterial.Click += new System.EventHandler(this.btnAgregarMaterial_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnQuitarMaterial);
            this.panelControl1.Controls.Add(this.btnAgregarMaterial);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 431);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(516, 58);
            this.panelControl1.TabIndex = 7;
            // 
            // Frm_Materiales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 489);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Materiales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Materiales";
            this.Shown += new System.EventHandler(this.Frm_Materiales_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl dtgMaterial;
        private DevExpress.XtraGrid.Views.Grid.GridView dtgValMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.SimpleButton btnQuitarMaterial;
        private DevExpress.XtraEditors.SimpleButton btnAgregarMaterial;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}