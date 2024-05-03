using GestioneRistorante.DTO;
using GestioneRistorante.Models;
using GestioneRistorante.Repo;

namespace GestioneRistorante.Services
{
    public class OrdiniService
    {
        private readonly OrdiniRepo _repo;
        private readonly PiattoService _servicePiatti;
        public OrdiniService(OrdiniRepo repo,PiattoService servP)
        {
            _repo = repo;
            _servicePiatti = servP;
        }
        public OrdiniDTO ConvertiOrdineDTO(Ordini men)
        {
            return new OrdiniDTO()
            {
                Cod = men.Codice,
                DatOrd = men.DataOrdine,
                DatOraConPre = men.DataOraConsegnaPrevista,
                PiaRif = men.PiattoRifs.Select(m => _servicePiatti.ConvertiPiattoDTO(m)).ToList()
            };
        }
    }
}
