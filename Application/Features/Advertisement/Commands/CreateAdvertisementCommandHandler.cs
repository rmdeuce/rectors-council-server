using MediatR;
using Application.Interfaces;
using Domain.Entities;
using Application.Features.Agendas.Queries.DTO;
using AutoMapper;

namespace Application.Features.Advertisement.Commands
{
    public class CreateAdvertisementCommandHandler : IRequestHandler<CreateAdvertisementCommand, int>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public CreateAdvertisementCommandHandler(IAppDBContext dbcontext, IMapper mapper)
        {
            this.dbContext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateAdvertisementCommand request, CancellationToken cancellationToken)
        {
            var advertisment = new Domain.Entities.Advertisement
            {
                Title = request.Title,
                Description = request.Description,
                MeetingDate = request.MeetingDate,
                Agendas = mapper.Map<List<Agenda>>(request.Agendas)
            };

            dbContext.Advertisements.Add(advertisment);

            await dbContext.SaveChangesAsync(cancellationToken);

            return advertisment.Id;
        }
    }
}
