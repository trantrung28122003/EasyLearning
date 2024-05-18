using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EasyLearning.Infrastructure.Data.Entities
{
    public class Answer : GenericEntity
    {
        [Column("Answer_Text")]
        public string? Text { get; set; }

        [Column("Answer_QuestionId")]
        public string? QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public ExerciseQuestion? ExerciseQuestions { get; set; }

        [Column("Answer_IsCorrect")]
        public bool? IsCorrect { get; set; }
    }
}
