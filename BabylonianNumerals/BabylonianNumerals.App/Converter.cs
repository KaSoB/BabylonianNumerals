using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabylonianNumerals {
    public static class Converter {
        /// <summary>
        /// Order: Most significant value on top
        /// </summary>
        public static Stack<long> Convert10To60(long value) {
            Stack<long> tmpStack = new Stack<long>();
            if(value == 0) {
                tmpStack.Push(0);
            } else {
                while (value != 0) {
                    tmpStack.Push(value % 60);
                    value /= 60;
                }
            }
            return tmpStack;
        }
        /// <summary>
        /// <param name="items">Order: Least significant value on top</param>
        /// </summary>
        public static double Convert60To10(Stack<long> items) {
            double result = 0;
            double power = 0;
            while(items.Any())
                result += items.Pop() * Math.Pow(60, power++);
            return result;
        }
    }
}
