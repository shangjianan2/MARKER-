using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.IO;
using System.IO.Ports;
using System.Security.Permissions;
using System.Threading;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;

namespace MARKER
{
    public partial class Form3 : Form
    {
        List<List<byte>> shuju_chart2_ci_erwei;
        int index = 0;
        public Form3(List<List<byte>> shuju_chart2_ci_erwei_xingcan, int index_xingcan)
        {
            InitializeComponent();

            shuju_chart2_ci_erwei = shuju_chart2_ci_erwei_xingcan;
            index = index_xingcan;

            rightup_chart.ChartAreas[0].AxisY.LabelStyle.Format = "N2";
            rightup_chart.Titles.Add("Magnet Sensor Time Domain");

            /**********************************************rightup_chart*****************************************************************/
            rightup_chart.Series.Clear();
            rightup_chart.ChartAreas[0].CursorX.IsUserEnabled = true;
            rightup_chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            rightup_chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

            rightup_chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            rightup_chart.ChartAreas[0].AxisX.ScrollBar.Size = 10;///////
            rightup_chart.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;

            rightup_chart.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = double.NaN;
            rightup_chart.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = 2;

            rightup_chart.ChartAreas[0].AxisY.Maximum = System.Double.NaN;
            rightup_chart.ChartAreas[0].AxisY.Minimum = System.Double.NaN;

            rightup_chart.ChartAreas[0].CursorY.IsUserEnabled = true;
            rightup_chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            rightup_chart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            rightup_chart.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
            rightup_chart.ChartAreas[0].AxisY.ScrollBar.Size = 10;///////
            rightup_chart.ChartAreas[0].AxisY.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;

            rightup_chart.ChartAreas[0].AxisY.ScaleView.SmallScrollSize = double.NaN;
            rightup_chart.ChartAreas[0].AxisY.ScaleView.SmallScrollSize = 200;

            double temp = 0;
            //double temp_double = 0;
            double max, min;
            
            rightup_chart.Series.Clear();

            Series rightup_chart_ch = new Series("ch1");
            rightup_chart_ch.ChartType = SeriesChartType.Spline;
            rightup_chart_ch.Color = Color.Red;

            max = -2147483647; min = 2147483647;
            byte[] tran_byte_4 = new byte[8];
            double temp_tran_1, temp_tran_2, temp_tran_3;
            for (int i = 0; i < shuju_chart2_ci_erwei[index].Count - 12; i += 12)//不能每个点都显示，都显示的话控件太卡（滚动条有明显的延迟）
            {
                tran_byte_4[0] = shuju_chart2_ci_erwei[index][i + 3];
                tran_byte_4[1] = shuju_chart2_ci_erwei[index][i + 2];
                tran_byte_4[2] = shuju_chart2_ci_erwei[index][i + 1];
                tran_byte_4[3] = shuju_chart2_ci_erwei[index][i];
                temp_tran_1 = BitConverter.ToSingle(tran_byte_4, 0);

                tran_byte_4[0] = shuju_chart2_ci_erwei[index][i + 7];
                tran_byte_4[1] = shuju_chart2_ci_erwei[index][i + 6];
                tran_byte_4[2] = shuju_chart2_ci_erwei[index][i + 5];
                tran_byte_4[3] = shuju_chart2_ci_erwei[index][i + 4];
                temp_tran_2 = BitConverter.ToSingle(tran_byte_4, 0);

                tran_byte_4[0] = shuju_chart2_ci_erwei[index][i + 11];
                tran_byte_4[1] = shuju_chart2_ci_erwei[index][i + 10];
                tran_byte_4[2] = shuju_chart2_ci_erwei[index][i + 9];
                tran_byte_4[3] = shuju_chart2_ci_erwei[index][i + 8];
                temp_tran_3 = BitConverter.ToSingle(tran_byte_4, 0);

                temp = (temp_tran_1 + temp_tran_2 + temp_tran_3) / 3;

                rightup_chart_ch.Points.AddXY(i / 4, temp);//////////////////////////////////////
                max = (temp > max) ? temp : max;
                min = (temp < min) ? temp : min;
            }
            rightup_chart.ChartAreas[0].AxisY.Maximum = max + (max - min) / 5;
            rightup_chart.ChartAreas[0].AxisY.Minimum = min - (max - min) / 5;

            rightup_chart.Series.Add(rightup_chart_ch);
        }

        private void rightup_chart_DoubleClick(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();//注意 这里是SaveFileDialog,不是OpenFileDialog
            sfd.DefaultExt = "jpeg";
            sfd.Filter = "图片(*.jpeg)|*.jpeg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //string[] temp_str = sfd.FileName.Split('.');//以‘。’为分割符，分成两份，取前一份
                //总共四个图片，要保存四份，添加了一定的命名规律
                rightup_chart.SaveImage(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)//关闭所有线程
        {
            this.Dispose();
            this.Close();
        }
    }
}
