namespace AutoPiterTest.Infrastructure.Entities.Enums;

public static class ConnectionTypeExtension
{
    public static string GetConnectionType(this ConnectionType connectionType)
    {
        return connectionType switch
        {
            ConnectionType.Local => "Локальное",
            ConnectionType.Network => "Сетевое",
            _ => throw new ArgumentOutOfRangeException(nameof(connectionType), connectionType, null)
        };
    }
}