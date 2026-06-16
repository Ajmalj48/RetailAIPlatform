using RetailAI.Shared.Models;

namespace RetailAI.Dashboard.Services;

public class AgentStatusService
{
    public List<AgentStatus> Agents { get; set; } =
    [
        new()
        {
            AgentName="Inventory Agent",
            Status="Waiting",
            Response=""
        },

        new()
        {
            AgentName="Shipping Agent",
            Status="Waiting",
            Response=""
        },

        new()
        {
            AgentName="Recommendation Agent",
            Status="Waiting",
            Response=""
        }
    ];
}