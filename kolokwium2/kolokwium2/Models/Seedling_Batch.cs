using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium2.Models;

[Table("Seedling_Batch")]
public class Seedling_Batch
{
    [Key]
    public int BatchId { get; set; }
    public int NurseryId { get; set; }
    public int SpeciesId { get; set; }
    public int Quantity { get; set; }
    public DateTime SownDate { get; set; }
    public DateTime? ReadyDate { get; set; }
    
    public Nursery Nursery { get; set; }
    public Tree_Species Species { get; set; }
    public ICollection<Responsible> Responsibles { get; set; } = null!;
}