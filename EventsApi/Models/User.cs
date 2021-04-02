using System.ComponentModel.DataAnnotations;

public class User
{
    public long Id { get; set; }

   
    [StringLength(50)]
    public string FirstName { get; set; }
  
    [StringLength(50)]
    public string Surname { get; set; }

    [StringLength(50)]
    public string Username { get; set; }

    public int Hours { get; set; }
    public int? PartOfGroupId { get; set; }
    public int? AdminOfGroupId { get; set; }
    public int[] EventsIds { get; set; }

}