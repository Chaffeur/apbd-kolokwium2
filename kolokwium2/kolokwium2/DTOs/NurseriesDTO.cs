namespace kolokwium2.DTOs;

public class NurseriesDTO
{
    public int nurseryId { get; set; }
    public string name { get; set; } = null!;
    public DateTime establishedDate { get; set; }
    public List<batchesDTO> batches { get; set; } = null!;

}

public class batchesDTO
{
    public int batchId { get; set; }
    public int quantity { get; set; }
    public DateTime sownDate { get; set; }
    public DateTime readyDate { get; set; }
    public speciesDTO species { get; set; } = null!;
    public List<responsibleDTO> responsibles { get; set; } = null!;
}

public class speciesDTO
{
    public string latinName { get; set; } = null!;
    public int growthTimeInYears { get; set; }
}

public class responsibleDTO
{
    public string firstName { get; set; } = null!;
    public string lastName { get; set; } = null!;
    public string role { get; set; } = null!;
    
}