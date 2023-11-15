using System.ComponentModel.DataAnnotations;
using VideoStreaming.API.Validators;

namespace VideoStreaming.API.Models.Request;

public class CreateVideoRequest
{
    [Required(ErrorMessage = "Por favor, selecione um arquivo.")]
    [FileExtensionsValidation]
    public IFormFile ArquivoMp4 { get; set; }
}
