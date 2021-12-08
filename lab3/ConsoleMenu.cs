using System;
using System.Collections.Generic;
using System.Text;


namespace lab3
{
    public static class ConsoleMenu
    {
        #region service functions
        private static string RandomString(int size, bool lowerCase = false)
        {
            Random _random = new Random();
            var builder = new StringBuilder(size);

            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26;

            for (int i = 0; i < size; i++)
            {
                var addedChar = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(addedChar);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
        private static void SearchForSpecificCharacter(TheString _str, char character)
        {
            bool status;
            for (int i = 0; i < _str.GetStringValue().Length; i++)
            {
                status = default;
                foreach (var item in _str.SearchForSpecificCharacterIndex(_str.GetStringValue(), character))
                {
                    if (item == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(_str.GetStringValue()[i]);
                        Console.ResetColor();
                        status = true;
                    }
                }
                if (!status)
                {
                    Console.Write(_str.GetStringValue()[i]);
                }
            }
        }
        #endregion

        public static void StartProgram()
        {

            Serializator ser = new Serializator();
            TheString[] arr = new TheString[4];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new TheString(RandomString(5));
            }



            Console.WriteLine("Binary Serialization: ");
            Console.WriteLine("----------------------");
            ser.BinSerialisation(arr);
            TheString[] newBinArray = new TheString[arr.Length];
            var binData = ser.BinDeSerialisation(arr);

            for (int i = 0; i < newBinArray.Length; i++)
            {
                if (binData is TheString[])
                {
                    newBinArray[i] = binData[i];
                }
                Console.WriteLine(newBinArray[i].GetStringValue());
            }
            Console.WriteLine("----------------------");



            Console.WriteLine("\n\nXML Serialization: ");
            Console.WriteLine("----------------------");
            ser.XMLSerialisation(arr);
            var xmlData = ser.XMLDeSerialisation(arr);
            TheString[] newXMLArray = new TheString[arr.Length];
            for (int i = 0; i < newXMLArray.Length; i++)
            {
                if (xmlData is TheString[])
                {
                    newXMLArray[i] = xmlData[i];
                }
                Console.WriteLine(newXMLArray[i].GetStringValue());
            }
            Console.WriteLine("----------------------");


            Console.WriteLine("\n\nJSON Serialization: ");
            Console.WriteLine("----------------------");
            ser.JSONSerialisation(arr);
            var jsonData = ser.JSONDeSerialisation(arr);
            TheString[] newJSONArray = new TheString[arr.Length];
            for (int i = 0; i < newJSONArray.Length; i++)
            {
                if (jsonData is TheString[])
                {
                    newJSONArray[i] = jsonData[i];
                }
                Console.WriteLine(newJSONArray[i].GetStringValue());
            }
            Console.WriteLine("----------------------");


            Console.WriteLine("\n\nCustom Serialization: ");
            Console.WriteLine("----------------------");
            List<CustomString> customList = new List<CustomString>(4);
            for (int i = 0; i < 4; i++)
            {
                customList.Add(new CustomString(RandomString(5)));
            }
            ser.CustomSerialisation(customList);
            var customBinData = ser.CustomDeSerialisation(customList);
            foreach (var item in customBinData)
            {
                Console.WriteLine(item.GetStringValue());
            }
            
            Console.WriteLine("----------------------");
        }
    }
}