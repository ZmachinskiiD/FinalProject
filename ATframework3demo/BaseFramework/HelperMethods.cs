using System.Drawing;
using System.Globalization;
using System.Text;

namespace ATframework3demo.BaseFramework
{
    public class HelperMethods
    {
        public static string GetHexColor(Color messageColor)
        {
            return "#" + messageColor.R.ToString("X2") + messageColor.G.ToString("X2") + messageColor.B.ToString("X2");
        }

        public static string GetDateTimeSaltString(bool convertToPseudoRoman = false, int maxLength = 0)
        {
            string res = DateTime.Now.ToString("ddMMyyyyHHmmss");
            if (convertToPseudoRoman)
                res = TransformNumberToPseudoRomanNumeral(long.Parse(res));
            if (maxLength > 0 && res.Length > maxLength)
                res = res[(res.Length - maxLength)..];
            return res;
        }
        public static string GetDate(int fromToday = 0,bool forConstuctor = false)
        {
            DateTime tomorrow = DateTime.Today.AddDays(fromToday);
            if(forConstuctor)
            {
                return tomorrow.ToString("yyyy-MM-dd");
            }
            return tomorrow.ToString("dd.MM.yyyy");
        }
        public static string GetTimeOfFestival(int minutesFromNow)
        {
            var Time = DateTime.Now.AddMinutes(minutesFromNow);
            return Time.ToString("HH:mm");
        }

        /// <summary>
        /// Превращает арабскую цифру в псевдоримскую, каждые 2 разряда конвертит в римскую
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string TransformNumberToPseudoRomanNumeral(long number)
        {
            string sourceNumber = number.ToString();
            if (number < 0)
                sourceNumber = sourceNumber[1..];
            string result = default;

            if (number < 10)
                result = TransformNumberToRomanNumeral(number);
            else
            {
                for (int i = 2; true; i += 2)
                {
                    string segment = sourceNumber[(i - 2)..];
                    if (segment.Length >= 2)
                        segment = segment[0..2];
                    result += TransformNumberToRomanNumeral(int.Parse(segment));
                    if (segment.Length < 2 || i == sourceNumber.Length)
                        break;
                }
            }

            if (number < 0)
                result = "-" + result;
            return result;
        }

        /// <summary>
        /// Превращает арабскую цифру в римскую
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static string TransformNumberToRomanNumeral(long number)
        {
            int[] roman_value_list = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] roman_char_list = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            StringBuilder res = new StringBuilder();

            for (int i = 0; i < roman_value_list.Length; i += 1)
            {
                while (number >= roman_value_list[i])
                {
                    number -= roman_value_list[i];
                    res.Append(roman_char_list[i]);
                }
            }

            return res.ToString();
        }
        public static string TransformDateToRussian(string inputDate)
        {
            DateTime date = DateTime.ParseExact(inputDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            return date.ToString("d MMMM yyyy", new CultureInfo("ru-RU"));
        }
        public static string? ConvertDateFormat(string inputDate)
        {
            if (DateTime.TryParseExact(inputDate, "dd.MM.yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                return date.ToString("yyyy-MM-dd");
            }
            return null;
        }
    }
}
