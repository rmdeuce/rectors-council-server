using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UploadableFile
{
    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, string>
    {
        public async Task<string> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            var file = request.File;

            var filePath = request.FilePath;

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }
    }
}
