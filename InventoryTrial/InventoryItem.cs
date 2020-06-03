namespace InventoryTrial
{
    public class InventoryItem
    {
        public ItemTypeEnum Item_Type { get; set; }
        public int Item_SellDays { get; set; }

        public int Item_QualityValue { get; set; }

        public bool ErrorOccured { get; set; }
        public string ErrorMessage { get; set; }

    }
}
