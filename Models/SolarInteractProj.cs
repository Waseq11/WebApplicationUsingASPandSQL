using System;
using System.ComponentModel.DataAnnotations;
namespace api.Models
{
    public class SolarInteractProj
    {
        [Key]
        public int ProjectId {get; set;}
        public string ProjectTitle {get; set;}
        public int Cost {get; set;}
        public string DueDate {get;set;}
 
    }
}