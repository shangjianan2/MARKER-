namespace MARKER
{
    partial class Form3
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
            this.rightup_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.rightup_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // rightup_chart
            // 
            chartArea2.Name = "ChartArea1";
            this.rightup_chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.rightup_chart.Legends.Add(legend2);
            this.rightup_chart.Location = new System.Drawing.Point(12, 12);
            this.rightup_chart.Name = "rightup_chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.rightup_chart.Series.Add(series2);
            this.rightup_chart.Size = new System.Drawing.Size(860, 537);
            this.rightup_chart.TabIndex = 0;
            this.rightup_chart.Text = "chart1";
            this.rightup_chart.DoubleClick += new System.EventHandler(this.rightup_chart_DoubleClick);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.rightup_chart);
            this.Name = "Form3";
            this.Text = "Magnet Sensor Time Domain";
            ((System.ComponentModel.ISupportInitialize)(this.rightup_chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart rightup_chart;
    }
}