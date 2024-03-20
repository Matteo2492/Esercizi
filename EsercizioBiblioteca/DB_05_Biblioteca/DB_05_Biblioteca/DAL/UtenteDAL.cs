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
    internal class UtenteDAL : IDal<Utente>
    {
        private static UtenteDAL? istanza;

        public static UtenteDAL getIstanza()
        {
            if (istanza == null)
            {
                istanza = new UtenteDAL();
            }
            return istanza;
        }
        private UtenteDAL()
        {

        }
        
        #region CREATE 
        /// <summary>
        /// Inserisce un nuovo utente nella tabella Utente
        /// </summary>
        /// <param name="t"></param>
        /// <returns>bool</returns>
        public bool Insert(Utente t)
        {
            bool risultato = false;
            using (SqlConnection con = new SqlConnection(Config.GetIstanza().GetConnectionString()))
            {
                SqlCommand sqlCommand = con.CreateCommand();
                sqlCommand.CommandText = "INSERT INTO Utente(Nome,Cognome,Email) VALUES" +
                    "(@valNom,@valCogn,@valEmail)";
                sqlCommand.Parameters.AddWithValue("@valNom", t.Nome);
                sqlCommand.Parameters.AddWithValue("@valCogn", t.Cognome);
                sqlCommand.Parameters.AddWithValue("@valEmail", t.Email);
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
        public List<Utente> GetAll()
        {
            List<Utente> list = new List<Utente> ();
            using (SqlConnection con = new SqlConnection(Config.GetIstanza().GetConnectionString()))
            {
                string query = "SELECT UtenteID, Nome, Cognome, Email FROM Utente";
                SqlCommand cmd = new SqlCommand(query, con); // query e connessione

                try
                {
                    con.Open(); // apre canale di connessione

                    SqlDataReader reader = cmd.ExecuteReader(); //comando di lettura

                    while (reader.Read())
                    {
                        Utente utente = new Utente()
                        {
                            ID = Convert.ToInt32(reader["UtenteID"]),
                            Nome = reader["Nome"].ToString(),
                            Cognome = reader["Cognome"].ToString(),
                            Email = reader["Email"].ToString(),
                        };
                        list.Add(utente);
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
        public bool Update(Utente t)
        {
            bool risultato = false;
            using (SqlConnection con = new SqlConnection(Config.GetIstanza().GetConnectionString()))
            {
                SqlCommand sqlCommand = con.CreateCommand();
                sqlCommand.CommandText = "UPDATE Utente SET Nome = @valNom, Cognome = @valCogn, Email= @valEmail WHERE UtenteID = @valID";
                sqlCommand.Parameters.AddWithValue("@valID", t.ID);
                sqlCommand.Parameters.AddWithValue("@valNom", t.Nome);
                sqlCommand.Parameters.AddWithValue("@valCogn", t.Cognome);
                sqlCommand.Parameters.AddWithValue("@valEmail", t.Email);
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
        public bool Delete(Utente t)
        {
            bool risultato = false;
            using (SqlConnection con = new SqlConnection(Config.GetIstanza().GetConnectionString()))
            {
                SqlCommand sqlCommand = con.CreateCommand();
                sqlCommand.CommandText = $"DELETE FROM Utente WHERE UtenteID = @idVal";
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
