using kolokwium2.DTOs;

namespace kolokwium2.Services;

public interface INurseService
{

    public Task<NurseriesDTO?> GetNurseries(int id);

}