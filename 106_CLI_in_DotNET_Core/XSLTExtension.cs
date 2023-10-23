using System;
using System.Collections.Generic;
using System.Text;

namespace OrderHubCli
{
    public class XSLTExtension
    {
        public int compare(string str1, string str2)
        {
            return string.Compare(str1, str2);
        }
        public string repeat(string c, int count)
        {
            if (count > 0)
            {
                return new string(c[0], count);
            }
            else
            {
                return "";
            }
        }

        public string csv(string str)
        {
            if (str.Contains(@"\n") || str.Contains("\"") || str.Contains(","))
            {
                return $"\"{str.Replace("\"", "\"\"")}\"";
            }
            else
            {
                return str;
            }
        }

        public string localDate(string utcDate, string format)
        {
            try
            {
                DateTime convertedDate = DateTime.SpecifyKind(
                                            DateTime.Parse((string)utcDate),
                                            DateTimeKind.Utc);

                return convertedDate.ToLocalTime().ToString(format);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}