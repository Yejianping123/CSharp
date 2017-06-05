using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChickenFarmConsoleApplication
{
    class MultiCellBuffer
    {
        /*
         * Max size of the buffer.
         */
        public static int N = 5;
        public static string[] multiCellBuffer;

        /*
         * Semaphore with initial and max count set to 2
         */
        public static Semaphore semaphore = new Semaphore(2, 2);

        /*
         * Initializing the buffer cell
         */
        public MultiCellBuffer(int threadCount)
        {
            multiCellBuffer = new string[N];
        }

        /*
         * function to set the data into one of the available cell
         */ 
        public Boolean setOneCell(int threadID, String encodedOrder)
        {
            semaphore.WaitOne();
            for (int i = 0; i < N; i++)
            {
                lock (this)
                {
                    /*
                     * if found an empty cell, set the data in that cell 
                     */ 
                    if (multiCellBuffer[i] == null)
                    {
                        multiCellBuffer[i] = encodedOrder;
                        return true;
                    }
                }
            }
            return false;
        }

        /*
        * function to retrieve the data from the cell
        */
        public String getOneCell(int threadID)
        {
            String encodedOrder = null;
            for (int i = 0; i < N; i++)
            {
                lock (this)
                {
                    /*
                     * if found the cell, get the data from that cell 
                     */
                    if (multiCellBuffer[i] != null)
                    {
                        encodedOrder = multiCellBuffer[i];
                        multiCellBuffer[i] = null;
                        semaphore.Release();
                        break;
                    }
                }
            }

            return encodedOrder;
        }
    }       
}
