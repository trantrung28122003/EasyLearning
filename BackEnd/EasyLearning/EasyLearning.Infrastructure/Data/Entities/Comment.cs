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
    public class Comment :GenericEntity
    {
        [Column("Comment_Content")]
        public string? ContentComment { get; set; }

        [Column("Comment_UserId")]
        public string? UserID { get; set; }

        public string? TrainingPartId { get; set; }
        [ForeignKey("TrainingPartId")]
        public TrainingPart? TrainingPart { get; set; }

        public ICollection<Reply>? Replies { get; set; }
    }
}
