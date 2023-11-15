namespace VideoStreaming.Application.Exceptions;

[Serializable]
public class VideoNotFoundException : Exception
{
    public VideoNotFoundException()
    {
    }

    public VideoNotFoundException(string? message) : base(message)
    {
    }
}
