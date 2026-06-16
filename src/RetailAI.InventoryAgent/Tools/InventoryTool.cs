using Microsoft.SemanticKernel;
using RetailAI.InventoryAgent.Services;

namespace RetailAI.InventoryAgent.Tools;

public class InventoryTool
{
    private readonly InventoryService _inventoryService;

    public InventoryTool(
        InventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    [KernelFunction]
    public async Task<string> CheckInventory(
        string product)
    {
        var item =
            await _inventoryService.FindProduct(product);

        if (item == null)
        {
            return "Product not found";
        }

        return
            $"{item.Name} is available with quantity {item.Quantity}. Price is ₹{item.Price}";
    }
}