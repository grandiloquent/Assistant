namespace Assistant
{
    partial class Hbk3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hbk3));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.dsStatisticsButton = new System.Windows.Forms.ToolStripButton();
            this.saveToImageButton = new System.Windows.Forms.ToolStripButton();
            this.sumButton = new System.Windows.Forms.ToolStripButton();
            this.sumStatisticsButton = new System.Windows.Forms.ToolStripButton();
            this.marksixButton = new System.Windows.Forms.ToolStrip();
            this.simulateButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.analysisButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.marksixButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dsStatisticsButton,
            this.saveToImageButton,
            this.sumButton,
            this.sumStatisticsButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // dsStatisticsButton
            // 
            this.dsStatisticsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.dsStatisticsButton.Image = ((System.Drawing.Image)(resources.GetObject("dsStatisticsButton.Image")));
            this.dsStatisticsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dsStatisticsButton.Name = "dsStatisticsButton";
            this.dsStatisticsButton.Size = new System.Drawing.Size(60, 22);
            this.dsStatisticsButton.Text = "单双统计";
            this.dsStatisticsButton.Click += new System.EventHandler(this.DsStatisticsButton_Click);
            // 
            // saveToImageButton
            // 
            this.saveToImageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveToImageButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToImageButton.Image")));
            this.saveToImageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToImageButton.Name = "saveToImageButton";
            this.saveToImageButton.Size = new System.Drawing.Size(36, 22);
            this.saveToImageButton.Text = "图片";
            this.saveToImageButton.Click += new System.EventHandler(this.saveToImageButton_Click);
            // 
            // sumButton
            // 
            this.sumButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sumButton.Image = ((System.Drawing.Image)(resources.GetObject("sumButton.Image")));
            this.sumButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sumButton.Name = "sumButton";
            this.sumButton.Size = new System.Drawing.Size(36, 22);
            this.sumButton.Text = "和值";
            this.sumButton.Click += new System.EventHandler(this.sumButton_Click);
            // 
            // sumStatisticsButton
            // 
            this.sumStatisticsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sumStatisticsButton.Image = ((System.Drawing.Image)(resources.GetObject("sumStatisticsButton.Image")));
            this.sumStatisticsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sumStatisticsButton.Name = "sumStatisticsButton";
            this.sumStatisticsButton.Size = new System.Drawing.Size(60, 22);
            this.sumStatisticsButton.Text = "和值统计";
            this.sumStatisticsButton.Click += new System.EventHandler(this.sumStatisticsButton_Click);
            // 
            // marksixButton
            // 
            this.marksixButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simulateButton,
            this.toolStripButton1,
            this.analysisButton});
            this.marksixButton.Location = new System.Drawing.Point(0, 25);
            this.marksixButton.Name = "marksixButton";
            this.marksixButton.Size = new System.Drawing.Size(800, 25);
            this.marksixButton.TabIndex = 1;
            this.marksixButton.Text = "toolStrip2";
            // 
            // simulateButton
            // 
            this.simulateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.simulateButton.Image = ((System.Drawing.Image)(resources.GetObject("simulateButton.Image")));
            this.simulateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.simulateButton.Name = "simulateButton";
            this.simulateButton.Size = new System.Drawing.Size(36, 22);
            this.simulateButton.Text = "模拟";
            this.simulateButton.Click += new System.EventHandler(this.simulateButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // analysisButton
            // 
            this.analysisButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.analysisButton.Image = ((System.Drawing.Image)(resources.GetObject("analysisButton.Image")));
            this.analysisButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.analysisButton.Name = "analysisButton";
            this.analysisButton.Size = new System.Drawing.Size(36, 22);
            this.analysisButton.Text = "分析";
            this.analysisButton.Click += new System.EventHandler(this.analysisButton_Click);
            // 
            // Hbk3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.marksixButton);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Hbk3";
            this.Text = "Hbk3";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.marksixButton.ResumeLayout(false);
            this.marksixButton.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton saveToImageButton;
        private System.Windows.Forms.ToolStripButton dsStatisticsButton;
        private System.Windows.Forms.ToolStripButton sumButton;
        private System.Windows.Forms.ToolStripButton sumStatisticsButton;
        private System.Windows.Forms.ToolStrip marksixButton;
        private System.Windows.Forms.ToolStripButton simulateButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton analysisButton;
    }
}