using System.ComponentModel.DataAnnotations;
using System;

public class Event {
    public long Id { get; set; }
    

    [StringLength(50)]
    public string Name { get; set; }
    public string Description { get; set; }

    [StringLength(100)]
    public string ExerciseType { get; set; }
    public float Longitude { get; set; }
    public float Latitude { get; set; }
    public DateTime Time { get; set; }
    public string Intensity { get; set; }
    public long GroupId { get; set; }

}