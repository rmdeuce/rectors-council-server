﻿using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.News.Commands
{
    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, int>
    {
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;

        public CreateNewsCommandHandler(IAppDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            var news = new Domain.Entities.News
            {
                PhotosUrl = request.PhotosUrl,
                Title = request.Title,
                Description = request.Description,
                MeetingDate = request.MeetingDate,
                Agendas = mapper.Map<List<Agenda>>(request.Agendas)
                
            };

            dbContext.News.Add(news);

            await dbContext.SaveChangesAsync(cancellationToken);

            return news.Id;
        }
    }
}
