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
    public class Reply :GenericEntity
    {
        [Column("Reply_Content")]
        public string? ContentReply { get; set; }

        [Column("Reply_UserId")]
        public string? UserID { get; set; }

        [Column("Reply_CommentId")]
        public string? CommentId { get; set; }
        [ForeignKey("CommentId")]
        public Comment? Comment { get; set; }
    }
}
