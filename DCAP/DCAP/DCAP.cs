using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DCAP
{
    public partial class FormDCAPHome : Form
    {
        //The Master DataTable
        public DataTable CarData = new DataTable();

        public FormDCAPHome()
        {
            InitializeComponent();
            Setup();
            ImportCarData();
            GetStats();
        }

        private void Setup()
        {
            this.chartMultiPurpose.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            this.chartMultiPurpose.ChartAreas[0].AxisX2.ScaleView.Zoomable = true;
            this.chartMultiPurpose.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            this.chartMultiPurpose.ChartAreas[0].AxisY2.ScaleView.Zoomable = true;


            this.CarData.Columns.Add("name", typeof(string));
            this.CarData.Columns.Add("value", typeof(double));
            this.CarData.Columns.Add("timestamp", typeof(double));

            this.chartMultiPurpose.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            this.chartMultiPurpose.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> DesiredSensors = new List<string>();
                this.chartMultiPurpose.Series.Clear();
                DesiredSensors.Add(this.FetchSelectedSeries(comboBoxSeries1.Text.ToString(), 1));
                DesiredSensors.Add(this.FetchSelectedSeries(comboBoxSeries2.Text.ToString(), 2));

                this.chartMultiPurpose.Titles[0].Text = comboBoxSeries1.Text.ToString() + " & " + comboBoxSeries2.Text.ToString();

                this.WriteToChart(DesiredSensors);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void GetStats()
        {
            double PerformanceCoeff = 0;

            int GearShifts = 0;
            double CountsOnThrottle = 0;
            bool ThrottleHigh = false;
            double CountsOnBrake = 0;
            bool BrakeHigh = false;
            double PedalCrossoverCounts = 0;
            double MaxTemperature = 0;

            foreach (DataRow Stats in this.CarData.Rows)
            {
                if (Stats["name"].Equals("GEAR"))
                    GearShifts++;

                if (Stats["name"].Equals("THROTTLE"))
                {
                    if ((double)Stats["value"] > 2.0)
                    {
                        CountsOnThrottle++; ThrottleHigh = true;
                        if (ThrottleHigh && BrakeHigh)
                        {
                            PedalCrossoverCounts++;
                        }
                    }
                    else
                    {
                        ThrottleHigh = false;
                    }
                }

                if (Stats["name"].Equals("BRAKE"))
                {
                    if ((double)Stats["value"] > 10.0)
                    {
                        CountsOnBrake++; BrakeHigh = true;
                        if (ThrottleHigh && BrakeHigh)
                        {
                            PedalCrossoverCounts++;
                        }
                    }
                    else
                    {
                        BrakeHigh = false;
                    }
                }

                if (Stats["name"].Equals("Temperature"))
                {
                    if ((double)Stats["value"] > MaxTemperature)
                    {
                        MaxTemperature = (double)Stats["value"];
                    }
                }
            }

            double totalCounts = CountsOnBrake + CountsOnThrottle;

            double pctOnThrottle = (CountsOnThrottle / totalCounts) * 100;
            double pctOnBrake = (CountsOnBrake / totalCounts) * 100;
            double pctCrossover = (PedalCrossoverCounts / totalCounts) * 100;


            listViewAnalysisView.Visible = false;
            listViewAnalysisView.Items.Add("Percentage Time Spent On Throttle - "
                                        + pctOnThrottle.ToString("#.##") +
                                        "%");

            listViewAnalysisView.Items.Add("Percentage Time Spent On Brake - "
                                        + pctOnBrake.ToString("#.##") +
                                        "%");

            listViewAnalysisView.Items.Add("Percentage Time On Pedal & Brake Together - "
                                        + pctCrossover.ToString("#.##") +
                                        "%");

            listViewAnalysisView.Items.Add("Number Of Gear Shifts - "
                                        + GearShifts.ToString());

            listViewAnalysisView.Items.Add("Max Temperature - "
                                        + MaxTemperature.ToString("#.##"));



            if (PerformanceCoeff < 25)
            {
                this.labelPerformance.BackColor = Color.Red;
                this.labelPerformance.Text = "POOR";
            }
            else if (PerformanceCoeff >= 25 && PerformanceCoeff <50)
            {
                this.labelPerformance.BackColor = Color.OrangeRed;
                this.labelPerformance.Text = "OK";
            }
            else if (PerformanceCoeff >= 50 && PerformanceCoeff < 75)
            {
                this.labelPerformance.BackColor = Color.YellowGreen;
                this.labelPerformance.Text = "GOOD";
            }
            else
            {
                this.labelPerformance.BackColor = Color.Lime;
                this.labelPerformance.Text = "GREAT";
            }

            PerformanceCoeff = 100 - pctCrossover;

            this.labelPerformance.Visible = true;
        }

        private string FetchSelectedSeries(string sensor, int number)
        {
            switch (sensor)
            {
                case "THROTTLE":
                    GenerateThrottle(number);
                    return sensor;

                case "BRAKE":
                    GenerateBrake(number);
                    return sensor;

                case "GEAR":
                    GenerateGear(number);
                    return sensor;

                case "ENGINE_RPM":
                    GenerateEngineRPM(number);
                    return sensor;

                case "WHEEL_RPM":
                    GenerateWheelRPM(number);
                    return sensor;

                case "TEMPERATURE":
                    GenerateTemperature(number);
                    return sensor;
                
                default:
                    return sensor;
            }
        }

        private void GenerateTemperature(int series)
        {
            this.chartMultiPurpose.Series.Add("TEMPERATURE");
            this.chartMultiPurpose.Series["TEMPERATURE"].ChartType = SeriesChartType.Line;
            this.chartMultiPurpose.Series["TEMPERATURE"].Color = Color.Red;
            this.chartMultiPurpose.Series["TEMPERATURE"].BorderWidth = 5;
            if (series == 1)
            {
                this.chartMultiPurpose.Series["TEMPERATURE"].YAxisType = AxisType.Primary;
            }
            else if (series == 2)
            {
                this.chartMultiPurpose.Series["TEMPERATURE"].YAxisType = AxisType.Secondary;
            }
        }

        private void GenerateWheelRPM(int series)
        {
            this.chartMultiPurpose.Series.Add("WHEEL_RPM");
            this.chartMultiPurpose.Series["WHEEL_RPM"].ChartType = SeriesChartType.Line;
            this.chartMultiPurpose.Series["WHEEL_RPM"].Color = Color.BlueViolet;
            this.chartMultiPurpose.Series["WHEEL_RPM"].BorderWidth = 5;
            if (series == 1)
            {
                this.chartMultiPurpose.Series["WHEEL_RPM"].YAxisType = AxisType.Primary;
            }
            else if (series == 2)
            {
                this.chartMultiPurpose.Series["WHEEL_RPM"].YAxisType = AxisType.Secondary;
            }

        }

        private void GenerateEngineRPM(int series)
        {
            this.chartMultiPurpose.Series.Add("ENGINE_RPM");
            this.chartMultiPurpose.Series["ENGINE_RPM"].ChartType = SeriesChartType.Line;
            this.chartMultiPurpose.Series["ENGINE_RPM"].Color = Color.Orange;
            this.chartMultiPurpose.Series["ENGINE_RPM"].BorderWidth = 5;
            if (series == 1)
            {
                this.chartMultiPurpose.Series["ENGINE_RPM"].YAxisType = AxisType.Primary;
            }
            else if (series == 2)
            {
                this.chartMultiPurpose.Series["ENGINE_RPM"].YAxisType = AxisType.Secondary;
            }
        }

        private void GenerateGear(int series)
        {
            this.chartMultiPurpose.Series.Add("GEAR");
            this.chartMultiPurpose.Series["GEAR"].ChartType = SeriesChartType.Line;
            this.chartMultiPurpose.Series["GEAR"].Color = Color.Chocolate;
            this.chartMultiPurpose.Series["GEAR"].BorderWidth = 5;
            if (series == 1)
            {
                this.chartMultiPurpose.Series["GEAR"].YAxisType = AxisType.Primary;
            }
            else if (series == 2)
            {
                this.chartMultiPurpose.Series["GEAR"].YAxisType = AxisType.Secondary;
            }

        }

        private void GenerateBrake(int series)
        {
            this.chartMultiPurpose.Series.Add("BRAKE");
            this.chartMultiPurpose.Series["BRAKE"].ChartType = SeriesChartType.Area;
            this.chartMultiPurpose.Series["BRAKE"].Color = Color.FromArgb(128, 255, 0, 0);
            if (series == 1)
            {
                this.chartMultiPurpose.Series["BRAKE"].YAxisType = AxisType.Primary;
            }
            else if (series == 2)
            {
                this.chartMultiPurpose.Series["BRAKE"].YAxisType = AxisType.Secondary;
            }
        }

        private void GenerateThrottle(int series)
        {
            this.chartMultiPurpose.Series.Add("THROTTLE");
            this.chartMultiPurpose.Series["THROTTLE"].ChartType = SeriesChartType.Area;
            this.chartMultiPurpose.Series["THROTTLE"].Color = Color.FromArgb(128, 0, 255, 0);
            if (series == 1)
            {
                this.chartMultiPurpose.Series["THROTTLE"].YAxisType = AxisType.Primary;
            }
            else if (series == 2)
            {
                this.chartMultiPurpose.Series["THROTTLE"].YAxisType = AxisType.Secondary;
            }
        }

        private void ImportCarData()
        {
            string textFilePath;
            OpenFileDialog openFileTXT = new OpenFileDialog();
            DialogResult textFilePath_dialog = openFileTXT.ShowDialog();
            if (textFilePath_dialog == DialogResult.OK)
            {
                textFilePath = openFileTXT.FileName;
            }
            else
            {
                textFilePath = null;
                this.Close();
            }

            try
            {
                string[] allLines = File.ReadAllLines(textFilePath);
                String[] tempLine = new String[5];

                foreach (String x in allLines)
                {
                    tempLine = x.Split('\t');
                    CarData.Rows.Add(tempLine[0].ToString(), Convert.ToDouble(tempLine[2]), Convert.ToDouble(tempLine[4]));
                }
            }
            catch (Exception flex)
            {
                MessageBox.Show("Exception - " + flex.ToString());
            }

        }

        private void WriteToChart(List<string> DesiredSensors)
        {
            BespokeTable bespokeTable = new BespokeTable(this.CarData, DesiredSensors);

            foreach (string desiredSensor in DesiredSensors)
            {
                foreach (DataRow carDataRow in bespokeTable.BespokeData.Rows)
                {
                    if  (carDataRow["name"].Equals(desiredSensor))
                    {
                        this.chartMultiPurpose.Series[desiredSensor].Points.AddXY(Convert.ToDouble(carDataRow["timestamp"]), Convert.ToDouble(carDataRow["value"]));
                    }
                }
            }
        }

        private void buttonSaveGraph_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Png Image|*.png|Tiff Image|*.tiff|Bitmap Image|*.bmp|Gif Image|*.gif|Enhanced Metafile|*.emf";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.SupportMultiDottedExtensions = true;
            saveFileDialog1.DefaultExt = string.Empty;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int saveFileIndex = saveFileDialog1.FilterIndex;
                if (saveFileDialog1.FileName != string.Empty)
                {
                    if (this.chartMultiPurpose.Visible == true)
                    {
                        switch (saveFileIndex)
                        {
                            case 1:
                                this.chartMultiPurpose.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Jpeg);
                                break;
                            case 2:
                                this.chartMultiPurpose.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Png);
                                break;
                            case 3:
                                this.chartMultiPurpose.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Tiff);
                                break;
                            case 4:
                                this.chartMultiPurpose.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Bmp);
                                break;
                            case 5:
                                this.chartMultiPurpose.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Gif);
                                break;
                            case 6:
                                this.chartMultiPurpose.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Emf);
                                break;
                        }
                    }
                    else
                    {
                        switch (saveFileIndex)
                        {
                            case 1:
                                this.chartMultiPurpose.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Jpeg);
                                break;
                            case 2:
                                this.chartMultiPurpose.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Png);
                                break;
                            case 3:
                                this.chartMultiPurpose.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Tiff);
                                break;
                            case 4:
                                this.chartMultiPurpose.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Bmp);
                                break;
                            case 5:
                                this.chartMultiPurpose.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Gif);
                                break;
                            case 6:
                                this.chartMultiPurpose.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Emf);
                                break;
                        }
                    }

                    //an array of all the file types
                    String[] filetypes = new String[] { "jpeg", "png", "tiff", "bmp", "giff", "emf" };

                    MessageBox.Show("Your image has been saved in " + (String)filetypes[saveFileIndex - 1] + " format", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void buttonResetZoom_Click(object sender, EventArgs e)
        {
            while (this.chartMultiPurpose.ChartAreas[0].AxisX.ScaleView.IsZoomed)
                this.chartMultiPurpose.ChartAreas[0].AxisX.ScaleView.ZoomReset();
            while (this.chartMultiPurpose.ChartAreas[0].AxisY.ScaleView.IsZoomed)
                this.chartMultiPurpose.ChartAreas[0].AxisY.ScaleView.ZoomReset();
        }

        private void buttonViewAnalysis_Click(object sender, EventArgs e)
        {
            if (this.listViewAnalysisView.Visible)
            {
                this.listViewAnalysisView.Visible = false;
            }
            else
            {
                this.listViewAnalysisView.Visible = true;
            }
        }

        private void FormDCAPHome_SizeChanged(object sender, EventArgs e)
        {
            this.chartMultiPurpose.Width = this.Width;
            this.chartMultiPurpose.Height = this.Height - (this.buttonGenerate.Height * 2);
            Point chartLocation = new Point(0, this.buttonSaveGraph.Height);
            this.chartMultiPurpose.Location = chartLocation;

            Point listLocation = new Point(this.Width/2 - this.listViewAnalysisView.Width/2, this.Height/2 - this.listViewAnalysisView.Height/2 - this.buttonSaveGraph.Height);

            this.listViewAnalysisView.Location = listLocation;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            for (int series = 0; series < this.chartMultiPurpose.Series.Count(); series++)
            {
                this.chartMultiPurpose.Series.RemoveAt(0);
            }
        }
    }
}
