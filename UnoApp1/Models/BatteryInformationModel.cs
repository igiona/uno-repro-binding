namespace UnoApp1.Models;

public enum BatteryChargingState
{
    Charging,
    NotCharing
}

public record PowerManagementModel(
    BatteryInformationModel BatteryInformation
)
{
    public static PowerManagementModel Empty => new PowerManagementModel(BatteryInformationModel.Empty);
}

public record BatteryInformationModel(
    double? BatteryStateOfCharge,
    BatteryChargingState? ChargingState
)
{
    public static BatteryInformationModel Empty => new BatteryInformationModel(null, null);
}
