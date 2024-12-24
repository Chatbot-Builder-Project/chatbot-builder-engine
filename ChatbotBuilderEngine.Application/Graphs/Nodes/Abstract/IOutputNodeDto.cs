namespace ChatbotBuilderEngine.Application.Graphs.Nodes.Abstract;

public interface IOutputNodeDto
{
    IEnumerable<int> GetOutputPortIds();
}