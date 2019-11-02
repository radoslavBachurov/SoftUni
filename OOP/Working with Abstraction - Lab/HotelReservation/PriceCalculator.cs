using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    public static class PriceCalculator
    {
        public static decimal GetTotalPrice(string[] input)
        {
            decimal pricePerday = decimal.Parse(input[0]);
            int numberOfDays = int.Parse(input[1]);
            Season seasonPrice = Enum.Parse<Season>(input[2]);

            DiscountType discount = DiscountType.None;
            if (input.Length == 4)
            {
                discount = Enum.Parse<DiscountType>(input[3]);
            }

            decimal finalPrice = pricePerday * (int)seasonPrice*numberOfDays;
            decimal totalPrice = finalPrice - finalPrice * (decimal)discount / 100;

            return totalPrice;
        }
    }
}

