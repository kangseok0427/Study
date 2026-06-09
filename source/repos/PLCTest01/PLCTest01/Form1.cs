using System;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ACTMULTILIB_K;

namespace PLCTest01
{
    public partial class Form1 : Form
    {
        ActEasyIF control = new ActEasyIF();
        int xPos = 1;

        public Form1()
        {
            InitializeComponent();

            chart1.Series.Clear();

            Series sB = chart1.Series.Add("B실린더");
            sB.ChartType = SeriesChartType.Line;

            Series sC = chart1.Series.Add("C실린더");
            sC.ChartType = SeriesChartType.Line;

            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 1;
        }

        // 시뮬레이터 연결 및 타이머 시작
        private void button1_Click(object sender, EventArgs e)
        {
            if (control.Open() == 0)
            {
                MessageBox.Show("연결되었습니다.");
                timer1.Enabled = true;
                pictureBox1.Image = Properties.Resources.cylinderoff;
            }
            else
            {
                MessageBox.Show("연결실패하였습니다.");
            }
        }
        // 전진 명령 전송
        private void button2_Click_1(object sender, EventArgs e)
        {
            short value = (short)(0x01 << 2);
            control.WriteDeviceBlock2("Y0", 1, ref value);
        }

        // 후진 명령 전송
        private void button3_Click_1(object sender, EventArgs e)
        {
            short value = (short)(0x01 << 3);
            control.WriteDeviceBlock2("Y0", 1, ref value);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            short value = (short)(0x01 << 5);
            control.WriteDeviceBlock2("Y0", 1, ref value);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            short value = (short)(0x01 << 4);
            control.WriteDeviceBlock2("Y0", 1, ref value);
        }

        // 1000ms 마다 센서 데이터를 읽어 이미지, 라벨, 차트 업데이트
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            short sensors = 0;
            control.ReadDeviceBlock2("X0", 1, out sensors);

            // B실린더 상태 (X02 후진, X03 전진)
            if ((sensors & (0x01 << 1)) != 0)
            {
                label1.Text = "B실린더: 전진";
                pictureBox1.Image = Properties.Resources.cylinderon;
                chart1.Series["B실린더"].Points.AddXY(xPos, 1);
            }
            else if ((sensors & (0x01 << 2)) != 0)
            {
                label1.Text = "B실린더: 후진";
                pictureBox1.Image = Properties.Resources.cylinderoff;
                chart1.Series["B실린더"].Points.AddXY(xPos, 0);
            }

            // C실린더 상태 (X4 전진, X5 후진)
            if ((sensors & (0x01 << 3)) != 0)
            {
                label2.Text = "C실린더: 전진";
                pictureBox2.Image = Properties.Resources.cylinderon;
                chart1.Series["C실린더"].Points.AddXY(xPos, 1);
            }
            else if ((sensors & (0x01 << 4)) != 0)
            {
                label2.Text = "C실린더: 후진";
                pictureBox2.Image = Properties.Resources.cylinderoff;
                chart1.Series["C실린더"].Points.AddXY(xPos, 0);
            }

            xPos++;

            if (chart1.Series["B실린더"].Points.Count > 20)
                chart1.Series["B실린더"].Points.RemoveAt(0);
            if (chart1.Series["C실린더"].Points.Count > 20)
                chart1.Series["C실린더"].Points.RemoveAt(0);

            chart1.ChartAreas[0].AxisX.Minimum = xPos - 20;
            chart1.ChartAreas[0].AxisX.Maximum = xPos;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}