using FluentValidation;
using MediatR;

namespace WarehouseManagement.Application.Common.Behaviors;
// Generic class, constraint: TRequest là IRequest<TResponse>

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    // Inject IEnumerable<IValidator<TRequest>> validators qua constructor
    // (DI sẽ tự inject tất cả validators tương ứng với TRequest)
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var validators = _validators.ToList();
        
        // Nếu không có validator nào → bỏ qua, gọi next() luôn
        if (validators.Count == 0) return await next();

        // Tạo ValidationContext<TRequest> với request hiện tại
        var context = new ValidationContext<TRequest>(request);

        // Chạy tất cả validators:
        var results = await Task.WhenAll(validators
            .Select(v => v.ValidateAsync(
                context,
                cancellationToken)));

        // Lọc ra CÁC lỗi (failures):
        var failures = results
            .SelectMany(r => r.Errors)
            .Where(f => f != null)
            .Distinct()
            .ToList();

        // Nếu có lỗi → throw ValidationException(failures)
        if (failures.Count != 0)
        {
            throw new ValidationException(failures);
        }

        // Không có lỗi → gọi next() để đi tiếp vào Handler
        return await next();
    }
}