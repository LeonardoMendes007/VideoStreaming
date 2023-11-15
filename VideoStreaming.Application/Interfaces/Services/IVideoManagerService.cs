using VideoStreaming.Application.Models;

namespace VideoStreaming.Application.Interfaces.Services;

public interface IVideoManagerService
{
    Task CreateVideo(Video video);
    Task DeleteVideo(string videoName);
    Task<IEnumerable<string>> GetVideos();
}
