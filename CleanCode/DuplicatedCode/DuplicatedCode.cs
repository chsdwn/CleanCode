
using System;

namespace CleanCode.DuplicatedCode
{
    public class Time
    {
        public int Hours { get; }
        public int Minutes { get; }

        public Time(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }

        public static Time Parse(string str)
        {
            int time;
            if (!string.IsNullOrWhiteSpace(str))
            {
                if (Int32.TryParse(str.Replace(":", ""), out time))
                {
                    int hours = time / 100;
                    int minutes = time % 100;

                    return new Time(hours, minutes);
                }
                else
                {
                    throw new ArgumentException("str");
                }
            }
            else
                throw new ArgumentNullException("str");
        }

    }

    class DuplicatedCode
    {
        public void AdmitGuest(string name, string admissionDateTime)
        {
            // Some logic 
            // ...

            var time = Time.Parse(admissionDateTime);

            // Some more logic 
            // ...
            if (time.Hours < 10)
            {

            }
        }

        public void UpdateAdmission(int admissionId, string name, string admissionDateTime)
        {
            // Some logic 
            // ...

            var time = Time.Parse(admissionDateTime);

            // Some more logic 
            // ...
            if (time.Hours < 10)
            {

            }
        }
    }
}
