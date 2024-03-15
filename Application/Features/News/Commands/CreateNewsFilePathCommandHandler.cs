using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.News.Commands
{
    public class CreateNewsFilePathCommandHandler : IRequestHandler<CreateNewsFilePathCommand, string>
    {
        public async Task<string> Handle(CreateNewsFilePathCommand request, CancellationToken cancellationToken)
        {
            var fileName = Path.GetFileName(request.File.FileName);
            var directoryPath = request.DirectoryPath;
            var filePath = Path.Combine(directoryPath, fileName);

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.File.CopyToAsync(stream);
            }

            return filePath;
        }
    }
}
