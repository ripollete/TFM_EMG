using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using signalAcquirer.model;

namespace signalAcquirer
{
    public partial class Form1 : Form
    {
        MyBL BL = new MyBL();
        double U = Convert.ToDouble(ConfigurationManager.AppSettings["U"]);
        public Form1()
        {
            InitializeComponent();
            sampleListCharge();

            //**** Rellenar comboBox Signal type ****//
            cb_signal_type.DataSource = BL.getsignals_type();
            cb_signal_type.DisplayMember = "signal";
            cb_signal_type.ValueMember = "Id";

        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            people i = (people)row.DataBoundItem;
            detail v = new detail(i.Id);
            v.ShowDialog();
        }

        private void Bt_create_Click(object sender, EventArgs e)
        {
            create v = new create();
            v.ShowDialog();
            sampleListCharge();
        }

        private void Bt_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "delete person", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataGridViewSelectedRowCollection selection = dataGridView1.SelectedRows;
                //BL.deleteSample();
                List<int> ToDeleteList = new List<int>();
                foreach (DataGridViewRow row in selection)
                {
                    ToDeleteList.Add(((people)row.DataBoundItem).Id);
                    //Forms.DataGridViewBand)selection.List[1]).Index
                }
                BL.deletePeople(ToDeleteList);
                sampleListCharge();
            }
        }

        private void sampleListCharge()
        {
            MyBL BLaux = new MyBL();
            dataGridView1.DataSource = BLaux.GetPeoples();
        }

        private void Btn_export_to_csv_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog1 = new FolderBrowserDialog();

            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;

                string csv = string.Empty;

                List<sample> samples = BL.getSamples();

                //Headers
                //csv += "sample_id;person_id;";
                //for (int i = 1; i <= 2560; i++)
                //{
                //    csv += "S" + i.ToString() + ';';
                //}
                //csv += "\r\n";

                //Add the Header row for CSV file.
                foreach (sample item in samples)
                {
                    //csv += item.Id.ToString() + ";" + item.id_person.ToString() + ";";
                    //foreach (sample_data item_sample_data in item.sample_data.OrderBy(S => S.order))
                    //{
                    //    csv += item_sample_data.A0.ToString() + ';';
                    //}
                    //csv += "\r\n";
                    string folderPerson = item.id_person.ToString().PadLeft(4, '0');
                    string folderToSaveFile = @folderName + @"\" + folderPerson + @"\";
                    string nameFile = item.signal_type1.type + "_" + folderPerson + "_" + item.Id.ToString() + "_" + ".csv";
                    csv = string.Empty;

                    if (!File.Exists(folderToSaveFile + nameFile))
                    {


                        foreach (sample_data item_sample_data in item.sample_data.OrderBy(S => S.order))
                        {
                            csv += ((double)(item_sample_data.A0.Value -512) * U).ToString();// + ';';
                            if (item_sample_data != item.sample_data.OrderBy(S => S.order).Last())
                                csv += "\r\n";
                        }

                        if (!Directory.Exists(@folderName + @"\" + folderPerson))
                        {
                            DirectoryInfo di = Directory.CreateDirectory(@folderName + @"\" + folderPerson);
                        }

                        File.WriteAllText(folderToSaveFile + nameFile, csv);
                    }
                }

                //Exporting to CSV.
                //string folderPath = @"C:\CSV\";
                //File.WriteAllText(folderPath + "DataGridViewExport.csv", csv);
            }
        }
    }
}
