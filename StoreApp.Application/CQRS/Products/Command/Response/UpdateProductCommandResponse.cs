namespace StoreApp.Application.CQRS.Products.Command.Response;

public class UpdateProductCommandResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}
