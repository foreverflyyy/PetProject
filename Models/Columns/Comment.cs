using System.Net;


namespace Models.Columns
{
    public class Comment
    {
        public string Author { get; set; }
        public string Body { get; set; }
        public string CommentId { get; set; }
        public string CreateData { get; set; }
        public string PostId { get; set; }
    }
}