using signalAcquirer.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
    public partial class detail : Form
    {
        MyBL BL = new MyBL();
        List<sample_data> SampleDataList;
        people _item;
        List<signals_persons> SampleList;
        int signal_type;
        Form2 vform2 = new Form2();
        int countSecond = 0;
        int itemsOfSecond = 0;
        string sample_action;
        int frequency = Convert.ToInt32(ConfigurationManager.AppSettings["frequency"]);
        int numSamples;//Convert.ToInt32(ConfigurationManager.AppSettings["frequency"]) * Convert.ToInt32(ConfigurationManager.AppSettings["secondsPsample"]);
        
        int secondsPsample = Convert.ToInt32(ConfigurationManager.AppSettings["secondsPsample"]);
        int totalSecondsRegister;
        int id_dample = 1;
        string IdTextSampleType;
        bool termina = false;
        public detail(int i)
        {
            InitializeComponent();
            _item = BL.getPeople(i);
            sampleListCharge();
            txt_name.DataBindings.Add(new Binding("Text", _item, "name"));
            txt_surnames.DataBindings.Add(new Binding("Text", _item, "surnames"));
            cbo_gender.SelectedIndex = _item.gender.HasValue ? _item.gender.Value : 0;
            txt_weight.DataBindings.Add(new Binding("Text", _item, "weight", true));
            txt_height.DataBindings.Add(new Binding("Text", _item, "height", true));
            //txt_gender.DataBindings.Add(new Binding("Text", _item, "gender"));
            if (_item.birth_date.HasValue)
                dt_birthday.Text = _item.birth_date.Value.Date.ToShortDateString();

            //**** Rellenar comboBox Signal type ****//
            cb_signal_type.DataSource = BL.getsignals_type();
            cb_signal_type.DisplayMember = "type";
            cb_signal_type.ValueMember = "Id";
        }

        private void sampleListCharge()
        {
            MyBL BLaux = new MyBL();
            SampleList = BLaux.getsignals_persons(_item.Id);
            dg_samples.DataSource = SampleList;
        }


        private void Btn_acquision_Click(object sender, EventArgs e)
        {
            sample_action = "Estabilización|"+(this.cb_signal_type.SelectedItem as signal_type).samples + "|Estabilización" ;
            signal_type = int.Parse(this.cb_signal_type.SelectedValue.ToString());
            IdTextSampleType = (this.cb_signal_type.SelectedItem as signal_type).type;
            numSamples = frequency * Convert.ToInt32(ConfigurationManager.AppSettings["secondsPsample"]) * (2 + BL.numberSignalsfromType(signal_type)); //+2 por los de estabilización
            totalSecondsRegister = Convert.ToInt32(ConfigurationManager.AppSettings["secondsPsample"]) * (2 + BL.numberSignalsfromType(signal_type));
            //15360
            SampleDataList.Clear();
            termina = false;
            serialPort1.WriteLine(IdTextSampleType);


        }

        private void bt_open_sp_Click(object sender, EventArgs e)
        {
            SelectComPort();
        }

        private void OpenComPort(string comport)
        {
            serialPort1.PortName = comport;
            try
            {
                serialPort1.Open();
                //id_dample = BL.NewSample(signal_type, _item.Id);
                //serialPort1.WriteLine(IdTextSampleType);
                //vform2.writeLabel("Prueba");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
                Close();
            }
        }

        private void SelectComPort()
        {
            SampleDataList = new List<sample_data>();
            ComSelect cs = new ComSelect();
            if (cs.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                    OpenComPort(cs.comport);
                    
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            
            CheckForIllegalCrossThreadCalls = false;
            
            int dataLength = serialPort1.BytesToRead;
            byte[] data = new byte[dataLength];
            int nbrDataRead = serialPort1.Read(data, 0, dataLength);
            if (nbrDataRead == 0)
                return;
            // add to buffer ...
            for (int i = 0; i < data.Length; i++)
                Buffer.Add(data[i]);

            // parse the buffer ...
            ParseBuffer();

            //if(!serialPort1.IsOpen)
            if(termina)
            {
                MessageBox.Show("Inicio del registro en db de los datos");
                BL.saveSampleData(signal_type, _item.Id, SampleDataList);
                MessageBox.Show("Registro guardado correctamente");
                SampleList = BL.getsignals_persons(_item.Id);
                grafico v = new grafico(BL.getDatasamplesLast(), BL.getsignal_typeString(signal_type));
                termina = false;
                v.ShowDialog();
            }
        }

        List<byte> Buffer = new List<byte>();
        
        private void ParseBuffer()
        {
            
            while (Buffer.Count > 0)
            {

                // packet header available and one packet available
                while ((Buffer.Count > 0) && (Buffer[0] != 0xa5)) Buffer.RemoveAt(0);

                if ((Buffer.Count >= 4) && (Buffer[0] == 0xa5))
                {
                    // read packet
                    byte[] pkg = new byte[4];
                    Olimexino328_packet pk = new Olimexino328_packet();

                    for (int i = 0; i < 4; i++)
                    {
                        pkg[i] = Buffer[0];
                        Buffer.RemoveAt(0);
                    }

                    if ((pkg[0] == 0xa5) && (pkg[1] == 0x5a))
                    {
                        if ((pkg[2] == 0xFF) && (pkg[3] == 0xFF))
                            termina = true;
                            //serialPort1.Close();

                        else {
                            pk.sync0 = pkg[0];
                            pk.sync1 = pkg[1];
                            pk.d1 = (UInt16)(pkg[3] + (pkg[2] << 8));

                            sample_data aux_item = new sample_data();
                            aux_item.id_sample = id_dample;
                            aux_item.A0 = pk.d1;//*U;
                            aux_item.order = SampleDataList.Count() + 1;
                            aux_item.olimex_count = pk.count;
                            //BL.saveData(aux_item);
                            SampleDataList.Add(aux_item);
                            
                            //Debug.WriteLine("-------------------");
                            //Debug.WriteLine(pk.d1);
                            //Debug.WriteLine(pkg[1]);
                            //Debug.WriteLine(pkg[2]);
                            //Debug.WriteLine(pkg[3]);
                            //Debug.WriteLine(pkg[4]);
                            //Debug.WriteLine(pkg[5]);
                            //Debug.WriteLine(pkg[6]);
                            //Debug.WriteLine((UInt16)(pkg[5] + (pkg[4] << 8)));
                            //Debug.WriteLine(SampleDataList.Count());
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Invalid packet received!");
                        MessageBox.Show("Invalid packet received!");
                    }
                }
                else
                {
                    break;
                }
            }
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            _item.birth_date = dt_birthday.Value;
            _item.gender = cbo_gender.SelectedIndex > 0 ? cbo_gender.SelectedIndex : (int?)null;
            BL.Guardar();
        }


        private void Dg_samples_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dg_samples.Rows[e.RowIndex];
            signals_persons i = (signals_persons)row.DataBoundItem;
            sample sample = BL.getSample(i.id);
            grafico v = new grafico(BL.getDatasamples(i.id), BL.getsignal_typeString(sample.signal_type));
            v.ShowDialog();
        }

        private void Bt_delete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure?", "delete signal", MessageBoxButtons.YesNo ) == DialogResult.Yes)
            {
                DataGridViewSelectedRowCollection selection = dg_samples.SelectedRows;
                //BL.deleteSample();
                List<int> ToDeleteList = new List<int>();
                foreach (DataGridViewRow row in selection)
                {
                    ToDeleteList.Add(((signals_persons)row.DataBoundItem).id);
                    //Forms.DataGridViewBand)selection.List[1]).Index
                }
                BL.deleteSample(ToDeleteList);
                sampleListCharge();
            }
        }

        private void Btn_refresh_Click(object sender, EventArgs e)
        {
            sampleListCharge();
        }

        private void bt_close_sp_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
        }

        
    }


}
