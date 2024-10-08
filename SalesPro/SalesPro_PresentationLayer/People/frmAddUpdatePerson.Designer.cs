namespace SalesPro_PresentationLayer.People
{
    partial class frmAddUpdatePerson
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtxtNotes = new System.Windows.Forms.RichTextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPhone4 = new System.Windows.Forms.TextBox();
            this.txtPhone1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhone3 = new System.Windows.Forms.TextBox();
            this.txtPhone2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(776, 32);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(84, 26);
            this.lblID.TabIndex = 17;
            this.lblID.Text = "[?????]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(955, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 26);
            this.label1.TabIndex = 16;
            this.label1.Text = "ID";
            // 
            // rtxtNotes
            // 
            this.rtxtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxtNotes.Location = new System.Drawing.Point(25, 249);
            this.rtxtNotes.Name = "rtxtNotes";
            this.rtxtNotes.Size = new System.Drawing.Size(830, 86);
            this.rtxtNotes.TabIndex = 5;
            this.rtxtNotes.Text = "";
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(573, 109);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(282, 35);
            this.txtAddress.TabIndex = 2;
            this.txtAddress.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(877, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Full Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(920, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 26);
            this.label7.TabIndex = 15;
            this.label7.Text = "Notes";
            // 
            // txtFullName
            // 
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullName.Location = new System.Drawing.Point(500, 66);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(355, 35);
            this.txtFullName.TabIndex = 1;
            this.txtFullName.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(25, 195);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(282, 35);
            this.txtEmail.TabIndex = 15;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(897, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "Address";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(750, 437);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 56);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(359, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 26);
            this.label8.TabIndex = 13;
            this.label8.Text = "Email";
            // 
            // txtPhone4
            // 
            this.txtPhone4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone4.Location = new System.Drawing.Point(25, 152);
            this.txtPhone4.Name = "txtPhone4";
            this.txtPhone4.Size = new System.Drawing.Size(282, 35);
            this.txtPhone4.TabIndex = 12;
            // 
            // txtPhone1
            // 
            this.txtPhone1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone1.Location = new System.Drawing.Point(573, 152);
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(282, 35);
            this.txtPhone1.TabIndex = 3;
            this.txtPhone1.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextBox);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(340, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 26);
            this.label5.TabIndex = 11;
            this.label5.Text = "Phone4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(902, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 26);
            this.label6.TabIndex = 7;
            this.label6.Text = "Phone2";
            // 
            // txtPhone3
            // 
            this.txtPhone3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone3.Location = new System.Drawing.Point(25, 109);
            this.txtPhone3.Name = "txtPhone3";
            this.txtPhone3.Size = new System.Drawing.Size(282, 35);
            this.txtPhone3.TabIndex = 10;
            // 
            // txtPhone2
            // 
            this.txtPhone2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone2.Location = new System.Drawing.Point(573, 195);
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.Size = new System.Drawing.Size(282, 35);
            this.txtPhone2.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(340, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 26);
            this.label9.TabIndex = 9;
            this.label9.Text = "Phone3";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(887, 437);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 56);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(902, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 26);
            this.label4.TabIndex = 5;
            this.label4.Text = "Phone1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rtxtNotes);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtFullName);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPhone4);
            this.groupBox1.Controls.Add(this.txtPhone1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPhone3);
            this.groupBox1.Controls.Add(this.txtPhone2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(10, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(1006, 344);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add New Person";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Maroon;
            this.label10.Location = new System.Drawing.Point(396, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(225, 32);
            this.label10.TabIndex = 26;
            this.label10.Text = "Add New Person";
            // 
            // frmAddUpdatePerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 569);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAddUpdatePerson";
            this.Text = "frmAddUpdatePerson";
            this.Load += new System.EventHandler(this.frmAddUpdatePerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtxtNotes;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhone4;
        private System.Windows.Forms.TextBox txtPhone1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPhone3;
        private System.Windows.Forms.TextBox txtPhone2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}