using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace signalAcquirer
{
    public partial class ComSelect : Form
    {
        public ComSelect()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public string comport { 
            get {
                
                    return comboBox1.Text;
            } 
        }

        private void ComSelect_Load(object sender, EventArgs e)
        {
            string[] theSerialPortNames = System.IO.Ports.SerialPort.GetPortNames();
            comboBox1.Items.AddRange(theSerialPortNames);
            comboBox1.Focus();
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }


        private void ComSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
