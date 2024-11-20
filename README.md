# Inventory Management
## Description:
The Inventory Management System is a simple C# console application designed to manage items in a store's inventory. This project focuses on creating and managing a collection of items with features to add, remove, view, and sort them. The system enforces business rules, such as ensuring items cannot have negative quantities and preventing duplicate item names in the store.
This project is ideal for practicing Object-Oriented Programming (OOP) concepts and working with collections in C#.

 ## Features:
- Item Class
Properties:
Name (string): The name of the item.
Quantity (int): The quantity of the item.
CreatedDate (DateTime): The date the item was added (default is the current date).
Rules:
Quantity cannot be negative.

- Store Class
Properties:
A private collection of items to store inventory (e.g., List<Item>).
Methods:
AddItem: Adds a new item to the inventory.
Prevents adding items with duplicate names.
RemoveItem: Deletes an item by name.
GetCurrentVolume: Computes the total quantity of items in the inventory.
FindItemByName: Finds and returns an item by its name.
SortByNameAsc: Returns the inventory sorted by item names in ascending order.

### Future Enhancements:
Persist inventory data to a file or database.
Add more features like updating item quantity and filtering by creation date.
Create a graphical user interface for better usability.
