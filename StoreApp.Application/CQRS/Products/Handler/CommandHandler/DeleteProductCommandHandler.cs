using MediatR;
using StoreApp.Application.CQRS.Products.Command.Request;
using StoreApp.Application.CQRS.Products.Command.Response;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
using StoreApp.Repository.Comman;

namespace StoreApp.Application.CQRS.Products.Handler.CommandHandler;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, ResponseModel<DeleteProductCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<DeleteProductCommandResponse>> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);
        _unitOfWork.ProductRepository.Delete(request.Id);
        await _unitOfWork.SaveChangesAsync();
        var response = new DeleteProductCommandResponse
        {
            Id = product.Id,
            Name = $"Deleted {product.Name}",
            Price = product.Price
        };
        return new ResponseModel<DeleteProductCommandResponse>(response);
    }
}