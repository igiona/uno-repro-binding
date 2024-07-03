using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;

namespace UnoApp1.Presentation;

public class BatteryStateOfChargeToTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var battInfo = value as BindableBatteryInformationModel;
        if (battInfo != null)
        {
            return $"Level is {battInfo.BatteryStateOfCharge} and currently {battInfo.ChargingState}";
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
