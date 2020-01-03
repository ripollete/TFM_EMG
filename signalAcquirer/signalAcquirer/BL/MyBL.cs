using signalAcquirer.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using signalAcquirer.resources;
using System.Configuration;

namespace signalAcquirer
{
    public class MyBL
    {
        DatabaseEntities db { get; set; }


        public MyBL()
        {
            db = new DatabaseEntities();
        }

        public List<people> GetPeoples()
        {
            return db.people.ToList();
        }

        public people createPeople(people newPeople)
        {
            //people newpeople = new people();
            db.people.Add(newPeople);
            Guardar();       
            return newPeople;
        }

        public people getPeople(int i)
        {
            return db.people.Where(P => P.Id == i).FirstOrDefault();
        }

        public List<sample> getSamples(int id_person)
        {
            return db.sample.Where(S => S.id_person == id_person).ToList();
        }

        public List<sample> getSamples()
        {
            return db.sample.ToList();
        }

        public sample getSample(int id_sample)
        {
            return db.sample.Where(S => S.Id == id_sample).FirstOrDefault();
        }

        public List<signals_persons> getsignals_persons(int id_person)
        {
            List<signals_persons> aux = new List<signals_persons>();
            
            aux= db.sample.Where(S => S.id_person == id_person).Select(S=> new signals_persons {id = S.Id, signal_type= S.signal_type1.type, acquire_data = S.acquisition_date}).ToList(); //, data = S.sample_data.ToList() }).ToList();

            //foreach (signals_persons item in aux)
            //{
            //    List<double> aux_data = item.data.Select(V =>(double)V.A0.Value ).ToList();
            //        //feature_absolute_mean_value(item.data.Select(V => (double)V.A0.Value)).ToList();
            //    item.CrucesCero = feature_cross(aux_data);
            //    item.absolute_mean_value = feature_absolute_mean_value(aux_data);
            //    item.variance = feature_variance(aux_data);
            //}

            return aux;
        }


        public List<signal_type> getsignals_type()
        {
            return db.signal_type.ToList();
        }

        public int numberSignalsfromType(int Id)
        {
            string actions = db.signal_type.Where(ST => ST.Id == Id).FirstOrDefault().samples;
            return actions.Split('|').Count();
        }

        public string getsignal_typeString(int i)
        {
            return db.signal_type.Where(S => S.Id == i).FirstOrDefault().samples;
        }

        public List<double> getDatasamples(int _id)
        {
            double U = Convert.ToDouble(ConfigurationManager.AppSettings["U"]);
            return db.sample_data.Where(SD => SD.id_sample == _id).Select(SD => (double)(SD.A0.Value - 512) * U).ToList();
        }

        public List<double> getDatasamplesLast()
        {
            int last = db.sample.Max(S => S.Id);
            double U = Convert.ToDouble(ConfigurationManager.AppSettings["U"]);
            return db.sample_data.Where(SD => SD.id_sample == last).Select(SD => (double)(SD.A0.Value -512) * U ).ToList();
        }

        public int NewSample(int _signal_type, int _id_person)
        {
            try
            {
                sample newSample = new sample();

                newSample.id_person = _id_person;
                newSample.signal_type = _signal_type;
                newSample.acquisition_date = DateTime.Now;
                newSample.frequency = Convert.ToInt32(ConfigurationManager.AppSettings["frequency"]);
                newSample.unit = ConfigurationManager.AppSettings["Unit"];
                db.sample.Add(newSample);
                //db.sample_data.Add(_data[0]);

                //db.sample_data.AddRange(_data);
                //db.Entry(_data).State = EntityState.Added;

                db.SaveChanges();
                return newSample.Id;
            }
            catch (UpdateException ex)
            {
                var a = ex.InnerException.Message.Split('\r')[0].ToString();
            }
            return -1;
            
        }

        public void saveData(sample_data _data)
        {
            try
            {
                sample sample = db.sample.Where(S => S.Id == _data.id_sample).FirstOrDefault();
                sample.sample_data.Add(_data);
                db.SaveChanges();
            }
            catch (UpdateException ex)
            {
                var a = ex.InnerException.Message.Split('\r')[0].ToString();
            }
        }


        public void saveSampleData(int _signal_type, int _id_person, List<sample_data> _data)
        {

            try
            {   
                sample newSample = new sample();

                newSample.id_person = _id_person;
                newSample.signal_type = _signal_type;
                newSample.acquisition_date = DateTime.Now;
                newSample.frequency = Convert.ToInt32(ConfigurationManager.AppSettings["frequency"]);
                newSample.unit = ConfigurationManager.AppSettings["Unit"];
                foreach (sample_data item in _data)
                {
                    try
                    {
                        newSample.sample_data.Add(item);
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
                db.sample.Add(newSample);
                    //db.sample_data.Add(_data[0]);

                //db.sample_data.AddRange(_data);
                //db.Entry(_data).State = EntityState.Added;

                db.SaveChanges();
            }
            catch (UpdateException ex)
            {
                var a = ex.InnerException.Message.Split('\r')[0].ToString();
            }
        }

        public void Guardar()
        {
            try
            {
                db.SaveChanges();
            }
            catch (UpdateException ex)
            {
                var a = ex.InnerException.Message.Split('\r')[0].ToString();
            }
        }

        public int feature_cross(List<double> lista)
        {
            int result = 0;
            for (int i = 0; i < lista.Count-1; i++)
            {
                if(Math.Abs(lista[i] - lista[i + 1])>= (0.01) && ((lista[i]- lista[i+1])>=(double)0.01 && ((lista[i] > 0 && lista[i+1] < 0) || (lista[i] < 0 && lista[i + 1] > 0))))
                {
                    result++;
                }
            }
            return result;
        }

        public double feature_absolute_mean_value(List<double> lista)
        {
            double result = 0;
            for (int i = 0; i < lista.Count(); i++)
            {
                result = result + Math.Abs(lista[0]);
            }

            return result / lista.Count();
        }

        public void deleteSample(List<int> list_to_delete)
        {
            foreach (int item in list_to_delete)
            {
                sample sample_to_delete = db.sample.Where(S => S.Id == item).FirstOrDefault();
                db.sample.Remove(sample_to_delete);
            }

            db.SaveChanges();
        }

        public void deletePeople(List<int> list_to_delete)
        {
            foreach (int item in list_to_delete)
            {
                people people_to_delete = db.people.Where(S => S.Id == item).FirstOrDefault();
                db.people.Remove(people_to_delete);
            }

            db.SaveChanges();
        }

        public double feature_variance(List<double> lista)
        {
            SampleStatistics aux = new SampleStatistics();
            return aux.Variance(lista);
        }


    }
    public class signals_persons
    {
        public int id { get; set; }
        public string signal_type { get; set; }
        public DateTime acquire_data { get; set; }
        //public int CrucesCero { get; set; }

        //public double absolute_mean_value { get; set; }
        //public double variance { get; set; }

        public List<sample_data> data { get; set; }
        public signals_persons()
        {
        }       
    }
}


