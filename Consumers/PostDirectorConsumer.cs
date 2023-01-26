using Homework5Client.DTO;
using MassTransit;
using System.Threading.Tasks;
using System;
using Homework5.Repository;
using Homework5.Mapper;

namespace Homework5.Consumers
{
	public class PostDirectorConsumer : IConsumer<PostDirectorRequest>
	{
		private readonly IDirectorRepository _repository;
		private readonly IPostDirectorMapper _mapper;

		public PostDirectorConsumer(IDirectorRepository repository, IPostDirectorMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public async Task Consume(ConsumeContext<PostDirectorRequest> context)
		{
			PostDirectorResponse response = new();

			var director = await _repository.Create(_mapper.Map(context.Message));
			response.Id = director;
			response.StatusCode = true;
			await context.RespondAsync<PostDirectorResponse>(response);
		}
	}
}
