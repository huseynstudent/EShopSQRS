using MediatR;
using StoreApp.Application.CQRS.Products.Command.Response;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
using System.Resources;

namespace StoreApp.Application.CQRS.Products.Command.Request;

public class UpdateProductCommandRequest : IRequest<ResponseModel<UpdateProductCommandResponse>>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}
