namespace SupplySyncBackend.Dtos.Inventory
{
    public class ReorderDto
    {
        public int ProductId { get; set; }
        public int ReorderQuantity { get; set; }
    }
}
