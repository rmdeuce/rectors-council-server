﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ConstituentDocuments.Commands
{
    public class DeleteConstituentDocumentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
