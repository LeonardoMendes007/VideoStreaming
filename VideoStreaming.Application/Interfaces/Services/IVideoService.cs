using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStreaming.Application.Interfaces.Services;

public interface IVideoService
{
    Task<Stream> GetVideoAsync(string videoName);
    Task<Stream> GetVideoChunk(string videoChunk);
}
