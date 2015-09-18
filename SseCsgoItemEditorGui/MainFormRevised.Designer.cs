namespace SseCsgoItemEditorGui
{
    partial class MainFormRevised
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tabCtlSettings = new System.Windows.Forms.TabControl();
            this.tabPageFile = new System.Windows.Forms.TabPage();
            this.tabPageOption = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFileNew = new System.Windows.Forms.Button();
            this.btnFileLoad = new System.Windows.Forms.Button();
            this.btnFileSave = new System.Windows.Forms.Button();
            this.btnFileExit = new System.Windows.Forms.Button();
            this.tabCtlSettings.SuspendLayout();
            this.tabPageFile.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 446);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(853, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "Ready";
            // 
            // tabCtlSettings
            // 
            this.tabCtlSettings.Controls.Add(this.tabPageFile);
            this.tabCtlSettings.Controls.Add(this.tabPageOption);
            this.tabCtlSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabCtlSettings.Location = new System.Drawing.Point(0, 0);
            this.tabCtlSettings.Name = "tabCtlSettings";
            this.tabCtlSettings.SelectedIndex = 0;
            this.tabCtlSettings.Size = new System.Drawing.Size(853, 79);
            this.tabCtlSettings.TabIndex = 1;
            // 
            // tabPageFile
            // 
            this.tabPageFile.Controls.Add(this.tableLayoutPanel1);
            this.tabPageFile.Location = new System.Drawing.Point(4, 22);
            this.tabPageFile.Name = "tabPageFile";
            this.tabPageFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFile.Size = new System.Drawing.Size(845, 53);
            this.tabPageFile.TabIndex = 0;
            this.tabPageFile.Text = "File";
            this.tabPageFile.UseVisualStyleBackColor = true;
            // 
            // tabPageOption
            // 
            this.tabPageOption.Location = new System.Drawing.Point(4, 22);
            this.tabPageOption.Name = "tabPageOption";
            this.tabPageOption.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOption.Size = new System.Drawing.Size(845, 53);
            this.tabPageOption.TabIndex = 1;
            this.tabPageOption.Text = "Option";
            this.tabPageOption.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.1365F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.8635F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 201F));
            this.tableLayoutPanel1.Controls.Add(this.btnFileNew, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFileLoad, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFileSave, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFileExit, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(839, 47);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnFileNew
            // 
            this.btnFileNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFileNew.Location = new System.Drawing.Point(3, 3);
            this.btnFileNew.Name = "btnFileNew";
            this.btnFileNew.Size = new System.Drawing.Size(157, 41);
            this.btnFileNew.TabIndex = 0;
            this.btnFileNew.Text = "New";
            this.btnFileNew.UseVisualStyleBackColor = true;
            // 
            // btnFileLoad
            // 
            this.btnFileLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFileLoad.Location = new System.Drawing.Point(166, 3);
            this.btnFileLoad.Name = "btnFileLoad";
            this.btnFileLoad.Size = new System.Drawing.Size(218, 41);
            this.btnFileLoad.TabIndex = 1;
            this.btnFileLoad.Text = "Load...";
            this.btnFileLoad.UseVisualStyleBackColor = true;
            // 
            // btnFileSave
            // 
            this.btnFileSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFileSave.Location = new System.Drawing.Point(390, 3);
            this.btnFileSave.Name = "btnFileSave";
            this.btnFileSave.Size = new System.Drawing.Size(244, 41);
            this.btnFileSave.TabIndex = 2;
            this.btnFileSave.Text = "Save...";
            this.btnFileSave.UseVisualStyleBackColor = true;
            // 
            // btnFileExit
            // 
            this.btnFileExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFileExit.Location = new System.Drawing.Point(640, 3);
            this.btnFileExit.Name = "btnFileExit";
            this.btnFileExit.Size = new System.Drawing.Size(196, 41);
            this.btnFileExit.TabIndex = 3;
            this.btnFileExit.Text = "Exit";
            this.btnFileExit.UseVisualStyleBackColor = true;
            // 
            // MainFormRevised
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 468);
            this.Controls.Add(this.tabCtlSettings);
            this.Controls.Add(this.statusStrip);
            this.Name = "MainFormRevised";
            this.ShowIcon = false;
            this.Text = "CSGO SSE Inventory Manager 1.0 - [x3r0]";
            this.tabCtlSettings.ResumeLayout(false);
            this.tabPageFile.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TabControl tabCtlSettings;
        private System.Windows.Forms.TabPage tabPageFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnFileNew;
        private System.Windows.Forms.Button btnFileLoad;
        private System.Windows.Forms.Button btnFileSave;
        private System.Windows.Forms.Button btnFileExit;
        private System.Windows.Forms.TabPage tabPageOption;
    }
}