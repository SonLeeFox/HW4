namespace ConverterApp;

class Converter
{
    private readonly decimal usdRate;
    private readonly decimal eurRate;

    public Converter(decimal usdRate, decimal eurRate)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(usdRate);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(eurRate);

        this.usdRate = usdRate;
        this.eurRate = eurRate;
    }

    public decimal UahToUsd(decimal uah) => uah / usdRate;

    public decimal UahToEur(decimal uah) => uah / eurRate;

    public decimal UsdToUah(decimal usd) => usd * usdRate;

    public decimal EurToUah(decimal eur) => eur * eurRate;
}
