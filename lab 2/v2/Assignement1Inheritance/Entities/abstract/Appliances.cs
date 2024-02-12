using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignement1Inheritance.Entities.@abstract
{
    public abstract class Appliance
    {
        public enum ApplianceTypes
        {
            unknown,
            Refrigerator = 1,
            Vacuum = 2,
            Microwave = 3,
            Dishwasher = 4,
        }

        private string _brand;
        private string _color;
        private long _itemNumber;
        private decimal _price;
        private int _quantity;
        private decimal _wattage;
        private bool _isAvalailable;


        public ApplianceTypes type
        {
            get { return DetermineApplianceTypeFromItemNumber(_itemNumber); }

        }



        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public long ItemNumber
        {
            get { return _itemNumber; }
            set { _itemNumber = value; }
        }
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public decimal Wattage
        {
            get { return _wattage; }
            set { _wattage = value; }
        }
        public bool IsAvalailable
        {
            get { return _isAvalailable; }
            set { _isAvalailable = value; }
        }

        public virtual string FormatForFile()
        {
            return string.Join(";", Brand, Color, ItemNumber, Price, Quantity, Wattage);
        }


        //constructor
        public Appliance(string brand, string color, long itemNumber, decimal price, int quantity, decimal wattage)
        {
            _brand = brand;
            _color = color;
            _itemNumber = itemNumber;
            _price = price;
            _quantity = quantity;
            _wattage = wattage;
        }


        public static ApplianceTypes DetermineApplianceTypeFromItemNumber(long itemNumber)
        {
            string firstDigitStr = itemNumber.ToString().Substring(0, 1);
            short firstDigit = short.Parse(firstDigitStr);

            if (firstDigit == 1)
            {
                return ApplianceTypes.Refrigerator;
            }
            else if (firstDigit == 2)
            {
                return ApplianceTypes.Vacuum;
            }
            else if (firstDigit == 3)
            {
                return ApplianceTypes.Microwave;
            }
            else if (firstDigit == 4 || firstDigit == 5)
            {
                return ApplianceTypes.Dishwasher;
            }
            else
            {
                return ApplianceTypes.unknown;
            }
        }

        public void checkout()
        { _quantity = Quantity - 1; }

    }
}