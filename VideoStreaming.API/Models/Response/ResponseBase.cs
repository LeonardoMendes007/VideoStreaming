using Microsoft.AspNetCore.Mvc;

namespace VideoStreaming.API.Models.Response;

public class ResponseBase<T>
{
    public T Data { get; set; }
    public ResponseBase(T parameter)
    {
        this.Data = parameter;
    }
}