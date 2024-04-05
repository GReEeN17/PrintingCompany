using AutoPiterTest.Infrastructure.Entities.Abstractions;
using EntityFrameworkCore.Triggered;

namespace AutoPiterTest.Infrastructure.Implementations.Abstractions;

public class EntityTrigger : IBeforeSaveTrigger<Entity>
{
    public Task BeforeSave(ITriggerContext<Entity> context, CancellationToken cancellationToken)
    {
        if (context.ChangeType is ChangeType.Added)
        {
            context.Entity.CreatedAt = DateTime.UtcNow;
            context.Entity.UpdatedAt = DateTime.UtcNow;
            context.Entity.IsActive = true;
        }
        
        if (context.ChangeType is ChangeType.Modified)
        {
            context.Entity.UpdatedAt = DateTime.UtcNow;
        }

        return Task.CompletedTask;
    }
}