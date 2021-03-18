using System.Collections.Generic;
using System.IO;
using System.Linq;
using Business.Constants;
using Entities.Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImagesOperationDtoValidator : AbstractValidator<CarImagesOperationDto>
    {
        public CarImagesOperationDtoValidator()
        {
            RuleFor(p => p.Images).NotNull();
            RuleFor(p => p.CarId).NotEmpty();
            RuleFor(p => p.CarId).NotNull();
            RuleFor(p => p.Images).Must(CheckIfImageLengh)
                .WithMessage(Messages.ImageNotFound);
            RuleFor(p => p.Images).Must(CheckIfFileExtension)
                .WithMessage(Messages.IncorrectFileExtension);
        }

        private bool CheckIfImageLengh(List<IFormFile> args)
        {
            if (args == null) return false; // args null kontrolünden geçemiyorsa

            foreach (var image in args)
            {
                if (image.Length <= 0)
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckIfFileExtension(List<IFormFile> args)
        {
            if (args == null) return false; // args null kontrolünden geçemiyorsa
            var acceptableExtensions = new List<string> { ".png", ".jpeg", ".jpg" };


            foreach (var image in args)
            {
                if (acceptableExtensions.All(c => c != Path.GetExtension(image.FileName).ToLower()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}