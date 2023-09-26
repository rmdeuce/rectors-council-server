using MediatR;
using Domain.Entities;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Application.Features.Agendas.Queries.DTO;

namespace Application.Features.Advertisement.Commands
{
    public class UpdateAdvertisementCommandHandler : IRequestHandler<UpdateAdvertisementCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public UpdateAdvertisementCommandHandler(IAppDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public async Task<Unit> Handle(UpdateAdvertisementCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Advertisements.FirstOrDefaultAsync(e => e.Id == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.Advertisement), request.Id);

            entity.Title = request.Title;
            entity.Description = request.Description;
            foreach (var agendaDto in request.Agendas)
            {     
                if (agendaDto.AdvertisementId != entity.Id)
                {  
                    throw new Exception("This Agenda does not belong to this Advertisement");
                }

                entity.Agendas = GetAgendaList(request.Agendas);
            }

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private List<Agenda> GetAgendaList(List<AgendaDTO> input)
        {
            List<Agenda> result = new List<Agenda>();

            foreach (var agenda in input)
            {
                Agenda newAgenda = new Agenda
                {
                    
                    Id = agenda.Id,
                    AdvertisementId = agenda.AdvertisementId,
                    NewsId = agenda.NewsId,
                    Description = agenda.Description,
                    Speakers = agenda.Speakers,
                    CoSpeakers = agenda.CoSpeakers,
                };

                result.Add(newAgenda);
            }

            return result;
        }

        
    }
}
