
namespace pxCard
{
    partial class frmPXCARD
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPXCARD));
            this.gpcImagePath = new DevExpress.XtraEditors.GroupControl();
            this.tspImagePath = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtImagePath = new System.Windows.Forms.ToolStripTextBox();
            this.btnImagePath = new System.Windows.Forms.ToolStripButton();
            this.tsProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gpcEmployeeData = new DevExpress.XtraEditors.GroupControl();
            this.gcEmployeeData = new DevExpress.XtraGrid.GridControl();
            this.gvEmployeeData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tspEmployeeNavigater = new System.Windows.Forms.ToolStrip();
            this.btnEmployeePath = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFirst = new System.Windows.Forms.ToolStripButton();
            this.btnPrev = new System.Windows.Forms.ToolStripButton();
            this.txtIndex = new System.Windows.Forms.ToolStripTextBox();
            this.lblCount = new System.Windows.Forms.ToolStripLabel();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.btnLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSample = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnCardSample = new System.Windows.Forms.ToolStripButton();
            this._preview = new CoolPrintPreview.CoolPrintPreviewControl();
            this.gpcEmployeeImage = new DevExpress.XtraEditors.GroupControl();
            this.tspZoomImage = new System.Windows.Forms.ToolStrip();
            this.btnImageCreate = new System.Windows.Forms.ToolStripButton();
            this.tssMove = new System.Windows.Forms.ToolStripSeparator();
            this.btnZoom100 = new System.Windows.Forms.ToolStripButton();
            this.btnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.btnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.btnZoom = new System.Windows.Forms.ToolStripSplitButton();
            this._itemActualSize = new System.Windows.Forms.ToolStripMenuItem();
            this._itemFullPage = new System.Windows.Forms.ToolStripMenuItem();
            this._itemPageWidth = new System.Windows.Forms.ToolStripMenuItem();
            this._itemTwoPages = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this._item500 = new System.Windows.Forms.ToolStripMenuItem();
            this._item200 = new System.Windows.Forms.ToolStripMenuItem();
            this._item150 = new System.Windows.Forms.ToolStripMenuItem();
            this._item100 = new System.Windows.Forms.ToolStripMenuItem();
            this._item75 = new System.Windows.Forms.ToolStripMenuItem();
            this._item50 = new System.Windows.Forms.ToolStripMenuItem();
            this._item25 = new System.Windows.Forms.ToolStripMenuItem();
            this._item10 = new System.Windows.Forms.ToolStripMenuItem();
            this.tssFunction = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.gpcImagePath)).BeginInit();
            this.gpcImagePath.SuspendLayout();
            this.tspImagePath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpcEmployeeData)).BeginInit();
            this.gpcEmployeeData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmployeeData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmployeeData)).BeginInit();
            this.tspEmployeeNavigater.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpcEmployeeImage)).BeginInit();
            this.gpcEmployeeImage.SuspendLayout();
            this.tspZoomImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpcImagePath
            // 
            this.gpcImagePath.AppearanceCaption.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpcImagePath.AppearanceCaption.Options.UseFont = true;
            this.gpcImagePath.Controls.Add(this.tspImagePath);
            this.gpcImagePath.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpcImagePath.Location = new System.Drawing.Point(0, 0);
            this.gpcImagePath.Name = "gpcImagePath";
            this.gpcImagePath.Size = new System.Drawing.Size(1495, 60);
            this.gpcImagePath.TabIndex = 0;
            this.gpcImagePath.Text = "設定照片位置";
            // 
            // tspImagePath
            // 
            this.tspImagePath.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtImagePath,
            this.btnImagePath,
            this.tsProgress,
            this.btnHelp});
            this.tspImagePath.Location = new System.Drawing.Point(2, 23);
            this.tspImagePath.Name = "tspImagePath";
            this.tspImagePath.Size = new System.Drawing.Size(1491, 39);
            this.tspImagePath.TabIndex = 3;
            this.tspImagePath.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(160, 35);
            this.toolStripLabel1.Text = "員工證照片位置：";
            this.toolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtImagePath
            // 
            this.txtImagePath.Enabled = false;
            this.txtImagePath.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(500, 39);
            this.txtImagePath.Text = "C:\\";
            // 
            // btnImagePath
            // 
            this.btnImagePath.BackColor = System.Drawing.Color.LightGray;
            this.btnImagePath.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnImagePath.Image = ((System.Drawing.Image)(resources.GetObject("btnImagePath.Image")));
            this.btnImagePath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImagePath.Name = "btnImagePath";
            this.btnImagePath.Size = new System.Drawing.Size(61, 36);
            this.btnImagePath.Text = "選擇";
            this.btnImagePath.Click += new System.EventHandler(this.btnImagePath_Click);
            // 
            // tsProgress
            // 
            this.tsProgress.Name = "tsProgress";
            this.tsProgress.Size = new System.Drawing.Size(200, 36);
            this.tsProgress.ToolTipText = "轉檔進度顯示";
            this.tsProgress.Visible = false;
            // 
            // btnHelp
            // 
            this.btnHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnHelp.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 36);
            this.btnHelp.Text = "幫助";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 60);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gpcEmployeeData);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this._preview);
            this.splitContainerControl1.Panel2.Controls.Add(this.gpcEmployeeImage);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1495, 702);
            this.splitContainerControl1.SplitterPosition = 828;
            this.splitContainerControl1.TabIndex = 2;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gpcEmployeeData
            // 
            this.gpcEmployeeData.AppearanceCaption.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpcEmployeeData.AppearanceCaption.Options.UseFont = true;
            this.gpcEmployeeData.Controls.Add(this.gcEmployeeData);
            this.gpcEmployeeData.Controls.Add(this.tspEmployeeNavigater);
            this.gpcEmployeeData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpcEmployeeData.Location = new System.Drawing.Point(0, 0);
            this.gpcEmployeeData.Name = "gpcEmployeeData";
            this.gpcEmployeeData.Size = new System.Drawing.Size(828, 702);
            this.gpcEmployeeData.TabIndex = 1;
            this.gpcEmployeeData.Text = "員工基本資料";
            // 
            // gcEmployeeData
            // 
            this.gcEmployeeData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEmployeeData.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcEmployeeData.Location = new System.Drawing.Point(2, 62);
            this.gcEmployeeData.MainView = this.gvEmployeeData;
            this.gcEmployeeData.Name = "gcEmployeeData";
            this.gcEmployeeData.Size = new System.Drawing.Size(824, 638);
            this.gcEmployeeData.TabIndex = 6;
            this.gcEmployeeData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEmployeeData});
            // 
            // gvEmployeeData
            // 
            this.gvEmployeeData.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gvEmployeeData.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvEmployeeData.Appearance.HeaderPanel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvEmployeeData.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvEmployeeData.Appearance.Row.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvEmployeeData.Appearance.Row.Options.UseFont = true;
            this.gvEmployeeData.GridControl = this.gcEmployeeData;
            this.gvEmployeeData.Name = "gvEmployeeData";
            this.gvEmployeeData.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gvEmployeeData.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvEmployeeData.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvEmployeeData.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gvEmployeeData.OptionsSelection.MultiSelect = true;
            this.gvEmployeeData.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvEmployeeData.OptionsSelection.UseIndicatorForSelection = false;
            this.gvEmployeeData.OptionsView.ColumnAutoWidth = false;
            this.gvEmployeeData.OptionsView.EnableAppearanceEvenRow = true;
            this.gvEmployeeData.OptionsView.ShowGroupPanel = false;
            this.gvEmployeeData.CustomDrawColumnHeader += new DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventHandler(this.gvEmployeeData_CustomDrawColumnHeader);
            this.gvEmployeeData.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvEmployeeData_CustomDrawCell);
            this.gvEmployeeData.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvEmployeeData_RowCellStyle);
            this.gvEmployeeData.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvEmployeeData_FocusedRowChanged);
            // 
            // tspEmployeeNavigater
            // 
            this.tspEmployeeNavigater.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tspEmployeeNavigater.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEmployeePath,
            this.toolStripSeparator3,
            this.btnUpdate,
            this.toolStripSeparator1,
            this.btnFirst,
            this.btnPrev,
            this.txtIndex,
            this.lblCount,
            this.btnNext,
            this.btnLast,
            this.toolStripSeparator2,
            this.btnSample,
            this.btnCancel,
            this.btnCardSample});
            this.tspEmployeeNavigater.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tspEmployeeNavigater.Location = new System.Drawing.Point(2, 23);
            this.tspEmployeeNavigater.Name = "tspEmployeeNavigater";
            this.tspEmployeeNavigater.Size = new System.Drawing.Size(824, 39);
            this.tspEmployeeNavigater.TabIndex = 5;
            // 
            // btnEmployeePath
            // 
            this.btnEmployeePath.BackColor = System.Drawing.Color.LightGray;
            this.btnEmployeePath.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnEmployeePath.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployeePath.Image")));
            this.btnEmployeePath.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEmployeePath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEmployeePath.Name = "btnEmployeePath";
            this.btnEmployeePath.Size = new System.Drawing.Size(77, 36);
            this.btnEmployeePath.Text = "讀取";
            this.btnEmployeePath.Click += new System.EventHandler(this.btnEmployeePath_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.SkyBlue;
            this.btnUpdate.Image = global::pxCard.Properties.Resources.refresh2_32x32;
            this.btnUpdate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 36);
            this.btnUpdate.Text = "更新";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // btnFirst
            // 
            this.btnFirst.Enabled = false;
            this.btnFirst.Image = global::pxCard.Properties.Resources.first_32x32;
            this.btnFirst.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(75, 36);
            this.btnFirst.Text = "最前";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Enabled = false;
            this.btnPrev.Image = global::pxCard.Properties.Resources.prev_32x32;
            this.btnPrev.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 36);
            this.btnPrev.Text = "上筆";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // txtIndex
            // 
            this.txtIndex.Enabled = false;
            this.txtIndex.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtIndex.MaxLength = 5;
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(60, 39);
            this.txtIndex.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIndex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIndex_KeyDown);
            this.txtIndex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIndex_KeyPress);
            // 
            // lblCount
            // 
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 36);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Image = global::pxCard.Properties.Resources.next_32x321;
            this.btnNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 36);
            this.btnNext.Text = "下筆";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Enabled = false;
            this.btnLast.Image = global::pxCard.Properties.Resources.last_32x32;
            this.btnLast.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 36);
            this.btnLast.Text = "最後";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // btnSample
            // 
            this.btnSample.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSample.Image = ((System.Drawing.Image)(resources.GetObject("btnSample.Image")));
            this.btnSample.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSample.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSample.Name = "btnSample";
            this.btnSample.Size = new System.Drawing.Size(75, 36);
            this.btnSample.Text = "範列";
            this.btnSample.Click += new System.EventHandler(this.btnSample_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::pxCard.Properties.Resources.delete_32x32;
            this.btnCancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 36);
            this.btnCancel.Text = "離開";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCardSample
            // 
            this.btnCardSample.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCardSample.Image = global::pxCard.Properties.Resources.information_32x32;
            this.btnCardSample.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCardSample.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCardSample.Name = "btnCardSample";
            this.btnCardSample.Size = new System.Drawing.Size(90, 36);
            this.btnCardSample.Text = "示意圖";
            this.btnCardSample.Click += new System.EventHandler(this.btnCardSample_Click);
            // 
            // _preview
            // 
            this._preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this._preview.Document = null;
            this._preview.Location = new System.Drawing.Point(0, 60);
            this._preview.Name = "_preview";
            this._preview.Size = new System.Drawing.Size(662, 642);
            this._preview.TabIndex = 1;
            // 
            // gpcEmployeeImage
            // 
            this.gpcEmployeeImage.AppearanceCaption.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpcEmployeeImage.AppearanceCaption.Options.UseFont = true;
            this.gpcEmployeeImage.Controls.Add(this.tspZoomImage);
            this.gpcEmployeeImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpcEmployeeImage.Location = new System.Drawing.Point(0, 0);
            this.gpcEmployeeImage.Name = "gpcEmployeeImage";
            this.gpcEmployeeImage.Size = new System.Drawing.Size(662, 60);
            this.gpcEmployeeImage.TabIndex = 0;
            this.gpcEmployeeImage.Text = "員工卡貼圖檔";
            // 
            // tspZoomImage
            // 
            this.tspZoomImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tspZoomImage.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tspZoomImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImageCreate,
            this.tssMove,
            this.btnZoom100,
            this.btnZoomIn,
            this.btnZoomOut,
            this.btnZoom,
            this.tssFunction});
            this.tspZoomImage.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tspZoomImage.Location = new System.Drawing.Point(2, 23);
            this.tspZoomImage.Name = "tspZoomImage";
            this.tspZoomImage.Size = new System.Drawing.Size(658, 35);
            this.tspZoomImage.TabIndex = 4;
            // 
            // btnImageCreate
            // 
            this.btnImageCreate.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnImageCreate.Image = ((System.Drawing.Image)(resources.GetObject("btnImageCreate.Image")));
            this.btnImageCreate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnImageCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImageCreate.Name = "btnImageCreate";
            this.btnImageCreate.Size = new System.Drawing.Size(105, 32);
            this.btnImageCreate.Text = "產生卡貼";
            this.btnImageCreate.Click += new System.EventHandler(this.btnImageCreate_Click);
            // 
            // tssMove
            // 
            this.tssMove.Name = "tssMove";
            this.tssMove.Size = new System.Drawing.Size(6, 35);
            // 
            // btnZoom100
            // 
            this.btnZoom100.Image = global::pxCard.Properties.Resources.zoom100percent_32x32;
            this.btnZoom100.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnZoom100.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoom100.Name = "btnZoom100";
            this.btnZoom100.Size = new System.Drawing.Size(85, 32);
            this.btnZoom100.Text = "100%";
            this.btnZoom100.Click += new System.EventHandler(this.btnZoom100_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Image = global::pxCard.Properties.Resources.zoomin_32x32;
            this.btnZoomIn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(75, 32);
            this.btnZoomIn.Text = "放大";
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Image = global::pxCard.Properties.Resources.zoomout_32x32;
            this.btnZoomOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(75, 32);
            this.btnZoomOut.Text = "縮小";
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoom
            // 
            this.btnZoom.AutoToolTip = false;
            this.btnZoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._itemActualSize,
            this._itemFullPage,
            this._itemPageWidth,
            this._itemTwoPages,
            this.toolStripMenuItem1,
            this._item500,
            this._item200,
            this._item150,
            this._item100,
            this._item75,
            this._item50,
            this._item25,
            this._item10});
            this.btnZoom.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnZoom.Image = ((System.Drawing.Image)(resources.GetObject("btnZoom.Image")));
            this.btnZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Size = new System.Drawing.Size(86, 32);
            this.btnZoom.Text = "Zoom";
            this.btnZoom.ButtonClick += new System.EventHandler(this.btnZoom_ButtonClick);
            this.btnZoom.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.btnZoom_DropDownItemClicked);
            // 
            // _itemActualSize
            // 
            this._itemActualSize.Image = ((System.Drawing.Image)(resources.GetObject("_itemActualSize.Image")));
            this._itemActualSize.Name = "_itemActualSize";
            this._itemActualSize.Size = new System.Drawing.Size(166, 24);
            this._itemActualSize.Text = "Actual Size";
            // 
            // _itemFullPage
            // 
            this._itemFullPage.Image = ((System.Drawing.Image)(resources.GetObject("_itemFullPage.Image")));
            this._itemFullPage.Name = "_itemFullPage";
            this._itemFullPage.Size = new System.Drawing.Size(166, 24);
            this._itemFullPage.Text = "Full Page";
            // 
            // _itemPageWidth
            // 
            this._itemPageWidth.Image = ((System.Drawing.Image)(resources.GetObject("_itemPageWidth.Image")));
            this._itemPageWidth.Name = "_itemPageWidth";
            this._itemPageWidth.Size = new System.Drawing.Size(166, 24);
            this._itemPageWidth.Text = "Page Width";
            // 
            // _itemTwoPages
            // 
            this._itemTwoPages.Image = ((System.Drawing.Image)(resources.GetObject("_itemTwoPages.Image")));
            this._itemTwoPages.Name = "_itemTwoPages";
            this._itemTwoPages.Size = new System.Drawing.Size(166, 24);
            this._itemTwoPages.Text = "Two Pages";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(163, 6);
            // 
            // _item500
            // 
            this._item500.Name = "_item500";
            this._item500.Size = new System.Drawing.Size(166, 24);
            this._item500.Text = "500%";
            // 
            // _item200
            // 
            this._item200.Name = "_item200";
            this._item200.Size = new System.Drawing.Size(166, 24);
            this._item200.Text = "200%";
            // 
            // _item150
            // 
            this._item150.Name = "_item150";
            this._item150.Size = new System.Drawing.Size(166, 24);
            this._item150.Text = "150%";
            // 
            // _item100
            // 
            this._item100.Name = "_item100";
            this._item100.Size = new System.Drawing.Size(166, 24);
            this._item100.Text = "100%";
            // 
            // _item75
            // 
            this._item75.Name = "_item75";
            this._item75.Size = new System.Drawing.Size(166, 24);
            this._item75.Text = "75%";
            // 
            // _item50
            // 
            this._item50.Name = "_item50";
            this._item50.Size = new System.Drawing.Size(166, 24);
            this._item50.Text = "50%";
            // 
            // _item25
            // 
            this._item25.Name = "_item25";
            this._item25.Size = new System.Drawing.Size(166, 24);
            this._item25.Text = "25%";
            // 
            // _item10
            // 
            this._item10.Name = "_item10";
            this._item10.Size = new System.Drawing.Size(166, 24);
            this._item10.Text = "10%";
            // 
            // tssFunction
            // 
            this.tssFunction.Name = "tssFunction";
            this.tssFunction.Size = new System.Drawing.Size(6, 35);
            // 
            // frmPXCARD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1495, 762);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.gpcImagePath);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmPXCARD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "全聯員工證卡貼轉檔系統";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPXCARD_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gpcImagePath)).EndInit();
            this.gpcImagePath.ResumeLayout(false);
            this.gpcImagePath.PerformLayout();
            this.tspImagePath.ResumeLayout(false);
            this.tspImagePath.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpcEmployeeData)).EndInit();
            this.gpcEmployeeData.ResumeLayout(false);
            this.gpcEmployeeData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmployeeData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmployeeData)).EndInit();
            this.tspEmployeeNavigater.ResumeLayout(false);
            this.tspEmployeeNavigater.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpcEmployeeImage)).EndInit();
            this.gpcEmployeeImage.ResumeLayout(false);
            this.gpcEmployeeImage.PerformLayout();
            this.tspZoomImage.ResumeLayout(false);
            this.tspZoomImage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpcImagePath;
        private System.Windows.Forms.ToolStrip tspImagePath;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnImagePath;
        private System.Windows.Forms.ToolStripTextBox txtImagePath;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl gpcEmployeeImage;
        public System.Windows.Forms.ToolStrip tspZoomImage;
        private System.Windows.Forms.ToolStripSeparator tssFunction;
        public System.Windows.Forms.ToolStripButton btnZoomIn;
        public System.Windows.Forms.ToolStripButton btnZoom100;
        public System.Windows.Forms.ToolStripButton btnZoomOut;
        private System.Windows.Forms.ToolStripSplitButton btnZoom;
        private System.Windows.Forms.ToolStripMenuItem _itemActualSize;
        private System.Windows.Forms.ToolStripMenuItem _itemFullPage;
        private System.Windows.Forms.ToolStripMenuItem _itemPageWidth;
        private System.Windows.Forms.ToolStripMenuItem _itemTwoPages;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem _item500;
        private System.Windows.Forms.ToolStripMenuItem _item200;
        private System.Windows.Forms.ToolStripMenuItem _item150;
        private System.Windows.Forms.ToolStripMenuItem _item100;
        private System.Windows.Forms.ToolStripMenuItem _item75;
        private System.Windows.Forms.ToolStripMenuItem _item50;
        private System.Windows.Forms.ToolStripMenuItem _item25;
        private System.Windows.Forms.ToolStripMenuItem _item10;
        private CoolPrintPreview.CoolPrintPreviewControl _preview;
        private DevExpress.XtraEditors.GroupControl gpcEmployeeData;
        private DevExpress.XtraGrid.GridControl gcEmployeeData;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEmployeeData;
        public System.Windows.Forms.ToolStrip tspEmployeeNavigater;
        public System.Windows.Forms.ToolStripButton btnFirst;
        public System.Windows.Forms.ToolStripButton btnPrev;
        private System.Windows.Forms.ToolStripTextBox txtIndex;
        public System.Windows.Forms.ToolStripButton btnNext;
        public System.Windows.Forms.ToolStripButton btnLast;
        private System.Windows.Forms.ToolStripButton btnImageCreate;
        private System.Windows.Forms.ToolStripSeparator tssMove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnEmployeePath;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lblCount;
        private System.Windows.Forms.ToolStripButton btnSample;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripButton btnCardSample;
        private System.Windows.Forms.ToolStripButton btnUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripProgressBar tsProgress;
        private System.Windows.Forms.ToolStripButton btnHelp;
    }
}

