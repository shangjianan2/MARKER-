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
    public partial class Form5 : Form
    {
        List<List<byte>> shuju_chart3_1_erwei;
        List<List<byte>> shuju_chart3_2_erwei;
        int index = 0;

        public Form5(List<List<byte>> shuju_chart3_1_erwei_xingcan, List<List<byte>> shuju_chart3_2_erwei_xingcan, int index_xingcan)
        {
            InitializeComponent();

            shuju_chart3_1_erwei = shuju_chart3_1_erwei_xingcan;
            shuju_chart3_2_erwei = shuju_chart3_2_erwei_xingcan;
            index = index_xingcan;

            rightdown_chart.ChartAreas[0].AxisY.LabelStyle.Format = "N2";
            rightdown_chart.Titles.Add("两通道在22.08Hz的幅值之差");

            /**********************************************rightdown_chart*****************************************************************/
            rightdown_chart.Series.Clear();
            rightdown_chart.ChartAreas[0].CursorX.IsUserEnabled = true;
            rightdown_chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            rightdown_chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

            rightdown_chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            rightdown_chart.ChartAreas[0].AxisX.ScrollBar.Size = 10;///////
            rightdown_chart.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;

            rightdown_chart.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = double.NaN;
            rightdown_chart.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = 2;

            rightdown_chart.ChartAreas[0].AxisY.Maximum = System.Double.NaN;
            rightdown_chart.ChartAreas[0].AxisY.Minimum = System.Double.NaN;

            rightdown_chart.ChartAreas[0].CursorY.IsUserEnabled = true;
            rightdown_chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            rightdown_chart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            rightdown_chart.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
            rightdown_chart.ChartAreas[0].AxisY.ScrollBar.Size = 10;///////
            rightdown_chart.ChartAreas[0].AxisY.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;

            rightdown_chart.ChartAreas[0].AxisY.ScaleView.SmallScrollSize = double.NaN;
            rightdown_chart.ChartAreas[0].AxisY.ScaleView.SmallScrollSize = 200;

            double temp1, temp2;


            double max, min;

            rightdown_chart.Series.Clear();


            Series rightdown_chart_ch2 = new Series("difference");
            rightdown_chart_ch2.ChartType = SeriesChartType.Spline;
            rightdown_chart_ch2.Color = Color.Black;

            max = -2147483647; min = 2147483647;
            byte[] tran_byte_4 = new byte[8];
            for (int i = 0; i < shuju_chart3_1_erwei[index].Count; i += 4)//不能每个点都显示，都显示的话控件太卡（滚动条有明显的延迟）
            {
                tran_byte_4[0] = shuju_chart3_1_erwei[index][i + 3];
                tran_byte_4[1] = shuju_chart3_1_erwei[index][i + 2];
                tran_byte_4[2] = shuju_chart3_1_erwei[index][i + 1];
                tran_byte_4[3] = shuju_chart3_1_erwei[index][i];
                temp1 = BitConverter.ToSingle(tran_byte_4, 0);

                tran_byte_4[0] = shuju_chart3_2_erwei[index][i + 3];
                tran_byte_4[1] = shuju_chart3_2_erwei[index][i + 2];
                tran_byte_4[2] = shuju_chart3_2_erwei[index][i + 1];
                tran_byte_4[3] = shuju_chart3_2_erwei[index][i];
                temp2 = BitConverter.ToSingle(tran_byte_4, 0);


                rightdown_chart_ch2.Points.AddXY(i/4, (temp1 - temp2));


                max = ((temp1 - temp2) > max) ? (temp1 - temp2) : max;
                min = ((temp1 - temp2) < min) ? (temp1 - temp2) : min;
            }

            rightdown_chart.ChartAreas[0].AxisY.Maximum = max + (max - min) / 5;
            rightdown_chart.ChartAreas[0].AxisY.Minimum = min - (max - min) / 5;

            rightdown_chart.Series.Add(rightdown_chart_ch2);
        }

        private void rightdown_chart_DoubleClick(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();//注意 这里是SaveFileDialog,不是OpenFileDialog
            sfd.DefaultExt = "jpeg";
            sfd.Filter = "图片(*.jpeg)|*.jpeg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //string[] temp_str = sfd.FileName.Split('.');//以‘。’为分割符，分成两份，取前一份
                //总共四个图片，要保存四份，添加了一定的命名规律
                rightdown_chart.SaveImage(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)//关闭所有线程
        {
            this.Dispose();
            this.Close();
        }
    }
}
