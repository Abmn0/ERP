using System.Security.Claims;

public static class ClaimsHelper
{
    public static int? GetUserId(ClaimsPrincipal user)
    {
        var idClaim = user.Claims.FirstOrDefault(x => x.Type == "UserId");
        if (idClaim != null && int.TryParse(idClaim.Value, out var id))
            return id;

        return null;
    }
}
