using System.ComponentModel.DataAnnotations;

public class Group {
    public long Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; }

}
    