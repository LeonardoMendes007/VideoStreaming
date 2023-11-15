using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using VideoStreaming.API.Models.Request;
using VideoStreaming.API.Models.Response;
using VideoStreaming.Application.Exceptions;
using VideoStreaming.Application.Interfaces.Services;
using VideoStreaming.Application.Models;

namespace VideoStreaming.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoManagerController : ControllerBase
    {
        private readonly ILogger<VideoController> _logger;
        private readonly IVideoManagerService _videoManagerService;

        public VideoManagerController(ILogger<VideoController> logger, IVideoManagerService videoManagerService)
        {
            _logger = logger;
            _videoManagerService = videoManagerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideo([FromForm] CreateVideoRequest createVideoRequest)
        {
            if (createVideoRequest.ArquivoMp4 != null && createVideoRequest.ArquivoMp4.Length > 0)
            {
                try
                {
                    var video = new Video(createVideoRequest.ArquivoMp4);

                    await _videoManagerService.CreateVideo(video);

                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.StackTrace);
                    return StatusCode(500, "Não foi possivel salvar seu video.");

                }
            }
            else
            {
                return BadRequest();
            }
            
        }

        [HttpDelete("videoName")]
        public async Task<IActionResult> DeleteVideo(string videoName)
        {
            try
            {
                return NoContent();
            }
            catch (VideoNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return StatusCode(500, "Não foi possivel salvar seu video.");
            }
            
        }


        [HttpGet]
        public async Task<IActionResult> GetVideos()
        {
            try
            {
                return Ok(new ResponseBase<IEnumerable<string>>((await _videoManagerService.GetVideos())));
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return StatusCode(500, "Não foi possivel salvar seu video.");
            }

        }
    }
}
