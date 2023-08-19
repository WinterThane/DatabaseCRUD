using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseCRUD.Models
{
    public class TableEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "TEXT")]
        [MaxLength(100)]
        public string? CreatedBy { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime CreatedAt { get; set; }

        [Column(TypeName = "TEXT")]
        [MaxLength(100)]
        public string? UpdatedBy { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime UpdatedAt { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Created at: {CreatedAt}, Updated at: {UpdatedAt}";
        }
    }
}
