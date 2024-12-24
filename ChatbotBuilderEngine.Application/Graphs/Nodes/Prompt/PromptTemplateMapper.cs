using ChatbotBuilderEngine.Domain.Graphs.Entities.Nodes.Prompt;
using Riok.Mapperly.Abstractions;

namespace ChatbotBuilderEngine.Application.Graphs.Nodes.Prompt;

[Mapper]
public static partial class PromptTemplateMapper
{
    public static PromptTemplate ToDomain(this PromptTemplateDto dto) => PromptTemplate.Create(dto.Text);

    public static partial PromptTemplateDto ToDto(this PromptTemplate domain);
}