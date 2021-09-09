using MediatR;
using NetStreams.ControlCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetStreams.ControlCenter.WebApi.Queries
{
    public class GetAllStreamProcessorsQuery: IRequest<List<StreamProcessor>>
    {
    }
}
