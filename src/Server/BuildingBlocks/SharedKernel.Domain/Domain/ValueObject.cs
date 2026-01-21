using System.Reflection;

namespace Marketplace.SharedKernel.Domain;
public abstract record ValueObject
{
    protected static void CheckRule(IBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }
}