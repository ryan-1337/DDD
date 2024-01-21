using Api.Endpoints;

namespace Api;

public static class MapEndpoints
{
    public static IEndpointRouteBuilder MapEndpoint(this IEndpointRouteBuilder group)
    {
        group.MapClient();
        group.MapPayment();
        return group;
    }
}
