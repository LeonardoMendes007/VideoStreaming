namespace VideoStreaming.Application.Exceptions;

[Serializable]
internal class VideoNotFoundException : Exception
{
    public VideoNotFoundException()
    {
    }

    public VideoNotFoundException(string? message) : base(message)
    {
    }
}
