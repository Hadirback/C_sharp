/*
dog dgo -> true 
dog dfo -> false
doog ddog -> false
 */


using System;
using System.Collections.Generic;

namespace ObjectManinulationTest
{
    public class Test
    {

        public bool Run(string inpStr1, string inpStr2)
        {
            try
            {
                var d1 = GetDict(inpStr1);
                var d2 = GetDict(inpStr2);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        public Dictionary<char, Int32> GetDict(string inpStr)
        {
            Dictionary<char, Int32> result = new Dictionary<char, int>();

            for (int i = 0; i < inpStr.Length; i++)
            {
                if (!result.ContainsKey(inpStr[i]))
                    result.Add(inpStr[i], 1);
                else
                    result[inpStr[i]] += 1;
            }

            return result;
        }

    }
}