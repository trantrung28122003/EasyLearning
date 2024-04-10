using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EasyLearning.Infrastructure.Data.Abstraction
{
    public class GenericEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Id { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateChange { get; set; }
        public string? ChangedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
