using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactBook.Core.Models
{
    public class Company : Entity
    {
        public int PersonId { get; set; }
        [Required]
        public string Title { set; get; }
        [Required]
        public string Position { set; get; }
        [Required]
        public string PhoneNumber { set; get; }
        [Required]
        public string Street { set; get; }
        [Required]
        public string City { set; get; }
        [Required]
        public string Country { set; get; }
        [DisplayName("Creation Date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { set; get; }
    }
}