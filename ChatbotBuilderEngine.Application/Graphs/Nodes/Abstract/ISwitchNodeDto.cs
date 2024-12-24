namespace ChatbotBuilderEngine.Application.Graphs.Nodes.Abstract;

public interface ISwitchNodeDto
{
    IEnumerable<int> GetFlowLinkIds();
}