using ChatbotBuilderEngine.Application.Core.Shared;
using ChatbotBuilderEngine.Application.Core.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace ChatbotBuilderEngine.Persistence.Repositories.Extensions;

internal static class QuaryableExtensions
{
    public static async Task<PageResponse<T>> PageResponseAsync<T>(
        this IQueryable<T> query,
        PageParams parameters,
        CancellationToken cancellationToken)
    {
        return new PageResponse<T>
        {
            TotalCount = await query.CountAsync(cancellationToken),
            Items = await query.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync(cancellationToken)
        };
    }
}