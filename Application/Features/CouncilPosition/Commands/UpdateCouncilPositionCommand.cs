﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CouncilPosition.Commands
{
    public class UpdateCouncilPositionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
