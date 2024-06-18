namespace BusinessAnalitics
{
    partial class Frm_Precios_Estibas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Precios_Estibas));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bIconos = new DevExpress.XtraBars.Bar();
            this.btnActualizar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnSalir = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bEstado = new DevExpress.XtraBars.Bar();
            this.lblProveedor = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnLimpiar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Buscar = new DevExpress.XtraEditors.SimpleButton();
            this.sp_Anio = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.sp_Semana = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dtgPreciosEstiba = new DevExpress.XtraGrid.GridControl();
            this.dtgValPreciosEstiba = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Temporada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Estiba = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_NHuerta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_FRecepcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Cajas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_KRecepcionados = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_KProcesados = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TCorte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PCosecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PAcarreo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DCosecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DAcarreo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TUnidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PCompra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_PBanda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_Guardar = new DevExpress.XtraBars.BarLargeButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sp_Anio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_Semana.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPreciosEstiba)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValPreciosEstiba)).BeginInit();
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
            this.btnActualizar,
            this.btnEliminar,
            this.btnSalir,
            this.btn_Guardar});
            this.barManager1.MainMenu = this.bIconos;
            this.barManager1.MaxItemId = 68;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnActualizar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Guardar),
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
            // btnActualizar
            // 
            this.btnActualizar.Caption = "Actualizar";
            this.btnActualizar.Id = 53;
            this.btnActualizar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.ImageOptions.Image")));
            this.btnActualizar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnActualizar.ImageOptions.LargeImage")));
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnActualizar_ItemClick);
            // 
            // btnSalir
            // 
            this.btnSalir.Caption = "Salir";
            this.btnSalir.Id = 63;
            this.btnSalir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.ImageOptions.Image")));
            this.btnSalir.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.ImageOptions.LargeImage")));
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalir_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(1195, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 539);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1195, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(64, 539);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1195, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 539);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Caption = "Limpiar";
            this.btnLimpiar.Id = 50;
            this.btnLimpiar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.ImageOptions.Image")));
            this.btnLimpiar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.ImageOptions.LargeImage")));
            this.btnLimpiar.Name = "btnLimpiar";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Id = 57;
            this.btnEliminar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.ImageOptions.Image")));
            this.btnEliminar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.ImageOptions.LargeImage")));
            this.btnEliminar.Name = "btnEliminar";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btn_Buscar);
            this.panelControl1.Controls.Add(this.sp_Anio);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.sp_Semana);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(64, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1131, 61);
            this.panelControl1.TabIndex = 4;
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Buscar.ImageOptions.Image")));
            this.btn_Buscar.Location = new System.Drawing.Point(415, 16);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_Buscar.TabIndex = 4;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // sp_Anio
            // 
            this.sp_Anio.EditValue = new decimal(new int[] {
            2023,
            0,
            0,
            0});
            this.sp_Anio.Location = new System.Drawing.Point(277, 17);
            this.sp_Anio.MenuManager = this.barManager1;
            this.sp_Anio.Name = "sp_Anio";
            this.sp_Anio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sp_Anio.Properties.IsFloatValue = false;
            this.sp_Anio.Properties.MaskSettings.Set("mask", "N00");
            this.sp_Anio.Properties.MaxValue = new decimal(new int[] {
            2027,
            0,
            0,
            0});
            this.sp_Anio.Properties.MinValue = new decimal(new int[] {
            2023,
            0,
            0,
            0});
            this.sp_Anio.Size = new System.Drawing.Size(100, 20);
            this.sp_Anio.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(232, 21);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(19, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Año";
            // 
            // sp_Semana
            // 
            this.sp_Semana.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sp_Semana.Location = new System.Drawing.Point(98, 17);
            this.sp_Semana.MenuManager = this.barManager1;
            this.sp_Semana.Name = "sp_Semana";
            this.sp_Semana.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sp_Semana.Properties.IsFloatValue = false;
            this.sp_Semana.Properties.MaskSettings.Set("mask", "N00");
            this.sp_Semana.Properties.MaxValue = new decimal(new int[] {
            52,
            0,
            0,
            0});
            this.sp_Semana.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sp_Semana.Size = new System.Drawing.Size(100, 20);
            this.sp_Semana.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(34, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(38, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Semana";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.dtgPreciosEstiba);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(64, 61);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(10);
            this.panelControl2.Size = new System.Drawing.Size(1131, 478);
            this.panelControl2.TabIndex = 5;
            // 
            // dtgPreciosEstiba
            // 
            this.dtgPreciosEstiba.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgPreciosEstiba.Location = new System.Drawing.Point(12, 12);
            this.dtgPreciosEstiba.MainView = this.dtgValPreciosEstiba;
            this.dtgPreciosEstiba.MenuManager = this.barManager1;
            this.dtgPreciosEstiba.Name = "dtgPreciosEstiba";
            this.dtgPreciosEstiba.Size = new System.Drawing.Size(1107, 454);
            this.dtgPreciosEstiba.TabIndex = 0;
            this.dtgPreciosEstiba.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgValPreciosEstiba});
            // 
            // dtgValPreciosEstiba
            // 
            this.dtgValPreciosEstiba.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Temporada,
            this.col_Estiba,
            this.col_NHuerta,
            this.col_FRecepcion,
            this.col_Cajas,
            this.col_KRecepcionados,
            this.col_KProcesados,
            this.col_TCorte,
            this.col_PCosecha,
            this.col_PAcarreo,
            this.col_DCosecha,
            this.col_DAcarreo,
            this.col_TUnidad,
            this.col_PCompra,
            this.col_PBanda});
            this.dtgValPreciosEstiba.GridControl = this.dtgPreciosEstiba;
            this.dtgValPreciosEstiba.Name = "dtgValPreciosEstiba";
            this.dtgValPreciosEstiba.OptionsView.ShowGroupPanel = false;
            this.dtgValPreciosEstiba.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.dtgValPreciosEstiba_CellValueChanged);
            // 
            // col_Temporada
            // 
            this.col_Temporada.Caption = "Temporada";
            this.col_Temporada.FieldName = "c_codigo_tem";
            this.col_Temporada.Name = "col_Temporada";
            this.col_Temporada.OptionsColumn.AllowEdit = false;
            this.col_Temporada.Visible = true;
            this.col_Temporada.VisibleIndex = 0;
            // 
            // col_Estiba
            // 
            this.col_Estiba.Caption = "Estiba";
            this.col_Estiba.FieldName = "c_codigo_sel";
            this.col_Estiba.Name = "col_Estiba";
            this.col_Estiba.OptionsColumn.AllowEdit = false;
            this.col_Estiba.Visible = true;
            this.col_Estiba.VisibleIndex = 1;
            // 
            // col_NHuerta
            // 
            this.col_NHuerta.Caption = "Nombre Huerta";
            this.col_NHuerta.FieldName = "v_nombrehuerta";
            this.col_NHuerta.Name = "col_NHuerta";
            this.col_NHuerta.OptionsColumn.AllowEdit = false;
            this.col_NHuerta.Visible = true;
            this.col_NHuerta.VisibleIndex = 2;
            // 
            // col_FRecepcion
            // 
            this.col_FRecepcion.Caption = "Fecha Recpecion";
            this.col_FRecepcion.FieldName = "d_fechaRecepcion";
            this.col_FRecepcion.Name = "col_FRecepcion";
            this.col_FRecepcion.OptionsColumn.AllowEdit = false;
            this.col_FRecepcion.Visible = true;
            this.col_FRecepcion.VisibleIndex = 3;
            // 
            // col_Cajas
            // 
            this.col_Cajas.Caption = "Cajas";
            this.col_Cajas.FieldName = "Cajas";
            this.col_Cajas.Name = "col_Cajas";
            this.col_Cajas.OptionsColumn.AllowEdit = false;
            this.col_Cajas.Visible = true;
            this.col_Cajas.VisibleIndex = 4;
            // 
            // col_KRecepcionados
            // 
            this.col_KRecepcionados.Caption = "Kg Recepcionados";
            this.col_KRecepcionados.FieldName = "n_kgRecepcion";
            this.col_KRecepcionados.Name = "col_KRecepcionados";
            this.col_KRecepcionados.OptionsColumn.AllowEdit = false;
            this.col_KRecepcionados.Visible = true;
            this.col_KRecepcionados.VisibleIndex = 5;
            // 
            // col_KProcesados
            // 
            this.col_KProcesados.Caption = "kg Procesados";
            this.col_KProcesados.FieldName = "n_kgProcesados";
            this.col_KProcesados.Name = "col_KProcesados";
            this.col_KProcesados.OptionsColumn.AllowEdit = false;
            this.col_KProcesados.Visible = true;
            this.col_KProcesados.VisibleIndex = 6;
            // 
            // col_TCorte
            // 
            this.col_TCorte.Caption = "Tipo Corte";
            this.col_TCorte.FieldName = "v_tipocorte";
            this.col_TCorte.Name = "col_TCorte";
            this.col_TCorte.Visible = true;
            this.col_TCorte.VisibleIndex = 7;
            // 
            // col_PCosecha
            // 
            this.col_PCosecha.Caption = "Pago Cosecha";
            this.col_PCosecha.FieldName = "b_pagocosecha";
            this.col_PCosecha.Name = "col_PCosecha";
            this.col_PCosecha.Visible = true;
            this.col_PCosecha.VisibleIndex = 8;
            // 
            // col_PAcarreo
            // 
            this.col_PAcarreo.Caption = "Pago Acarreo";
            this.col_PAcarreo.FieldName = "b_pagoacarreo";
            this.col_PAcarreo.Name = "col_PAcarreo";
            this.col_PAcarreo.Visible = true;
            this.col_PAcarreo.VisibleIndex = 9;
            // 
            // col_DCosecha
            // 
            this.col_DCosecha.Caption = "Desc Cosecha";
            this.col_DCosecha.FieldName = "b_descuentocosecha";
            this.col_DCosecha.Name = "col_DCosecha";
            this.col_DCosecha.Visible = true;
            this.col_DCosecha.VisibleIndex = 10;
            // 
            // col_DAcarreo
            // 
            this.col_DAcarreo.Caption = "Desc Acarreo";
            this.col_DAcarreo.FieldName = "b_descuentoacarreo";
            this.col_DAcarreo.Name = "col_DAcarreo";
            this.col_DAcarreo.Visible = true;
            this.col_DAcarreo.VisibleIndex = 11;
            // 
            // col_TUnidad
            // 
            this.col_TUnidad.Caption = "Tipo Unidad";
            this.col_TUnidad.FieldName = "v_tipocamion";
            this.col_TUnidad.Name = "col_TUnidad";
            this.col_TUnidad.Visible = true;
            this.col_TUnidad.VisibleIndex = 12;
            // 
            // col_PCompra
            // 
            this.col_PCompra.Caption = "Precio Compra";
            this.col_PCompra.FieldName = "n_preciocompra";
            this.col_PCompra.Name = "col_PCompra";
            this.col_PCompra.Visible = true;
            this.col_PCompra.VisibleIndex = 14;
            // 
            // col_PBanda
            // 
            this.col_PBanda.Caption = "Pago en Banda";
            this.col_PBanda.FieldName = "b_PagoBanda";
            this.col_PBanda.Name = "col_PBanda";
            this.col_PBanda.Visible = true;
            this.col_PBanda.VisibleIndex = 13;
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.Caption = "Guardar";
            this.btn_Guardar.Id = 67;
            this.btn_Guardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Guardar.ImageOptions.Image")));
            this.btn_Guardar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Guardar.ImageOptions.LargeImage")));
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Guardar_ItemClick);
            // 
            // Frm_Precios_Estibas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 561);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Frm_Precios_Estibas";
            this.Text = "Frm_Precios_Estibas";
            this.Load += new System.EventHandler(this.Frm_Precios_Estibas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sp_Anio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_Semana.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPreciosEstiba)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValPreciosEstiba)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraBars.BarManager barManager1;
        public DevExpress.XtraBars.Bar bIconos;
        private DevExpress.XtraBars.BarLargeButtonItem btnActualizar;
        private DevExpress.XtraBars.BarLargeButtonItem btnSalir;
        private DevExpress.XtraBars.Bar bEstado;
        private DevExpress.XtraBars.BarStaticItem lblProveedor;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarLargeButtonItem btnLimpiar;
        private DevExpress.XtraBars.BarLargeButtonItem btnEliminar;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl dtgPreciosEstiba;
        private DevExpress.XtraGrid.Views.Grid.GridView dtgValPreciosEstiba;
        private DevExpress.XtraGrid.Columns.GridColumn col_Temporada;
        private DevExpress.XtraGrid.Columns.GridColumn col_Estiba;
        private DevExpress.XtraGrid.Columns.GridColumn col_NHuerta;
        private DevExpress.XtraGrid.Columns.GridColumn col_FRecepcion;
        private DevExpress.XtraGrid.Columns.GridColumn col_Cajas;
        private DevExpress.XtraGrid.Columns.GridColumn col_KRecepcionados;
        private DevExpress.XtraGrid.Columns.GridColumn col_KProcesados;
        private DevExpress.XtraGrid.Columns.GridColumn col_TCorte;
        private DevExpress.XtraGrid.Columns.GridColumn col_PCosecha;
        private DevExpress.XtraGrid.Columns.GridColumn col_PAcarreo;
        private DevExpress.XtraGrid.Columns.GridColumn col_DCosecha;
        private DevExpress.XtraGrid.Columns.GridColumn col_DAcarreo;
        private DevExpress.XtraGrid.Columns.GridColumn col_TUnidad;
        private DevExpress.XtraGrid.Columns.GridColumn col_PCompra;
        private DevExpress.XtraEditors.SpinEdit sp_Anio;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SpinEdit sp_Semana;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Buscar;
        private DevExpress.XtraGrid.Columns.GridColumn col_PBanda;
        private DevExpress.XtraBars.BarLargeButtonItem btn_Guardar;
    }
}