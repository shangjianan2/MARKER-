namespace MARKER
{
    partial class Form4
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.leftdown_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.leftdown_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // leftdown_chart
            // 
            chartArea2.Name = "ChartArea1";
            this.leftdown_chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.leftdown_chart.Legends.Add(legend2);
            this.leftdown_chart.Location = new System.Drawing.Point(12, 12);
            this.leftdown_chart.Name = "leftdown_chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.leftdown_chart.Series.Add(series2);
            this.leftdown_chart.Size = new System.Drawing.Size(860, 537);
            this.leftdown_chart.TabIndex = 0;
            this.leftdown_chart.Text = "chart1";
            this.leftdown_chart.DoubleClick += new System.EventHandler(this.leftdown_chart_DoubleClick);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.leftdown_chart);
            this.Name = "Form4";
            this.Text = "No.1两通道在22.08Hz对应的幅值";
            ((System.ComponentModel.ISupportInitialize)(this.leftdown_chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart leftdown_chart;
    }
}