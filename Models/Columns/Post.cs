
namespace Models.Columns
{
    public class Post
    {
        public string Body { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public DateTime CreatedData { get; set; }
        public string Header { get; set; }
        public string PostId { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}