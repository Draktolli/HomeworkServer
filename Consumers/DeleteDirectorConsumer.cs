using Homework5.Mapper;
using Homework5.Repository;
using Homework5Client.DTO;
using MassTransit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Homework5.Consumers
{
	public class DeleteDirectorConsumer : IConsumer<DeleteDirectorRequest>
	{
		private readonly IDirectorRepository _repository;

		public DeleteDirectorConsumer(IDirectorRepository repository)
		{
			_repository = repository;
		}
		public async Task Consume(ConsumeContext<DeleteDirectorRequest> context)
		{
			DeleteDirectorResponse response = new();

			var director = await _repository.Delete(context.Message.Id);
			if (director == null)
			{
				response.StatuseCode = false;
				response.Errors = new List<string>();
				response.Errors.Add("нет такого директора");
				await context.RespondAsync<DeleteDirectorResponse>(response);
				return;
			}

			response.StatuseCode = true;
			await context.RespondAsync<DeleteDirectorResponse>(response);
		}
	}
}
