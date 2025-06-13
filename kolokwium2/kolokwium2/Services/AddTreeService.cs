using kolokwium2.Data;
using kolokwium2.DTOs;
using kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium2.Services;

public class AddTreeService : IAddTreeService
{
    
    private readonly DatabaseContext _context;

    public AddTreeService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task AddTree(TreesDTO trees)
    {

        var speciesExsists = await _context.Tree_Species.FirstOrDefaultAsync(e => e.LatinName.Equals(trees.species));

        if (speciesExsists == null)
        {
            throw new Exception("Species not found");
        }
        
        var nurseryExsists = await _context.Nurseries.FirstOrDefaultAsync(e => e.Name.Equals(trees.nursery));

        if (nurseryExsists == null)
        {
            throw new Exception("Nursery not found");
        }

        foreach (var res in trees.responsibles)
        {
            var emp = await _context.Responsibles.FindAsync(res.employeeId);
            if(emp == null)
                throw new ArgumentException("Racer not found");
            
        }

        await _context.AddAsync(new Nursery
        {
            EstablishedDate = DateTime.Now,
            Name = trees.nursery,
        });
        
        await _context.SaveChangesAsync();

        await _context.AddAsync(new Seedling_Batch
        {
            Quantity = trees.quantity,
            SownDate = DateTime.Now
        });
        
        await _context.SaveChangesAsync();

        await _context.AddAsync(new Tree_Species
        {
            LatinName = trees.species,
            GrowthTimeInYears = 10
        });
        
        await _context.SaveChangesAsync();
        
    }
}