using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection;
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
        Console.WriteLine($"Item {Name?.ToUpper()} founded! Quantity: {Quantity}, Create Date: {Date} ");
    }
    public void PrintItemInfoSorted(){
        Console.WriteLine($"Name: {Name}, Quantity: {Quantity}, Create Date: {Date} ");
    }
}
public enum SortType{ 
    asc,
    desc
}
class Store{
    List<Item> warehouse = new List<Item>();
    // public int volume = 0;
    public int maximumCapacity;
    public Store(int maximumCapacity){
        this.maximumCapacity = maximumCapacity;
    }
    public int MaximumCapacity{
        set{ maximumCapacity = value; } 
        get{ return maximumCapacity; }
        }
    public void AddItem(Item itemName){
        if(FindItemByName(itemName.Name) != null){
            Console.WriteLine($""); 
            throw new Exception("Repeated item name");
        }else if(maximumCapacity < warehouse.Count){
            Console.WriteLine($""); 
            throw new ArgumentException("Capacity is full");
        }else{
            warehouse.Add(itemName);
            // volume++; 
            Console.WriteLine("Item added.");
        }
    } 
    public void DeleteItem(Item itemName){
        if(FindItemByName(itemName.Name) != null){  
            warehouse.Remove(itemName);
            Console.WriteLine($"{itemName.Name} deleted");
            // volume--;
        }else{
            throw new Exception("No item founded");
        }
    } 
    public void GetCurrentVolume(){
        Console.WriteLine($"Total quantity of items in the warehouse: {warehouse.Sum(i=> i.Quantity)}");
    } 
    public Item? FindItemByName(string itemName){
        return warehouse.FirstOrDefault(item => item.Name == itemName);       
    }
    public List<Item> SortByNameAsc(){   
        return warehouse.OrderBy(i => i.Name).ToList();    
    }
    public List<Item> SortByDate(SortType type){
        if(type == SortType.asc){
        return [.. warehouse.OrderBy(i => i.Date)];           
        }else{
        return warehouse.OrderByDescending(i => i.Date).ToList();      
        }
    }
    public void GroupByDate(){
        var dateForLastThreeMonths =  DateTime.Now.AddMonths(-3);
        var dateList = warehouse.GroupBy(i => i.Date >= dateForLastThreeMonths);
        Console.WriteLine("Old Items:");
        foreach (var item in dateList){
            if (item.Key){
             Console.WriteLine($"New Arrival:");
            }
        foreach (var i in item){
            Console.WriteLine($" - {i.Name}, Created: {i.Date.ToShortDateString()}");
        }}
    }

class Program{
    public static void Main(string[] args)
    {
        try{
            Store s =new Store(4);        
        
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
        
        s.DeleteItem(waterBottle);

        s.GetCurrentVolume();

        Item? foundItem = s.FindItemByName("Sunscreen");
        if(foundItem != null){
            foundItem.PrintItemInfo();
        }else{
            throw new Exception($"The {foundItem} item not in the list");
        }

        var sortedItems = s.SortByNameAsc();
        Console.WriteLine("Sorted Items:");
        sortedItems.ForEach(i => i.PrintItemInfoSorted());

        var sorteDate = s.SortByDate(SortType.asc);
        Console.WriteLine("Sorted Items By Date:");
        sorteDate.ForEach(i => i.PrintItemInfoSorted());

        s.GroupByDate();
        }catch(FormatException fe){
            Console.WriteLine($"{fe}");        
        }
 
    }
}}