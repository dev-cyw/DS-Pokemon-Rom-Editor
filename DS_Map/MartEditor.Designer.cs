namespace DSPRE {
    partial class MartEditor {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.Tabs = new System.Windows.Forms.TabControl();
            this.MainMartTAB = new System.Windows.Forms.TabPage();
            this.MainMartSaveBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LevelCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ItemCB = new System.Windows.Forms.ComboBox();
            this.OtherMartsTAB = new System.Windows.Forms.TabPage();
            this.MainMartLB = new DSPRE.ListBox2();
            this.Tabs.SuspendLayout();
            this.MainMartTAB.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.MainMartTAB);
            this.Tabs.Controls.Add(this.OtherMartsTAB);
            this.Tabs.Location = new System.Drawing.Point(12, 12);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(327, 191);
            this.Tabs.TabIndex = 0;
            // 
            // MainMartTAB
            // 
            this.MainMartTAB.Controls.Add(this.MainMartSaveBTN);
            this.MainMartTAB.Controls.Add(this.label2);
            this.MainMartTAB.Controls.Add(this.LevelCB);
            this.MainMartTAB.Controls.Add(this.label1);
            this.MainMartTAB.Controls.Add(this.ItemCB);
            this.MainMartTAB.Controls.Add(this.MainMartLB);
            this.MainMartTAB.Location = new System.Drawing.Point(4, 22);
            this.MainMartTAB.Name = "MainMartTAB";
            this.MainMartTAB.Padding = new System.Windows.Forms.Padding(3);
            this.MainMartTAB.Size = new System.Drawing.Size(319, 165);
            this.MainMartTAB.TabIndex = 0;
            this.MainMartTAB.Text = "Main Mart";
            this.MainMartTAB.UseVisualStyleBackColor = true;
            // 
            // MainMartSaveBTN
            // 
            this.MainMartSaveBTN.Image = global::DSPRE.Properties.Resources.saveButton;
            this.MainMartSaveBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MainMartSaveBTN.Location = new System.Drawing.Point(239, 17);
            this.MainMartSaveBTN.Name = "MainMartSaveBTN";
            this.MainMartSaveBTN.Size = new System.Drawing.Size(74, 23);
            this.MainMartSaveBTN.TabIndex = 5;
            this.MainMartSaveBTN.Text = "Save";
            this.MainMartSaveBTN.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.MainMartSaveBTN.UseVisualStyleBackColor = true;
            this.MainMartSaveBTN.Click += new System.EventHandler(this.MainMartSaveBTN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Level";
            // 
            // LevelCB
            // 
            this.LevelCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LevelCB.FormattingEnabled = true;
            this.LevelCB.Location = new System.Drawing.Point(138, 18);
            this.LevelCB.Name = "LevelCB";
            this.LevelCB.Size = new System.Drawing.Size(95, 21);
            this.LevelCB.TabIndex = 3;
            this.LevelCB.SelectedIndexChanged += new System.EventHandler(this.LevelCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Item";
            // 
            // ItemCB
            // 
            this.ItemCB.FormattingEnabled = true;
            this.ItemCB.Location = new System.Drawing.Point(6, 18);
            this.ItemCB.Name = "ItemCB";
            this.ItemCB.Size = new System.Drawing.Size(113, 21);
            this.ItemCB.TabIndex = 1;
            this.ItemCB.SelectedIndexChanged += new System.EventHandler(this.ItemCB_SelectedIndexChanged);
            // 
            // OtherMartsTAB
            // 
            this.OtherMartsTAB.Location = new System.Drawing.Point(4, 22);
            this.OtherMartsTAB.Name = "OtherMartsTAB";
            this.OtherMartsTAB.Padding = new System.Windows.Forms.Padding(3);
            this.OtherMartsTAB.Size = new System.Drawing.Size(319, 165);
            this.OtherMartsTAB.TabIndex = 1;
            this.OtherMartsTAB.Text = "Other Marts";
            this.OtherMartsTAB.UseVisualStyleBackColor = true;
            // 
            // MainMartLB
            // 
            this.MainMartLB.FormattingEnabled = true;
            this.MainMartLB.Location = new System.Drawing.Point(6, 45);
            this.MainMartLB.Name = "MainMartLB";
            this.MainMartLB.Size = new System.Drawing.Size(307, 108);
            this.MainMartLB.TabIndex = 0;
            this.MainMartLB.SelectedIndexChanged += new System.EventHandler(this.MainMartLB_SelectedIndexChanged);
            // 
            // MartEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(351, 212);
            this.Controls.Add(this.Tabs);
            this.MaximizeBox = false;
            this.Name = "MartEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mart Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MartEditor_FormClosing);
            this.Tabs.ResumeLayout(false);
            this.MainMartTAB.ResumeLayout(false);
            this.MainMartTAB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage MainMartTAB;
        private System.Windows.Forms.ComboBox LevelCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ItemCB;
        private ListBox2 MainMartLB;
        private System.Windows.Forms.TabPage OtherMartsTAB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button MainMartSaveBTN;
    }
}