﻿using ChatbotBuilderEngine.Domain.Graphs.Abstract;
using ChatbotBuilderEngine.Domain.Graphs.Abstract.Behaviors;
using ChatbotBuilderEngine.Domain.Graphs.Entities.Ports;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Data;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Ids;
using ChatbotBuilderEngine.Domain.Graphs.ValueObjects.Meta;

namespace ChatbotBuilderEngine.Domain.Graphs.Entities.Nodes;

public sealed class StaticNode<TOutputData> : Node, IOutputNode
    where TOutputData : Data
{
    public TOutputData Data { get; } = null!;
    public OutputPort<TOutputData> OutputPort { get; } = null!;

    private StaticNode(
        NodeId id,
        DateTime createdAt,
        DateTime updatedAt,
        InfoMeta info,
        VisualMeta visual,
        TOutputData data,
        OutputPort<TOutputData> outputPort)
        : base(id, createdAt, updatedAt, info, visual)
    {
        Data = data;
        OutputPort = outputPort;
    }

    /// <inheritdoc/>
    private StaticNode()
    {
    }

    public static StaticNode<TOutputData> Create(
        NodeId id,
        DateTime createdAt,
        DateTime updatedAt,
        InfoMeta info,
        VisualMeta visual,
        TOutputData data,
        OutputPort<TOutputData> outputPort)
    {
        outputPort.EnsureNodeIdIs(id);

        return new StaticNode<TOutputData>(id, createdAt, updatedAt, info, visual, data, outputPort);
    }

    public IEnumerable<OutputPortId> GetOutputPortIds()
    {
        yield return OutputPort.Id;
    }

    public void PublishOutputs()
    {
        OutputPort.Publish(Data);
    }
}