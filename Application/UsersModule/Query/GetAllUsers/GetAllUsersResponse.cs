namespace UsersModule.Query.GetAllUsers
{
    public record GetAllUsersResponse
    {
        public string Login { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? LastLoginDate { get; init; }
    }
}
