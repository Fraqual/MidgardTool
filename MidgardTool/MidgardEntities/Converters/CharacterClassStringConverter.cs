using MidgardEntities.Character;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace MidgardEntities.Converters
{
    [ValueConversion(typeof(object), typeof(string))]
    public class CharacterClassStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null)
            {
                if(value is List<CharacterClass>)
                {
                    return ((List<CharacterClass>)value).ConvertAll(c => c.Name);
                }
                if(value is List<CharacterRace>)
                {
                    return ((List<CharacterRace>)value).ConvertAll(r => r.Name);
                }
            }
            return new List<string>();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
