using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Interfaces;

public interface IResult<T>
{
    Result<T> Success(string message);
    Result<T> Success(T data, string message);
    Result<T> Success(T data, string token, string message);
    Result<T> BadRequest(string message);
}
