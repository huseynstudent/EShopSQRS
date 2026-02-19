using MediatR;
using StoreApp.Application.CQRS.Products.Query.Request;
using StoreApp.Application.CQRS.Products.Query.Response;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
using StoreApp.Repository.Comman;


namespace StoreApp.Application.CQRS.Products.Handler.QueryHandler;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, ResponseModel<GetProductByIdQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProductByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<GetProductByIdQueryResponse>> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);
        var response = new GetProductByIdQueryResponse
        {
            Id = product.Id,
            Name = product.Name
        };

        return new ResponseModel<GetProductByIdQueryResponse>(response);
    }
}