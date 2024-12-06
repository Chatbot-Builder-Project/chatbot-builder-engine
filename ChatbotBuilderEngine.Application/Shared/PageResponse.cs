namespace ChatbotBuilderEngine.Application.Shared;

public sealed class PageResponse<TItem>
{
    public required int TotalCount { get; set; }
    public required IReadOnlyList<TItem> Items { get; set; }
}