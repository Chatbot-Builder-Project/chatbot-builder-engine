using ChatbotBuilderEngine.Application.Core.Extensions;
using ChatbotBuilderEngine.Application.Graphs.Enums;
using ChatbotBuilderEngine.Application.Graphs.Links.DataLinks;
using ChatbotBuilderEngine.Application.Graphs.Links.FlowLinks;
using ChatbotBuilderEngine.Application.Graphs.Nodes;
using ChatbotBuilderEngine.Application.Graphs.Nodes.Extensions;
using FluentValidation;

namespace ChatbotBuilderEngine.Application.Graphs;

public sealed class GraphValidator : AbstractValidator<GraphDto>
{
    public GraphValidator()
    {
        RuleFor(x => x)
            .Must(x =>
            {
                HashSet<int> identifiers = [];

                if (x.Nodes.Any(node => !identifiers.Add(node.Info.Identifier)))
                {
                    return false;
                }

                if (x.DataLinks.Any(link => !identifiers.Add(link.Info.Identifier)))
                {
                    return false;
                }

                if (x.FlowLinks.Any(link => !identifiers.Add(link.Info.Identifier)))
                {
                    return false;
                }

                if (x.Enums.Any(@enum => !identifiers.Add(@enum.Info.Identifier)))
                {
                    return false;
                }

                return true;
            });

        RuleFor(x => x.Nodes)
            .Must(nodes => nodes
                .Any(node => node.Type == NodeType.Interaction));

        RuleFor(x => x.Nodes)
            .IsUnique();

        RuleForEach(x => x.Nodes)
            .ChildRules(node => node
                .RuleFor(x => x)
                .SetValidator(x => x.GetValidator()));

        RuleFor(x => x.DataLinks)
            .IsUnique();

        RuleForEach(x => x.DataLinks)
            .ChildRules(link => link
                .RuleFor(x => x)
                .SetValidator(new DataLinkValidator()));

        RuleFor(x => x.FlowLinks)
            .IsUnique();

        RuleForEach(x => x.FlowLinks)
            .ChildRules(link => link
                .RuleFor(x => x)
                .SetValidator(new FlowLinkValidator()));

        RuleFor(x => x.Enums)
            .IsUnique();

        RuleForEach(x => x.Enums)
            .ChildRules(@enum => @enum
                .RuleFor(x => x)
                .SetValidator(new EnumValidator()));
    }
}