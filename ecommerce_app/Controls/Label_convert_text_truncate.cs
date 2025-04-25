using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_app.Controls
{
    public class Label_convert_text_truncate : IValueConverter
    {
        public int MaxLength { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text && text.Length > MaxLength)
            {
                return text.Substring(0, MaxLength) + "...";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
