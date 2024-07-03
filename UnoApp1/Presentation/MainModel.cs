namespace UnoApp1.Presentation;

public partial record MainModel
{
    private INavigator _navigator;

    public MainModel(
        IStringLocalizer localizer,
        IOptions<AppConfig> appInfo,
        INavigator navigator)
    {
        _navigator = navigator;
        Title = "Main";
        Title += $" - {localizer["ApplicationName"]}";
        Title += $" - {appInfo?.Value?.Environment}";
    }

    public string? Title { get; }

    public IState<string> Name => State<string>.Value(this, () => string.Empty);

    public IState<PowerManagementModel> PowerManagement => State<PowerManagementModel>.Value(this, () => PowerManagementModel.Empty);

    public async Task GoToSecond()
    {
        var name = await Name;
        //await _navigator.NavigateViewModelAsync<SecondModel>(this, data: new Entity(name!));
        await PowerManagement.UpdateAsync(pm =>
            (pm ?? PowerManagementModel.Empty) with
            {
                BatteryInformation = (pm?.BatteryInformation ?? BatteryInformationModel.Empty) with 
                    { 
                        BatteryStateOfCharge = Random.Shared.Next(0, 100),
                        ChargingState = (BatteryChargingState)Random.Shared.Next(0, Enum.GetValues<BatteryChargingState>().Length)
                    }
            }, CancellationToken.None);
    }
}
