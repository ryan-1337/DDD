using Api.Endpoints;

namespace Api;

public static class MapEndpoints
{
    public static IEndpointRouteBuilder MapEndpoint(this IEndpointRouteBuilder group)
    {
        group.MapUser();
        return group;
    }
}
