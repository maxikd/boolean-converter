namespace System.Text.Json.Serialization.BooleanConverter;

public class BooleanConverter : JsonConverter<bool>
{
    public override bool Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.False => false,
            JsonTokenType.True => true,
            JsonTokenType.String => HandleString(ref reader),
            _ => throw new JsonException($"Invalid value for token type {reader.TokenType}")
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        bool value,
        JsonSerializerOptions options)
    {
        writer.WriteBooleanValue(value);
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