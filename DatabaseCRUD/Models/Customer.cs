using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseCRUD.Models
{
    public class Customer : TableEntityBase
    {
        [Column(TypeName = "TEXT")]
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [Column(TypeName = "TEXT")]
        [MaxLength(100)]
        public string? LastName { get; set; }
    }
}
