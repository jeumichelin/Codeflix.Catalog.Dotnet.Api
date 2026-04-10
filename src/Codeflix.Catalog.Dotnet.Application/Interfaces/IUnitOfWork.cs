namespace Codeflix.Catalog.Dotnet.Application.Interfaces;

public interface IUnitOfWork
{
    public Task Commit(CancellationToken cancellationToken);

    public Task Rollback(CancellationToken cancellationToken);
}
