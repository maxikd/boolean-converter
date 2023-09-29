namespace System.Text.Json.Serialization.BooleanConverter.UnitTests;

public class NullableBooleanConverterWriteTests
{
    private readonly JsonSerializerOptions _options;

    public NullableBooleanConverterWriteTests()
    {
        _options = new JsonSerializerOptions();
        _options.Converters.Add(new NullableBooleanConverter());
    }

    [Fact]
    public void Write_WhenNull_ShouldWriteNullValue()
    {
        var result = JsonSerializer.Serialize<bool?>(null, _options);

        Assert.Equal("null", result);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Write_WhenBoolean_ShouldWriteBooleanValue(
        bool value)
    {
        var result = JsonSerializer.Serialize<bool?>(value, _options);

        Assert.Equal(value.ToString(), result, true);
    }
}