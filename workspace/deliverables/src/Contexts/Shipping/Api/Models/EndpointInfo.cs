namespace Migration.Shipping.Api.Models;

public sealed record EndpointInfo(
    string LegacyEndpoint,
    string Context,
    string Method,
    string Evidence
);