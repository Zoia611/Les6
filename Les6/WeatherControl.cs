using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Les6
{
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TempProperty;
        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }

        enum precip
        {
            sun = 0,
            cloud = 1,
            rain = 2,
            snow = 3,
        }

        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }


        public WeatherControl(string windDirection, int windSpeed, int temp)
        {
            this.WindDirection = windDirection;
            this.WindSpeed = windSpeed;
            this.Temp = temp;
        }

        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsArrange,
                    null,
                    new CoerceValueCallback(CoerceTemp)),
                new ValidateValueCallback(ValidateTemp));
        }

        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
                return v;
            else
                return 0;
        }

        private static bool ValidateTemp(object value)
        {
            int v = (int)value;
            if (v >= -50 && v <= 50)
                return true;
            else
                return false;
        }
    }
}
