using System;
using System.Globalization;
using System.Windows.Data;

namespace UTExLMS.Converters
{
    public class GenderToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string gender && parameter is string targetGender)
            {
                return gender.Equals(targetGender, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isChecked && isChecked && parameter is string targetGender)
            {
                return targetGender;
            }
            return null;
        }
    }
}
