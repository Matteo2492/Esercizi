namespace Lez02_08_ContenitoriSemplici
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] contenitore = { 6,66,23,54,2,6 };
            //Console.WriteLine(contenitore[2]);

            //int[] numeri = new int[6];

            //Presa una stringa composta in questo modo : "Giovanni, Valeria, Marika, Mario, Valeria".
            //Trasformarla in un array evetindo le ripetizioni
            //string stringa = "Giovanni, Valeria, Marika, Mario, Valeria,";
            //string[] container = new string[5];
            //int number = stringa.IndexOf(",");
           
            //for(int i = 0; i < 5; i++)
            //{
            //    container[i] = stringa.Substring(number, (number+number));
            //}
            //Console.WriteLine(number);
            //Console.WriteLine(container[0]);

            string stringa2 = "Giovanni,Valeria,Marika,Mario,Valeria,";
            string[] myArray = stringa2.Split(",");
            myArray = myArray.Distinct().ToArray();
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine(myArray[i]);
            }
        }
    }
}
