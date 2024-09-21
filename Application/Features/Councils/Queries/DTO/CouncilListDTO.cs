namespace Application.Features.Councils.Queries.DTO
{
    public class CouncilListDTO
    {
        public int Total { get; set; }

        public IList<CouncilDTO> Councils { get; set; }
    }
}
