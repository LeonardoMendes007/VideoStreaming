using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using VideoStreaming.Application.Interfaces.Services;

namespace VideoStreaming.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly ILogger<VideoController> _logger;
        private readonly IVideoService _videoService;

        public VideoController(ILogger<VideoController> logger, IVideoService videoService)
        {
            _logger = logger;
            _videoService = videoService;
        }

        [HttpGet("{videoName}.m3u8")]
        public async Task<IActionResult> GetVideo(string videoName)
        {
            var stream = await _videoService.GetVideoAsync(videoName);

            if(stream is null)
            {
                return NotFound();
            }

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType($"{videoName}.m3u8", out var contentType))
            {
                contentType = "application/vnd.apple.mpegurl";
            }

            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return new FileStreamResult(stream, contentType);
        }

        [HttpGet("{videoChunk}.ts")]
        public async Task<IActionResult> GetVideoChunk(string videoChunk)
        {
            var stream = await _videoService.GetVideoChunk(videoChunk);

            if (stream is null)
            {
                return NotFound();
            }

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType($"{videoChunk}.ts", out var contentType))
            {
                contentType = "video/mp2t";
            }

            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return new FileStreamResult(stream, contentType);
        }
    }
}
