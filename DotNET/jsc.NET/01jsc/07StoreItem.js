class StoreItem
{
    var ItemNumber : long;
    var ItemName   : String;
    var UnitPrice  : double; 
}

var anItem : StoreItem[] = new StoreItem[2];

anItem[0] = new StoreItem();
anItem[0].ItemNumber = 79576;
anItem[0].ItemName   = "Women Skirt";
anItem[0].UnitPrice  = 34.55;

anItem[1] = new StoreItem();
anItem[1].ItemNumber = 305417;
anItem[1].ItemName   = "60\" Gold Chain";
anItem[1].UnitPrice  = 224.95;

print("Store Inventory");
print("Item # " + anItem[0].ItemNumber);
print("Name:  " + anItem[0].ItemName);
print("Price: $" + anItem[0].UnitPrice);
print();
print("Item # " + anItem[1].ItemNumber);
print("Name:  " + anItem[1].ItemName);
print("Price: $" + anItem[1].UnitPrice);