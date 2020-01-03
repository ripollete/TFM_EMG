using signalAcquirer.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace signalAcquirer
{
    public partial class create : Form
    {
        MyBL BL = new MyBL();
        people _item;
        public create()
        {
            InitializeComponent();
            _item = new people();

            txt_name.DataBindings.Add(new Binding("Text", _item, "name"));
            txt_surnames.DataBindings.Add(new Binding("Text", _item, "surnames"));
            cbo_gender.SelectedIndex = _item.gender.HasValue ? _item.gender.Value : 0;
            txt_weight.DataBindings.Add(new Binding("Text", _item, "weight",true));
            txt_height.DataBindings.Add(new Binding("Text", _item, "height",true));

            //txt_gender.DataBindings.Add(new Binding("Text", _item, "gender"));
            if (_item.birth_date.HasValue)
                dt_birthday.Text = _item.birth_date.Value.Date.ToShortDateString();
            
        }


        private void Btn_create_Click(object sender, EventArgs e)
        {
            BL.createPeople(_item);
            detail v = new detail(_item.Id);
            v.Show();
            this.Close();
        }
    }


}
