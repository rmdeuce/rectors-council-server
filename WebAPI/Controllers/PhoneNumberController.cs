using Application.Features.PhoneNumber.Commands;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DTO.PhoneNumber;

namespace WebAPI.Controllers
{
    public class PhoneNumberController : BaseController
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public PhoneNumberController(IMapper mapper, ILoggerFactory loggerFactory)
        {
            this.mapper = mapper;
            this.logger = loggerFactory.CreateLogger("Phone number info");
        }

        [Authorize(Roles = "Content manager")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePhoneNumberDTO dto)
        {
            var command = mapper.Map<UpdatePhoneNumberCommand>(dto);

            await Mediator.Send(command);

            logger.LogInformation($"User{UserEmail} updated Phone number with id: {dto.Id}");

            return NoContent();
        }

        [Authorize(Roles = "Content manager")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePhoneNumberCommand
            {
                Id = id
            };

            await Mediator.Send(command);

            logger.LogInformation($"User {UserEmail} deleted Phone number with id: {id}");

            return NoContent();
        }

    }
}
