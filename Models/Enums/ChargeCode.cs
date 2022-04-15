

namespace Storage.Models.Enums
{
    [Flags]
    public enum ChargeCode
    {
        Undefined = 0,
        FlatRate = 1,
        FuelSurcharge = 2,
        PerMile = 4,
        HazMat = 8,
        Minimum = 16,
        StopOffCharge = 32,
        DriverAssist = 64,
        TWIC = 128,
        Team = 256
    }
}
