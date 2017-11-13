namespace QuanLyVPP1.GUI
{
    partial class fCapNhatSanPham
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvHangHoa = new System.Windows.Forms.DataGridView();
            this.txbTimHH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.numGiaMua = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.txbDVTinh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnXoaHH = new System.Windows.Forms.Button();
            this.numGia = new System.Windows.Forms.NumericUpDown();
            this.btnThemHH = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDanhMuc = new System.Windows.Forms.ComboBox();
            this.txbMaHH = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbTenHH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.numGiaMuaCN = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.numSoLuongCN = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txbDVTinhCN = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numGiaCN = new System.Windows.Forms.NumericUpDown();
            this.btnSuaHH = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbDanhMucCN = new System.Windows.Forms.ComboBox();
            this.txbMaHHCN = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txbTenHHCN = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaMua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaMuaCN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongCN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaCN)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvHangHoa);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 333);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hàng Hóa";
            // 
            // dgvHangHoa
            // 
            this.dgvHangHoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangHoa.Location = new System.Drawing.Point(6, 19);
            this.dgvHangHoa.Name = "dgvHangHoa";
            this.dgvHangHoa.ReadOnly = true;
            this.dgvHangHoa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHangHoa.Size = new System.Drawing.Size(558, 308);
            this.dgvHangHoa.TabIndex = 0;
            // 
            // txbTimHH
            // 
            this.txbTimHH.Location = new System.Drawing.Point(650, 12);
            this.txbTimHH.Name = "txbTimHH";
            this.txbTimHH.Size = new System.Drawing.Size(152, 20);
            this.txbTimHH.TabIndex = 10;
            this.txbTimHH.TextChanged += new System.EventHandler(this.txbTimHH_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(594, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tìm Kiếm:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(588, 38);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(281, 307);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.numGiaMua);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.numSoLuong);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txbDVTinh);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.btnXoaHH);
            this.tabPage1.Controls.Add(this.numGia);
            this.tabPage1.Controls.Add(this.btnThemHH);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cmbDanhMuc);
            this.tabPage1.Controls.Add(this.txbMaHH);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txbTenHH);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(273, 281);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thêm Sản Phẩm";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // numGiaMua
            // 
            this.numGiaMua.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numGiaMua.Location = new System.Drawing.Point(87, 134);
            this.numGiaMua.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numGiaMua.Name = "numGiaMua";
            this.numGiaMua.Size = new System.Drawing.Size(140, 20);
            this.numGiaMua.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 141);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 38;
            this.label14.Text = "Giá Mua:";
            // 
            // numSoLuong
            // 
            this.numSoLuong.Location = new System.Drawing.Point(87, 106);
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(91, 20);
            this.numSoLuong.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Số lượng:";
            // 
            // txbDVTinh
            // 
            this.txbDVTinh.Location = new System.Drawing.Point(87, 77);
            this.txbDVTinh.Name = "txbDVTinh";
            this.txbDVTinh.Size = new System.Drawing.Size(174, 20);
            this.txbDVTinh.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Đơn vị tính:";
            // 
            // btnXoaHH
            // 
            this.btnXoaHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaHH.Location = new System.Drawing.Point(170, 240);
            this.btnXoaHH.Name = "btnXoaHH";
            this.btnXoaHH.Size = new System.Drawing.Size(75, 30);
            this.btnXoaHH.TabIndex = 9;
            this.btnXoaHH.Text = "Xóa";
            this.btnXoaHH.UseVisualStyleBackColor = true;
            this.btnXoaHH.Click += new System.EventHandler(this.btnXoaHH_Click);
            // 
            // numGia
            // 
            this.numGia.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numGia.Location = new System.Drawing.Point(87, 162);
            this.numGia.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numGia.Name = "numGia";
            this.numGia.Size = new System.Drawing.Size(140, 20);
            this.numGia.TabIndex = 6;
            // 
            // btnThemHH
            // 
            this.btnThemHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemHH.Location = new System.Drawing.Point(42, 240);
            this.btnThemHH.Name = "btnThemHH";
            this.btnThemHH.Size = new System.Drawing.Size(75, 30);
            this.btnThemHH.TabIndex = 8;
            this.btnThemHH.Text = "Thêm";
            this.btnThemHH.UseVisualStyleBackColor = true;
            this.btnThemHH.Click += new System.EventHandler(this.btnThemHH_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Danh mục:";
            // 
            // cmbDanhMuc
            // 
            this.cmbDanhMuc.FormattingEnabled = true;
            this.cmbDanhMuc.Location = new System.Drawing.Point(87, 190);
            this.cmbDanhMuc.Name = "cmbDanhMuc";
            this.cmbDanhMuc.Size = new System.Drawing.Size(174, 21);
            this.cmbDanhMuc.TabIndex = 7;
            // 
            // txbMaHH
            // 
            this.txbMaHH.Location = new System.Drawing.Point(87, 21);
            this.txbMaHH.Name = "txbMaHH";
            this.txbMaHH.Size = new System.Drawing.Size(174, 20);
            this.txbMaHH.TabIndex = 1;
            this.txbMaHH.TextChanged += new System.EventHandler(this.txbMaHH_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Mã hàng hóa:";
            // 
            // txbTenHH
            // 
            this.txbTenHH.Location = new System.Drawing.Point(87, 49);
            this.txbTenHH.Name = "txbTenHH";
            this.txbTenHH.Size = new System.Drawing.Size(174, 20);
            this.txbTenHH.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Tên hàng hóa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Giá Bán:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.numGiaMuaCN);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.numSoLuongCN);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txbDVTinhCN);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.numGiaCN);
            this.tabPage2.Controls.Add(this.btnSuaHH);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.cmbDanhMucCN);
            this.tabPage2.Controls.Add(this.txbMaHHCN);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.txbTenHHCN);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(273, 281);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cập Nhật TT Sản Phẩm";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 141);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 54;
            this.label15.Text = "Giá Mua:";
            // 
            // numGiaMuaCN
            // 
            this.numGiaMuaCN.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numGiaMuaCN.Location = new System.Drawing.Point(87, 134);
            this.numGiaMuaCN.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numGiaMuaCN.Name = "numGiaMuaCN";
            this.numGiaMuaCN.Size = new System.Drawing.Size(140, 20);
            this.numGiaMuaCN.TabIndex = 53;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 169);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 52;
            this.label13.Text = "Giá Bán:";
            // 
            // numSoLuongCN
            // 
            this.numSoLuongCN.Location = new System.Drawing.Point(87, 106);
            this.numSoLuongCN.Name = "numSoLuongCN";
            this.numSoLuongCN.Size = new System.Drawing.Size(91, 20);
            this.numSoLuongCN.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "Số lượng:";
            // 
            // txbDVTinhCN
            // 
            this.txbDVTinhCN.Location = new System.Drawing.Point(87, 77);
            this.txbDVTinhCN.Name = "txbDVTinhCN";
            this.txbDVTinhCN.Size = new System.Drawing.Size(174, 20);
            this.txbDVTinhCN.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 48;
            this.label9.Text = "Đơn vị tính:";
            // 
            // numGiaCN
            // 
            this.numGiaCN.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numGiaCN.Location = new System.Drawing.Point(87, 162);
            this.numGiaCN.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numGiaCN.Name = "numGiaCN";
            this.numGiaCN.Size = new System.Drawing.Size(140, 20);
            this.numGiaCN.TabIndex = 5;
            // 
            // btnSuaHH
            // 
            this.btnSuaHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaHH.Location = new System.Drawing.Point(103, 237);
            this.btnSuaHH.Name = "btnSuaHH";
            this.btnSuaHH.Size = new System.Drawing.Size(75, 30);
            this.btnSuaHH.TabIndex = 7;
            this.btnSuaHH.Text = "Sửa";
            this.btnSuaHH.UseVisualStyleBackColor = true;
            this.btnSuaHH.Click += new System.EventHandler(this.btnSuaHH_Click_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Danh mục:";
            // 
            // cmbDanhMucCN
            // 
            this.cmbDanhMucCN.FormattingEnabled = true;
            this.cmbDanhMucCN.Location = new System.Drawing.Point(87, 190);
            this.cmbDanhMucCN.Name = "cmbDanhMucCN";
            this.cmbDanhMucCN.Size = new System.Drawing.Size(174, 21);
            this.cmbDanhMucCN.TabIndex = 6;
            // 
            // txbMaHHCN
            // 
            this.txbMaHHCN.Enabled = false;
            this.txbMaHHCN.Location = new System.Drawing.Point(87, 21);
            this.txbMaHHCN.Name = "txbMaHHCN";
            this.txbMaHHCN.Size = new System.Drawing.Size(174, 20);
            this.txbMaHHCN.TabIndex = 1;
            this.txbMaHHCN.TextChanged += new System.EventHandler(this.txbMaHHCN_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Mã hàng hóa:";
            // 
            // txbTenHHCN
            // 
            this.txbTenHHCN.Location = new System.Drawing.Point(87, 49);
            this.txbTenHHCN.Name = "txbTenHHCN";
            this.txbTenHHCN.Size = new System.Drawing.Size(174, 20);
            this.txbTenHHCN.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "Tên hàng hóa:";
            // 
            // btnViewAll
            // 
            this.btnViewAll.Location = new System.Drawing.Point(808, 4);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(66, 35);
            this.btnViewAll.TabIndex = 11;
            this.btnViewAll.Text = "Xem \r\nTất Cả";
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // fCapNhatSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 350);
            this.Controls.Add(this.btnViewAll);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txbTimHH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "fCapNhatSanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cập Nhật Sản Phẩm";
            this.Load += new System.EventHandler(this.fCapNhatHang_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaMua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaMuaCN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongCN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaCN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvHangHoa;
        private System.Windows.Forms.TextBox txbTimHH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbDVTinh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnXoaHH;
        private System.Windows.Forms.NumericUpDown numGia;
        private System.Windows.Forms.Button btnThemHH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDanhMuc;
        private System.Windows.Forms.TextBox txbMaHH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbTenHH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numSoLuongCN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbDVTinhCN;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numGiaCN;
        private System.Windows.Forms.Button btnSuaHH;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbDanhMucCN;
        private System.Windows.Forms.TextBox txbMaHHCN;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txbTenHHCN;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numGiaMua;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numGiaMuaCN;
        private System.Windows.Forms.Button btnViewAll;
    }
}