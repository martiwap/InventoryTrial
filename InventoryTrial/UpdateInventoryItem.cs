using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryTrial
{
    public static class UpdateInventoryItem
    {
        public static InventoryItem Update_InventoryItem(InventoryItem item, int daysPast)
        {
            // validate input
            if (item == null || daysPast == 0)
                return new InventoryItem() { ErrorOccured = true };

            var result = new InventoryItem();

            // check itemInput type
            switch (item.Item_Type)
            {
                case ItemTypeEnum.AgedBrie:
                    result = UpdateAgedBrieValue(item, daysPast);
                    break;
                case ItemTypeEnum.ChristmasCrackers:
                    result = UpdateChristmasCrackersValue(item, daysPast);
                    break;
                case ItemTypeEnum.FreshItem:
                    result = UpdateFreshItemValue(item, daysPast);
                    break;
                case ItemTypeEnum.FrozenItem:
                    result = UpdateFrozenItemValue(item, daysPast);
                    break;
                case ItemTypeEnum.Soap:
                    result = item;
                    break;
                case ItemTypeEnum.NotSpecified:
                    result.ErrorOccured = true;
                    result.ErrorMessage = "Item not Specified or not Valid. Please add this item to the ItemTypes";
                    break;
                case ItemTypeEnum.NotValid:
                    result.ErrorOccured = true;
                    result.ErrorMessage = "NO SUCH ITEM";
                    break;
                default:
                    return new InventoryItem() { ErrorOccured = true };
            }

            return result;
        }

        public static List<InventoryItem> Update_All_IventoryItem(List<InventoryItem> listOfItems, int daysPast)
        {
            if (listOfItems == null || listOfItems.Count() == 0)
                return new List<InventoryItem>() { new InventoryItem() { ErrorOccured = true, ErrorMessage = "Input not valid" } };

            List<InventoryItem> resultList = new List<InventoryItem>();

            foreach (var item in listOfItems)
            {
                resultList.Add(Update_InventoryItem(item, daysPast));
            }

            return resultList;
        }


        // ---- PRIVATE METHODS

        private static InventoryItem UpdateAgedBrieValue(InventoryItem itemInput, int daysPast)
        {
            var result = new InventoryItem() { Item_Type = itemInput.Item_Type };
            var sellInDatePast = false;

            // update SellIn Value
            if (IsSellInDatePast(itemInput.Item_SellDays))
                sellInDatePast = true;
            result.Item_SellDays = itemInput.Item_SellDays - daysPast;

            // Update Quality Value
            result.Item_QualityValue = itemInput.Item_QualityValue + 1;

            result.Item_QualityValue = ValidateQualityValue(result.Item_QualityValue);

            return result;
        }

        private static InventoryItem UpdateChristmasCrackersValue(InventoryItem itemInput, int daysPast)
        {
            var result = new InventoryItem() { Item_Type = itemInput.Item_Type };
            var sellInDatePast = false;

            // update SellIn Value
            if (IsSellInDatePast(itemInput.Item_SellDays))
                sellInDatePast = true;
            result.Item_SellDays = itemInput.Item_SellDays - daysPast;

            // Update Quality Value
            if (result.Item_SellDays <= 10 && result.Item_SellDays > 5)
                result.Item_QualityValue = itemInput.Item_QualityValue + 2;
            else if (result.Item_SellDays <= 5)
                result.Item_QualityValue = itemInput.Item_QualityValue + 3;
            else
                result.Item_QualityValue = itemInput.Item_QualityValue + 1;

            // check if christmas is past recenlty
            var isXmasGone = IsChristmasGone(DateTime.Now);
            if (isXmasGone)
                result.Item_QualityValue = 0;
            else
                result.Item_QualityValue = ValidateQualityValue(result.Item_QualityValue);

            return result;
        }

        private static InventoryItem UpdateFreshItemValue(InventoryItem itemInput, int daysPast)
        {
            var result = new InventoryItem() { Item_Type = itemInput.Item_Type };
            var sellInDatePast = false;

            // update SellIn Value
            if (IsSellInDatePast(itemInput.Item_SellDays))
                sellInDatePast = true;
            result.Item_SellDays = itemInput.Item_SellDays - daysPast;

            // Update Quality Value
            if (sellInDatePast)
                result.Item_QualityValue = itemInput.Item_QualityValue - 2 * 2;
            else
                result.Item_QualityValue = itemInput.Item_QualityValue - 2;

            result.Item_QualityValue = ValidateQualityValue(result.Item_QualityValue);

            return result;
        }

        private static InventoryItem UpdateFrozenItemValue(InventoryItem itemInput, int daysPast)
        {
            var result = new InventoryItem() { Item_Type = itemInput.Item_Type };
            var sellInDatePast = false;

            // update SellIn Value
            if (IsSellInDatePast(itemInput.Item_SellDays))
                sellInDatePast = true;
            result.Item_SellDays = itemInput.Item_SellDays - daysPast;

            // Update Quality Value
            if (sellInDatePast)
                result.Item_QualityValue = itemInput.Item_QualityValue - 1 * 2;
            else
                result.Item_QualityValue = itemInput.Item_QualityValue - 1;

            result.Item_QualityValue = ValidateQualityValue(result.Item_QualityValue);

            return result;
        }

        // --- HELPER METHOD

        // check if sellin date is past
        private static bool IsSellInDatePast(int sellInDate)
        {
            if (sellInDate == 0 || sellInDate < 0)
                return true;
            else
                return false;
        }

        // validate Quality Value
        private static int ValidateQualityValue(int qualityValue)
        {
            // check Quality value is not NEGATIVE || > 50
            if (qualityValue < 0)
                qualityValue = 0;
            if (qualityValue > 50)
                qualityValue = 50;

            return qualityValue;
        }

        private static bool IsChristmasGone(DateTime date)
        {
            var currentYear = DateTime.Now.Year;
            DateTime christmasCurrentYear = new DateTime(currentYear, 12, 25);
            DateTime firstOctober = new DateTime(currentYear, 10, 1);

            if (christmasCurrentYear <= date && date <= firstOctober)
                return false;

            return true;
        }
    }
}
