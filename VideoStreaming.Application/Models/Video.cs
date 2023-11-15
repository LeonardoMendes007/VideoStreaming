using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStreaming.Application.Models;

public class Video
{
    public Video(IFormFile arquivoMp4)
    {
        ArquivoMp4 = arquivoMp4;
    }

    public IFormFile ArquivoMp4 { get; set; }
}
