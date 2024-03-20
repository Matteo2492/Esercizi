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
    internal class LibroDAL : IDal<Libro>
    {
        private static LibroDAL? istanza;

        public static LibroDAL getIstanza()
        {
            if (istanza == null)
            {
                istanza = new LibroDAL();
            }
            return istanza;
        }
        private LibroDAL()
        {

        }
        #region CREATE 
        /// <summary>
        /// Inserisce un nuovo libro nella tabella Libro
        /// </summary>
        /// <param name="t"></param>
        /// <returns>bool</returns>
        public bool Insert(Libro t)
        {
            bool risultato = false;
            using (SqlConnection con = new SqlConnection(Config.GetIstanza().GetConnectionString()))
            {
                SqlCommand sqlCommand = con.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO Libro(Titolo,Disponibilita) VALUES" +
                    "(@valTit,@valDisp)";
                sqlCommand.Parameters.AddWithValue("@valTit", t.Titolo);
                sqlCommand.Parameters.AddWithValue("@valDisp", t.Disponibilita);
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
        #endregion

        #region READ
        /// <summary>
        /// Crea una lista List<> di Utenti con relativo ID,Nome,Cognome,Email
        /// </summary>
        /// <returns>List<Utente></returns>
        public List<Libro> GetAll()
        {
            List<Libro> list = new List<Libro>();
            using (SqlConnection con = new SqlConnection(Config.GetIstanza().GetConnectionString()))
            {
                string query = "SELECT LibroID, Titolo, Disponibilita FROM Libro";
                SqlCommand cmd = new SqlCommand(query, con); // query e connessione

                try
                {
                    con.Open(); // apre canale di connessione

                    SqlDataReader reader = cmd.ExecuteReader(); //comando di lettura

                    while (reader.Read())
                    {
                        Libro libro = new Libro()
                        {
                            ID = Convert.ToInt32(reader["LibroID"]),
                            Titolo = reader["Titolo"].ToString(),
                            Disponibilita = Convert.ToBoolean(reader["Disponibilita"]) 
                        };
                        list.Add(libro);
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
                return list;
            }
        }
        #endregion


        #region UPDATE
        /// <summary>
        /// Esegue L'update di uno specifico utente in base all'ID 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Update(Libro t)
        {
            bool risultato = false;
            using (SqlConnection con = new SqlConnection(Config.GetIstanza().GetConnectionString()))
            {
                SqlCommand sqlCommand = con.CreateCommand();
                sqlCommand.CommandText = "UPDATE Libro SET Titolo = @valTit, Disponibilita = @valDis WHERE LibroID = @valID";
                sqlCommand.Parameters.AddWithValue("@valID", t.ID);
                sqlCommand.Parameters.AddWithValue("@valTit", t.Titolo);
                sqlCommand.Parameters.AddWithValue("@valDisp", t.Disponibilita);
                try
                {
                    con.Open();
                    if (sqlCommand.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("All good, Update avvenuto con successo");
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
        #endregion


        #region DELETE
        /// <summary>
        /// Elimina un utente con uno specifico ID dalla tabella Utente
        /// </summary>
        /// <param name="t"></param>
        /// <returns>bool</returns>
        public bool Delete(Libro t)
        {
            bool risultato = false;
            using (SqlConnection con = new SqlConnection(Config.GetIstanza().GetConnectionString()))
            {
                SqlCommand sqlCommand = con.CreateCommand();
                sqlCommand.CommandText = $"DELETE FROM Libro WHERE LibroID = @idVal";
                sqlCommand.Parameters.AddWithValue("@idVal", t.ID);
                try
                {
                    con.Open();
                    if (sqlCommand.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("All good, Delete avvenuta con successo");
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
        #endregion

        
    }
}
