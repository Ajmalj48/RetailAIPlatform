using Microsoft.SemanticKernel;
using RetailAI.CustomerAgent.Services;

namespace RetailAI.CustomerAgent.Plugins;

public class InventoryPlugin
{
    private readonly InventoryService _inventoryService;

    public InventoryPlugin(InventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    [KernelFunction]
    public async Task<string> CheckInventory(string product)
    {
        var response = await _inventoryService.CheckStock(product);

        if (response == null)
            return "Unable to retrieve inventory information.";

        return $"{response.Product} is available with quantity {response.Quantity}.";
    }
}