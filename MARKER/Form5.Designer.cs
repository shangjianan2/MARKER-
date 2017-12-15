namespace MARKER
{
    partial class Form5
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.rightdown_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.rightdown_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // rightdown_chart
            // 
            chartArea1.Name = "ChartArea1";
            this.rightdown_chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.rightdown_chart.Legends.Add(legend1);
            this.rightdown_chart.Location = new System.Drawing.Point(12, 12);
            this.rightdown_chart.Name = "rightdown_chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.rightdown_chart.Series.Add(series1);
            this.rightdown_chart.Size = new System.Drawing.Size(860, 537);
            this.rightdown_chart.TabIndex = 0;
            this.rightdown_chart.Text = "chart1";
            this.rightdown_chart.DoubleClick += new System.EventHandler(this.rightdown_chart_DoubleClick);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.rightdown_chart);
            this.Name = "Form5";
            this.Text = "两通道在22.08Hz的幅值之差";
            ((System.ComponentModel.ISupportInitialize)(this.rightdown_chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart rightdown_chart;
    }
}