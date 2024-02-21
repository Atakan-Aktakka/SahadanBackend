using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahadan.Application.Models
{
    public class ApiResult<T>
{
    private ApiResult() { }

    private ApiResult(bool succeeded, T? data, IEnumerable<string>? messages)
    {
        Succeeded = succeeded;
        Data = data;
        Messages = messages;
    }

    public bool Succeeded { get; set; }

    public T? Data { get; set; }

    public IEnumerable<string>? Messages { get; set; }

    public static ApiResult<T> Success(T? Data)
    {
        return new ApiResult<T>(true, Data, new List<string>());
    }

    public static ApiResult<T> Failure(IEnumerable<string>? errors)
    {
        return new ApiResult<T>(false, default, errors);
    }
}
}