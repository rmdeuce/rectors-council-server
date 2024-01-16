using Application.Common.Exceptions;
using Application.Features.Agendas.Queries.DTO;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.News.Commands
{
    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, Unit>
    {
        private readonly IAppDBContext dbContext;

        public UpdateNewsCommandHandler(IAppDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.News.Include(e => e.Agendas).FirstOrDefaultAsync(e => e.Id == request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.News), request.Id);

            entity.Title = request.Title;
            entity.PhotosUrl = request.PhotosUrl;
            entity.Description = request.Description;
            entity.Agendas = UpdateAgendaListByNews(entity.Agendas, request.Agendas);

            await dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private List<Agenda> UpdateAgendaListByNews(List<Agenda> agendaList, List<AgendaDTO> agendaDTOList)
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
