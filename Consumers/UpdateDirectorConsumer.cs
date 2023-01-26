using Homework5.Mapper;
using Homework5.Repository;
using Homework5Client.DTO;
using MassTransit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Homework5.Consumers
{
	public class UpdateDirectorConsumer : IConsumer<UpdateDirectorRequest>
	{
		private readonly IDirectorRepository _repository;
		private readonly IUpdateDirectorMapper _mapper;

		public UpdateDirectorConsumer(IDirectorRepository repository, IUpdateDirectorMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public async Task Consume(ConsumeContext<UpdateDirectorRequest> context)
		{
			UpdateDirectorResponse response = new();

			var director = await _repository.Update(context.Message.Id, context.Message.Name, context.Message.SurName);

			if (director == null)
			{
				response.StatuseCode = false;
				response.Errors = new List<string>();
				response.Errors.Add("нет такого директора");
				await context.RespondAsync<UpdateDirectorResponse>(response);
				return;
			}

			response = _mapper.Map(director);
			response.StatuseCode = true;
			await context.RespondAsync<UpdateDirectorResponse>(response);
		}
	}
}
