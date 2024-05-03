using DB_05_Biblioteca.Models;
using DB_05_Biblioteca.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_05_Biblioteca.DAL
{
    internal class PrestitoDAL : IDal<Prestito>
    {
        private static PrestitoDAL? istanza;

        public static PrestitoDAL getIstanza()
        {
            if (istanza == null)
            {
                istanza = new PrestitoDAL();
            }
            return istanza;
        }
        private PrestitoDAL()
        {

        }
        public bool Delete(Prestito t)
        {
            throw new NotImplementedException();
        }

        public List<Prestito> GetAll()
        {
            throw new NotImplementedException();
        }

        public Prestito GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Prestito t)
        {
            bool risultato = false;
            using (SqlConnection con = new SqlConnection(Config.GetIstanza().GetConnectionString()))
            {
                SqlCommand sqlCommand = con.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO Prestito(Data_prestito,Data_ritorno,LibroID,UtenteID) VALUES" +
                    "(@valDataP,@valDataR,@valLibroID,@valUtenteID)";
                sqlCommand.Parameters.AddWithValue("@valDataP", t.DataPrestito);
                sqlCommand.Parameters.AddWithValue("@valDataR", t.DataRitorno);
                sqlCommand.Parameters.AddWithValue("@valLibroID", t.LibroID);
                sqlCommand.Parameters.AddWithValue("@valUtenteID", t.UtenteID);
                try
                {
                    con.Open();
                    if (sqlCommand.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("All good, inserimento avvenuto con successo");
                        risultato = true;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                return risultato;
            }
        }

        public bool Update(Prestito t)
        {
            throw new NotImplementedException();
        }
    }
}
