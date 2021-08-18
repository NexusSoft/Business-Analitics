namespace Business_Analitics
{
    partial class Frm_ReportInventarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ReportInventarios));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bIconos = new DevExpress.XtraBars.Bar();
            this.btnLimpiar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnComparar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnExportar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnSalir = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bEstado = new DevExpress.XtraBars.Bar();
            this.lblProveedor = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnSeleccionar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtFecha2 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtFecha1 = new DevExpress.XtraEditors.DateEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dtgReporte = new DevExpress.XtraGrid.GridControl();
            this.dtgValReporte = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.xtraSaveFileDialog1 = new DevExpress.XtraEditors.XtraSaveFileDialog(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bIconos,
            this.bEstado});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblProveedor,
            this.btnLimpiar,
            this.btnComparar,
            this.btnExportar,
            this.btnSalir,
            this.btnSeleccionar});
            this.barManager1.MainMenu = this.bIconos;
            this.barManager1.MaxItemId = 67;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.barManager1.StatusBar = this.bEstado;
            // 
            // bIconos
            // 
            this.bIconos.BarName = "Menú principal";
            this.bIconos.DockCol = 0;
            this.bIconos.DockRow = 0;
            this.bIconos.DockStyle = DevExpress.XtraBars.BarDockStyle.Left;
            this.bIconos.FloatLocation = new System.Drawing.Point(42, 184);
            this.bIconos.FloatSize = new System.Drawing.Size(1106, 535);
            this.bIconos.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLimpiar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnComparar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSalir)});
            this.bIconos.OptionsBar.AllowCollapse = true;
            this.bIconos.OptionsBar.AllowQuickCustomization = false;
            this.bIconos.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.None;
            this.bIconos.OptionsBar.DisableClose = true;
            this.bIconos.OptionsBar.DisableCustomization = true;
            this.bIconos.OptionsBar.DrawBorder = false;
            this.bIconos.OptionsBar.DrawDragBorder = false;
            this.bIconos.OptionsBar.RotateWhenVertical = false;
            this.bIconos.OptionsBar.UseWholeRow = true;
            this.bIconos.Text = "Menú principal";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Caption = "Limpiar";
            this.btnLimpiar.Id = 50;
            this.btnLimpiar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.ImageOptions.Image")));
            this.btnLimpiar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.ImageOptions.LargeImage")));
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLimpiar_ItemClick);
            // 
            // btnComparar
            // 
            this.btnComparar.Caption = "Comparar";
            this.btnComparar.Id = 53;
            this.btnComparar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnComparar.ImageOptions.Image")));
            this.btnComparar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnComparar.ImageOptions.LargeImage")));
            this.btnComparar.Name = "btnComparar";
            this.btnComparar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnComparar_ItemClick);
            // 
            // btnExportar
            // 
            this.btnExportar.Caption = "Exportar";
            this.btnExportar.Id = 57;
            this.btnExportar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.ImageOptions.Image")));
            this.btnExportar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExportar.ImageOptions.LargeImage")));
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportar_ItemClick);
            // 
            // btnSalir
            // 
            this.btnSalir.Caption = "Salir";
            this.btnSalir.Id = 63;
            this.btnSalir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.ImageOptions.Image")));
            this.btnSalir.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.ImageOptions.LargeImage")));
            this.btnSalir.Name = "btnSalir";
            // 
            // bEstado
            // 
            this.bEstado.BarName = "Barra de estado";
            this.bEstado.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bEstado.DockCol = 0;
            this.bEstado.DockRow = 0;
            this.bEstado.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bEstado.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblProveedor)});
            this.bEstado.OptionsBar.AllowQuickCustomization = false;
            this.bEstado.OptionsBar.DrawDragBorder = false;
            this.bEstado.OptionsBar.UseWholeRow = true;
            this.bEstado.Text = "Barra de estado";
            // 
            // lblProveedor
            // 
            this.lblProveedor.Caption = "Proveedor:";
            this.lblProveedor.Id = 48;
            this.lblProveedor.Name = "lblProveedor";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(833, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 404);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(833, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(66, 404);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(833, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 404);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Caption = "Seleccionar";
            this.btnSeleccionar.Id = 66;
            this.btnSeleccionar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSeleccionar.ImageOptions.Image")));
            this.btnSeleccionar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSeleccionar.ImageOptions.LargeImage")));
            this.btnSeleccionar.Name = "btnSeleccionar";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.Mask.EditMask = "n0";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(66, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl1.Size = new System.Drawing.Size(767, 73);
            this.panelControl1.TabIndex = 4;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.dtFecha2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.dtFecha1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(7, 7);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(753, 59);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Fechas a Comparar";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(328, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 13);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "Fecha 2:";
            // 
            // dtFecha2
            // 
            this.dtFecha2.EditValue = null;
            this.dtFecha2.Location = new System.Drawing.Point(378, 25);
            this.dtFecha2.MenuManager = this.barManager1;
            this.dtFecha2.Name = "dtFecha2";
            this.dtFecha2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFecha2.Properties.Appearance.Options.UseFont = true;
            this.dtFecha2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFecha2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFecha2.Size = new System.Drawing.Size(181, 22);
            this.dtFecha2.TabIndex = 13;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Fecha 1:";
            // 
            // dtFecha1
            // 
            this.dtFecha1.EditValue = null;
            this.dtFecha1.Location = new System.Drawing.Point(67, 25);
            this.dtFecha1.MenuManager = this.barManager1;
            this.dtFecha1.Name = "dtFecha1";
            this.dtFecha1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFecha1.Properties.Appearance.Options.UseFont = true;
            this.dtFecha1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFecha1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFecha1.Size = new System.Drawing.Size(181, 22);
            this.dtFecha1.TabIndex = 11;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.dtgReporte);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(66, 73);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(10);
            this.panelControl2.Size = new System.Drawing.Size(767, 331);
            this.panelControl2.TabIndex = 5;
            // 
            // dtgReporte
            // 
            this.dtgReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgReporte.Location = new System.Drawing.Point(12, 12);
            this.dtgReporte.MainView = this.dtgValReporte;
            this.dtgReporte.MenuManager = this.barManager1;
            this.dtgReporte.Name = "dtgReporte";
            this.dtgReporte.Size = new System.Drawing.Size(743, 307);
            this.dtgReporte.TabIndex = 0;
            this.dtgReporte.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgValReporte});
            // 
            // dtgValReporte
            // 
            this.dtgValReporte.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4});
            this.dtgValReporte.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.dtgValReporte.GridControl = this.dtgReporte;
            this.dtgValReporte.GroupCount = 1;
            this.dtgValReporte.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "f1Volumen", this.gridColumn5, "(Volumen ={0:n0})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "p1Volumen", this.gridColumn6, "(Porcentaje ={0:p})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "f2Volumen", this.gridColumn7, "(Volumen ={0:n0})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "p2Volumen", this.gridColumn8, "(Porcentaje ={0:p})")});
            this.dtgValReporte.Name = "dtgValReporte";
            this.dtgValReporte.OptionsView.AllowCellMerge = true;
            this.dtgValReporte.OptionsView.ShowFooter = true;
            this.dtgValReporte.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "Producto";
            this.gridBand1.Columns.Add(this.gridColumn1);
            this.gridBand1.Columns.Add(this.gridColumn2);
            this.gridBand1.Columns.Add(this.gridColumn3);
            this.gridBand1.Columns.Add(this.gridColumn4);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 300;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Pais";
            this.gridColumn1.FieldName = "Nombre_Pais";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.Visible = true;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tratamiento";
            this.gridColumn2.FieldName = "Nombre_Tratamiento";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.Visible = true;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Categoria";
            this.gridColumn3.FieldName = "Nombre_Categoria";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.Visible = true;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tamaño";
            this.gridColumn4.FieldName = "Nombre_Tamanio";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.Visible = true;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Fecha 1";
            this.gridBand2.Columns.Add(this.gridColumn5);
            this.gridBand2.Columns.Add(this.gridColumn6);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 150;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Volumen";
            this.gridColumn5.DisplayFormat.FormatString = "n0";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "f1Volumen";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsColumn.AllowMove = false;
            this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "f1Volumen", "SUMA={0:n0}")});
            this.gridColumn5.Visible = true;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Porcentaje";
            this.gridColumn6.DisplayFormat.FormatString = "p";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "p1Volumen";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsColumn.AllowMove = false;
            this.gridColumn6.Visible = true;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "Fecha 2";
            this.gridBand3.Columns.Add(this.gridColumn7);
            this.gridBand3.Columns.Add(this.gridColumn8);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 150;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Volumen";
            this.gridColumn7.DisplayFormat.FormatString = "n0";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "f2Volumen";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsColumn.AllowMove = false;
            this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "f2Volumen", "SUMA={0:n0}")});
            this.gridColumn7.Visible = true;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Porcentaje";
            this.gridColumn8.DisplayFormat.FormatString = "p";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "p2Volumen";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.OptionsColumn.AllowMove = false;
            this.gridColumn8.Visible = true;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "Diferencia";
            this.gridBand4.Columns.Add(this.gridColumn9);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 3;
            this.gridBand4.Width = 75;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Incremento";
            this.gridColumn9.DisplayFormat.FormatString = "p";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "porcen";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.OptionsColumn.AllowMove = false;
            this.gridColumn9.Visible = true;
            // 
            // xtraSaveFileDialog1
            // 
            this.xtraSaveFileDialog1.FileName = "xtraSaveFileDialog1";
            // 
            // Frm_ReportInventarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 429);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Frm_ReportInventarios";
            this.Text = "Reporte Comparativo";
            this.Shown += new System.EventHandler(this.Frm_ReportInventarios_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraBars.BarManager barManager1;
        public DevExpress.XtraBars.Bar bIconos;
        private DevExpress.XtraBars.BarLargeButtonItem btnLimpiar;
        private DevExpress.XtraBars.BarLargeButtonItem btnComparar;
        private DevExpress.XtraBars.BarLargeButtonItem btnExportar;
        private DevExpress.XtraBars.BarLargeButtonItem btnSalir;
        private DevExpress.XtraBars.Bar bEstado;
        private DevExpress.XtraBars.BarStaticItem lblProveedor;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarLargeButtonItem btnSeleccionar;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl dtgReporte;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView dtgValReporte;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn7;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn8;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn9;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dtFecha2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtFecha1;
        private DevExpress.XtraEditors.XtraSaveFileDialog xtraSaveFileDialog1;
    }
}