using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minutes
{
    public class AMorPM
    {
        static void Main(string[] args)
        {
        }
        public string AddMinutes(string time, int additionalMinutes)
        {
            string finalTime = "";
            string[] splitOffMeridiem;

            if (time.Contains(' '))
                splitOffMeridiem = time.Split(' ');
            else
            {
                Console.WriteLine("Improper Format, confirm entry contains AM/PM");
                return string.Empty;
            }

            string meridiem = splitOffMeridiem[1];

            if (!(meridiem.ToUpper() == "AM" || meridiem.ToUpper() == "PM"))
            {
                Console.WriteLine("Improper Format, confirm entry contains AM/PM");
                return string.Empty;
            }

            var hms = splitOffMeridiem[0].Split(':');

            if (hms.Count() != 3)
            {
                Console.WriteLine("Improper Format, confirm contains {H}H:MM:SS");
                return string.Empty;
            }

            int h, m, s = 0;
            if (int.TryParse(hms[0], out h) && int.TryParse(hms[1], out m) && int.TryParse(hms[2], out s))
            {
                int additionalHours = additionalMinutes / 60;
                additionalMinutes = additionalMinutes % 60;

                h = h + additionalHours;
                if (h > 12)
                {
                    h = h % 12;
                    if (h == 0)
                        h = 12;
                    else
                        if (meridiem.ToUpper() == "AM")
                            meridiem = "PM";
                        else if (meridiem.ToUpper() == "PM")
                            meridiem = "AM";
                }

                m = m + additionalMinutes;
                if (m > 59)
                {
                    m = m % 60;
                    if (h + 1 == 12)
                    {
                        h++;
                        if (meridiem.ToUpper() == "AM")
                            meridiem = "PM";
                        else if (meridiem.ToUpper() == "PM")
                            meridiem = "AM";
                    }
                    else if (h + 1 == 13)
                        h = 1;
                }

                StringBuilder sb = new StringBuilder();
                sb.Append(h);
                sb.Append(":");
                if (m < 10)
                    sb.Append("0" + m);
                else
                    sb.Append(m);
                sb.Append(":");
                if (s < 10)
                    sb.Append("0" + s);
                else
                    sb.Append(s);
                sb.Append(" ");
                sb.Append(meridiem);

                finalTime = sb.ToString();
                return finalTime;
            }
            else
            {
                Console.WriteLine("Improper Format, confirm contains {H}H:MM:SS");
                return string.Empty;
            }
        }
    }
}
