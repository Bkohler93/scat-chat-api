namespace scat_chat_api.Services.ScatService
{
    public interface IScatService
    {
        Task<ServiceResponse<List<GetScatDto>>> GetAllScats();
        Task<ServiceResponse<GetScatDto>> GetScatById(int id);
        Task<ServiceResponse<List<GetScatDto>>> AddScat(AddScatDto newScat);
        Task<ServiceResponse<GetScatDto>> UpdateScat(UpdateScatDto updateScat);
        Task<ServiceResponse<List<GetScatDto>>> DeleteScat(int id);
    }
}