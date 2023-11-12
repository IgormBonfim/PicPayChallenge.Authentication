namespace PicPayChallenge.Common.Requests
{
    public class PaginationRequest
    {
        public int ItemsPerPage { get; set; } = 20;
        public int Page { get; set; } = 1;
    }
}
