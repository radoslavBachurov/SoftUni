using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.ValidatorAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

        private int MinValue { get; set; }
        private int MaxValue { get; set; }

        public override bool IsValid(object obj)
        {
            if (obj is int number)
            {
                if (number >= this.MinValue && number <= this.MaxValue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new AggregateException("Input is not valid integer");
            }
        }
    }
}
