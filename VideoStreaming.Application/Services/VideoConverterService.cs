using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStreaming.Application.Interfaces.Services;

namespace VideoStreaming.Application.Services;

public class VideoConverterService : IVideoConverterService
{
    public async Task ConverterMP4toM3U8(string inputFilePath, string outputFilePath)
    {
        var _arguments = $"-i \"{inputFilePath}\" -profile:v baseline -level 3.0 -s 640x360 -start_number 0 -hls_time 10 -hls_list_size 0 -f hls \"{outputFilePath}\".m3u8";

        // Start the FFmpeg process
        Process ffmpeg = new();
        ffmpeg.StartInfo.FileName = @"D:\Videos\ffmpeg.exe"; //download ffmpeg for your OS: https://github.com/BtbN/FFmpeg-Builds/releases and  Set the path to your FFmpeg binary 
        ffmpeg.StartInfo.Arguments = _arguments;
        ffmpeg.StartInfo.UseShellExecute = false;
        ffmpeg.StartInfo.RedirectStandardOutput = true;
        ffmpeg.Start();

        // Wait for the process to finish
        ffmpeg.WaitForExit();
    }
}
