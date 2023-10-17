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
            var entity = await dbContext.Advertisements.Include(e => e.Agendas).FirstOrDefaultAsync(e => e.Id == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.Advertisement), request.Id);

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Agendas = UpdateAgendaListByAdvertisement(entity.Agendas, request.Agendas);

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private List<Agenda> UpdateAgendaListByAdvertisement(List<Agenda> agendaList, List<AgendaDTO> agendaDTOList)
        {
            List<Agenda> result = new List<Agenda>();

            foreach (var agenda in agendaList)
            {
                if (!agenda.IsDeleted)
                {
                    var agendaDTO = agendaDTOList.FirstOrDefault(a => a.Id == agenda.Id);

                    if (agendaDTO != null)
                    {
                        agenda.Description = agendaDTO.Description;
                        agenda.Speakers = agendaDTO.Speakers;
                        agenda.CoSpeakers = agendaDTO.CoSpeakers;
                    }
                }

                result.Add(agenda);
            }

            return result;
        }    
    }
}
