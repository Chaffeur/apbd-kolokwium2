using kolokwium2.Data;
using kolokwium2.DTOs;
using Microsoft.EntityFrameworkCore;

namespace kolokwium2.Services;

public class NurseService : INurseService
{
    
    private readonly DatabaseContext _context;

    public NurseService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<NurseriesDTO?> GetNurseries(int id)
    {

        return await _context.Nurseries.Where(e => e.NurseryId == id).Select(n => new NurseriesDTO
        {
            nurseryId = n.NurseryId,
            name = n.Name,
            establishedDate = n.EstablishedDate,
            batches = n.Seedling_Batches.Select(b => new batchesDTO
            {
                batchId = b.BatchId,
                quantity = b.Quantity,
                sownDate = b.SownDate,
                readyDate = (DateTime)b.ReadyDate,
                species = new speciesDTO
                {
                    latinName = b.Species.LatinName,
                    growthTimeInYears = b.Species.GrowthTimeInYears
                },
                responsibles = b.Responsibles.Select(r => new responsibleDTO
                {
                    firstName = r.EmployeeNav.FirstName,
                    lastName = r.EmployeeNav.LastName,
                    role = r.Role
                }).ToList()
            }).ToList()
        }).FirstOrDefaultAsync();



    }
}