namespace ChatbotBuilderEngine.Application.Core.Shared;

/// <summary>
/// The parameters for paginating a list of items.
/// </summary>
/// <param name="PageNumber">The current page number to retrieve. A positive integer.</param>
/// <param name="PageSize">The number of items to include on each page of results. A positive integer.</param>
public sealed record PageParams(int PageNumber, int PageSize);