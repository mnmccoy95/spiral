using System;

//--------------- CLI Application for writing a spiral of user defined size to the console ---------------//
namespace Spiral
{
    class Program
    {
        static void Main(string[] args)
        {
            SpiralRun();
        }
        static void SpiralRun()
        {
            //initialize permanent size variable
            int permSize = 0;
            Console.Write("Enter the size of your spiral: ");
            try
            {
                //read user input anc create spiral that size.
                permSize = Int32.Parse(Console.ReadLine());
                
                //failsafe if user inters a value too small for a "spiral"
                if(permSize > 1)
                {
                    //calls method to generate the spiral
                    SpiralCreate(permSize);
                }
                else
                {   
                    //exception thrown if spiral value too low
                    throw new Exception();
                }
            }
            catch
            {
                //if user does not enter a valid integer, restart method.
                SpiralRun();
            }
        }

        //method to generate desired spiral
        static void SpiralCreate(int permSize)
        {   
            //initialize spiral matrix, setting all values to a space
            string[,] mat = new string[permSize, permSize];
            for(int i = 0; i < permSize; i++)
            {
                for(int j = 0; j < permSize; j++)
                {
                    mat[i,j] = " ";
                }
            }

            //initialize size value for line lengths
            int size = permSize;
            //initialize direction value for switch case
            int direction = 1;
            //staring row value when traveling right
            int rightRow = 0;
            //starting row value when traveling left
            int leftRow = permSize-2;
            //starting column value when traveling down
            int downColumn = permSize-1;
            //starting column value when travling up
            int upColumn = 2;
            //initialize value to track direction change
            int count = 0;

            //line size decreases value with each turn and stops when equal to 1
            while(size != 1)
            {
                switch (direction)
                {
                    //logic for rows traveling right
                    case 1:
                        //set relevant values to "*"
                        for(int i = 0; i < size; i++)
                        {
                            mat[rightRow, i + count/2] = "*";
                        }
                        //change value for future rows traveling right
                        rightRow = rightRow + 2;
                        //decrease line size
                        size--;
                        //increase turn count
                        count++;
                        //switch to next direction
                        direction = 2;
                        break;

                    //logic for columns traveling down
                    case 2:
                        //set relevant values to "*"
                        for(int i = 0; i < size; i++)
                        {
                            mat[i + ((count-1)/2), downColumn] = "*";
                        }
                        //change value for future columns traveling down
                        downColumn = downColumn - 2;
                        //decrease line size
                        size--;
                        //increase turn count
                        count++;
                        //switch to next direction
                        direction = 3;
                        break;

                    //logic for rows travling left
                    case 3:
                        //set relevant values to "*"
                        for(int i = 0; i < size; i++)
                        {
                            mat[leftRow, permSize - size + i - ((count-2)/2)] = "*";
                        }
                        //change value for future rows traveling left
                        leftRow = leftRow - 2;
                        //decrease line size
                        size--;
                        //increase turn count
                        count++;
                        //switch to next direction
                        direction = 4;
                        break;

                    //logic for columns traveling up
                    case 4:
                    //set relevant values to "*"
                        for(int i = 0; i < size; i++)
                        {
                            mat[size+((count-1)/2)-i, upColumn] = "*";
                        }
                        //change value for future columns traveling up
                        upColumn = upColumn + 2;
                        //decrease line size
                        size--;
                        //increase turn count
                        count++;
                        //switch to next direction
                        direction = 1;
                        break;
                }
            }
            //print resulting spiral
            Print(mat);
        }

        //method for writing two dimensional matrices to console
        static void Print(string[,] mat)
        {
            //iterate through rows
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                //iterate through columns
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    //print each value to console
                    Console.Write(mat[i,j]);
                }
                //format to properly display each row
                Console.WriteLine();
            }
        }
    }
}
