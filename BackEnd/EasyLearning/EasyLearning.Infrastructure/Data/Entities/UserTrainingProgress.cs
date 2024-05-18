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
    public class UserTrainingProgress : GenericEntity
    {
        [Column("User_Id")]
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        [Column("Training_Part_Id")]
        public string? TrainingPartId { get; set; }
        [ForeignKey("TrainingPartId")]
        public TrainingPart? TrainingPart { get; set; }

        [Column("Percentage_Watched")]
        public double? PercentageWatched { get; set; }


        [Column("Correct_Answers")]
        public int? CorrectAnswersCount { get; set; }

        [Column("IsCompleted")]
        public bool IsCompleted { get; set; }
    }
}
