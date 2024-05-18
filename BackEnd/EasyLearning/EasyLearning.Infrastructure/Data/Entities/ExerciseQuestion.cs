using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Infrastructure.Data.Entities
{
    public class ExerciseQuestion: GenericEntity
    {
        [Column("ExerciseQuestion_Question")]
        public string? Question { get; set; }

        [Column("ExerciseQuestion_TrainingPartId")]
        public string? TrainingPartId { get; set; }

        [ForeignKey("TrainingPartId")]
        public TrainingPart? TrainingPart { get; set; }
    
        public ICollection<Answer>? Answers { get; set; }
       
    }
}
