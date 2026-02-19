namespace StoreApp.Application.CQRS.Products.Query.Response;

public class GetAllProductQueryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}
