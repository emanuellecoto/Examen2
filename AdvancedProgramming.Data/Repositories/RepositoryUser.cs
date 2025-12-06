namespace AdvancedProgramming.Data.Repositories
{
    /// <summary>
    /// Repository interface for User entities.
    /// Defines the contract for User-specific data access operations.
    /// </summary>
    public interface IRepositoryUser : IRepositoryBase<UserDetail>
    {
    }

    /// <summary>
    /// Repository implementation for User entities.
    /// Provides data access operations for User entities using Entity Framework.
    /// </summary>
    public class RepositoryUser : RepositoryBase<UserDetail>, IRepositoryUser
    {
        /// <summary>
        /// Initializes a new instance of the RepositoryUse r class.
        /// </summary>
        public RepositoryUser() : base()
        {
        }
    }
}
