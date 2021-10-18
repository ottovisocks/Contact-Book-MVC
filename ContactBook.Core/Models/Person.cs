using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactBook.Core.Models
{
    public class Person : Entity
    {
        [DisplayName("Person Name")]
        [Required]
        public string Name { set; get; }
        [DisplayName("Phone Number")]
        [Required]
        public string PhoneNumber { set; get; }
        [DisplayName("E-mail")]
        [Required]
        public string Email { set; get; }
        public int LocationInfoId { set; get; }
        public virtual PersonLocation LocationInfo { set; get; }
        public int CompanyInfoId { set; get; }
        public virtual Company CompanyInfo { set; get; }
        [DisplayName("Creation Date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { set; get; }
    }
}

// [Range(1, int.MaxValue, ErrorMessage = "message")]
