using System;


namespace FileIO
{
    class Program
    {
        public static List<Item> Items = new List<Item>();
        public static string path = "./list.csv";
        static void Main(string[] args)
        {
            if(File.Exists(path))
            {
                using StreamReader file = new StreamReader(path);
                string ln;
                while((ln = file.ReadLine()) != null)
                {
                    string[] parts = ln.Split(',');
                    Items.Add(new Item(parts[0],Int32.Parse(parts[1]), Int32.Parse(parts[2])));
                }
                file.Close();
            }
            // draw menu
            while(true)
            {
                Console.Clear();
                Console.WriteLine("----------------\n1. Add New Item\n\n2. List All Items\n\n3. Show Total Cost\n\n4. Clear List\n\n5. Save List\n\n6. Exit\n\n--------------");
                var kp = Console.ReadKey().Key.ToString(); 
                switch(kp)
                {
                    case "D1":
                        Console.Clear();
                        Add();
                        continue;
                    case "D2":
                        Console.Clear();
                        List();
                        Console.ReadKey();
                        continue;
                    case "D3":
                        Console.Clear();
                        Cost();
                        Console.ReadKey();
                        continue;
                    case "D4":
                        Console.Clear();
                        Clear();
                        continue;
                    case "D5":
                        Console.Clear();
                        Save();
                        Console.WriteLine("Saved");
                        Console.ReadKey();
                        continue;
                    case "D6":
                        Console.Clear();
                        Console.WriteLine("Thanks for using the Shopping List App");
                        break;
                    default:
                        continue;
                    
                }
                break;
            }
        }
        public static void Add() 
        {
            string tempTitle;
            int tempQuantity;
            int tempUnitPrive;
            Console.WriteLine("You've selected to add an item");
            Console.Write("\n Enter the item title : ");
            tempTitle = Console.ReadLine();
            Console.Write("\n Enter the item quantity : ");
            int.TryParse(Console.ReadLine(), out tempQuantity);
            Console.Write("\n Enter the Unit Price : ");
            int.TryParse(Console.ReadLine(), out tempUnitPrive);

            Items.Add(new Item(tempTitle, tempQuantity, tempUnitPrive));
            System.Console.WriteLine(" you have added an item successfully");
        }
        public static void List() 
        {
            Console.WriteLine(" Title | Quantity | UnitPrice");
            foreach (var item in Items) 
            {
                Console.WriteLine("{0} | {1} | {2}", item.Title, item.Quantity, item.UnitPrice);
            }
        }
        public static void cost() 
        {
            int sum =0;
            foreach (var item in Items)
            {
                var tempTotalPrice = item.Quantity * item.UnitPrice;
                sum += tempTotalPrice;
            }
            Console.WriteLine("Total cost is {0}", sum);
        }
        public static void clear() 
        {
            Items = new List<Item>();
        }
        public static void Save()
        {
            StreamWriter writer = new StreamWriter(path);
            foreach (var item in Items)
            {
                writer.WriteLine("{0},{1},{2}", item.Title, item.Quantity, item.UnitPrice);
            
            }
            writer.Close();
        }
    }
    
}