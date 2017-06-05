using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenFarmConsoleApplication
{
    /*
     * A class to keep track of the time taken to complete a process
     */ 
    class TimeStamp
    {
        /*
         * A duration is difference between the start and end time
         */ 
        private DateTime start;
        private DateTime end;

        public DateTime Start
        {
            get
            {
                return start;
            }

            set
            {
                start = value;
            }
        }

        public DateTime End
        {
            get
            {
                return end;
            }

            set
            {
                end = value;
            }
        }

        /*
         * Assign only the start time when a timestamp is called.
         */ 
        public TimeStamp()
        {
            Start = DateTime.Now;
        }

        /*
         * a function to calculate the time taken to process a task.
         */
        public long timeStampDifference()
        {
            return (this.End - this.Start).Milliseconds;
        }
    }
}
