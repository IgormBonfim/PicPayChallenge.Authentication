namespace PicPayChallenge.Common.Responses
{
    public class Pagination<T> where T : class
    {
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<T> Records { get; set; }
    }
}
