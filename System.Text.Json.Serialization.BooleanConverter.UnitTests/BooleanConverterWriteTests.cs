namespace System.Text.Json.Serialization.BooleanConverter.UnitTests;

public class BooleanConverterWriteTests
{
    private readonly JsonSerializerOptions _options;

    public BooleanConverterWriteTests()
    {
        _options = new JsonSerializerOptions();
        _options.Converters.Add(new BooleanConverter());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Write_ShouldWriteBooleanValue(
        bool value)
    {
        var result = JsonSerializer.Serialize<bool>(value, _options);

        Assert.Equal(value.ToString(), result, true);
    }
}