using Application.Interfaces.Respositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastrucutre.Extenstions;

public class TokenDecodeService : ITokenDecodeService
{
    private readonly HttpContextAccessor _httContextAccessor;

    public TokenDecodeService(HttpContextAccessor httContextAccessor)
    {
        _httContextAccessor = httContextAccessor;
    }

    public int GetUserId()
    {
        var user = _httContextAccessor.HttpContext.User;

        return int.Parse(user.FindFirst("userId").Value);
    }
}
