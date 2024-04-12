using EasyLearning.Infrastructure.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Infrastructure.Data.Entities
{
    public class AddOn : GenericEntity
    {
        [Column("Add_On_Name")]
        public string? AddOnName { get; set; }

        public Guid CoursesId { get; set; }
        [ForeignKey("CoureseId")]
        public Course? Course { get; set; }

    }
}
