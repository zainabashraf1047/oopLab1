using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;


namespace businessCRUD
{
  
    class Program
    {
        static string[] names = new string[5];
        static string[] password = new string[5];
        /*//static int option*/
        static void Main(string[] args)
        {
            //string option = null;
            int[] itemPriceA = new int[100];
            string[] itemNameA = new string[100];
            int noOfItems = 0;
            int index = 0;
            readItemDataFromFile(ref itemNameA,ref itemPriceA,ref index);

            int option = menu();
            do
            {
                string path = "D:\ooplab\\businessCRUD\\businessCRUD\\userdata.txt";
                readData( path,  names,password);
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Enter New name: ");
                    string nameEnter = Console.ReadLine();
                    Console.WriteLine("Enter New password: ");
                    string passwordEnter = Console.ReadLine();
                    signUp(path, nameEnter, passwordEnter);
                }

                else if (option == 2)
                {
                    Console.WriteLine("Enter name: ");
                    string nameEnter = Console.ReadLine();
                    Console.WriteLine("Enter password: ");
                    string passwordEnter = Console.ReadLine();
                    bool flag= signIn(nameEnter, passwordEnter, names, password);
                    {
                        if(flag==true)
                        {
                            Console.WriteLine("Valid User");
                            Console.Clear();
                            chkOption(ref noOfItems, ref itemNameA, ref itemPriceA, ref index);
                        }
                        else if(flag == false)
                        {
                            Console.WriteLine("InValid User");
                        }
                    }

                }
                //Console.WriteLine("Passwordsssssssssssss" +password[])
            }
            while (option < 3);
            Console.ReadKey();
        

            chkOption(ref noOfItems, ref itemNameA, ref itemPriceA, ref index);

        }


        static void writeItemDataInFile(ref int noOfItems, ref string[] itemNameA, ref int[] itemPriceA, ref int index)
        {
            string path = "D:\\ooplab\\businessCRUD\\businessCRUD\\itemData.txt";
            StreamWriter file = new StreamWriter(path, false) ;
            for (int i = 0; i < index; i++)
            {
                file.WriteLine(itemNameA[i] + "," + itemPriceA[i]);
            }
            file.Flush();
            file.Close();

        }
        static string parseData(string record, int field)
        {

            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        static void readItemDataFromFile(ref string[] itemNameA,ref int[] itemPriceA,ref int index)
        {
            string path = "D:\\ooplab\\businessCRUD\\businessCRUD\\itemData.txt";

            if (File.Exists(path))
            {
                StreamReader fileVar = new StreamReader(path);
                string record;
                while ((record = fileVar.ReadLine()) != null)
                {

                    if (record == "" || record == " ")
                    {
                        continue;
                    }
                   
                    string itemName = parseData(record, 1);
                    int itemPrice = int.Parse(parseData(record, 2));
                    index++;
                    itemNameA[index] = itemName;
                    itemPriceA[index] = itemPrice;
                }
                fileVar.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }

        }

        static void chkOption(ref int noOfItems, ref string[] itemNameA, ref int[] itemPriceA, ref int index)
        {
            int choice = 0;
            while (choice != 7)
            {
                Console.WriteLine("1. Create Menu");
                Console.WriteLine("2. Read Menu");
                Console.WriteLine("3. Update Item");
                Console.WriteLine("4. Delete Item");
                Console.WriteLine("5. Add Item");
                Console.WriteLine("6. View Sorted Data");

                Console.WriteLine("Enter Your Choice");
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    createMenu(ref noOfItems, ref itemNameA, ref itemPriceA, ref index);
                    Console.Clear();
                    chkOption(ref noOfItems, ref itemNameA, ref itemPriceA, ref index);
                }
                else if (choice == 2)
                {
                    /*Thread.Sleep(100000);*/
                    readMenu(ref index, ref itemNameA, ref itemPriceA);
                    Console.Clear();
                    chkOption(ref noOfItems, ref itemNameA, ref itemPriceA, ref index);
                }
                else if (choice == 3)
                {
                    updateItem(ref index, ref itemNameA, ref itemPriceA,ref noOfItems);
                    Console.Clear();
                    chkOption(ref noOfItems, ref itemNameA, ref itemPriceA, ref index);
                }
                else if (choice == 4)
                {
                    deleteItem(ref index, ref itemNameA, ref itemPriceA, ref noOfItems);
                    Console.Clear();
                    chkOption(ref noOfItems, ref itemNameA, ref itemPriceA, ref index);
                }
                else if (choice == 5)
                {
                    addItem(ref index, ref itemNameA, ref itemPriceA, ref noOfItems);
                    Console.Clear();
                    chkOption(ref noOfItems, ref itemNameA, ref itemPriceA, ref index);

                }
                else if (choice == 6)
                {
                    sortedData(ref index, ref itemNameA, ref itemPriceA);
                    Console.Clear();
                    chkOption(ref noOfItems, ref itemNameA, ref itemPriceA, ref index);
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                    Console.Clear();
                }

            }
        }

        static int menu()
        {
        int option;
        Console.WriteLine("1. Sign Up");
        Console.WriteLine("2. Sign In");
        Console.WriteLine("Enter Option");
        option = int.Parse(Console.ReadLine());
        return option;
        }
/*static string parseData(string record, int field)
{
    int comma = 1;
    string item = "";
    for (int x = 0; x < record.Length; x++)
    {
        if (record == ",")
        {
            comma++;
        }
        else if (comma == field)
        {
            item = item + record[x];
        }
    }
    return item;
}*/
        static void readData(string path, string[] names, string[] password)
        {
        int x = 0;
        path = "D:\\ooplab\\businessCRUD\\businessCRUD\\userdata.txt";
        if (File.Exists(path))
        {
            StreamReader fileVariable = new StreamReader(path);
            string record;
            while ((record = fileVariable.ReadLine()) != null)
            {

                if (record == "" || record == " ")
                {
                    continue;
                }
                names[x] = parseData(record, 1);
                password[x] = parseData(record, 2);
                x++;

                if (x >= 5)
                {
                    break;
                }
            }
            fileVariable.Close();
            }
            else
            {
            Console.WriteLine("Not Exists");
            }
        }
        static bool signIn(string nameEnter, string passwordEnter, string[] names, string[] password)
             {
              bool flag = false;
             for (int x = 0; x < 5; x++)
              {
                if (nameEnter == names[x] && passwordEnter == password[x])
                {

                        flag = true;
           
                }
             }
             Console.ReadKey();
              return flag;
         }
         static void signUp(string path, string nameEnter, string passwordEnter)
         {
         StreamWriter file = new StreamWriter(path, true);
         file.WriteLine(nameEnter + "," + passwordEnter);
         file.Flush();
         file.Close();
         }

        static void createMenu(ref int noOfItems, ref string[] itemNameA, ref int[] itemPriceA, ref int index)
        {

            Console.WriteLine("Enter number of items you want to add: ");
            noOfItems = int.Parse(Console.ReadLine());

            for (int i = 0; i < noOfItems; i++)
            {

                Console.WriteLine("Enter name of item: ");
                string itemName = Console.ReadLine();
                itemNameA[index] = itemName;
                Console.WriteLine("Enter price of item: ");
                itemPriceA[index] = int.Parse(Console.ReadLine());
                index++;
            }
            writeItemDataInFile(ref noOfItems, ref itemNameA, ref itemPriceA, ref index);
            /*Console.WriteLine(index);*/
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

        }
        static void deleteItem(ref int index, ref string[] itemNameA, ref int[] itemPriceA, ref int noOfItems)
        {
            Console.Write("Enter name of item you want to delete: ");
            string itemName = Console.ReadLine();
            int temp = 0;
            for (int i = 0; i < index; i++)
            {
                if (itemName == itemNameA[i])
                {
                    temp = i;
                }
            }
            for (int i = temp; i < index; i++)
            {
                itemNameA[i] = itemNameA[i + 1];
                itemPriceA[i] = itemPriceA[i + 1];
            }
            index--;
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            writeItemDataInFile(ref noOfItems, ref itemNameA, ref itemPriceA, ref index);
        }
        static void updateItem(ref int index, ref string[] itemNameA, ref int[] itemPriceA,ref int noOfItems)
        {
            bool flag = false;
            Console.Write("Enter name of item you want to update: ");
            string itemName = Console.ReadLine();
            for (int i = 0; i < index; i++)
            {

                if (itemNameA[i] == itemName)
                {
                    Console.WriteLine("Enter new price of item: ");
                    itemPriceA[i] = int.Parse(Console.ReadLine());
                    flag = true;
                }

            }
            if (flag == false)
            {

                Console.WriteLine("Item don't exist");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            writeItemDataInFile(ref noOfItems, ref itemNameA, ref itemPriceA, ref index);
        }
        static void readMenu(ref int index, ref string[] itemNameA, ref int[] itemPriceA)
        {
            Console.WriteLine("MENU LIST");
            Console.WriteLine("Items \t prices");
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(itemNameA[i] + "\t" + itemPriceA[i]);

            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

        }
        static void addItem(ref int index, ref string[] itemNameA, ref int[] itemPriceA,ref int noOfItems)
        {
            bool flag = false;
            Console.Write("Enter name of item you want to add: ");
            string itemName = Console.ReadLine();
            for (int i = 0; i < index; i++)
            {
                if (itemName == itemNameA[i])
                {
                    flag = true;
                }

            }
            if (flag == true)
            {
                Console.WriteLine("Item Already Present");
            }
            else
            {
                Console.WriteLine("Enter price of item you added: ");
                int itemPrice = int.Parse(Console.ReadLine());
                itemNameA[index] = itemName;
                itemPriceA[index] = itemPrice;
                index++;
            }
            writeItemDataInFile(ref noOfItems, ref itemNameA, ref itemPriceA, ref index);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

        }
        static void sortedData(ref int index, ref string[] itemNameA, ref int[] itemPriceA)
        {
            int temp = 0;
            string tempName = null;
            for (int i = 0; i < index; i++)
            {
                for (int j = i + 1; j < index; j++)
                {
                    if (itemPriceA[i] > itemPriceA[j])
                    {
                        temp = itemPriceA[i];
                        tempName = itemNameA[i];
                        itemPriceA[i] = itemPriceA[j];
                        itemNameA[i] = itemNameA[j];
                        itemPriceA[j] = temp;
                        itemNameA[j] = tempName;
                    }
                }

            }
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(itemNameA[i] + "\t" + itemPriceA[i]);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();


        }

    }
}
        /*static void rand()
        {
            Random rnd = new Random();
            int min = 0;
            int max = 100;
            int randomNumber = rnd.Next(min, max);
            Console.WriteLine(randomNumber);
            Console.ReadKey();
        }

        static void rand2()
        {
            Random rnd = new Random();
            double randomDouble = rnd.NextDouble();
            Console.WriteLine(randomDouble); 
            Console.ReadKey();
        }


        static void changeClr()
        {
            Console.WriteLine("Without color");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("With Red color");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("With Green color");
        }
*/


   
