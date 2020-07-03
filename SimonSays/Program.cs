using System;
using System.Collections.Generic;

namespace SimonSays
{
    class Program
    {
        static void Main(string[] args)
        {
            // Simon Says
            // https://open.kattis.com/problems/simonsays 
            // Simple program about substring -- get the last part if string is accepted

            int myCounter = EnterCounter();

            var myAnswers = GetAllEchoes(myCounter);

            PrintList(myAnswers);
        }
        private static void PrintList(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        private static List<string> GetAllEchoes(int count)
        {
            var answers = new List<string>();
            string myOrder;
            for (int i = 0; i < count; i++)
            {
                myOrder = EnterSimonInstruction();
                if (SimonInstructionCheck(myOrder) == true)
                    answers.Add(YourEcho(myOrder));
            }
            return answers;
        }

        private static bool SimonInstructionCheck(string str)
        {
            if (str.Length < 12)
                return false;

            string flag = "Simon says";
            for (int i = 0; i < flag.Length; i++)
            {
                if (str[i] != flag[i])
                    return false;
            }
            return true;
        }
        private static int EnterCounter()
        {
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (a < 1 || a > 1000)
                    throw new ArgumentException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterCounter();
            }
            return a;
        }
        private static string YourEcho(string sound)
        {
            int sLeng = sound.Length;
            int nLeng = sLeng - 11;
            string str = "";
            try
            {
                if (sLeng < 12)
                    throw new ArgumentNullException();
                for (int i = 0; i < nLeng; i++)
                {
                    str = str + sound[i + 11].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return str;
        }
        private static string EnterSimonInstruction()
        {
            string str = "";
            try
            {
                str = Console.ReadLine();
                if (SimonInstructionConditions(str) == false)
                    throw new ArgumentException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterSimonInstruction();
            }
            return str;
        }
        private static bool SimonInstructionConditions(string str)
        {
            if (str.Length > 100)
                return false;
            else if (str[str.Length - 1] != '.')
                return false;
            else
                return true;
        }
    }
}
