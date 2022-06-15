
namespace Sentez_WebServices_Client_Sample
{
    partial class frmRestApi
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRestApi));
            this.btLogin = new System.Windows.Forms.Button();
            this.txtLoginToken = new System.Windows.Forms.TextBox();
            this.tabControlSentez = new System.Windows.Forms.TabControl();
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCompanyPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCompanyCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserCode = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPageGet = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBONames = new System.Windows.Forms.ComboBox();
            this.txtInventoryRecId = new System.Windows.Forms.TextBox();
            this.btGetById = new System.Windows.Forms.Button();
            this.btGetAll = new System.Windows.Forms.Button();
            this.tabPageQuery = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgViewExecuteQuery = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btExecuteQuery_GetProductWithVariants = new System.Windows.Forms.Button();
            this.tabPageInsertRecord = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btInsertOrderReceiptBO = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPageUpdate = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.btUpdateRecord = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlSentez.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPageGet.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPageQuery.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewExecuteQuery)).BeginInit();
            this.panel4.SuspendLayout();
            this.tabPageInsertRecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPageUpdate.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(542, 466);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(141, 40);
            this.btLogin.TabIndex = 0;
            this.btLogin.Text = "Login";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // txtLoginToken
            // 
            this.txtLoginToken.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLoginToken.Location = new System.Drawing.Point(401, 532);
            this.txtLoginToken.Name = "txtLoginToken";
            this.txtLoginToken.ReadOnly = true;
            this.txtLoginToken.Size = new System.Drawing.Size(419, 27);
            this.txtLoginToken.TabIndex = 1;
            this.txtLoginToken.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabControlSentez
            // 
            this.tabControlSentez.Controls.Add(this.tabPageLogin);
            this.tabControlSentez.Controls.Add(this.tabPageGet);
            this.tabControlSentez.Controls.Add(this.tabPageQuery);
            this.tabControlSentez.Controls.Add(this.tabPageInsertRecord);
            this.tabControlSentez.Controls.Add(this.tabPageUpdate);
            this.tabControlSentez.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSentez.Location = new System.Drawing.Point(0, 0);
            this.tabControlSentez.Name = "tabControlSentez";
            this.tabControlSentez.SelectedIndex = 0;
            this.tabControlSentez.Size = new System.Drawing.Size(1197, 699);
            this.tabControlSentez.TabIndex = 3;
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.Controls.Add(this.label1);
            this.tabPageLogin.Controls.Add(this.label7);
            this.tabPageLogin.Controls.Add(this.txtCompanyPassword);
            this.tabPageLogin.Controls.Add(this.label6);
            this.tabPageLogin.Controls.Add(this.txtCompanyCode);
            this.tabPageLogin.Controls.Add(this.label5);
            this.tabPageLogin.Controls.Add(this.txtPassword);
            this.tabPageLogin.Controls.Add(this.label4);
            this.tabPageLogin.Controls.Add(this.txtUserCode);
            this.tabPageLogin.Controls.Add(this.pictureBox1);
            this.tabPageLogin.Controls.Add(this.btLogin);
            this.tabPageLogin.Controls.Add(this.txtLoginToken);
            this.tabPageLogin.Location = new System.Drawing.Point(4, 24);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogin.Size = new System.Drawing.Size(1189, 671);
            this.tabPageLogin.TabIndex = 0;
            this.tabPageLogin.Text = "Login";
            this.tabPageLogin.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(353, 537);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Token";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(337, 423);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Company Password";
            // 
            // txtCompanyPassword
            // 
            this.txtCompanyPassword.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCompanyPassword.Location = new System.Drawing.Point(468, 418);
            this.txtCompanyPassword.Name = "txtCompanyPassword";
            this.txtCompanyPassword.Size = new System.Drawing.Size(280, 27);
            this.txtCompanyPassword.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(362, 384);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Company Code";
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCompanyCode.Location = new System.Drawing.Point(468, 379);
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.Size = new System.Drawing.Size(280, 27);
            this.txtCompanyCode.TabIndex = 8;
            this.txtCompanyCode.Text = "01";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(396, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.Location = new System.Drawing.Point(468, 340);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(280, 27);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.Text = "12345";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(390, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "User Code";
            // 
            // txtUserCode
            // 
            this.txtUserCode.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUserCode.Location = new System.Drawing.Point(468, 301);
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Size = new System.Drawing.Size(280, 27);
            this.txtUserCode.TabIndex = 4;
            this.txtUserCode.Text = "Sentez";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(286, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(561, 178);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // tabPageGet
            // 
            this.tabPageGet.Controls.Add(this.panel2);
            this.tabPageGet.Controls.Add(this.panel1);
            this.tabPageGet.Location = new System.Drawing.Point(4, 24);
            this.tabPageGet.Name = "tabPageGet";
            this.tabPageGet.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGet.Size = new System.Drawing.Size(1189, 671);
            this.tabPageGet.TabIndex = 1;
            this.tabPageGet.Text = "Get Record";
            this.tabPageGet.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1183, 554);
            this.panel2.TabIndex = 4;
            // 
            // dgView
            // 
            this.dgView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgView.Location = new System.Drawing.Point(0, 0);
            this.dgView.Name = "dgView";
            this.dgView.Size = new System.Drawing.Size(1183, 554);
            this.dgView.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbBONames);
            this.panel1.Controls.Add(this.txtInventoryRecId);
            this.panel1.Controls.Add(this.btGetById);
            this.panel1.Controls.Add(this.btGetAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1183, 111);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "BO Name";
            // 
            // cmbBONames
            // 
            this.cmbBONames.FormattingEnabled = true;
            this.cmbBONames.Items.AddRange(new object[] {
            "InventoryBO",
            "OrderReceiptBO",
            "InventoryReceiptBO",
            "InvoiceBO",
            "CurrentAccountBO"});
            this.cmbBONames.Location = new System.Drawing.Point(32, 35);
            this.cmbBONames.Name = "cmbBONames";
            this.cmbBONames.Size = new System.Drawing.Size(181, 23);
            this.cmbBONames.TabIndex = 5;
            // 
            // txtInventoryRecId
            // 
            this.txtInventoryRecId.Location = new System.Drawing.Point(377, 65);
            this.txtInventoryRecId.Name = "txtInventoryRecId";
            this.txtInventoryRecId.PlaceholderText = "RecId";
            this.txtInventoryRecId.Size = new System.Drawing.Size(141, 23);
            this.txtInventoryRecId.TabIndex = 3;
            this.txtInventoryRecId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btGetById
            // 
            this.btGetById.Location = new System.Drawing.Point(377, 25);
            this.btGetById.Name = "btGetById";
            this.btGetById.Size = new System.Drawing.Size(141, 40);
            this.btGetById.TabIndex = 2;
            this.btGetById.Text = "Get By RecId";
            this.btGetById.UseVisualStyleBackColor = true;
            this.btGetById.Click += new System.EventHandler(this.btGetById_Click);
            // 
            // btGetAll
            // 
            this.btGetAll.Location = new System.Drawing.Point(230, 25);
            this.btGetAll.Name = "btGetAll";
            this.btGetAll.Size = new System.Drawing.Size(141, 40);
            this.btGetAll.TabIndex = 1;
            this.btGetAll.Text = "Get All Records";
            this.btGetAll.UseVisualStyleBackColor = true;
            this.btGetAll.Click += new System.EventHandler(this.btGetAll_Click);
            // 
            // tabPageQuery
            // 
            this.tabPageQuery.Controls.Add(this.panel6);
            this.tabPageQuery.Controls.Add(this.panel5);
            this.tabPageQuery.Controls.Add(this.panel4);
            this.tabPageQuery.Location = new System.Drawing.Point(4, 24);
            this.tabPageQuery.Name = "tabPageQuery";
            this.tabPageQuery.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageQuery.Size = new System.Drawing.Size(1189, 671);
            this.tabPageQuery.TabIndex = 4;
            this.tabPageQuery.Text = "Execute Query";
            this.tabPageQuery.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtQuery);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 119);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1183, 308);
            this.panel6.TabIndex = 6;
            // 
            // txtQuery
            // 
            this.txtQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuery.Location = new System.Drawing.Point(0, 0);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.PlaceholderText = "SELECT * FROM Meta_City";
            this.txtQuery.Size = new System.Drawing.Size(1183, 308);
            this.txtQuery.TabIndex = 3;
            this.txtQuery.Text = resources.GetString("txtQuery.Text");
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgViewExecuteQuery);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 427);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1183, 241);
            this.panel5.TabIndex = 5;
            // 
            // dgViewExecuteQuery
            // 
            this.dgViewExecuteQuery.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgViewExecuteQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewExecuteQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgViewExecuteQuery.Location = new System.Drawing.Point(0, 0);
            this.dgViewExecuteQuery.Name = "dgViewExecuteQuery";
            this.dgViewExecuteQuery.Size = new System.Drawing.Size(1183, 241);
            this.dgViewExecuteQuery.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.btExecuteQuery_GetProductWithVariants);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1183, 116);
            this.panel4.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(410, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(498, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Note: Update ve Insert sorguları için api/Utility/UtilityNonQuery methodunnu kull" +
    "anmalısınız.";
            // 
            // btExecuteQuery_GetProductWithVariants
            // 
            this.btExecuteQuery_GetProductWithVariants.Location = new System.Drawing.Point(45, 33);
            this.btExecuteQuery_GetProductWithVariants.Name = "btExecuteQuery_GetProductWithVariants";
            this.btExecuteQuery_GetProductWithVariants.Size = new System.Drawing.Size(359, 59);
            this.btExecuteQuery_GetProductWithVariants.TabIndex = 0;
            this.btExecuteQuery_GetProductWithVariants.Text = "ExecuteQuery Variantlı Ürünler Listesi";
            this.btExecuteQuery_GetProductWithVariants.UseVisualStyleBackColor = true;
            this.btExecuteQuery_GetProductWithVariants.Click += new System.EventHandler(this.btExecuteQuery_GetProductWithVariants_Click);
            // 
            // tabPageInsertRecord
            // 
            this.tabPageInsertRecord.Controls.Add(this.pictureBox2);
            this.tabPageInsertRecord.Controls.Add(this.label8);
            this.tabPageInsertRecord.Controls.Add(this.btInsertOrderReceiptBO);
            this.tabPageInsertRecord.Controls.Add(this.textBox1);
            this.tabPageInsertRecord.Location = new System.Drawing.Point(4, 24);
            this.tabPageInsertRecord.Name = "tabPageInsertRecord";
            this.tabPageInsertRecord.Size = new System.Drawing.Size(1189, 671);
            this.tabPageInsertRecord.TabIndex = 2;
            this.tabPageInsertRecord.Text = "Insert Record";
            this.tabPageInsertRecord.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(33, 109);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1125, 541);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(313, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(845, 62);
            this.label8.TabIndex = 6;
            this.label8.Text = resources.GetString("label8.Text");
            // 
            // btInsertOrderReceiptBO
            // 
            this.btInsertOrderReceiptBO.Location = new System.Drawing.Point(33, 22);
            this.btInsertOrderReceiptBO.Name = "btInsertOrderReceiptBO";
            this.btInsertOrderReceiptBO.Size = new System.Drawing.Size(274, 81);
            this.btInsertOrderReceiptBO.TabIndex = 4;
            this.btInsertOrderReceiptBO.Text = "Insert OrderReceipt";
            this.btInsertOrderReceiptBO.UseVisualStyleBackColor = true;
            this.btInsertOrderReceiptBO.Click += new System.EventHandler(this.btInsertBO_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1189, 671);
            this.textBox1.TabIndex = 5;
            // 
            // tabPageUpdate
            // 
            this.tabPageUpdate.Controls.Add(this.label9);
            this.tabPageUpdate.Controls.Add(this.btUpdateRecord);
            this.tabPageUpdate.Location = new System.Drawing.Point(4, 24);
            this.tabPageUpdate.Name = "tabPageUpdate";
            this.tabPageUpdate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUpdate.Size = new System.Drawing.Size(1189, 671);
            this.tabPageUpdate.TabIndex = 3;
            this.tabPageUpdate.Text = "Update Record";
            this.tabPageUpdate.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(309, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(845, 62);
            this.label9.TabIndex = 8;
            this.label9.Text = resources.GetString("label9.Text");
            // 
            // btUpdateRecord
            // 
            this.btUpdateRecord.Location = new System.Drawing.Point(29, 66);
            this.btUpdateRecord.Name = "btUpdateRecord";
            this.btUpdateRecord.Size = new System.Drawing.Size(274, 81);
            this.btUpdateRecord.TabIndex = 7;
            this.btUpdateRecord.Text = "Update OrderReceipt";
            this.btUpdateRecord.UseVisualStyleBackColor = true;
            this.btUpdateRecord.Click += new System.EventHandler(this.btUpdateRecord_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 677);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1197, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // frmRestApi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 699);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControlSentez);
            this.Name = "frmRestApi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sentez Web Services Rest Api Example";
            this.tabControlSentez.ResumeLayout(false);
            this.tabPageLogin.ResumeLayout(false);
            this.tabPageLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPageGet.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageQuery.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewExecuteQuery)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPageInsertRecord.ResumeLayout(false);
            this.tabPageInsertRecord.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPageUpdate.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.TextBox txtLoginToken;
        private System.Windows.Forms.TabControl tabControlSentez;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btGetAll;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Button btGetById;
        private System.Windows.Forms.TextBox txtInventoryRecId;
        private System.Windows.Forms.TabPage tabPageLogin;
        private System.Windows.Forms.TabPage tabPageGet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBONames;
        private System.Windows.Forms.TabPage tabPageInsertRecord;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btInsertOrderReceiptBO;
        private System.Windows.Forms.TabPage tabPageQuery;
        private System.Windows.Forms.TabPage tabPageUpdate;
        private System.Windows.Forms.Button btExecuteQuery_GetProductWithVariants;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgViewExecuteQuery;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCompanyCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCompanyPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btUpdateRecord;
    }
}

