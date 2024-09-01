using System.Collections.Immutable;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Item{
    string? name;
    int quantity;
    DateTime createDate ;
    public Item(string? name, int quantity, DateTime? date = null){
        Name = name;
        Quantity = quantity;
        Date = date ?? DateTime.Now;
    }
    public string? Name{set{name = value;} get{return name;}}
    public int Quantity{set{quantity = value;} get{return quantity;}}
    public DateTime Date{set{createDate = value;} get{return createDate;}}
    public void PrintItemInfo(){
        Console.WriteLine($"Item {Name} founded! Quantity: {Quantity}, Create Date: {Date} ");
    }
}

class Store{
    List<Item> warehouse = new List<Item>();
    public static int volume = 0;
    // public Store(){
    //     cart = new List<Item>();
    // }
    public void AddItem(Item itemName){
            if(warehouse.Contains(itemName)){
                Console.WriteLine($"Repeated item name");
            }else{
            warehouse.Add(itemName);
            volume++; 
            Console.WriteLine("Item added");
            }
    } 
    public void DeleteItem(Item itemName){
            if(warehouse.Contains(itemName)){  
                warehouse.Remove(itemName);
                volume--;
                Console.WriteLine("Item deleted");
            }else{
                Console.WriteLine($"No item founded");
            }
    } 
    public static void GetCurrentVolume(){
        Console.WriteLine($"Number of items in the warehouse: {volume}");
    } 
    public Item? FindItemByName(string itemName){
        var findItems = warehouse.FirstOrDefault(i => i.Name == itemName);
        return findItems;
    }
    public List<Item> SortByNameAsc(){
    //return a list    
        var storedItems = warehouse.OrderBy(i => i.Name);
        return storedItems.ToList();
    }

}

class Program{
    public static void Main(string[] args)
    {
        Store s =new Store();
        var waterBottle = new Item("Water Bottle", 10, new DateTime(2023, 1, 1));
        s.AddItem(waterBottle);
        var chocolateBar = new Item("Chocolate Bar", 15, new DateTime(2023, 2, 1));
        s.AddItem(chocolateBar);
        var notebook = new Item("Notebook", 5, new DateTime(2023, 3, 1));
        s.AddItem(notebook);
        var batteries = new Item("Batteries", 10);
        s.AddItem(batteries);
        var umbrella = new Item("Umbrella", 5);
        s.AddItem(umbrella);
        var sunscreen = new Item("Sunscreen", 8);
        s.AddItem(sunscreen);

        Store.GetCurrentVolume();
        s.DeleteItem(waterBottle);
        Store.GetCurrentVolume();
        
        Item? foundItem = s.FindItemByName(" ");
        if(foundItem != null){
            foundItem.PrintItemInfo();
        }else{
            Console.WriteLine("empty input");
        }
        s.SortByNameAsc();
    }
}