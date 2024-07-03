namespace UnoApp1.Models;

public enum BatteryChargingState
{
    Charging,
    NotCharing
}

public record PowerManagementModel(
    double? BatteryStateOfCharge,
    BatteryChargingState? ChargingState
)
{
    public static PowerManagementModel Empty => new PowerManagementModel(null, null);
}
