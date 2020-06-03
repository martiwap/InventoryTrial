using InventoryTrial;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InventoryTrialUnitTests
{
    [TestClass]
    public class UpdateInventoryItemTests
    {
        // all the test cases below are in case scenario of "After One Day"
        int oneDay = 1;

        /* 
         * input Frozen Item 2 2 -> expected output Frozen Item 1 1       
         */
        [TestMethod]
        public void TestCase_One_AfterOneDay_FrozenItem()
        {
            InventoryItem itemInput = new InventoryItem()
            {
                Item_Type = ItemTypeEnum.FrozenItem,
                Item_SellDays = 2,
                Item_QualityValue = 2
            };

            InventoryItem itemOutputExpected = new InventoryItem()
            {
                Item_Type = ItemTypeEnum.FrozenItem,
                Item_SellDays = 1,
                Item_QualityValue = 1
            };

            InventoryItem updateItemResult = UpdateInventoryItem.Update_InventoryItem(itemInput, oneDay);

            // Assert expected values with output values
            Assert.AreEqual(itemOutputExpected.Item_QualityValue, updateItemResult.Item_QualityValue);
            Assert.AreEqual(itemOutputExpected.Item_SellDays, updateItemResult.Item_SellDays);
        }

        /* 
         * input Frozen Item -1 55 -> expected output Frozen Item -2 50      
         */
        [TestMethod]
        public void TestCase_Two_AfterOneDay_FrozenItem()
        {
            InventoryItem itemInput = new InventoryItem()
            {
                Item_Type = ItemTypeEnum.FrozenItem,
                Item_SellDays = -1,
                Item_QualityValue = 55
            };

            InventoryItem itemOutputExpected = new InventoryItem()
            {
                Item_Type = ItemTypeEnum.FrozenItem,
                Item_SellDays = -2,
                Item_QualityValue = 50
            };

            InventoryItem updateItemResult = UpdateInventoryItem.Update_InventoryItem(itemInput, oneDay);

            // Assert expected values with output values
            Assert.AreEqual(itemOutputExpected.Item_QualityValue, updateItemResult.Item_QualityValue);
            Assert.AreEqual(itemOutputExpected.Item_SellDays, updateItemResult.Item_SellDays);
        }

        /* 
         * input Aged Brie 1 1 -> expected output Aged Brie 0 2      
         */
        [TestMethod]
        public void TestCase_Three_AfterOneDay_AgedBrie()
        {
            InventoryItem itemInput = new InventoryItem()
            {
                Item_Type = ItemTypeEnum.AgedBrie,
                Item_SellDays = 1,
                Item_QualityValue = 1
            };

            InventoryItem itemOutputExpected = new InventoryItem()
            {
                Item_Type = ItemTypeEnum.AgedBrie,
                Item_SellDays = 0,
                Item_QualityValue = 2
            };

            InventoryItem updateItemResult = UpdateInventoryItem.Update_InventoryItem(itemInput, oneDay);

            // Assert expected values with output values
            Assert.AreEqual(itemOutputExpected.Item_QualityValue, updateItemResult.Item_QualityValue);
            Assert.AreEqual(itemOutputExpected.Item_SellDays, updateItemResult.Item_SellDays);
        }

        /* 
         * input Christmas Crackers -1 2 -> expected output Christmas Crackers -2 0     
         */
        [TestMethod]
        public void TestCase_Four_AfterOneDay_ChristmasCrackers()
        {
            InventoryItem itemInput = new InventoryItem()
            {
                Item_Type = ItemTypeEnum.ChristmasCrackers,
                Item_SellDays = -1,
                Item_QualityValue = 2
            };

            InventoryItem itemOutputExpected = new InventoryItem()
            {
                Item_Type = ItemTypeEnum.ChristmasCrackers,
                Item_SellDays = -2,
                Item_QualityValue = 0
            };

            InventoryItem updateItemResult = UpdateInventoryItem.Update_InventoryItem(itemInput, oneDay);

            // Assert expected values with output values
            Assert.AreEqual(itemOutputExpected.Item_QualityValue, updateItemResult.Item_QualityValue);
            Assert.AreEqual(itemOutputExpected.Item_SellDays, updateItemResult.Item_SellDays);
        }

        /* 
         * input Christmas Crackers 9 2 -> expected output Christmas Crackers 8 4   
         * NOTE : this test will fail else we are close to christmas temp !
         * which is why is it Ignored!
         */
        [Ignore]
        [TestMethod]
        public void TestCase_Five_AfterOneDay_ChristmasCrackers()
        {
            InventoryItem itemInput = new InventoryItem()
            {
                Item_Type = ItemTypeEnum.ChristmasCrackers,
                Item_SellDays = 9,
                Item_QualityValue = 2
            };

            InventoryItem itemOutputExpected = new InventoryItem()
            {
                Item_Type = ItemTypeEnum.ChristmasCrackers,
                Item_SellDays = 8,
                Item_QualityValue = 4
            };

            InventoryItem updateItemResult = UpdateInventoryItem.Update_InventoryItem(itemInput, oneDay);

            // Assert expected values with output values
            Assert.AreEqual(itemOutputExpected.Item_QualityValue, updateItemResult.Item_QualityValue);
            Assert.AreEqual(itemOutputExpected.Item_SellDays, updateItemResult.Item_SellDays);
        }

        /* 
         * input Soap 2 2 -> expected output Soap 2 2 
         */
        [TestMethod]
        public void TestCase_Six_AfterOneDay_Soap()
        {
            InventoryItem itemInput = new InventoryItem()
            {
                Item_Type = ItemTypeEnum.Soap,
                Item_SellDays = 2,
                Item_QualityValue = 2
            };

            InventoryItem itemOutputExpected = new InventoryItem()
            {
                Item_Type = ItemTypeEnum.Soap,
                Item_SellDays = 2,
                Item_QualityValue = 2
            };

            InventoryItem updateItemResult = UpdateInventoryItem.Update_InventoryItem(itemInput, oneDay);

            // Assert expected values with output values
            Assert.AreEqual(itemOutputExpected.Item_QualityValue, updateItemResult.Item_QualityValue);
            Assert.AreEqual(itemOutputExpected.Item_SellDays, updateItemResult.Item_SellDays);
        }

        /* 
         * inputFresh Item 2 2 -> expected output Fresh Item 1 0
         */
        [TestMethod]
        public void TestCase_Seven_AfterOneDay_FreshItem()
        {
            InventoryItem itemInput = new InventoryItem()
            {
                Item_Type = ItemTypeEnum.FreshItem,
                Item_SellDays = 2,
                Item_QualityValue = 2
            };

            InventoryItem itemOutputExpected = new InventoryItem()
            {
                Item_Type = ItemTypeEnum.FreshItem,
                Item_SellDays = 1,
                Item_QualityValue = 0
            };

            InventoryItem updateItemResult = UpdateInventoryItem.Update_InventoryItem(itemInput, oneDay);

            // Assert expected values with output values
            Assert.AreEqual(itemOutputExpected.Item_QualityValue, updateItemResult.Item_QualityValue);
            Assert.AreEqual(itemOutputExpected.Item_SellDays, updateItemResult.Item_SellDays);
        }

        /* 
        * inputFresh Item -1 5 -> expected output Fresh Item -2 1
        */
        [TestMethod]
        public void TestCase_Eight_AfterOneDay_FreshItem()
        {
            InventoryItem itemInput = new InventoryItem()
            {
                Item_Type = ItemTypeEnum.FreshItem,
                Item_SellDays = -1,
                Item_QualityValue = 5
            };

            InventoryItem itemOutputExpected = new InventoryItem()
            {
                Item_Type = ItemTypeEnum.FreshItem,
                Item_SellDays = -2,
                Item_QualityValue = 1
            };

            InventoryItem updateItemResult = UpdateInventoryItem.Update_InventoryItem(itemInput, oneDay);

            // Assert expected values with output values
            Assert.AreEqual(itemOutputExpected.Item_QualityValue, updateItemResult.Item_QualityValue);
            Assert.AreEqual(itemOutputExpected.Item_SellDays, updateItemResult.Item_SellDays);
        }


        /* 
        * INVALID ITEM -> expected output NO SUCH ITEM
        */
        [TestMethod]
        public void TestCase_Nine_AfterOneDay_InvalidItem()
        {
            InventoryItem itemInput = new InventoryItem()
            {
                Item_Type = ItemTypeEnum.NotValid,
                Item_SellDays = -1,
                Item_QualityValue = 5
            };

            InventoryItem itemOutputExpected = new InventoryItem()
            {
                ErrorMessage = "NO SUCH ITEM",
                ErrorOccured = true
            };

            InventoryItem updateItemResult = UpdateInventoryItem.Update_InventoryItem(itemInput, oneDay);

            // Assert expected values with output values
            Assert.AreEqual(itemOutputExpected.ErrorMessage, updateItemResult.ErrorMessage);
            Assert.AreEqual(itemOutputExpected.ErrorOccured, updateItemResult.ErrorOccured);
        }
    }
}
