using Homework5.Mapper;
using Homework5.Repository;
using Homework5Client.DTO;
using MassTransit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Homework5.Consumers
{
	public class GetDirectorConsumer : IConsumer<GetDirectorRequest>
	{
		private readonly IDirectorRepository _repository;
		private readonly IGetDirectorMapper _mapper;

		public GetDirectorConsumer(IDirectorRepository repository, IGetDirectorMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public async Task Consume(ConsumeContext<GetDirectorRequest> context)
		{
			GetDirectorResponse response = new();

			var director = await _repository.Read(context.Message.Id);
			if (director == null)
			{
				response.StatuseCode = false;
				response.Errors = new List<string>();
				response.Errors.Add("нет такого директора");
				await context.RespondAsync<GetDirectorResponse>(response);
				return;
			}

			response = _mapper.Map(director);
			response.StatuseCode = true;
			await context.RespondAsync<GetDirectorResponse>(response);
		}
	}
}
