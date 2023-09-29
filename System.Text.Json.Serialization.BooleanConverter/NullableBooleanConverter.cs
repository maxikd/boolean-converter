namespace System.Text.Json.Serialization.BooleanConverter;

public class NullableBooleanConverter : JsonConverter<bool?>
{
    public override bool? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.Null => null,
            JsonTokenType.False => false,
            JsonTokenType.True => true,
            JsonTokenType.String => HandleString(ref reader),
            _ => throw new JsonException($"Invalid value for token type {reader.TokenType}")
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        bool? value,
        JsonSerializerOptions options)
    {
        if (!value.HasValue)
            writer.WriteNullValue();
        else
            writer.WriteBooleanValue(value.Value);
    }

    private static bool HandleString(
        ref Utf8JsonReader reader)
    {
        var stringBool = reader.GetString();

        if (bool.TryParse(stringBool, out bool result))
            return result;

        throw new JsonException($"Invalid boolean value \"{stringBool}\"");
    }
}