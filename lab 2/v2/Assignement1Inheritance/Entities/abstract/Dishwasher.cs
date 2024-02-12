using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignement1Inheritance.Entities.@abstract
{
    internal class Dishwasher : Appliance
    {
        public const string SoundRatingQuietest = "Qt";
        public const string SoundRatingQuiet = "Qu";
        public const string SoundRatingQuieter = "Qr";
        public const string SoundRatingModerate = "M";

        private string _feature;
        private string _soundRating;

        public string Feature
        {
            get { return _feature; }
            set { _feature = value; }
        }
        public string SoundRating
        {
            get { return _soundRating; }
            set { _soundRating = value; }
        }

        public string SoundRatingDisplay
        {
            get
            {
                switch (_soundRating)
                {
                    case SoundRatingQuietest:
                        return "Quietest";
                    case SoundRatingQuiet:
                        return "Quiet";
                    case SoundRatingQuieter:
                        return "Quieter";
                    case SoundRatingModerate:
                        return "Moderate";
                    default:
                        return "Unknown";
                }
            }
        }

        public Dishwasher(long itemNumber, string brand, string color, decimal price, int quantity, decimal wattage, string feature, string soundRating) : base(brand, color, itemNumber, price, quantity, wattage)
        {
            _feature = feature;
            _soundRating = soundRating;
        }


        public override string FormatForFile()
        {
            string commonFormatted = base.FormatForFile();
            string formatted = string.Join(";", commonFormatted, Feature, SoundRating);

            return formatted;
        }

        public override string ToString()
        {
            string display =
                string.Format("Item Number: {0}", ItemNumber) + "\n" +
                string.Format("Brand: {0}", Brand) + "\n" +
                string.Format("Color: {0}", Color) + "\n" +
                string.Format("Price: {0}", Price) + "\n" +
                string.Format("Quantity: {0}", Quantity) + "\n" +
                string.Format("Wattage: {0}", Wattage) + "\n" +
                string.Format("Feature: {0}", Feature) + "\n" +
                string.Format("Sound Rating: {0}", SoundRatingDisplay) + "\n";

            return display;
        }





    }
}
