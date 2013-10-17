namespace Ass2
{
    partial class Ass2Form
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
            this.btnFleet1 = new System.Windows.Forms.Button();
            this.btnFleet2 = new System.Windows.Forms.Button();
            this.txtFleet1 = new System.Windows.Forms.TextBox();
            this.txtFleet2 = new System.Windows.Forms.TextBox();
            this.txtSeed = new System.Windows.Forms.TextBox();
            this.labelSeed = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnFleet1
            // 
            this.btnFleet1.Location = new System.Drawing.Point(13, 13);
            this.btnFleet1.Name = "btnFleet1";
            this.btnFleet1.Size = new System.Drawing.Size(75, 23);
            this.btnFleet1.TabIndex = 0;
            this.btnFleet1.Text = "Fleet1";
            this.btnFleet1.UseVisualStyleBackColor = true;
            this.btnFleet1.Click += new System.EventHandler(this.btnFleet1_Click);
            // 
            // btnFleet2
            // 
            this.btnFleet2.Location = new System.Drawing.Point(13, 42);
            this.btnFleet2.Name = "btnFleet2";
            this.btnFleet2.Size = new System.Drawing.Size(75, 23);
            this.btnFleet2.TabIndex = 1;
            this.btnFleet2.Text = "Fleet1";
            this.btnFleet2.UseVisualStyleBackColor = true;
            this.btnFleet2.Click += new System.EventHandler(this.btnFleet2_Click);
            // 
            // txtFleet1
            // 
            this.txtFleet1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFleet1.Location = new System.Drawing.Point(109, 15);
            this.txtFleet1.Name = "txtFleet1";
            this.txtFleet1.Size = new System.Drawing.Size(548, 20);
            this.txtFleet1.TabIndex = 2;
            this.txtFleet1.TextChanged += new System.EventHandler(this.txtFleet1_TextChanged);
            // 
            // txtFleet2
            // 
            this.txtFleet2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFleet2.Location = new System.Drawing.Point(109, 44);
            this.txtFleet2.Name = "txtFleet2";
            this.txtFleet2.Size = new System.Drawing.Size(548, 20);
            this.txtFleet2.TabIndex = 3;
            this.txtFleet2.TextChanged += new System.EventHandler(this.txtFleet2_TextChanged);
            // 
            // txtSeed
            // 
            this.txtSeed.Location = new System.Drawing.Point(109, 86);
            this.txtSeed.Name = "txtSeed";
            this.txtSeed.Size = new System.Drawing.Size(100, 20);
            this.txtSeed.TabIndex = 4;
            this.txtSeed.TextChanged += new System.EventHandler(this.txtSeed_TextChanged);
            // 
            // labelSeed
            // 
            this.labelSeed.AutoSize = true;
            this.labelSeed.Location = new System.Drawing.Point(26, 89);
            this.labelSeed.Name = "labelSeed";
            this.labelSeed.Size = new System.Drawing.Size(62, 13);
            this.labelSeed.TabIndex = 5;
            this.labelSeed.Text = "Seed Value";
            this.labelSeed.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(241, 82);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(162, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Run Simulation";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(1, 126);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(666, 361);
            this.txtOutput.TabIndex = 7;
            this.txtOutput.TextChanged += new System.EventHandler(this.txtOutput_TextChanged);
            // 
            // Ass2Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 489);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.labelSeed);
            this.Controls.Add(this.txtSeed);
            this.Controls.Add(this.txtFleet2);
            this.Controls.Add(this.txtFleet1);
            this.Controls.Add(this.btnFleet2);
            this.Controls.Add(this.btnFleet1);
            this.Name = "Ass2Form";
            this.Text = "Dominion Game by Guangbo Chen";
            this.Load += new System.EventHandler(this.Ass2Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFleet1;
        private System.Windows.Forms.Button btnFleet2;
        private System.Windows.Forms.TextBox txtFleet1;
        private System.Windows.Forms.TextBox txtFleet2;
        private System.Windows.Forms.TextBox txtSeed;
        private System.Windows.Forms.Label labelSeed;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtOutput;
    }
}

