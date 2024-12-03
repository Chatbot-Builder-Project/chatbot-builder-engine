using ChatbotBuilderProtos.V1.Shared;
using ChatbotBuilderProtos.V1.Workflows;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace ChatbotBuilderEngine.Presentation;

public class WorkflowService : ChatbotBuilderProtos.V1.Workflows.WorkflowService.WorkflowServiceBase
{
    public override Task<ListWorkflowResult> ListWorkflows(ListWorkflowRequest request, ServerCallContext context)
    {
        return Task.FromResult(new ListWorkflowResult
        {
            Workflows = new WorkflowListResponse
            {
                Meta = new PageResponseMeta { TotalCount = 1 },
                Workflows =
                {
                    new List<WorkflowResponse>
                    {
                        new()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "Workflow 1",
                            Description = "Description 1",
                            CreatedAt = Timestamp.FromDateTime(DateTime.UtcNow),
                            UpdatedAt = Timestamp.FromDateTime(DateTime.UtcNow)
                        }
                    }
                }
            }
        });
    }

    public override Task<GetWorkflowResult> GetWorkflow(GetWorkflowRequest request, ServerCallContext context)
    {
        return Task.FromResult(new GetWorkflowResult
        {
            Workflow = new WorkflowDetailsResponse
            {
                Workflow = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Workflow 1",
                    Description = "Description 1",
                    CreatedAt = Timestamp.FromDateTime(DateTime.UtcNow),
                    UpdatedAt = Timestamp.FromDateTime(DateTime.UtcNow)
                },
                Components = new WorkflowComponents()
            }
        });
    }

    public override Task<CreateWorkflowResult> CreateWorkflow(CreateWorkflowRequest request, ServerCallContext context)
    {
        return Task.FromResult(new CreateWorkflowResult
        {
            Created = new CreatedResponse { Id = Guid.NewGuid().ToString() }
        });
    }

    public override Task<UpdateWorkflowResult> UpdateWorkflow(UpdateWorkflowRequest request, ServerCallContext context)
    {
        return Task.FromResult(new UpdateWorkflowResult { Updated = new UpdatedResponse() });
    }

    public override Task<DeleteWorkflowResult> DeleteWorkflow(DeleteWorkflowRequest request, ServerCallContext context)
    {
        return Task.FromResult(new DeleteWorkflowResult { Deleted = new DeletedResponse() });
    }
}