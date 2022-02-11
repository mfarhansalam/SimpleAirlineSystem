using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationSystem
{
    class Program
    {

        public static bool[] seats;
        public static int totalAssignedFirstClass;
        public static int totalAssignedSecondClass;

        static void Main(string[] args)
        {

            seats = new bool[10];

            int selectedClass = 0;

            for (int i = 0; i < 10; i++)
                seats[i] = false;
            for ( int i = 1; i<=10; i++)
            {
                Console.WriteLine(" Please Type 1 for first class or 2 for Economy class");
                selectedClass = Convert.ToInt32(Console.ReadLine());

                while(selectedClass < 1 || selectedClass > 2)
                {
                    Console.WriteLine("Please only enter 1 or 2");
                    selectedClass = Convert.ToInt32(Console.ReadLine());

                }
                if (selectedClass == 1)
                {
                    if (totalAssignedFirstClass == 5 && totalAssignedSecondClass < 5)
                    {
                        Console.WriteLine("Sorry first class is full ,Do ou want to get ticket economy? Y or N");
                        if (Console.ReadLine().Equals("N")) 
                        {
                            Console.WriteLine("Please go away !!!");

                        }
                        else
                        {
                            assignSecondClass();
                        }
                    }
                    else if (totalAssignedFirstClass < 5)
                    {
                        assignFirstClass();
                    }

                    
                }
                else
                {
                    if (totalAssignedSecondClass == 5 && totalAssignedFirstClass < 5)
                        Console.WriteLine("sorry economy is full, do you want first class ?  Y or N");

                    if (Console.ReadLine().Equals("N"))
                    {
                        Console.WriteLine("please go awway");
                    }
                    else
                    {
                        assignFirstClass();
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("sorry the plane is full");
             
        }

        public static void assignFirstClass()
        {
            bool noDuplicate = false;
            int index =0;
            Random rand = new Random();

            //keep generate the seat number until a free seat assigned
            
            while (!noDuplicate)
            {
                noDuplicate = true;
                index = rand.Next(1, 6);
                if (seats[index] == true)
                    noDuplicate = false;
            }
            seats[index] = true;
            totalAssignedFirstClass++;
            Console.WriteLine("Assigned seat {0:N0}", index);
        }

        public static void assignSecondClass()
        {
            bool noDuplicate = false;
            int index = 0;
            Random rand = new Random();

            //keep generate the seat number until a free seat assigned

            while (!noDuplicate)
            {
                index = rand.Next(1, 6);
                if (seats[index] == true)
                    noDuplicate = false;
            }
            seats[index] = true;
            totalAssignedFirstClass++;
            Console.WriteLine("Assigned seat {0:N0}", index);
        }




    }
}
