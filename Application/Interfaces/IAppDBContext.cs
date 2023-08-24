using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IAppDBContext
    {
        DbSet<Advertisement> Advertisements { get; set; }
        DbSet<Agenda> Agendas { get; set; }
        DbSet<ConstituentDocument> ConstituentDocuments { get; set; }
        DbSet<Council> Councils { get; set; }
        DbSet<CouncilMember> CouncilMembers { get; set; }
        DbSet<CouncilPosition> CouncilPositions { get; set; }
        DbSet<InformationDocument> InformationDocuments { get; set; }
        DbSet<InformationDocumentType> InformationDocumentTypes { get; set; }
        DbSet<News> News { get; set; }
        DbSet<PhoneNumber> PhoneNumbers { get; set; }
        DbSet<WorkPlan> WorkPlans { get; set; }
        DbSet<University> Universities { get; set; }
        DbSet<CouncilMemberUniversityPosition> CouncilMemberUniversityPositions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
