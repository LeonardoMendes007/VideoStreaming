using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStreaming.Application.Interfaces.Services;

public interface IVideoConverterService
{
    Task ConverterMP4toM3U8(string inputFilePath, string outputFilePath);
}
