namespace kolokwium2.DTOs;

public class TreesDTO
{
    public int quantity { get; set; }
    public string species { get; set; } = null!;
    public string nursery { get; set; } = null!;
    public List<responsiblesDTO> responsibles { get; set; } = null!;
}

public class responsiblesDTO
{
    public int employeeId { get; set; }
    public string role { get; set; } = null!;

}