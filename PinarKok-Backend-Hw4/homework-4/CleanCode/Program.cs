using System;

namespace CleanCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region Boolean Karşılaştırmalar

            bool isDelivered = true;

            // DON'T
            if (isDelivered == true)
            {
                // codes
            }

            // DO
            if (isDelivered)
            {
                // codes
            }

            #endregion Boolean Karşılaştırmalar

            #region Boolean Değer Atamaları

            int score = 60;

            // DON'T
            bool isSuccessful;

            if (score > 59)
            {
                isSuccessful = true;
            }
            else
            {
                isSuccessful = false;
            }

            // DO
            bool isSuccessful2 = score > 59;

            #endregion Boolean Değer Atamaları

            #region Pozitif Ol

            // DON'T
            bool isNotIncluded = false;

            if (!isNotIncluded)
            {
                // codes
            }

            // DO
            bool isIncluded = true;

            if (isNotIncluded)
            {
                // codes
            }

            #endregion Pozitif Ol

            #region Ternary IF

            bool isGraduated = true;
            int creditTaken;

            // DON'T
            if (isGraduated)
            {
                creditTaken = 240;
            }
            else
            {
                creditTaken = 0;
            }

            // DO
            int creditToken = isGraduated ? 240 : 0;

            #endregion Ternary IF

            #region Stringly Type vs Strongly Type

            // DON'T 
            string toDo = "Homework four";

            if (toDo == "Homework four")
            {
                // codes
            }

            // DO
            string homeworkFour = "Homework four";

            if (toDo == homeworkFour)
            {
                // codes
            }

            #endregion Stringly Type vs Strongly Type

            #region Başı Boş İfadeler

            int cash = 5;
            bool isAccountSuspended;

            // DON'T

            if (cash <= 0)
            {
                isAccountSuspended = true;
            }

            // DO
            int lowerLimit = 0;

            if (cash <= lowerLimit)
            {
                isAccountSuspended = true;
            }

            #endregion Başı Boş İfadeler

            Console.ReadKey();
        }
    }
}
