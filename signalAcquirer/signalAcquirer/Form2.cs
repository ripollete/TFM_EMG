using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace signalAcquirer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Graphics g;
            //panel1.Controls.Add(g.FillEllipse(new SolidBrush(Color.Red), 10, 5, 30, 30));
        }

        public void writeLabel(int elements,int frequency,string action,int totalseconds)
        {
            int seconds =  (elements / frequency);
            string[] actions = action.Split('|');
            this.lb_prueba.Text = (seconds+1).ToString();
            int secondsForAction = totalseconds / actions.Length;
            if (secondsForAction == 0)
                secondsForAction = 1;
            int posaction = (seconds) / secondsForAction;
            this.lb_action.Text = actions[posaction];
        }
    }


}
