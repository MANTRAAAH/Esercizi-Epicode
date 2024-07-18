using GestioneSpedizioni.Models;

namespace GestioneSpedizioni.Services
{
    public interface ISpedizioneService
    {
        Task<List<Spedizione>> GetAllSpedizioniAsync();
        Task<Spedizione> GetSpedizioneByIdAsync(int id);
        Task<bool> CreateSpedizioneAsync(Spedizione spedizione);
        Task<bool> UpdateSpedizioneAsync(Spedizione spedizione);
        Task<bool> DeleteSpedizioneAsync(int id);
        Task<List<Aggiornamenti>> GetAggiornamentiBySpedizioneIdAsync(int spedizioneId);
        Task<Spedizione> GetSpedizioneByTrackingRequestAsync(TrackingRequest request);
        Task<List<Spedizione>> GetSpedizioniInConsegnaOggiAsync();
        Task<int> GetNumeroSpedizioniInAttesaConsegnaAsync();
        Task<List<SpedizioniPerCittaViewModel>> GetSpedizioniPerCittaDestinatariaAsync();
    }

}
