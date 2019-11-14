using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class SmartPhone : IBrowse, ICall
    {
        public string Browse(string webSite)
        {
            string toReturn = $"Browsing: {webSite}!";
            return toReturn;
        }

        public string Call(string number)
        {
            string toReturn = $"Calling... {number}";
            return toReturn;
        }
    }
}
