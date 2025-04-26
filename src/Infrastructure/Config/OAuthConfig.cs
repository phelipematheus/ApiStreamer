namespace Infrastructure.Config;

public class OAuthConfig
{
    public required string ClientId { get; set; }
    public required string ClientSecret { get; set; }
    public required string AuthorizationUrl { get; set; }
    public required string TokenUrl { get; set; }
    public required string RedirectUrl { get; set; }
    public required string JwksUrl { get; set; }
}
