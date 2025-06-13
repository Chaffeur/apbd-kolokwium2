using kolokwium2.DTOs;

namespace kolokwium2.Services;

public interface IAddTreeService
{
    
    public Task AddTree(TreesDTO trees);
    
}