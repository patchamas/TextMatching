namespace TextMatching
{
    partial class Form1
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
            this.groubFile = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.gridInput = new System.Windows.Forms.DataGridView();
            this.txtResultArguments = new System.Windows.Forms.TextBox();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.gridFound = new System.Windows.Forms.DataGridView();
            this.groubFile.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFound)).BeginInit();
            this.SuspendLayout();
            // 
            // groubFile
            // 
            this.groubFile.Controls.Add(this.gridFound);
            this.groubFile.Controls.Add(this.txtSearchValue);
            this.groubFile.Controls.Add(this.txtResultArguments);
            this.groubFile.Controls.Add(this.btnAdd);
            this.groubFile.Controls.Add(this.txtPath);
            this.groubFile.Controls.Add(this.btnBrowse);
            this.groubFile.Location = new System.Drawing.Point(12, 12);
            this.groubFile.Name = "groubFile";
            this.groubFile.Size = new System.Drawing.Size(343, 382);
            this.groubFile.TabIndex = 5;
            this.groubFile.TabStop = false;
            this.groubFile.Text = "Step2: File Input";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(173, 45);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(15, 19);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(314, 20);
            this.txtPath.TabIndex = 2;
            this.txtPath.Text = "E:\\CPE\\6] ALGO\\JHW2\\Product.txt";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(254, 45);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnProcess);
            this.groupBox2.Controls.Add(this.gridInput);
            this.groupBox2.Location = new System.Drawing.Point(361, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 377);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Step3: Input";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(128, 340);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(209, 340);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 5;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // gridInput
            // 
            this.gridInput.AllowUserToAddRows = false;
            this.gridInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridInput.Location = new System.Drawing.Point(15, 19);
            this.gridInput.Name = "gridInput";
            this.gridInput.Size = new System.Drawing.Size(268, 315);
            this.gridInput.TabIndex = 1;
            // 
            // txtResultArguments
            // 
            this.txtResultArguments.Location = new System.Drawing.Point(229, 74);
            this.txtResultArguments.Name = "txtResultArguments";
            this.txtResultArguments.Size = new System.Drawing.Size(100, 20);
            this.txtResultArguments.TabIndex = 6;
            this.txtResultArguments.Text = "10";
            this.txtResultArguments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.Location = new System.Drawing.Point(229, 100);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(100, 20);
            this.txtSearchValue.TabIndex = 7;
            // 
            // gridFound
            // 
            this.gridFound.AllowUserToAddRows = false;
            this.gridFound.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFound.Location = new System.Drawing.Point(15, 126);
            this.gridFound.Name = "gridFound";
            this.gridFound.Size = new System.Drawing.Size(314, 242);
            this.gridFound.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 406);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groubFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groubFile.ResumeLayout(false);
            this.groubFile.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFound)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groubFile;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.DataGridView gridInput;
        private System.Windows.Forms.TextBox txtResultArguments;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.DataGridView gridFound;
    }
}

