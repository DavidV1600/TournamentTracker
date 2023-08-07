using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class Prize
    {
        /// <summary>
        /// Unique Identifier for the prize
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Represents the int value of the place in the competition
        /// </summary>
        public int PlaceNumber { get; set; }

        /// <summary>
        /// Represents the string value of the place in the competition
        /// </summary>
        public string PlaceName { get; set; }

        /// <summary>
        /// Represents the decimal value of the prize amount of the competition
        /// </summary>
        public decimal PrizeAmount { get; set; }

        /// <summary>
        /// Represents the percentage of the prize
        /// </summary>
        public double PrizePercentage { get; set; }

        public Prize()
        {

        }

        public Prize(string placeName, string placeNumber, string prizeAmount, string prizePercentage)
        {
            PlaceName = placeName;
            int placeNumberValue = 0;
            int.TryParse(placeNumber, out placeNumberValue);
            PlaceNumber = placeNumberValue;

            decimal prizeAmountValue = 0;
            decimal.TryParse(prizeAmount, out prizeAmountValue);
            PrizeAmount = prizeAmountValue;

            double prizePercentageValue = 0;
            double.TryParse(prizePercentage, out prizePercentageValue);
            PrizePercentage = prizePercentageValue;
        }
    }
}
