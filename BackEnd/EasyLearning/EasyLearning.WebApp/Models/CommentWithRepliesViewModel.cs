namespace EasyLearning.WebApp.Models
{
    public class CommentWithRepliesViewModel
    {
        public string? CommentId { get; set; }
        public string? Content { get; set; }
        public string? UserId { get; set; }
        public DateTime? DateCreate { get; set; }
        public List<ReplyViewModel>? Replies { get; set; }
    }
    public class ReplyViewModel
    {
        public string? ReplyId { get; set; }
        public string? Content { get; set; }
        public string? UserId { get; set; }
        public DateTime? DateCreate { get; set; }
    }
}
