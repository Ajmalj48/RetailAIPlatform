namespace RetailAI.ShippingAgent.Models;

public class ShippingRegion
{
    public int Id { get; set; }

    public string Region { get; set; } = "";

    public int DeliveryDays { get; set; }

    public decimal ShippingCost { get; set; }
}