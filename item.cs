using System;

namespace FileIO
{
    class Item
    {
        public string Title {get; set;}
        public int Quantity {get; set;}
        public int UnitPrice {get; set;}
        public Item(string pTitle, int pQuantity, int pUnitPrice)
        {
            this.Title =pTitle;
            Quantity = pQuantity;
            UnitPrice = pUnitPrice;
        }
    }
}