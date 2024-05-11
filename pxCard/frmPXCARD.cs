using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using pxCard.DBControl;
using CoolPrintPreview;
using DevExpress.XtraGrid.Columns;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Ionic.Zip;

namespace pxCard
{
    public partial class frmPXCARD : Form
    {
        private readonly string _dbPath = @"data source=.\main\pxCard.db";
        private readonly string _paperId = "pxcard";
        private readonly string _formatId = "card-v01";
        private readonly string _imgUnder = @".\main\pxCard.png";
        private readonly string _imgWhite = @".\main\white.png";
        private readonly int _inZipFileCount = 20;

        private DataTable _dtEmployee = new DataTable();
        private BindingSource _bsEmployee = new BindingSource();
        private PrintDocument _document;
        private string _printer = string.Empty;
        private int start = 0;
        private int paper_width = 0;
        private int paper_height = 0;
        private PaperKind paperKind = PaperKind.B5;
        private static readonly float INCH = 0.254f;

        public enum PrintType { Text, Barcode, Image, QRCode }



        public frmPXCARD() : this(null)
        {
        }

        public frmPXCARD(Control parentForm)
        {
            InitializeComponent();
            this.MouseWheel += FrmPXCARD_MouseWheel;
            if (parentForm != null)
            {
                Size = parentForm.Size;
            }
        }

        private void FrmPXCARD_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                _preview.Zoom = (_preview.Zoom < 5) ? _preview.Zoom += .25 : _preview.Zoom;
            else
                _preview.Zoom = (_preview.Zoom > 1) ?_preview.Zoom -= .25 : _preview.Zoom;

            
            //MessageBox.Show(e.Delta.ToString());
        }

        public PrintDocument Document
        {
            get { return _document; }
            set
            {
                // unhook event handlers
                if (_document != null)
                {
                    _document.BeginPrint -= _doc_BeginPrint;
                    _document.EndPrint -= _doc_EndPrint;
                }

                // save the value
                _document = value;

                // hook up event handlers
                if (_document != null)
                {
                    _document.BeginPrint += _doc_BeginPrint;
                    _document.EndPrint += _doc_EndPrint;
                }


                // don't assign document to preview until this form becomes visible
                if (Visible)
                {
                    _preview.Document = Document;
                }
            }
        }

        private void _doc_BeginPrint(object sender, PrintEventArgs e)
        {
            btnCancel.Text = "取消";
            btnImageCreate.Enabled = false;
        }

        private void _doc_EndPrint(object sender, PrintEventArgs e)
        {
            btnCancel.Text = "離開";
            btnImageCreate.Enabled = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (_preview.IsRendering && !e.Cancel)
            {
                _preview.Cancel();
            }
        }

        private void btnImagePath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "請選擇圖檔所在資料夾";
                if (dialog.ShowDialog(null) == DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(dialog.SelectedPath))
                    {
                        MessageBox.Show("資料夾路徑不能為空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    txtImagePath.Text = dialog.SelectedPath;
                }
            }
        }

        private DataTable Import_From_Excel(string file_name)
        {
            DataTable table = new DataTable();
            Excel.Application excel_app = null;
            Excel.Workbook excel_workbook = null;
            Excel.Worksheet excel_sheet = null;
            Excel.Range excel_range = null;

            try
            {
                excel_app = new Excel.Application();
                excel_app.Visible = false;
                excel_app.DisplayAlerts = false;

                excel_workbook = excel_app.Workbooks.Open(file_name);
                excel_sheet = (Excel.Worksheet)excel_workbook.Worksheets.Item[1];
                excel_range = excel_sheet.UsedRange;

                int col_count = excel_range.Columns.Count;
                int row_count = excel_range.Rows.Count;

                for (int j = 1; j <= col_count; j++)
                {
                    table.Columns.Add(Convert.ToString
                                         (excel_range.Cells[1, j].Value2), typeof(string));
                }
                //filling the table from  excel file                
                for (int i = 2; i <= row_count; i++)
                {
                    DataRow dr = table.NewRow();
                    for (int j = 0; j < col_count; j++)
                    {

                        dr[j] = Convert.ToString(excel_range.Cells[i, j + 1].Value2);
                    }

                    table.Rows.InsertAt(dr, table.Rows.Count + 1);
                }

                excel_workbook.Close();
                excel_app.Quit();

                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                excel_range = null;
                excel_sheet = null;
                excel_workbook = null;
            }
        }

        private void btnEmployeePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Excel Files|*.xls;*.xlsx";

            if (dialog.ShowDialog() == DialogResult.OK || dialog.FileName.Trim() != string.Empty)
            {
                string file_name = dialog.FileName.Trim();
                   
                _dtEmployee = Import_From_Excel(file_name).Add_Row_Number("序號").Add_Name_Space("姓名").Add_Image_Extension("照片名稱");
                _bsEmployee.DataSource = _dtEmployee;


                InitEmployeeDatatable(_dtEmployee);
                gcEmployeeData.DataSource = _bsEmployee;

                //btnFirst.Enabled = true;
                //btnPrev.Enabled = true;
                if (_dtEmployee.Rows.Count > 1)
                {
                    txtIndex.Enabled = true;
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                }

                InitEmployeeDataGrid(gvEmployeeData);

                //Print_Detail(_dtEmployee, txtImagePath.Text);

                Batch_Preview(GetDefaultPrinter());
            }      
        }

        private void InitEmployeeDatatable(DataTable dtb)
        {
            int index = 0;
            dtb.Columns["序號"].SetOrdinal(index++);
            dtb.Columns["員工編號"].SetOrdinal(index++);
            dtb.Columns["姓名"].SetOrdinal(index++);
            dtb.Columns["卡號"].SetOrdinal(index++);
            dtb.Columns["照片名稱"].SetOrdinal(index++);
           
            dtb.Columns["序號"].Caption = "序號";
            dtb.Columns["員工編號"].Caption = "員工編號";
            dtb.Columns["姓名"].Caption = "姓名";
            dtb.Columns["卡號"].Caption = "卡號";
            dtb.Columns["照片名稱"].Caption = "照片名稱";
           
            dtb.Columns["序號"].ReadOnly = true;
            dtb.Columns["員工編號"].ReadOnly = true;
            dtb.Columns["姓名"].ReadOnly = false;
            dtb.Columns["卡號"].ReadOnly = true;
            dtb.Columns["照片名稱"].ReadOnly = false;
        }

        private void InitEmployeeDataGrid(GridView view)
        {
            view.Columns["序號"].VisibleIndex = 0;

            view.Columns["序號"].BestFit();
            view.Columns["員工編號"].Width = 100;
            view.Columns["姓名"].Width = 100;
            view.Columns["卡號"].Width = 200;
            view.Columns["照片名稱"].Width = 300;

            view.Columns["序號"].OptionsColumn.AllowEdit = false;
            view.Columns["員工編號"].OptionsColumn.AllowEdit = false;
            view.Columns["姓名"].OptionsColumn.AllowEdit = true;
            view.Columns["卡號"].OptionsColumn.AllowEdit = false;
            view.Columns["照片名稱"].OptionsColumn.AllowEdit = true;

            view.Columns["序號"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            view.Columns["員工編號"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            view.Columns["姓名"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            view.Columns["卡號"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            view.Columns["照片名稱"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;

            view.OptionsCustomization.AllowFilter = false;
            view.FocusedRowHandle = 0;
            view.SelectAll();

            
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            //gvEmployeeData.MoveFirst();
            
            _preview.StartPage = 0;
            gvEmployeeData.FocusedRowHandle = _preview.StartPage;
            gvEmployeeData.SelectRow(_preview.StartPage);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            //gvEmployeeData.MovePrev();
            _preview.StartPage--;
            gvEmployeeData.FocusedRowHandle = _preview.StartPage;
            gvEmployeeData.SelectRow(_preview.StartPage);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //gvEmployeeData.MoveNext();
            _preview.StartPage++;
            gvEmployeeData.FocusedRowHandle = _preview.StartPage;
            gvEmployeeData.SelectRow(_preview.StartPage);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            //gvEmployeeData.MoveLast();        
            _preview.StartPage = _preview.PageCount - 1;
            gvEmployeeData.FocusedRowHandle = _preview.PageCount - 1;
            gvEmployeeData.SelectRow(_preview.PageCount - 1);
        }

        private void txtIndex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int row_index = int.Parse(txtIndex.Text);

                if (row_index > gvEmployeeData.RowCount)
                {
                    MessageBox.Show("超過總筆數", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIndex.SelectAll();
                    return;
                }

                gvEmployeeData.FocusedRowHandle = row_index - 1;
            }
        }

        private void gvEmployeeData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtIndex.Text = (gvEmployeeData.FocusedRowHandle + 1).ToString();
            lblCount.Text = $@"/ {gvEmployeeData.RowCount}";

            btnFirst.Enabled = (gvEmployeeData.FocusedRowHandle == 0) ? false : true;
            btnPrev.Enabled = (gvEmployeeData.FocusedRowHandle == 0) ? false : true;

            btnLast.Enabled = (gvEmployeeData.FocusedRowHandle == gvEmployeeData.RowCount - 1) ? false : true;
            btnNext.Enabled = (gvEmployeeData.FocusedRowHandle == gvEmployeeData.RowCount - 1) ? false : true;

            _preview.StartPage = gvEmployeeData.FocusedRowHandle;
        }

        private void txtIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar) && e.KeyChar != (int)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void gvEmployeeData_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column != null && e.Column.Name == "員工編號")
            {
                e.DefaultDraw();
                e.Handled = true;
                e.Graphics.DrawString("Selector", e.Appearance.Font, Brushes.Black, new PointF(e.Bounds.X, e.Bounds.Y));
            }
        }

        private void gvEmployeeData_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "序號" || e.Column.FieldName == "員工編號" || e.Column.FieldName == "卡號")
            {
                e.Appearance.BackColor = Color.LightGray;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_preview.IsRendering)
            {
                _preview.Cancel();
            }
            else
            {
                Close();
            }
        }

        private void btnImageCreate_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(gvEmployeeData.GetSelectedRows().Count().ToString());

            int[] select = gvEmployeeData.GetSelectedRows();
            GridView view = gvEmployeeData;
            //GridColumn colImage = view.Columns["照片名稱"];
            GridColumn colEmployeeId = view.Columns["員工編號"];

            tsProgress.Minimum = 0;
            tsProgress.Maximum = select.Length;
            tsProgress.Step = 1;
            tsProgress.Value = 0;
            


            if (select.Length == 0)
            {
                MessageBox.Show("沒有選擇轉檔資料!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "請選擇儲存的目錄";
                if (dialog.ShowDialog(null) == DialogResult.OK)
                {

                    if (string.IsNullOrEmpty(dialog.SelectedPath))
                    {
                        MessageBox.Show("資料夾路徑不能為空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string output = dialog.SelectedPath;
                    string file = string.Empty;

                    tsProgress.Visible = true;

                    new Thread(() =>
                    {

                        foreach (int i in select)
                        {
                            this.Invoke(new EventHandler(delegate {
                                tsProgress.PerformStep();
                            }));

                            file = view.GetRowCellValue(i, colEmployeeId).ToString();
                            Resize_Image(_preview.Images[i], 0.75f).Save(Path.Combine(output, file + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);                         
                        }

                        Compressed_Image(output);

                        System.Diagnostics.Process.Start("Explorer.exe", $"/e, {output}");

                        this.Invoke(new EventHandler(delegate {
                            tsProgress.Visible = false;
                            MessageBox.Show("轉檔完成!!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }));
                    }).Start();
            }
            }


        }

        private Image Resize_Image(Image imgToResize, float percent)
        {
            //Get the image current width  
            int sourceWidth = imgToResize.Width;
            //Get the image current height  
            int sourceHeight = imgToResize.Height;
         
            //New Width  
            int destWidth = (int)(sourceWidth * percent);
            //New Height  
            int destHeight = (int)(sourceHeight * percent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height  
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (Image)b;
        }

        private void Compressed_Image(string path)
        { 
      
            ZipFile zip = new ZipFile();
            string filter =  @"^.+\.\bjpg\b$";

            int file_idx = 0;
            int zip_idx = 0;

            foreach (string fname in Directory.GetFiles(path).Where(file =>
                                                    Regex.IsMatch(file.ToLower().Trim(), filter)))
            {
                file_idx++;

                if (file_idx % _inZipFileCount == 0)
                {
                    zip.AddFile(fname,"");
                    zip_idx++;
                    zip.Save(Path.Combine(path, $"PIC-{zip_idx.ToString("000")}.zip"));
                    file_idx = 0;
                    zip = new ZipFile();
                }
                else
                {
                    zip.AddFile(fname, "");
                }
            }

            if (file_idx % _inZipFileCount != 0)
            {
                zip_idx++;
                zip.Save(Path.Combine(path, $"PIC-{zip_idx.ToString("000")}.zip"));
            }

            zip.Dispose();

        }

        private  byte[] BinaryReadToEnd(Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }

        private DataTable Print_Detail(DataTable dtb, string img_path)
        {
            String guid = Guid.NewGuid().ToString();
            string now = DateTime.Now.ToString();

            DataTable ret = MakeNamesTable();

            foreach (DataRow dr in dtb.Rows)
            {
                DataRow row = ret.NewRow();

                string card_num = dr["卡號"].ToString().Insert(4, "    ").Insert(12, "    ").Insert(20, "    ");

                row["print_seq"] = Convert.ToUInt32(dr["序號"]);
                row["format_id"] = _formatId;
                row["data"] = $@"{_imgUnder}^{Path.Combine(img_path,dr["照片名稱"].ToString())}^{dr["員工編號"].ToString()}^{dr["姓名"].ToString()}^{_imgWhite}^{dr["卡號"].ToString()}^{card_num}";
                row["crt_date"] = now;

                ret.Rows.Add(row);
            }

            return ret;
        }

        private DataTable MakeNamesTable()
        {
            DataTable namesTable = new DataTable("CardDetail");

            DataColumn seqColumn = new DataColumn();
            seqColumn.DataType = System.Type.GetType("System.Int32");
            seqColumn.ColumnName = "print_seq";
            namesTable.Columns.Add(seqColumn);

            DataColumn formatColumn = new DataColumn();
            formatColumn.DataType = System.Type.GetType("System.String");
            formatColumn.ColumnName = "format_id";
            formatColumn.DefaultValue = _formatId;
            namesTable.Columns.Add(formatColumn);

            DataColumn dataColumn = new DataColumn();
            dataColumn.DataType = System.Type.GetType("System.String");
            dataColumn.ColumnName = "data";
            namesTable.Columns.Add(dataColumn);

            DataColumn timeColumn = new DataColumn();
            timeColumn.DataType = System.Type.GetType("System.String");
            timeColumn.ColumnName = "crt_date";
            namesTable.Columns.Add(timeColumn);

            DataColumn[] keys = new DataColumn[1];
            keys[0] = seqColumn;
            namesTable.PrimaryKey = keys;

            return namesTable;
        }

        public void Batch_Preview(string printer)
        {

            _printer = printer;

            //int page = 0;
            start = 0;


            //try
            //{
                DaoPopPaper paper = new DaoPopPaper(_dbPath, _paperId);

                paper_width = mmToInch(paper.Width);
                paper_height = mmToInch(paper.Height);

                paperKind = PaperKind.Custom;

                if (paper.Kind.ToUpper() == "B5")
                    paperKind = PaperKind.B5;

                if (paper.Kind.ToUpper() == "A4")
                    paperKind = PaperKind.A4;

                using (PrintDocument p = new PrintDocument())
                {
                    p.PrintPage += new PrintPageEventHandler(Batch_PrintPage);
                    //Design.CoolPrintPreviewDialog ppd = new Design.CoolPrintPreviewDialog();
                    //ppd.WindowState = FormWindowState.Maximized;

                    p.DefaultPageSettings.Landscape = paper.Direction;
                    PaperSize pageSize = null;

                    if (paper.Direction)
                        pageSize = new PaperSize("Default", paper_height, paper_width);
                    else
                        pageSize = new PaperSize("Default", paper_width, paper_height);

                    pageSize.RawKind = (int)paperKind;
                    p.DefaultPageSettings.PaperSize = pageSize;
                    p.PrinterSettings.PrinterName = _printer;

                    this.Document = p;
                    //ppd.Document = p;
                    //ppd.ShowDialog();
                    //page = ppd._preview.PageCount;
                }

            //}
            //catch (Exception ex)
            //{
                
            //    MessageBox.Show(ex.Message, "錯誤",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //}

            //return page;
        }

        private void Batch_PrintPage(object sender, PrintPageEventArgs e)
        {
            DaoPopFormat daoFormat = new DaoPopFormat(_dbPath, _formatId);


            DataTable detailTable = Print_Detail(_dtEmployee, txtImagePath.Text);
            DataTable dtFormat = null;

            int shiftX = 0;
            int shiftY = 0;
            int max_shittY = 0;
            bool chPage = false;
            int i = 0;

            for (i = start; i < detailTable.Rows.Count; i++)
            {
                string[] printList = detailTable.Rows[i]["DATA"].ToString().Split('^');
                string fmtId = detailTable.Rows[i]["FORMAT_ID"] == DBNull.Value ? string.Empty : detailTable.Rows[i]["FORMAT_ID"].ToString();
                dtFormat = daoFormat.Format_Detail;
                int format_width = mmToInch(daoFormat.Format_Width);
                int format_height = mmToInch(daoFormat.Format_Height);

                if (printList.Length != dtFormat.Rows.Count)
                {
                    string msg = string.Format("字串資料不正確，\r\n請洽詢資訊部，\r\n謝謝。\r\n字串： {0} 個，\r\n格式： {1} 個", printList.Length, dtFormat.Rows.Count);
                    Font font = new Font("微軟正黑體", 12, FontStyle.Bold);
                    e.Graphics.DrawString(msg, font, new SolidBrush(Color.Black), shiftX + 5, shiftY + 5);
                }
                else
                {
                    PrintWithFormat(e, printList, dtFormat, shiftX, shiftY);
                }

                string next_format_id = string.Empty;
                int next_format_width = 0;
                int next_format_height = 0;

                shiftX += format_width;
                if (max_shittY < shiftY + format_height) max_shittY = shiftY + format_height;

                if (i + 1 < detailTable.Rows.Count)
                {
                   
                    next_format_id = detailTable.Rows[i + 1]["FORMAT_ID"] == null ? string.Empty : detailTable.Rows[i + 1]["FORMAT_ID"].ToString();

                    DaoPopFormat next_format = new DaoPopFormat(_dbPath, next_format_id);
                    next_format_width = mmToInch(next_format.Format_Width);
                    next_format_height = mmToInch(next_format.Format_Height);

                    if (shiftX + next_format_width > paper_width || shiftX >= paper_width)
                    {
                        shiftX = 0;
                        shiftY = max_shittY;
                    }
                }

                if (shiftY >= paper_height || shiftY + next_format_height > paper_height) //大於頁高，換頁
                {
                    chPage = true;
                    start = i + 1;
                    shiftX = 0;
                    shiftY = 0;
                    max_shittY = 0;
                    break;
                }
                else
                {
                    chPage = false;
                }
            }

            if (chPage)//設定換頁
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
                start = 0;
            }
        }

        private void PrintWithFormat(PrintPageEventArgs e, string[] list, DataTable format, int shiftX, int shiftY)
        {
            string fontFamily = string.Empty;
            float fontSize = 0f;
            string fontStyle = string.Empty;
            float textWidth = 0f;
            float textHeight = 0f;
            string fontColor = string.Empty;
            StringAlignment vAlign = StringAlignment.Near;
            StringAlignment hAlign = StringAlignment.Near;
            PrintType printType = PrintType.Text;
            bool isMatrix = false;
            bool dynamicMatrix = false;
            float zoomX = 1f;
            float zoomY = 1f;
            bool isDirectionVertical = false;
            bool isBox = false;
            StringFormat drawFormat = new StringFormat();
            int boxline = 2;

            int origX = 0;
            int origY = 0;

            for (int i = 0; i < format.Rows.Count; i++)
            {
                try
                {
                    /* 設定文字格式 */
                    fontFamily = format.Rows[i]["FONT_NAME"] == DBNull.Value ? "微軟正黑體" : format.Rows[i]["FONT_NAME"].ToString();            //文字字型
                    fontSize = format.Rows[i]["FONT_SIZE"] == DBNull.Value ? 1 : Convert.ToInt32(format.Rows[i]["FONT_SIZE"]);         //文字大小
                    fontStyle = format.Rows[i]["FONT_STYLE"] == DBNull.Value ? "REGULAR" : format.Rows[i]["FONT_STYLE"].ToString().ToUpper(); //文字Style 
                    textWidth = format.Rows[i]["WIDTH"] == DBNull.Value ? 0 : Convert.ToInt32(format.Rows[i]["WIDTH"]);                //文字最大寬度
                    textHeight = format.Rows[i]["HEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(format.Rows[i]["HEIGHT"]);             //文字最大高度
                    vAlign = (StringAlignment)(format.Rows[i]["VERTICAL_ALIGN"] == DBNull.Value ? 0 : Convert.ToInt32(format.Rows[i]["VERTICAL_ALIGN"])); //文字垂直對齊
                    hAlign = (StringAlignment)(format.Rows[i]["HORIZONTAL_ALIGN"] == DBNull.Value ? 0 : Convert.ToInt32(format.Rows[i]["HORIZONTAL_ALIGN"])); //文字水平對齊
                    FontStyle eFontStyle = GetFontStyle(fontStyle);

                    /* 設定列印起始位址 */
                    origX = format.Rows[i]["X_SITE"] == DBNull.Value ? 0 : Convert.ToInt32(format.Rows[i]["X_SITE"]); //X軸位置                
                    origY = format.Rows[i]["Y_SITE"] == DBNull.Value ? 0 : Convert.ToInt32(format.Rows[i]["Y_SITE"]); //Y軸位置
                    origX += shiftX; //計算X位移
                    origY += shiftY; //計算Y位移
                    Point PSite = new Point(origX, origY);

                    isMatrix = false;
                    isBox = false;
                    dynamicMatrix = false;
                    zoomX = 1.0f;
                    zoomY = 1.0f;
                    //*****  復原向量比例  *****//
                    Matrix oriMatrix = new Matrix();
                    oriMatrix.Scale(zoomX, zoomY);
                    e.Graphics.Transform = oriMatrix;

                    /* //////////對齊測試框線/////////////*/
                    //if (vAlign != StringAlignment.Near && hAlign != StringAlignment.Near)


                    /* 設定文字顏色 */
                    fontColor = format.Rows[i]["FONT_COLOR"] == DBNull.Value ? "Black" : format.Rows[i]["FONT_COLOR"].ToString(); //文字顏色 
                    Color color = new Color();
                    color = Color.FromName(fontColor);

                    /* 文字特殊設定：文字大小、文字Style、文字顏色 */

                    string[] para = list[i].Split(new string[] { "@@" }, StringSplitOptions.RemoveEmptyEntries);

                    //取得列印資料
                    string printData = string.Empty;
                    if (i < list.Length && list[i] != string.Empty)
                    {
                        printData = para[0] == null ? "" : para[0].ToString();
                    }

                    printType = (PrintType)(format.Rows[i]["PRINT_TYPE"] == DBNull.Value ? 0 : Convert.ToInt32(format.Rows[i]["PRINT_TYPE"]));
                    isMatrix = format.Rows[i]["MATRIX"] == DBNull.Value ? false : Convert.ToBoolean(format.Rows[i]["MATRIX"]);
                    isDirectionVertical = format.Rows[i]["DIRECTION_VERTICAL"] == DBNull.Value ? false : Convert.ToBoolean(format.Rows[i]["DIRECTION_VERTICAL"]);

                    if (para.Length > 1)
                    {
                        para[1] = para[1].ToUpper();
                        string[] attribute = para[1].Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string str in attribute)
                        {
                            string[] value = str.Split(':');
                            switch (value[0])
                            {
                                case "SIZE":
                                    fontSize = Convert.ToInt32(value[1]);
                                    break;
                                case "STYLE":
                                    eFontStyle = GetFontStyle(value[1]);
                                    break;
                                case "COLOR":
                                    color = Color.FromName(value[1]);
                                    break;
                                case "ZOOMW":
                                    isMatrix = true;
                                    dynamicMatrix = true;
                                    zoomX = Convert.ToSingle(value[1]);
                                    break;
                                case "ZOOMH":
                                    isMatrix = true;
                                    dynamicMatrix = true;
                                    zoomY = Convert.ToSingle(value[1]);
                                    break;
                                case "BOX":
                                    isBox = true;
                                    if (value.Length == 2)
                                        boxline = int.Parse(value[1]);
                                    else
                                        boxline = 2;
                                    break;
                                case "BCODE":
                                    printType = PrintType.Barcode;
                                    fontFamily = value[1];
                                    break;
                                case "HEIGHT":
                                    textHeight = Convert.ToInt32(value[1]);
                                    break;
                            }
                        }
                    }

                    Font PrintFont = new Font(fontFamily, fontSize, eFontStyle, System.Drawing.GraphicsUnit.Point);

                    /* 垂直對齊、水平對齊 */
                    if (isDirectionVertical == true)
                        drawFormat = new StringFormat(StringFormatFlags.DirectionVertical);
                    else
                        drawFormat = new StringFormat();
                    drawFormat.LineAlignment = vAlign;
                    drawFormat.Alignment = hAlign;

                    #region 列印文字 
                    if (printType == PrintType.Text)
                    {
                        if (isBox == true && textWidth != 0 && textHeight != 0)
                        {
                            e.Graphics.DrawRectangle(new Pen(color, boxline), origX, origY, textWidth, textHeight);
                        }

                        Matrix matrix = new Matrix();
                        if (isMatrix == true) /* !!!!!有轉折才縮放，要再確定需求!!!!!!! */
                        {
                            if (dynamicMatrix == false)
                            {
                                zoomX = format.Rows[i]["X_ZOOM"] == DBNull.Value ? 1f : Convert.ToSingle(format.Rows[i]["X_ZOOM"]);
                                zoomY = format.Rows[i]["Y_ZOOM"] == DBNull.Value ? 1f : Convert.ToSingle(format.Rows[i]["Y_ZOOM"]);
                            }
                            matrix.Scale(zoomX, zoomY);
                            e.Graphics.Transform = matrix;
                            if (textWidth != 0 && textHeight != 0)
                                e.Graphics.DrawString(printData, PrintFont, new SolidBrush(color),
                                    new RectangleF((int)(origX / zoomX), (int)(origY / zoomY), (int)(textWidth / zoomX), (int)(textHeight / zoomY)), drawFormat);
                            else
                                e.Graphics.DrawString(printData, PrintFont, new SolidBrush(color),
                                    new Point((int)(origX / zoomX), (int)(origY / zoomY)), drawFormat);
                        }
                        else
                        {
                            matrix.Scale(1, 1);
                            e.Graphics.Transform = matrix;
                            if (textWidth != 0 && textHeight != 0)
                                e.Graphics.DrawString(printData, PrintFont, new SolidBrush(color), new RectangleF(origX, origY, textWidth, textHeight), drawFormat);
                            else
                                e.Graphics.DrawString(printData, PrintFont, new SolidBrush(color), PSite, drawFormat);
                        }
                    }
                    #endregion

                    #region 列印Barcode
                    if (printType == PrintType.Barcode)
                    {
                        if (printData == string.Empty || printData.Length < 3)
                        {
                            continue;
                        }

                        Code128 code = new Code128();
                        Code128.Encode encode = GetBarcodeEncode(fontFamily);

                        Image img = null;
                
                        img = code.GetCodeImage(printData, encode);

                        if (textWidth != 0 && textHeight != 0)
                            e.Graphics.DrawImage(img, origX, origY, textWidth, textHeight);
                        else
                            e.Graphics.DrawImage(img, origX, origY);

                        img.Dispose();
                    }
                    #endregion

                    #region 列印圖片
                    if (printType == PrintType.Image)
                    {
                        if (printData == string.Empty)
                        {
                            continue;
                        }

                        Image img = null;
                        if (printData.ToUpper().IndexOf("HTTP") == -1)
                        {
                            using (FileStream fs = new FileStream(printData, FileMode.Open))
                            {
                                BinaryReader br = new BinaryReader(fs);
                                img = Image.FromStream(br.BaseStream);
                            }
                        }
                        else
                        {
                            System.Net.WebClient WC = new System.Net.WebClient();
                            MemoryStream Ms = new MemoryStream(WC.DownloadData(printData));
                            img = Image.FromStream(Ms);
                        }

                        e.Graphics.DrawImage(img, origX, origY, textWidth, textHeight);
                        img.Dispose();
                    }

                    #endregion


                }
                catch
                {
                    //_log.Write(LogLevel.ERROE, "第" + i + "筆資料，"+ ex.Message);
                }
            }
        }

        private FontStyle GetFontStyle(string fontStyle)
        {
            switch (fontStyle)
            {
                case "BOLD": //粗體字
                case "B":
                    return FontStyle.Bold;
                case "ITALIC"://斜體字
                case "I":
                    return FontStyle.Italic;
                case "REGULAR"://一般文字
                case "R":
                    return FontStyle.Regular;
                case "STRIKEOUT"://刪除線
                case "S":
                    return FontStyle.Strikeout;
                case "UNDERLINE"://加底線
                case "U":
                    return FontStyle.Underline;
                default:
                    return FontStyle.Regular;
            }
        }

        private Code128.Encode GetBarcodeEncode(string barcode)
        {
            switch (barcode.ToUpper())
            {
                default:
                case "BARCODE128A":
                case "CODE128A":
                    return Code128.Encode.Code128A;
                case "BARCODE128B":
                case "CODE128B":
                    return Code128.Encode.Code128B;
                case "BARCODE128C":
                case "CODE128C":
                    return Code128.Encode.Code128C;
            }
        }

        private int mmToInch(int mm)
        {
            return (int)(mm / INCH);
        }
        private int mmToInch(float mm)
        {
            return (int)(mm / INCH);
        }

        private void btnSample_Click(object sender, EventArgs e)
        {
            string file = @".\main\sample.xlsx";
            if (File.Exists(file))
                System.Diagnostics.Process.Start(file);
            else
                MessageBox.Show("找不到範例資料", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCardSample_Click(object sender, EventArgs e)
        {
            string file = @".\main\員工福利卡貼紙示意.jpg";
            if (File.Exists(file))
                System.Diagnostics.Process.Start(file);
            else
                MessageBox.Show("找不到卡貼示意圖", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnZoom_ButtonClick(object sender, EventArgs e)
        {
            _preview.ZoomMode = _preview.ZoomMode == ZoomMode.ActualSize
              ? ZoomMode.FullPage
              : ZoomMode.ActualSize;
        }

        private void btnZoom_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == _itemActualSize)
            {
                _preview.ZoomMode = ZoomMode.ActualSize;
            }
            else if (e.ClickedItem == _itemFullPage)
            {
                _preview.ZoomMode = ZoomMode.FullPage;
            }
            else if (e.ClickedItem == _itemPageWidth)
            {
                _preview.ZoomMode = ZoomMode.PageWidth;
            }
            else if (e.ClickedItem == _itemTwoPages)
            {
                _preview.ZoomMode = ZoomMode.TwoPages;
            }
            if (e.ClickedItem == _item10)
            {
                _preview.Zoom = .1;
            }
            else if (e.ClickedItem == _item100)
            {
                _preview.Zoom = 1;
            }
            else if (e.ClickedItem == _item150)
            {
                _preview.Zoom = 1.5;
            }
            else if (e.ClickedItem == _item200)
            {
                _preview.Zoom = 2;
            }
            else if (e.ClickedItem == _item25)
            {
                _preview.Zoom = .25;
            }
            else if (e.ClickedItem == _item50)
            {
                _preview.Zoom = .5;
            }
            else if (e.ClickedItem == _item500)
            {
                _preview.Zoom = 5;
            }
            else if (e.ClickedItem == _item75)
            {
                _preview.Zoom = .75;
            }
        }

        private void btnZoom100_Click(object sender, EventArgs e)
        {
            _preview.Zoom = 1;
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            _preview.Zoom = (_preview.Zoom < 5) ? _preview.Zoom += .25 : 5;
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            _preview.Zoom = (_preview.Zoom > .25) ? _preview.Zoom -= .25 : .1;
        }

        private void frmPXCARD_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Environment.Exit(Environment.ExitCode);      
        }

        /*
        private void gvEmployeeData_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            string img_name = e.Value != DBNull.Value ? e.Value.ToString().Trim() : string.Empty;

            if (view.FocusedColumn.FieldName == "照片名稱")
            {
                if (img_name == string.Empty)
                {
                    e.Valid = false;
                    e.ErrorText = "照片名稱空白!!";
                }
                else if (!File.Exists(Path.Combine(txtImagePath.Text.Trim(), img_name)))
                {
                    e.Valid = false;
                    e.ErrorText = "照片不存在!!";
                }
            }
        }

        private void gvEmployeeData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            GridColumn colImage = view.Columns["照片名稱"];
            string valImage = view.GetRowCellValue(e.RowHandle, colImage) != DBNull.Value ? Convert.ToString(view.GetRowCellValue(e.RowHandle, colImage)) : string.Empty ;

            if (valImage == string.Empty)
            {
                view.SetColumnError(colImage, "照片名稱空白!!");
                e.Valid = false;
            }
            else if (!File.Exists(Path.Combine(txtImagePath.Text, valImage )))
            {
                view.SetColumnError(colImage, "照片不存在!!");
                e.Valid = false;
            }
        }
        */

        private void gvEmployeeData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "照片名稱")
            {
                e.DefaultDraw();
                if (!File.Exists(Path.Combine(txtImagePath.Text.Trim(), e.CellValue.ToString())))
                {
                    e.Cache.DrawString("✖", new Font("微軟正黑體", 16, FontStyle.Bold), Brushes.Red, new Point( e.Bounds.Right - 30, e.Bounds.Location.Y-5));
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            gvEmployeeData.PostEditor();
            gvEmployeeData.CloseEditor();
            _bsEmployee.EndEdit();

            Batch_Preview(GetDefaultPrinter());
            btnUpdate.Enabled = true;
        }

        private string GetDefaultPrinter()
        {
            PrintDocument printDoc = new PrintDocument();
            String sDefaultPrinter = printDoc.PrinterSettings.PrinterName;

            return sDefaultPrinter;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string file = @".\main\help.jpg";
            if (File.Exists(file))
                System.Diagnostics.Process.Start(file);
            else
                MessageBox.Show("找不到說明檔", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    public static class DataTableExtensions
    {
        public static DataTable Add_Row_Number(this DataTable dt, string column_name)
        {
            dt.Columns.Add(new DataColumn(column_name, typeof(string)));

            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                row[column_name] = i.ToString();
            }
            dt.Columns[column_name].ReadOnly = true;

            return dt;
        }

        public static DataTable Add_Name_Space(this DataTable dt, string column_name)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row[column_name].ToString().Length == 2)
                    row[column_name] = row[column_name].ToString().Insert(1, "    ");
                else if (row[column_name].ToString().Length == 3)
                    row[column_name] = row[column_name].ToString().Insert(1, "  ").Insert(4, "  ");
            }

            return dt;
        }

        public static DataTable Add_Image_Extension(this DataTable dt, string column_name)
        {
            foreach (DataRow row in dt.Rows)
            {
                row[column_name] = Path.GetExtension(row[column_name].ToString().Trim()) == string.Empty ?
                        row[column_name].ToString().Trim() + ".jpg" : row[column_name].ToString().Trim();
            }

            return dt;
        }
    }
}


/*
new Thread(() =>
{
    DataTable sites = new DataTable();

    using (IDbConnection cn = new SqlConnection(SYNC_SITE))
    {
        var rows = cn.ExecuteReader("SELECT [ID] ,[NAME] ,[IP] FROM [PXMSDE].[dbo].[POP_LABEL_STORE] ORDER BY [ID]");
        sites.Load(rows);
    }

    using (IDbConnection cn = new SQLiteConnection(DB_CONN))
    {
        cn.Execute(@"DELETE FROM Site");
        try
        {
            foreach (DataRow dr in sites.Rows)
            {
                var cmd = @"INSERT INTO Site VALUES (@id, @name, @ip)";
                cn.Execute(cmd, new Site(dr["ID"].ToString(), dr["NAME"].ToString(), dr["IP"].ToString()));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    InitSitesList();

}).Start();

this.BeginInvoke(new EventHandler(delegate {
    this.Text = "下傳咖啡券 - (" + DateTime.Now.ToString("HH:mm:ss") + ")";
}));
*/
