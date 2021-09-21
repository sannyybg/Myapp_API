using System;
using System.Collections.Generic;
using System.Text;

namespace DbProvider.Abstractions
{
    public interface IJWTService
    {
        string GenerateSecurityToken(string email);
    }
}
