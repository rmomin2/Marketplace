namespace Marketplace.SharedKernel.Domain;

public interface IItemUniquenessChecker
{
    bool IsUnique(string embedding);
}
