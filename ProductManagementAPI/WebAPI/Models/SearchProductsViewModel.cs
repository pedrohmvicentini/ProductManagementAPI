namespace WebAPI.Models
{
    public class SearchProductsViewModel
    {
        public int Id { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set;} = 0;
    }
}
