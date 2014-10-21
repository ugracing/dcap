namespace DCAP
{
    partial class FormDCAPHome
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartMultiPurpose = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.comboBoxSeries1 = new System.Windows.Forms.ComboBox();
            this.buttonSaveGraph = new System.Windows.Forms.Button();
            this.comboBoxSeries2 = new System.Windows.Forms.ComboBox();
            this.buttonResetZoom = new System.Windows.Forms.Button();
            this.listViewAnalysisView = new System.Windows.Forms.ListBox();
            this.labelPerformance = new System.Windows.Forms.Label();
            this.buttonViewAnalysis = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartMultiPurpose)).BeginInit();
            this.SuspendLayout();
            // 
            // chartMultiPurpose
            // 
            this.chartMultiPurpose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chartMultiPurpose.BackColor = System.Drawing.Color.LightCyan;
            chartArea4.Name = "ChartAreaDCAP";
            this.chartMultiPurpose.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartMultiPurpose.Legends.Add(legend4);
            this.chartMultiPurpose.Location = new System.Drawing.Point(0, 26);
            this.chartMultiPurpose.Name = "chartMultiPurpose";
            this.chartMultiPurpose.Size = new System.Drawing.Size(799, 439);
            this.chartMultiPurpose.TabIndex = 0;
            this.chartMultiPurpose.Text = "Title";
            title4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            title4.ForeColor = System.Drawing.Color.Gray;
            title4.Name = "TitleChart";
            title4.Text = "Generate A Chart";
            this.chartMultiPurpose.Titles.Add(title4);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.BackColor = System.Drawing.Color.Aquamarine;
            this.buttonGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerate.Location = new System.Drawing.Point(0, 0);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(94, 24);
            this.buttonGenerate.TabIndex = 1;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = false;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // comboBoxSeries1
            // 
            this.comboBoxSeries1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBoxSeries1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSeries1.FormattingEnabled = true;
            this.comboBoxSeries1.Items.AddRange(new object[] {
            "THROTTLE",
            "BRAKE",
            "GEAR",
            "WHEEL_RPM",
            "ENGINE_RPM",
            "TEMPERATURE"});
            this.comboBoxSeries1.Location = new System.Drawing.Point(99, 0);
            this.comboBoxSeries1.Name = "comboBoxSeries1";
            this.comboBoxSeries1.Size = new System.Drawing.Size(195, 24);
            this.comboBoxSeries1.TabIndex = 2;
            // 
            // buttonSaveGraph
            // 
            this.buttonSaveGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveGraph.BackColor = System.Drawing.Color.White;
            this.buttonSaveGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveGraph.Location = new System.Drawing.Point(705, 0);
            this.buttonSaveGraph.Name = "buttonSaveGraph";
            this.buttonSaveGraph.Size = new System.Drawing.Size(89, 24);
            this.buttonSaveGraph.TabIndex = 3;
            this.buttonSaveGraph.Text = "Save Chart";
            this.buttonSaveGraph.UseVisualStyleBackColor = false;
            this.buttonSaveGraph.Click += new System.EventHandler(this.buttonSaveGraph_Click);
            // 
            // comboBoxSeries2
            // 
            this.comboBoxSeries2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBoxSeries2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSeries2.FormattingEnabled = true;
            this.comboBoxSeries2.Items.AddRange(new object[] {
            "THROTTLE",
            "BRAKE",
            "GEAR",
            "WHEEL_RPM",
            "ENGINE_RPM",
            "TEMPERATURE"});
            this.comboBoxSeries2.Location = new System.Drawing.Point(300, 0);
            this.comboBoxSeries2.Name = "comboBoxSeries2";
            this.comboBoxSeries2.Size = new System.Drawing.Size(184, 24);
            this.comboBoxSeries2.TabIndex = 4;
            // 
            // buttonResetZoom
            // 
            this.buttonResetZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResetZoom.BackColor = System.Drawing.Color.White;
            this.buttonResetZoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetZoom.Location = new System.Drawing.Point(603, 0);
            this.buttonResetZoom.Name = "buttonResetZoom";
            this.buttonResetZoom.Size = new System.Drawing.Size(99, 24);
            this.buttonResetZoom.TabIndex = 5;
            this.buttonResetZoom.Text = "Reset Zoom";
            this.buttonResetZoom.UseVisualStyleBackColor = false;
            this.buttonResetZoom.Click += new System.EventHandler(this.buttonResetZoom_Click);
            // 
            // listViewAnalysisView
            // 
            this.listViewAnalysisView.Enabled = false;
            this.listViewAnalysisView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewAnalysisView.FormattingEnabled = true;
            this.listViewAnalysisView.ItemHeight = 20;
            this.listViewAnalysisView.Location = new System.Drawing.Point(215, 172);
            this.listViewAnalysisView.Name = "listViewAnalysisView";
            this.listViewAnalysisView.Size = new System.Drawing.Size(455, 104);
            this.listViewAnalysisView.TabIndex = 8;
            // 
            // labelPerformance
            // 
            this.labelPerformance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPerformance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPerformance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelPerformance.Location = new System.Drawing.Point(738, 452);
            this.labelPerformance.Name = "labelPerformance";
            this.labelPerformance.Size = new System.Drawing.Size(64, 16);
            this.labelPerformance.TabIndex = 9;
            this.labelPerformance.Visible = false;
            // 
            // buttonViewAnalysis
            // 
            this.buttonViewAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonViewAnalysis.BackColor = System.Drawing.Color.White;
            this.buttonViewAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonViewAnalysis.Location = new System.Drawing.Point(499, 0);
            this.buttonViewAnalysis.Name = "buttonViewAnalysis";
            this.buttonViewAnalysis.Size = new System.Drawing.Size(101, 24);
            this.buttonViewAnalysis.TabIndex = 7;
            this.buttonViewAnalysis.Text = "View Analysis";
            this.buttonViewAnalysis.UseVisualStyleBackColor = false;
            this.buttonViewAnalysis.Click += new System.EventHandler(this.buttonViewAnalysis_Click);
            // 
            // FormDCAPHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 467);
            this.Controls.Add(this.labelPerformance);
            this.Controls.Add(this.listViewAnalysisView);
            this.Controls.Add(this.buttonViewAnalysis);
            this.Controls.Add(this.buttonResetZoom);
            this.Controls.Add(this.comboBoxSeries2);
            this.Controls.Add(this.buttonSaveGraph);
            this.Controls.Add(this.comboBoxSeries1);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.chartMultiPurpose);
            this.Name = "FormDCAPHome";
            this.Text = "DCAP";
            this.SizeChanged += new System.EventHandler(this.FormDCAPHome_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.chartMultiPurpose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartMultiPurpose;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.ComboBox comboBoxSeries1;
        private System.Windows.Forms.Button buttonSaveGraph;
        private System.Windows.Forms.ComboBox comboBoxSeries2;
        private System.Windows.Forms.Button buttonResetZoom;
        private System.Windows.Forms.ListBox listViewAnalysisView;
        private System.Windows.Forms.Label labelPerformance;
        private System.Windows.Forms.Button buttonViewAnalysis;
    }
}

