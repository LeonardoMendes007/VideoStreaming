using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStreaming.Application.Exceptions;
using VideoStreaming.Application.Interfaces.Services;
using VideoStreaming.Application.Models;

namespace VideoStreaming.Application.Services;

public class VideoManagerService : IVideoManagerService
{
    private readonly IVideoConverterService _videoConverterService;
    private readonly IFileProvider _fileProvider;

    public VideoManagerService(IFileProvider fileProvider ,IVideoConverterService videoConverterService)
    {
        this._fileProvider = fileProvider;
        this._videoConverterService = videoConverterService;
    }
    public async Task CreateVideo(Video video)
    {
        if (video.ArquivoMp4 != null && video.ArquivoMp4.Length > 0)
        {

            var fileName = video.ArquivoMp4.FileName.ToLower().Replace(".mp4", "");
            var DirecInfo = Directory.CreateDirectory(@$"D:\Videos\{fileName}");

            // Cria um nome temporário para o arquivo
            string caminhoTemporario = @$"{DirecInfo.FullName}\{fileName}.mp4";

            // Salva o conteúdo do arquivo temporariamente
            using (var stream = File.Create(caminhoTemporario))
            {
                video.ArquivoMp4.CopyTo(stream);
            }

            await this._videoConverterService.ConverterMP4toM3U8(@$"{caminhoTemporario}", $@"{DirecInfo.FullName}\{fileName}");

            File.Delete(caminhoTemporario);
        }
    }

    public async Task DeleteVideo(string videoName)
    {
        if (!Directory.Exists(@$"D:\Videos\{videoName}"))
            throw new VideoNotFoundException();

        Directory.Delete(@$"D:\Videos\{videoName}");
    }

    public async Task<IEnumerable<string>> GetVideos()
    {
        return Directory.GetDirectories(@$"D:\Videos\").ToList().ConvertAll(x => Path.GetFileName(x)).ToList();
    }
}
