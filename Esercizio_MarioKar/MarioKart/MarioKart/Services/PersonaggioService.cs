using MarioKart.DTO;
using MarioKart.Models;
using MarioKart.Repos;

namespace MarioKart.Services
{
    public class PersonaggioService : IService<Personaggio>
    {
        private readonly PersonaggioRepo _repository;

        public PersonaggioService(PersonaggioRepo repository)
        {
            _repository = repository;
        }

        public IEnumerable<Personaggio> PrendiliTutti()
        {
            return _repository.GetAll();
        }

        public List<PersonaggioDTO> RestituisciTutti()
        {
            List<PersonaggioDTO> elenco = this.PrendiliTutti().Select(p => new PersonaggioDTO()
            {
                Nom = p.Nome,
                Cat = p.Categoria,
                Cos = p.Costo,
                Des = p.Descrizione,
            }).ToList();

            return elenco;
        }


        public bool InserisciPersonaggio(PersonaggioDTO oPro)
        {
            Personaggio pro = new Personaggio()
            {
                Nome = oPro.Nom,
                Categoria = oPro.Cat,
                Costo = oPro.Cos,
                Descrizione = oPro.Des
            };

            return _repository.Create(pro);
        }
        public bool AggiornaPersonaggio(PersonaggioDTO oPro)
        {
            Personaggio? temp = _repository.GetByNome(oPro.Nom);
            if(temp is not null)
            {
                Personaggio pro = new Personaggio()
                {
                    PersonaggioID = temp.PersonaggioID,
                    Nome = oPro.Nom,
                    Categoria = oPro.Cat,
                    Costo = oPro.Cos,
                    Descrizione = oPro.Des
                };
                return _repository.Update(pro);
            }
            return false;
        }
        public bool EliminaPersonaggio(PersonaggioDTO oPro)
        {
            if (oPro.Nom is not null)
            {
                Personaggio? temp = _repository.GetByNome(oPro.Nom);

                if (temp is not null)
                    return _repository.Delete(temp.PersonaggioID);
            }
            return false;
        }
    }
}

