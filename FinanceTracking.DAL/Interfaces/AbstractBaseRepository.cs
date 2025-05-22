using AutoMapper;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FinanceTracking.DAL.Interfaces
{
    public abstract class AbstractBaseRepository
    {
        protected IMapper Mapper { get; }
        protected ILogger Logger { get; }

        protected AbstractBaseRepository(IMapper mapper, ILogger logger) =>
            (Mapper, Logger) = (mapper, logger);

        protected AbstractBaseRepository(IServiceProvider provider, ILogger logger)
        {
            Mapper = provider.GetRequiredService<IMapper>();
            Logger = logger;
        }
    }
}