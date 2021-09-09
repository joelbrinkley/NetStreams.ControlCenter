using MediatR;
using Microsoft.EntityFrameworkCore;
using NetStreams.ControlCenter.Infrastructure.EntityFrameworkCore;
using NetStreams.ControlCenter.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetStreams.ControlCenter.WebApi.Queries
{
    public class GetAllStreamProcessorsQueryHandler : IRequestHandler<GetAllStreamProcessorsQuery, List<StreamProcessor>>
    {
        private readonly TelemetryDbContext _dbContext;

        public GetAllStreamProcessorsQueryHandler(TelemetryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StreamProcessor>> Handle(GetAllStreamProcessorsQuery request, CancellationToken cancellationToken)
        {
            var streamProcessors = await _dbContext.StreamProcessors.Include(sp => sp.StreamPartitions).ToListAsync(cancellationToken);
            return streamProcessors;
        }
    }
}
