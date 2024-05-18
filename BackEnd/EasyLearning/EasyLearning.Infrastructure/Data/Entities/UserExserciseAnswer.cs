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
    public class UserExserciseAnswer :GenericEntity
    {
        [Column("User_Id")]
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        [Column("ExerciseQuestion_Id")]
        public string? ExerciseQuestionId { get; set; }
        [ForeignKey("ExerciseQuestionId")]
        public ExerciseQuestion? ExerciseQuestion { get; set; }

        [Column("SelectedAnswer")]
        public string? SelectedAnswer { get; set; }
        
    }
}
