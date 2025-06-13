using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium2.Models;

[Table("Responsible")]
public class Responsible
{
    public int BatchId { get; set; }
    public int Employee { get; set; }
    [MaxLength(100)]
    public string Role { get; set; } = null!;

    public Employee EmployeeNav { get; set; } = null!;
    public Seedling_Batch BatchNav { get; set; } = null!;
}