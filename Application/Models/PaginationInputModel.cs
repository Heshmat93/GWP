namespace Application.Models
{
    public class PaginationInputModel<T>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public T Data { get; set; }
    }
}
