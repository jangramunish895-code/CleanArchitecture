using Application.Dtos.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Users;

public class GetUserDto : CommonDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public long MobileNo { get; set; }
}
