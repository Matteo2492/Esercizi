using GestioneImpiegati.Models;
using GestioneImpiegati.Repo;

namespace GestioneImpiegati.Services
{
    public class ImpiegatoService
    {
        private readonly ImpiegatoRepo _repository;

        public ImpiegatoService(ImpiegatoRepo repo)
        {
            _repository = repo;
        }
        public Impiegato? ImpiegatiMatriolca(string matricola)
        {
            Impiegato? tmp = _repository.GetByMatricola(matricola);
            if(tmp!=null)
            {
                return tmp;
            }
            return tmp;
        }
        public List<Impiegato> ElencoImpiegati()
        {
            return _repository.GetAll();
        }

        public bool InserisciImpiegato(Impiegato pro)
        {
            return _repository.Insert(pro);
        }

        public bool EliminaImpiegatoperID(int varID)
        {
            Impiegato? temp = _repository.GetById(varID);
            if (temp == null)
                return false;

            return _repository.Delete(temp.ImpiegatoId);
        }

        public bool ModificaImpiegato(Impiegato vecchio, Impiegato nuovo)
        {
            vecchio.Nome = nuovo.Nome;
            vecchio.Cognome = nuovo.Cognome;
            vecchio.DataNasc = nuovo.DataNasc;
            vecchio.Ruolo = nuovo.Ruolo;
            vecchio.Indirizzo = nuovo.Indirizzo;
            vecchio.RepartoRif = nuovo.RepartoRif;
            vecchio.CittaRif = nuovo.CittaRif;
            vecchio.ProvinciaRif = nuovo.ProvinciaRif;

            return _repository.Update(vecchio);
        }
    }
}
