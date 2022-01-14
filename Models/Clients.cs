using System.ComponentModel.DataAnnotations;

namespace api.Models

{
    public class Clients
    {
        [Key]
        public int ClientId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string City {get; set;}
        public int PhoneNum {get; set;}

    }
}