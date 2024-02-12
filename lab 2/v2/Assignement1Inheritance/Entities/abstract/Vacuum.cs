namespace Assignement1Inheritance.Entities.@abstract
{
    internal class Vacuum : Appliance
    {
        //fields
        private readonly string _grade;
        private readonly short _batteryVoltage;

        //properties
        public string Grade
        {
            get { return _grade; }
        }
        public short BatteryVoltage
        {
            get { return _batteryVoltage; }
        }

        //constructor
        public Vacuum(long itemNumber, string brand, int quantity, decimal wattage, string color, decimal price, string grade, short batteryVoltage) : base(brand, color, itemNumber, price, quantity, wattage)
        {
            _grade = grade;
            _batteryVoltage = batteryVoltage;
        }

        //methods
        public override string FormatForFile()
        {
            string commonFormatted = base.FormatForFile();
            string formatted = string.Join(";", commonFormatted, Grade, BatteryVoltage);

            return formatted;
        }

        public override string ToString()
        {
            string display =
                string.Format("Item Number: {0}", ItemNumber) + "\n" +
                string.Format("Brand: {0}", Brand) + "\n" +
                string.Format("Quantity: {0}", Quantity) + "\n" +
                string.Format("Wattage: {0}", Wattage) + "\n" +
                string.Format("Color: {0}", Color) + "\n" +
                string.Format("Price: {0}", Price) + "\n" +
                string.Format("Grade: {0}", Grade) + "\n" +
                string.Format("Battery Voltage: {0}", BatteryVoltage);

            return display;
        }
    }
}

