
namespace EN.Shared
{
    public class CustomerPaginateResult
    {
        public IEnumerable<Customer> Data { get; set; }
        public int TotalCount { get; set; }
    }
}