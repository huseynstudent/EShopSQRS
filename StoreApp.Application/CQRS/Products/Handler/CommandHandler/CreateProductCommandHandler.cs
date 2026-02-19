using MediatR;
using StoreApp.Application.CQRS.Products.Command.Request;
using StoreApp.Application.CQRS.Products.Command.Response;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
using StoreApp.Domain.Entities;
using StoreApp.Repository.Comman;

namespace StoreApp.Application.CQRS.Products.Handler.CommandHandler;

class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, ResponseModel<CreateProductCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<CreateProductCommandResponse>> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name
        };
        await _unitOfWork.ProductRepository.AddAsync(product);
        await _unitOfWork.SaveChangesAsync();
        var response = new CreateProductCommandResponse
        {
            Id = product.Id,
            Name = product.Name,
            Price= product.Price
        };
        return new ResponseModel<CreateProductCommandResponse>(response);

    }
}
