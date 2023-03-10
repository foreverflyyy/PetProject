

namespace Models.Columns
{
    public class Page<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<T> Records { get; set; }
        public int TotalPages { get; set; }
        public string PostId { get; set; }
        public T Additional { get; set; }
    }
}
