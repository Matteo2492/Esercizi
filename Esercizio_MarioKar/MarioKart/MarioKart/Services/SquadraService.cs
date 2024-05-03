using MarioKart.DTO;
using MarioKart.Models;
using MarioKart.Repos;
using Microsoft.EntityFrameworkCore;

namespace MarioKart.Services
{
    public class SquadraService
    {
        private readonly SquadraRepo _repository;

        public SquadraService(SquadraRepo repository)
        {
            _repository = repository;
        }

        public IEnumerable<Squadra> PrendiliTutti()
        {
            return _repository.GetAll();
        }

        public List<SquadraDTO> RestituisciTutti()
        {
            List<SquadraDTO> elenco = this.PrendiliTutti().Select(p => new SquadraDTO()
            {
                Use = p.Username,
                Cre = p.Crediti,
                PersonaggioCinquantaRIFDTO = p.PersonaggioCinquantaRIF,
                PersonaggioCentoRIFDTO = p.PersonaggioCentoRIF,
                PersonaggioCentoCinquantaRIFDTO = p.PersonaggioCentoCinquantaRIF
            }).ToList();

            return elenco;
        }

        public bool InserisciSquadra(SquadraDTO oPro)
        {
            int numeroSquadre = _repository.GetAll().Count();
            if (numeroSquadre >= 3)
            {
                return false;
            }

            Squadra pro = new Squadra()
            {
                Username = oPro.Use,
                Crediti = oPro.Cre,
                PersonaggioCinquantaRIF = oPro.PersonaggioCinquantaRIFDTO,
                PersonaggioCentoRIF = oPro.PersonaggioCentoRIFDTO,
                PersonaggioCentoCinquantaRIF = oPro.PersonaggioCentoCinquantaRIFDTO
            };

            return _repository.Create(pro);
        }
        public bool AggiornaSquadra(SquadraDTO oPro)
        {
            Squadra? temp = _repository.GetByNome(oPro.Use);
            if (temp is not null)
            {
                Squadra pro = new Squadra()
                {
                    SquadraID = temp.SquadraID,
                    Username = oPro.Use,
                    Crediti = oPro.Cre,
                    PersonaggioCinquantaRIF = oPro.PersonaggioCinquantaRIFDTO,
                    PersonaggioCentoRIF = oPro.PersonaggioCentoRIFDTO,
                    PersonaggioCentoCinquantaRIF = oPro.PersonaggioCentoCinquantaRIFDTO
                };
                return _repository.Update(pro);
            }
            return false;
        }
        public bool EliminaSquadra(SquadraDTO oPro)
        {
            if (oPro.Use is not null)
            {
                Squadra? temp = _repository.GetByNome(oPro.Use);

                if (temp is not null)
                    return _repository.Delete(temp.SquadraID);
            }
            return false;
        }
    }
}
