using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());

            double oneLev = 1.0;
            double twoLevs = 2.0;
            double fiftyCoins = 0.5;
            double twentyCoins = 0.2;
            double tenCoins = 0.1;
            double fiveCoins = 0.05;
            double twoCoins = 0.02;
            double oneCoin = 0.01;
            double reachedMoney = 0;
            double numberCoins = 0;



            if (change >= 2)
            {
                double numberTwoBigCoins = Math.Floor(change / 2);
                change = Math.Round(change - (numberTwoBigCoins * twoLevs),2);
                numberCoins += numberTwoBigCoins;
            }
            if (change >= 1)
            {
                double numberOneBigCoins = Math.Floor(change / 1);
                change = Math.Round(change - (numberOneBigCoins * oneLev),2);
                numberCoins += numberOneBigCoins;
            }
            if (change >= 0.5)
            {
                double numberFiveCoins = Math.Floor(change / 0.5);
                change = Math.Round(change - (numberFiveCoins* fiftyCoins) ,2);
                numberCoins += numberFiveCoins;
            }
            if (change >= 0.2)
            {
                double numberTwoCoins = Math.Floor(change / 0.2);
                change = Math.Round(change - (numberTwoCoins *twentyCoins) ,2);
                numberCoins += numberTwoCoins;
            }
            if (change >= 0.1)
            {
                double numberZeroOneCoins = Math.Floor(change / 0.1);
                change = Math.Round(change - (numberZeroOneCoins *tenCoins),2);
                numberCoins += numberZeroOneCoins;
            }
            if (change >= 0.05)
            {
                double numberZeroFiveCoins = Math.Floor(change / 0.05);
                change = Math.Round(change - (numberZeroFiveCoins *fiveCoins),2);
                numberCoins += numberZeroFiveCoins;
            }
            if (change >= 0.02)
            {
                double numberZeroTwo = Math.Floor(change / 0.02);
                change = Math.Round(change - (numberZeroTwo *twoCoins),2);
                numberCoins += numberZeroTwo;
            }
            if (change >= 0.01)
            {
                double numberZeroOne = Math.Floor(change / 0.01);
                change = Math.Round(change - (numberZeroOne *oneCoin),2);
                numberCoins += numberZeroOne;
            }

            Console.WriteLine(numberCoins);



        }
    }
}
