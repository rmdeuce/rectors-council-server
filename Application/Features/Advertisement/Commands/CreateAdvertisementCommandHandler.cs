using MediatR;
using Application.Interfaces;

namespace Application.Features.Advertisement.Commands
{
    public class CreateAdvertisementCommandHandler : IRequestHandler<CreateAdvertisementCommand, int>
    {
        private readonly IAppDBContext dbContext;

        public CreateAdvertisementCommandHandler(IAppDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public async Task<int> Handle(CreateAdvertisementCommand request, CancellationToken cancellationToken)
        {
            var advertisment = new Domain.Entities.Advertisement
            {
                Title = request.Title,
                Description = request.Description,
                Agendas = request.Agendas
            };

            dbContext.Advertisements.Add(advertisment);

            await dbContext.SaveChangesAsync(cancellationToken);

            return advertisment.Id;
        }
    }
}
