namespace Winform
{
    partial class Form1
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
            label1 = new Label();
            textBoxGrid = new TextBox();
            tabControlTarget = new TabControl();
            tabPage1 = new TabPage();
            comboBoxPlanet = new ComboBox();
            tabPage2 = new TabPage();
            label2 = new Label();
            textBoxTLE = new TextBox();
            labelPostion = new Label();
            label3 = new Label();
            textBoxAddress = new TextBox();
            buttonConnect = new Button();
            labelTarget = new Label();
            labelCurrent = new Label();
            buttonTrack = new Button();
            tabControlTarget.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 25);
            label1.Name = "label1";
            label1.Size = new Size(53, 25);
            label1.TabIndex = 0;
            label1.Text = "GRID";
            // 
            // textBoxGrid
            // 
            textBoxGrid.Location = new Point(110, 22);
            textBoxGrid.Name = "textBoxGrid";
            textBoxGrid.Size = new Size(150, 31);
            textBoxGrid.TabIndex = 1;
            textBoxGrid.TextChanged += textBoxGrid_TextChanged;
            // 
            // tabControlTarget
            // 
            tabControlTarget.Controls.Add(tabPage1);
            tabControlTarget.Controls.Add(tabPage2);
            tabControlTarget.Location = new Point(12, 81);
            tabControlTarget.Name = "tabControlTarget";
            tabControlTarget.SelectedIndex = 0;
            tabControlTarget.Size = new Size(983, 204);
            tabControlTarget.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(comboBoxPlanet);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(975, 166);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Planet";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBoxPlanet
            // 
            comboBoxPlanet.FormattingEnabled = true;
            comboBoxPlanet.Location = new Point(22, 30);
            comboBoxPlanet.Name = "comboBoxPlanet";
            comboBoxPlanet.Size = new Size(182, 33);
            comboBoxPlanet.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(textBoxTLE);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(975, 166);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Satellite";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 16);
            label2.Name = "label2";
            label2.Size = new Size(38, 25);
            label2.TabIndex = 1;
            label2.Text = "TLE";
            // 
            // textBoxTLE
            // 
            textBoxTLE.Location = new Point(22, 44);
            textBoxTLE.Multiline = true;
            textBoxTLE.Name = "textBoxTLE";
            textBoxTLE.Size = new Size(931, 90);
            textBoxTLE.TabIndex = 0;
            // 
            // labelPostion
            // 
            labelPostion.AutoSize = true;
            labelPostion.Location = new Point(293, 25);
            labelPostion.Name = "labelPostion";
            labelPostion.Size = new Size(0, 25);
            labelPostion.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 441);
            label3.Name = "label3";
            label3.Size = new Size(144, 25);
            label3.TabIndex = 4;
            label3.Text = "Address (rotctld)";
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(188, 438);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(186, 31);
            textBoxAddress.TabIndex = 5;
            textBoxAddress.Text = "127.0.0.1:4533";
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(398, 436);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(134, 34);
            buttonConnect.TabIndex = 6;
            buttonConnect.Text = "Connect";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // labelTarget
            // 
            labelTarget.AutoSize = true;
            labelTarget.Font = new Font("Segoe UI", 14F);
            labelTarget.ForeColor = SystemColors.Highlight;
            labelTarget.Location = new Point(38, 297);
            labelTarget.Name = "labelTarget";
            labelTarget.Size = new Size(0, 38);
            labelTarget.TabIndex = 7;
            // 
            // labelCurrent
            // 
            labelCurrent.AutoSize = true;
            labelCurrent.Font = new Font("Segoe UI", 14F);
            labelCurrent.ForeColor = Color.Maroon;
            labelCurrent.Location = new Point(38, 363);
            labelCurrent.Name = "labelCurrent";
            labelCurrent.Size = new Size(0, 38);
            labelCurrent.TabIndex = 8;
            // 
            // buttonTrack
            // 
            buttonTrack.Location = new Point(538, 436);
            buttonTrack.Name = "buttonTrack";
            buttonTrack.Size = new Size(112, 34);
            buttonTrack.TabIndex = 9;
            buttonTrack.Text = "Track";
            buttonTrack.UseVisualStyleBackColor = true;
            buttonTrack.Click += buttonTrack_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1007, 527);
            Controls.Add(buttonTrack);
            Controls.Add(labelCurrent);
            Controls.Add(labelTarget);
            Controls.Add(buttonConnect);
            Controls.Add(textBoxAddress);
            Controls.Add(label3);
            Controls.Add(labelPostion);
            Controls.Add(tabControlTarget);
            Controls.Add(textBoxGrid);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Satellite Rotator Controller by BH4EZW";
            tabControlTarget.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxGrid;
        private TabControl tabControlTarget;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label labelPostion;
        private ComboBox comboBoxPlanet;
        private Label label2;
        private TextBox textBoxTLE;
        private Label label3;
        private TextBox textBoxAddress;
        private Button buttonConnect;
        private Label labelTarget;
        private Label labelCurrent;
        private Button buttonTrack;
    }
}
