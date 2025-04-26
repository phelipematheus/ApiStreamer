using System.Text.Json;
using System.Text.Json.Serialization;

namespace CrossCutting;

public class StringToIntConverter : JsonConverter<int>
{
    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            string stringValue = reader.GetString() ?? "0";

            return int.TryParse(stringValue, out int intValue)
                ? intValue
                : throw new JsonException($"Não foi possível converter '{stringValue}' para int.");
        }
        else if (reader.TokenType == JsonTokenType.Number)
        {
            return reader.GetInt32();
        }
        throw new JsonException("Tipo de token JSON inesperado para conversão int.");
    }

    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value);
    }
}
