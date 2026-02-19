using MediatR;
using StoreApp.Application.CQRS.Products.Command.Request;
using StoreApp.Application.CQRS.Products.Command.Response;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
using StoreApp.Repository.Comman;

namespace StoreApp.Application.CQRS.Products.Handler.CommandHandler;

class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, ResponseModel<UpdateProductCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<UpdateProductCommandResponse>> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);
        product.Name = request.Name;
        _unitOfWork.ProductRepository.Update(product);
        await _unitOfWork.SaveChangesAsync();

        var response = new UpdateProductCommandResponse
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };

        return new ResponseModel<UpdateProductCommandResponse>(response);
    }
}