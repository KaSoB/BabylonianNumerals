using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabylonianNumerals {
    public static class Converter {
        public static Stack<long> ConvertTo60(long value) {
            Stack<long> tmpStack = new Stack<long>();
            while (value != 0) {
                tmpStack.Push(value % 60);
                value /= 60;
            }
            return tmpStack;
        }
        public static double ConvertTo10(Stack<long> items) {
            double result = 0;
            double power = 0;
            while(items.Any())
                result += items.Pop() * Math.Pow(60, power++);
            return result;
        }
    }
}
