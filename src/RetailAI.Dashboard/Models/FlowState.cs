namespace RetailAI.Dashboard.Models
{
    public class FlowState
    {
        public int CurrentStep { get; set; }

        public string OllamaJson { get; set; } = "";

        public string InventoryJson { get; set; } = "";

        public string ShippingJson { get; set; } = "";

        public string RecommendationJson { get; set; } = "";
    }
}
