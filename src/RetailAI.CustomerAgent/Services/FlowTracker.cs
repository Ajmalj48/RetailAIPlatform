using RetailAI.CustomerAgent.Models;
using System.Text.Json;

namespace RetailAI.CustomerAgent.Services;

public class FlowTracker
{
    public FlowState State { get; set; } = new();

    public void Reset()
    {
        State = new FlowState();
    }

    public void SetStep(int step)
    {
        State.CurrentStep = step;
    }

    public void SetOllama(object obj)
    {
        State.OllamaJson =
            JsonSerializer.Serialize(
                obj,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });
    }

    public void SetInventory(object obj)
    {
        State.InventoryJson =
            JsonSerializer.Serialize(
                obj,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });
    }

    public void SetShipping(object obj)
    {
        State.ShippingJson =
            JsonSerializer.Serialize(
                obj,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });
    }

    public void SetRecommendation(object obj)
    {
        State.RecommendationJson =
            JsonSerializer.Serialize(
                obj,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });
    }
}