using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;


namespace ArduinoPlotter
{
    public partial class Form1 : Form
    {
        int i = 0;
        int newData = 0;
        public Form1()
        {
            InitializeComponent();

            serialPort1.PortName = "COM3";
            serialPort1.BaudRate = 9600;
            serialPort1.Open();
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerAsync();
            chart1.Series["z accel"].BorderWidth = 3;         
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                Thread.Sleep(10);
                if(serialPort1.BytesToRead > 0)
                {
                    Int32.TryParse(serialPort1.ReadLine(), out newData);
                    backgroundWorker1.ReportProgress(0, i);
                    i++;
                }
            }   
        }

        private void backgroundWorker1_ProgressChanged(
            object sender,
            ProgressChangedEventArgs e)
        {
            chart1.Series["z accel"].Points.AddXY(i, newData);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(newData.ToString());
        }
    }
}
