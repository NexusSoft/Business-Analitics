namespace Business_Analitics
{
    partial class Frm_CosechaKgNoSolicitados
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
            this.components = new System.ComponentModel.Container();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dtgRecepcion = new DevExpress.XtraGrid.GridControl();
            this.dtgValRecepcion = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dtgTamanio = new DevExpress.XtraGrid.GridControl();
            this.dtgValTamanio = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRecepcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValRecepcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTamanio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValTamanio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.dtgRecepcion);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl1.Size = new System.Drawing.Size(402, 119);
            this.panelControl1.TabIndex = 0;
            // 
            // dtgRecepcion
            // 
            this.dtgRecepcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgRecepcion.Location = new System.Drawing.Point(7, 7);
            this.dtgRecepcion.MainView = this.dtgValRecepcion;
            this.dtgRecepcion.Name = "dtgRecepcion";
            this.dtgRecepcion.Size = new System.Drawing.Size(388, 105);
            this.dtgRecepcion.TabIndex = 0;
            this.dtgRecepcion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgValRecepcion});
            // 
            // dtgValRecepcion
            // 
            this.dtgValRecepcion.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.dtgValRecepcion.GridControl = this.dtgRecepcion;
            this.dtgValRecepcion.Name = "dtgValRecepcion";
            this.dtgValRecepcion.OptionsView.ShowFooter = true;
            this.dtgValRecepcion.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Fecha";
            this.gridColumn3.FieldName = "d_fecha_rec";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Recepcion";
            this.gridColumn4.FieldName = "c_codigo_rec";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "%";
            this.gridColumn5.FieldName = "Porcentaje";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.dtgTamanio);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 119);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl2.Size = new System.Drawing.Size(402, 249);
            this.panelControl2.TabIndex = 1;
            // 
            // dtgTamanio
            // 
            this.dtgTamanio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgTamanio.Location = new System.Drawing.Point(7, 7);
            this.dtgTamanio.MainView = this.dtgValTamanio;
            this.dtgTamanio.Name = "dtgTamanio";
            this.dtgTamanio.Size = new System.Drawing.Size(388, 235);
            this.dtgTamanio.TabIndex = 1;
            this.dtgTamanio.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgValTamanio});
            // 
            // dtgValTamanio
            // 
            this.dtgValTamanio.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.dtgValTamanio.GridControl = this.dtgTamanio;
            this.dtgValTamanio.Name = "dtgValTamanio";
            this.dtgValTamanio.OptionsView.ShowFooter = true;
            this.dtgValTamanio.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tamaño";
            this.gridColumn1.FieldName = "v_nombre_tam";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Kilos";
            this.gridColumn2.FieldName = "Peso";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Peso", "SUMA={0:#.##}")});
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // Frm_CosechaKgNoSolicitados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 368);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_CosechaKgNoSolicitados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kg No Solicitados";
            this.Shown += new System.EventHandler(this.Frm_CosechaKgNoSolicitados_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgRecepcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValRecepcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTamanio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValTamanio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl dtgRecepcion;
        private DevExpress.XtraGrid.Views.Grid.GridView dtgValRecepcion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.GridControl dtgTamanio;
        private DevExpress.XtraGrid.Views.Grid.GridView dtgValTamanio;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
    }
}