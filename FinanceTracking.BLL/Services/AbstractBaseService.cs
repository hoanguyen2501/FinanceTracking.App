using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FinanceTracking.BLL.Services
{
    public abstract class AbstractBaseService
    {
        protected IMapper Mapper { get; }
        protected ILogger Logger { get; }

        protected AbstractBaseService(IMapper mapper, ILogger logger) =>
            (Mapper, Logger) = (mapper, logger);

        protected AbstractBaseService(IServiceProvider provider, ILogger logger) :
            this(provider.GetRequiredService<IMapper>(), logger)
        {
        }
    }
}
