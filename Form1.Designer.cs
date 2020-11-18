namespace WPMigrator
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSetWpDir = new System.Windows.Forms.Button();
            this.txtWpDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSetMysqlDir = new System.Windows.Forms.Button();
            this.txtMysqlDir = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listWpTables = new System.Windows.Forms.ListBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtWhMysqlPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWhMysqlUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWhMysqlHost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWhDomain = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSetOutputDir = new System.Windows.Forms.Button();
            this.txtOutputDir = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnStartMigration = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSetWpDir);
            this.groupBox1.Controls.Add(this.txtWpDir);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSetMysqlDir);
            this.groupBox1.Controls.Add(this.txtMysqlDir);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnTestConnection);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 222);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Step 1: Wordpress and MySQL Details";
            // 
            // btnSetWpDir
            // 
            this.btnSetWpDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetWpDir.Location = new System.Drawing.Point(252, 61);
            this.btnSetWpDir.Name = "btnSetWpDir";
            this.btnSetWpDir.Size = new System.Drawing.Size(71, 23);
            this.btnSetWpDir.TabIndex = 19;
            this.btnSetWpDir.Text = "Set";
            this.btnSetWpDir.UseVisualStyleBackColor = true;
            this.btnSetWpDir.Click += new System.EventHandler(this.btnSetWpDir_Click);
            // 
            // txtWpDir
            // 
            this.txtWpDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWpDir.Location = new System.Drawing.Point(30, 63);
            this.txtWpDir.Name = "txtWpDir";
            this.txtWpDir.ReadOnly = true;
            this.txtWpDir.Size = new System.Drawing.Size(216, 20);
            this.txtWpDir.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Wordpress Website Directory:";
            // 
            // btnSetMysqlDir
            // 
            this.btnSetMysqlDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetMysqlDir.Location = new System.Drawing.Point(252, 124);
            this.btnSetMysqlDir.Name = "btnSetMysqlDir";
            this.btnSetMysqlDir.Size = new System.Drawing.Size(71, 23);
            this.btnSetMysqlDir.TabIndex = 16;
            this.btnSetMysqlDir.Text = "Set";
            this.btnSetMysqlDir.UseVisualStyleBackColor = true;
            this.btnSetMysqlDir.Click += new System.EventHandler(this.btnSetMysqlPath_Click);
            // 
            // txtMysqlDir
            // 
            this.txtMysqlDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMysqlDir.Location = new System.Drawing.Point(30, 124);
            this.txtMysqlDir.Name = "txtMysqlDir";
            this.txtMysqlDir.ReadOnly = true;
            this.txtMysqlDir.Size = new System.Drawing.Size(216, 20);
            this.txtMysqlDir.TabIndex = 15;
            this.txtMysqlDir.Text = "G:\\Program Files\\xampp\\mysql";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "MySQL Directory:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listWpTables);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(346, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(162, 155);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database Tables";
            // 
            // listWpTables
            // 
            this.listWpTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listWpTables.FormattingEnabled = true;
            this.listWpTables.Location = new System.Drawing.Point(3, 16);
            this.listWpTables.Name = "listWpTables";
            this.listWpTables.Size = new System.Drawing.Size(156, 136);
            this.listWpTables.TabIndex = 0;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestConnection.Location = new System.Drawing.Point(30, 173);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(293, 23);
            this.btnTestConnection.TabIndex = 8;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtWhMysqlPass);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtWhMysqlUser);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtWhMysqlHost);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtWhDomain);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 243);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(544, 162);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Step 2: WebHost Details";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // txtWhMysqlPass
            // 
            this.txtWhMysqlPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWhMysqlPass.Location = new System.Drawing.Point(115, 118);
            this.txtWhMysqlPass.Name = "txtWhMysqlPass";
            this.txtWhMysqlPass.PasswordChar = '*';
            this.txtWhMysqlPass.Size = new System.Drawing.Size(393, 20);
            this.txtWhMysqlPass.TabIndex = 21;
            this.txtWhMysqlPass.Text = "fsdfsdfsdsdfs";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "MySQL Pass:";
            // 
            // txtWhMysqlUser
            // 
            this.txtWhMysqlUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWhMysqlUser.Location = new System.Drawing.Point(115, 89);
            this.txtWhMysqlUser.Name = "txtWhMysqlUser";
            this.txtWhMysqlUser.Size = new System.Drawing.Size(393, 20);
            this.txtWhMysqlUser.TabIndex = 19;
            this.txtWhMysqlUser.Text = "wp122_user1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "MySQL User:";
            // 
            // txtWhMysqlHost
            // 
            this.txtWhMysqlHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWhMysqlHost.Location = new System.Drawing.Point(115, 60);
            this.txtWhMysqlHost.Name = "txtWhMysqlHost";
            this.txtWhMysqlHost.Size = new System.Drawing.Size(393, 20);
            this.txtWhMysqlHost.TabIndex = 17;
            this.txtWhMysqlHost.Text = "localhost";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "MySQL Host:";
            // 
            // txtWhDomain
            // 
            this.txtWhDomain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWhDomain.Location = new System.Drawing.Point(115, 31);
            this.txtWhDomain.Name = "txtWhDomain";
            this.txtWhDomain.Size = new System.Drawing.Size(393, 20);
            this.txtWhDomain.TabIndex = 15;
            this.txtWhDomain.Text = "http//www.testsite.com";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Domain Name:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSetOutputDir);
            this.groupBox4.Controls.Add(this.txtOutputDir);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 421);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(544, 92);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Step 3: Output Configuration";
            // 
            // btnSetOutputDir
            // 
            this.btnSetOutputDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetOutputDir.Location = new System.Drawing.Point(417, 48);
            this.btnSetOutputDir.Name = "btnSetOutputDir";
            this.btnSetOutputDir.Size = new System.Drawing.Size(91, 23);
            this.btnSetOutputDir.TabIndex = 14;
            this.btnSetOutputDir.Text = "Browse";
            this.btnSetOutputDir.UseVisualStyleBackColor = true;
            this.btnSetOutputDir.Click += new System.EventHandler(this.btnSetOutputDir_Click);
            // 
            // txtOutputDir
            // 
            this.txtOutputDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputDir.Location = new System.Drawing.Point(35, 50);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.ReadOnly = true;
            this.txtOutputDir.Size = new System.Drawing.Size(361, 20);
            this.txtOutputDir.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Output Directory:";
            // 
            // btnStartMigration
            // 
            this.btnStartMigration.Location = new System.Drawing.Point(394, 529);
            this.btnStartMigration.Name = "btnStartMigration";
            this.btnStartMigration.Size = new System.Drawing.Size(162, 32);
            this.btnStartMigration.TabIndex = 14;
            this.btnStartMigration.Text = "Start Migration";
            this.btnStartMigration.UseVisualStyleBackColor = true;
            this.btnStartMigration.Click += new System.EventHandler(this.btnStartMigration_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 573);
            this.Controls.Add(this.btnStartMigration);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "WPMigrator - Easy Wordpress Migration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtWhDomain;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSetOutputDir;
        private System.Windows.Forms.TextBox txtOutputDir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnStartMigration;
        private System.Windows.Forms.Button btnSetMysqlDir;
        private System.Windows.Forms.TextBox txtMysqlDir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listWpTables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWpDir;
        private System.Windows.Forms.Button btnSetWpDir;
        private System.Windows.Forms.TextBox txtWhMysqlPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWhMysqlUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWhMysqlHost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

