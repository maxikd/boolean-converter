namespace System.Text.Json.Serialization.BooleanConverter.UnitTests;

public class NullableBooleanConverterReadTests
{
    private readonly JsonSerializerOptions _options;

    public NullableBooleanConverterReadTests()
    {
        _options = new JsonSerializerOptions();
        _options.Converters.Add(new NullableBooleanConverter());
    }

    [Fact]
    public void Read_WhenNull_ShouldDeserializeToNull()
    {
        var json = "null";

        var result = JsonSerializer.Deserialize<bool?>(json, _options);

        Assert.False(result.HasValue);
        Assert.Null(result);
    }

    [Fact]
    public void Read_WhenFalse_ShouldDeserializeToFalse()
    {
        var json = "false";

        var result = JsonSerializer.Deserialize<bool?>(json, _options);

        Assert.False(result);
    }

    [Fact]
    public void Read_WhenFalseString_ShouldDeserializeToFalse()
    {
        var json = "\"false\"";

        var result = JsonSerializer.Deserialize<bool?>(json, _options);

        Assert.False(result);
    }

    [Fact]
    public void Read_WhenTrue_ShouldDeserializeToTrue()
    {
        var json = "true";

        var result = JsonSerializer.Deserialize<bool?>(json, _options);

        Assert.True(result);
    }

    [Fact]
    public void Read_WhenTrueString_ShouldDeserializeToTrue()
    {
        var json = "\"true\"";

        var result = JsonSerializer.Deserialize<bool?>(json, _options);

        Assert.True(result);
    }

    [Fact]
    public void Read_WhenInvalidString_ShouldThrowJsonException()
    {
        var json = "\"sbrubles\"";

        Assert.Throws<JsonException>(
            () => JsonSerializer.Deserialize<bool?>(json, _options));
    }

    [Theory]
    [InlineData("[]")]
    [InlineData("{}")]
    [InlineData("69")]
    public void Read_WhenUnknownTokenType_ShouldThrowJsonException(
        string json)
    {
        Assert.Throws<JsonException>(
            () => JsonSerializer.Deserialize<bool?>(json, _options));
    }
}