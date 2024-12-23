using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderEngine.Application.Graphs.Enums;

public sealed record EnumDto(
    InfoMeta Info,
    IReadOnlyList<OptionData> Options);