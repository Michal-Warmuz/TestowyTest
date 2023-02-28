using Contract.Repository;
using Mediator.Enums;
using Mediator.Query;

namespace UsersModule.Query.GetAllUsers
{
    public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, IEnumerable<GetAllUsersResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<QueryResult<IEnumerable<GetAllUsersResponse>>> Handle(GetAllUsersQuery query, CancellationToken cancellation)
        {
            var users = await _userRepository.GetAllAsync();

            var result = users.Select(x => new GetAllUsersResponse()
            {
                CreatedAt = x.CreatedAt,
                LastLoginDate = x.LastLoginDate,
                Login = x.Login
            });

            return new QueryResult<IEnumerable<GetAllUsersResponse>>(ResponseStatus.Ok, result);
        }
    }
}
