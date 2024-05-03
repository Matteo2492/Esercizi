using EsercizioEventi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercizioEventi.DAL
{
    internal static class Csv
    {
        public static void CsvWrite(Object item)
        {
            string pathPartecipanti = "C:\\Users\\BS000000000\\Desktop\\Partecipanti\\partecipanti.csv";
            string pathRisorse = "C:\\Users\\BS000000000\\Desktop\\Partecipanti\\partecipanti.csv";
            string pathEventi = "C:\\Users\\BS000000000\\Desktop\\Partecipanti\\partecipanti.csv";

            if(item.GetType() == typeof(Partecipanti)){
                Partecipanti tt = (Partecipanti)item;
                try
                {
                    using (StreamWriter sw = new StreamWriter(pathPartecipanti))
                    {
                        sw.WriteLine(tt.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        
    }
}
