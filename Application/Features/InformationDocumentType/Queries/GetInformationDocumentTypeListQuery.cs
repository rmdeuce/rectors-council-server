﻿using Application.Features.InformationDocumentType.Queries.DTO;
using MediatR;

namespace Application.Features.InformationDocumentType.Queries
{
    public class GetInformationDocumentTypeListQuery : IRequest<InformationDocumentTypeListDTO>
    {
    }
}
