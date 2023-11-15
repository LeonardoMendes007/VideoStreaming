using System.ComponentModel.DataAnnotations;

namespace VideoStreaming.API.Validators;

public class FileExtensionsValidation : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            IFormFile file = (IFormFile)value;
            string extention = Path.GetExtension(file.FileName);

            if (extention != ".mp4")
            {
                return new ValidationResult("O arquivo deve ser no formato mp4.");
            }
        }

        return ValidationResult.Success;

    }
}
