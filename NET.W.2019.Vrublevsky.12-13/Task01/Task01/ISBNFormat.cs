using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Task01
{
    /// <summary>
    /// Convert an ISBN string to formatted form.
    /// </summary>
    public class ISBNFormat : IFormatProvider, ICustomFormatter
    {
        private const int ISBNlenght = 13;

        /// <summary>
        /// Return current ISBNFormat.
        /// </summary>
        /// <param name="formatType">Type</param>
        /// <returns>Current ISBNFormat.</returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Convert string to formatted form.
        /// </summary>
        /// <param name="fmt">Format.</param>
        /// <param name="arg">Arguments.</param>
        /// <param name="formatProvider">Class that implement IFormatProvider.</param>
        /// <returns>Formatted string or FormatException.</returns>
        public string Format(string fmt, object arg, IFormatProvider formatProvider)
        {
            if (arg.GetType() != typeof(string))
            {
                try
                {
                    return this.HandleOtherFormats(fmt, arg);
                }
                catch (FormatException e)
                {
                    Program.Logger.Error(string.Format("The format of '{0}' is invalid.", fmt), e);
                }
            }

            string ufmt;
            try
            {
                ufmt = fmt.ToUpper(new CultureInfo("en-US"));
            }
            catch (NullReferenceException)
            {
                return arg.ToString();
            }

            if (!(ufmt == "ISBN"))
            {
                try
                {
                    return this.HandleOtherFormats(fmt, arg);
                }
                catch (FormatException e)
                {
                    Program.Logger.Error(string.Format("The format of '{0}' is invalid.", fmt), e);
                }
            }

            string result = arg.ToString();

            if (result.Length != ISBNlenght)
            {
                throw new FormatException("ISBN must contains 13 digits.");
            }
            else
            {
                return result.Substring(0, 3) + "-" + result.Substring(3, 1) + "-" + result.Substring(4, 4) + "-" + result.Substring(8, 4) + "-" + result.Substring(12, 1);
            }
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
            {
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            }
            else if (arg != null)
            {
                return arg.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}