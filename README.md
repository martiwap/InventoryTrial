# InventoryTrial
Console application developed in TDD (first) to update quality of goods in stock

Welcome to InventoryTrial!

This is a small console application developed in c# using a TDD approach, with the function of helping you updating the quality state of certain goods.

##
This console application has been developed in a total of 4 hours. It has been the first time that I have developed something following the TDD approach and I found it quite pleasant. 
I do believe that the code could have been written in a better way, so please share any uncaught exception or missed case scenario that have not been kept into consideration.
##

- RULES

You need to know that the application has been written following the following rules: 

(1) All items have a SellIn value which denotes the number of days we have to sell the item;
(2) All items have a Quality value which denotes how valuable the item is;
(3) At the end of each day our system lowers both values for every item;
(4) Once the sell by date has passed, Quality degrades twice as fast;
(5) The Quality of an item is never negative;
(6) The Quality of an item is never more than 50;
(7) "Aged Brie" actually increases in Quality the older it gets;
(8) “Frozen Item” decreases in Quality by 1;
(9) "Soap" never has to be sold or decreases in Quality;
(10) "Christmas Crackers", like “Aged Brie”, increases in Quality as its SellIn value approaches; Its
quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less
but quality drops to 0 after Christmas ;
(11) "Fresh Item" degrade in Quality twice as fast as “Frozen Item”;

- TEST CASES

And using the following test cases (after one day):

Test Input  --> Expected Output 

Aged Brie 1 1 --> Aged Brie 0 2 ;
Christmas Crackers -1 2 --> Christmas Crackers -2 0 ;
Christmas Crackers 9 2 --> Christmas Crackers 8 4 (*) ;
Soap 2 2 --> Soap 2 2 ;
Frozen Item -1 55 --> Frozen Item -2 50 ;
Frozen Item 2 2 --> Frozen Item 1 1 ;
INVALID ITEM 2 2 --> NO SUCH ITEM ;
Fresh Item 2 2 --> Fresh Item 1 0 ;
Fresh Item -1 5 --> Fresh Item -2 1 ;


- HOW TO RUN

Please download and install Visual Studio (or a different IDE that will allow you ro RUN the solution and the tests).
- BUILD
- Clone or download this repository on your machine.
- Open the sln/repository with your IDE (VisualStudio recommended)
- Once in the editor, in the SolutionExplorer you should be able to see that this solution is made out of two project: InventoryTrial and InventoryTrialTests.
- In the SolutionExplorer right click on the solution name " Solution 'InventoryTrial' (2 projects) " and press "Build Solution" to build.
- You might have to downlowad again the packages not found, like MSTesting.
- TESTS
- Once the Build is succeeded, you can run all the tests available in the second project by going on the voice menu "Test" (on the top bar usually) -> "Run" -> "All Tests"
- You can see from the code that all the tests cases have the scenarion of updating everyitem after "one day".
- CONSOLE
- You can use the console application by pressing "Start" or "Run" depending on the IDE in use. This will open a console terminal where you can update the quality of certain items (like the ones above). 
You can do this for one item at the time. There is a method that allows you to update a list of items but it has not been implemented in the console program. 
- Follow the instruction and see your updated item's quality.

Notes: 
(*) The unitTests for this scenario has been ignored on purpose. This tests will fail in the assertion because we are not close to the Christmas season. Christmas temp is considered from 2nd October up to 25th December, hence we assume that any Christmas Crackers available in stock has dropped to 0 in its quality value. The tests values your current date (like today).

If it is required to used the console application for further items, the enum class containing the ItemTypes needs to be modified.


