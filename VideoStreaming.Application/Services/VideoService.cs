using Microsoft.Extensions.FileProviders;
using VideoStreaming.Application.Exceptions;
using VideoStreaming.Application.Interfaces.Services;

namespace VideoStreaming.Application.Services;

public class VideoService : IVideoService
{
    private readonly IFileProvider _fileProvider;
    public VideoService(IFileProvider fileProvider) {
        this._fileProvider = fileProvider;
    }

    public async Task<Stream> GetVideoAsync(string videoName)
    {
        var streamProvider = _fileProvider;
        var fileInfo = streamProvider.GetFileInfo(@$"{videoName}\{videoName}.m3u8");

        if (!fileInfo.Exists)
        {
            return null;
        }

        return fileInfo.CreateReadStream();
    }

    public async Task<Stream> GetVideoChunk(string videoName, string videoChunk)
    {
        var streamProvider = _fileProvider;
        var fileInfo = streamProvider.GetFileInfo(@$"{videoName}\{videoChunk}.ts");

        if (!fileInfo.Exists)
        {
            return null;
        }

        return fileInfo.CreateReadStream();
    }
}


