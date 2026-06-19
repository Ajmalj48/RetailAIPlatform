//using RetailAI.CustomerAgent.Services;
//using RetailAI.InventoryAgent.Models;
//using RetailAI.RecommendationAgent.Models;
//using RetailAI.ShippingAgent.Models;
//using System.Text.Json;

//namespace RetailAI.CustomerAgent.Agents;

//public class CustomerAgent
//{
//    private readonly InventoryApiClient _inventory;
//    private readonly ShippingApiClient _shipping;
//    private readonly RecommendationApiClient _recommendation;
//    private readonly OllamaService _ollama;
//    private readonly FlowTracker _flow;

//    public CustomerAgent(
//        InventoryApiClient inventory,
//        ShippingApiClient shipping,
//        RecommendationApiClient recommendation,
//        OllamaService ollama,
//        FlowTracker flow)
//    {
//        _inventory = inventory;
//        _shipping = shipping;
//        _recommendation = recommendation;
//        _ollama = ollama;
//        _flow = flow;
//    }

//    public async Task<string> ProcessRequest(
//        string request)
//    {
//        _flow.Reset();

//        //
//        // Customer Agent
//        //
//        _flow.SetStep(1);

//        //
//        // Ollama
//        //
//        var info =
//            await _ollama.ExtractInformation(
//                request);

//        _flow.SetOllama(info);

//        _flow.SetStep(2);

//        await Task.Delay(1500);

//        //
//        // Inventory
//        //
//        var inventory =
//            await _inventory.CheckInventory(
//                info.Product);

//        _flow.SetInventory(inventory);

//        _flow.SetStep(3);

//        await Task.Delay(1500);

//        //
//        // Shipping
//        //
//        var shipping =
//            await _shipping.EstimateDelivery(
//                info.Region);

//        _flow.SetShipping(shipping);

//        _flow.SetStep(4);

//        await Task.Delay(1500);

//        //
//        // Recommendation
//        //
//        var recommendation =
//            await _recommendation.GetRecommendations(
//                info.Product);

//        _flow.SetRecommendation(recommendation);

//        _flow.SetStep(5);

//        await Task.Delay(1500);

//        //
//        // Completed
//        //
//        _flow.SetStep(6);

//        await Task.Delay(1500);

//        var inventoryObj =
//            JsonSerializer.Deserialize<Product>(
//        inventory);

//        var shippingObj =
//            JsonSerializer.Deserialize<ShippingRegion>(
//                shipping);

//        //var recommendations =
//        //    JsonSerializer.Deserialize<RecommendationMapping>(
//        //        recommendation);

//        var recommendations =
//            JsonSerializer.Deserialize<List<string>>(
//                recommendation);

//        return
//        $"""
//            Product Found

//            {inventoryObj!.Name}

//            Category:
//            {inventoryObj.Category}

//            Price:
//            ₹{inventoryObj.Price}

//            Available Quantity:
//            {inventoryObj.Quantity}

//            Delivery Region:
//            {shippingObj!.Region}

//            Delivery Time:
//            {shippingObj.DeliveryDays} days

//            Shipping Cost:
//            ₹{shippingObj.ShippingCost}

//            Recommended Accessories:

//            {string.Join("\n", recommendations!)}
//            """;
//    }
//}

using RetailAI.CustomerAgent.Services;
using RetailAI.InventoryAgent.Models;
using RetailAI.ShippingAgent.Models;

namespace RetailAI.CustomerAgent.Agents;

public class CustomerAgent
{
    private readonly InventoryApiClient _inventory;
    private readonly ShippingApiClient _shipping;
    private readonly RecommendationApiClient _recommendation;
    private readonly OllamaService _ollama;
    private readonly FlowTracker _flow;

    public CustomerAgent(
        InventoryApiClient inventory,
        ShippingApiClient shipping,
        RecommendationApiClient recommendation,
        OllamaService ollama,
        FlowTracker flow)
    {
        _inventory = inventory;
        _shipping = shipping;
        _recommendation = recommendation;
        _ollama = ollama;
        _flow = flow;
    }

    public async Task<string> ProcessRequest(string request)
    {
        //--------------------------------------
        // Reset Flow
        //--------------------------------------
        _flow.Reset();

        //--------------------------------------
        // Customer Agent Started
        //--------------------------------------
        _flow.SetStep(1);

        //--------------------------------------
        // Ollama
        //--------------------------------------
        var info =
            await _ollama.ExtractInformation(request);

        _flow.SetOllama(info);

        Console.WriteLine($"Product={info.Product}");
        Console.WriteLine($"Region={info.Region}");

        _flow.SetStep(2);

        await Task.Delay(1500);

        //--------------------------------------
        // Inventory Agent
        //--------------------------------------
        Product inventory =
            await _inventory.CheckInventory(
                info.Product);

        _flow.SetInventory(inventory);

        _flow.SetStep(3);

        await Task.Delay(1500);

        //--------------------------------------
        // Shipping Agent
        //--------------------------------------
        ShippingRegion shipping =
            await _shipping.EstimateDelivery(
                info.Region);

        _flow.SetShipping(shipping);

        _flow.SetStep(4);

        await Task.Delay(1500);

        //--------------------------------------
        // Recommendation Agent
        //--------------------------------------
        List<string> recommendations =
            await _recommendation.GetRecommendations(
                info.Product);

        _flow.SetRecommendation(recommendations);

        _flow.SetStep(5);

        await Task.Delay(1500);

        //--------------------------------------
        // Completed
        //--------------------------------------
        _flow.SetStep(6);

        await Task.Delay(1500);

        //--------------------------------------
        // Human Readable Response
        //--------------------------------------
        return
            $"""
            <h4>✅ Product Found</h4>

            <h5>{inventory.Name}</h5>

            <p>
            <b>Category:</b> {inventory.Category}
            </p>

            <p>
            💰 <b>Price:</b> ₹{inventory.Price:N0}
            </p>

            <p>
            📦 <b>Available Quantity:</b> {inventory.Quantity}
            </p>

            <h5>🚚 Delivery Details</h5>

            <p>
            <b>Region:</b> {shipping.Region}<br/>
            <b>Delivery Time:</b> {shipping.DeliveryDays} days<br/>
            <b>Shipping Cost:</b> ₹{shipping.ShippingCost:N0}
            </p>

            <h5>🎁 Recommended Accessories</h5>

            <ul>
            {string.Join("", recommendations.Select(x => $"<li>{x}</li>"))}
            </ul>
            """;
    }
}