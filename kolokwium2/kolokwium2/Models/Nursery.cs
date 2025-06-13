using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium2.Models;

[Table("Nursery")]
public class Nursery
{
    [Key]
    public int NurseryId { get; set; }
    [MaxLength(100)] public string Name { get; set; } = null!;
    public DateTime EstablishedDate { get; set; }
    
    public ICollection<Seedling_Batch> Seedling_Batches { get; set; } = null!;
}