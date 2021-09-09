using System;
using System.Collections.Generic;

namespace NetStreams.ControlCenter.Models
{
    public class StreamProcessor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Running { get; set; }
        public DateTimeOffset LastStarted { get; set; }
        public DateTimeOffset LastHeartBeat { get; set; }
        public List<StreamPartition> StreamPartitions { get; set; } = new List<StreamPartition>();

        public StreamProcessor()
        {

        }
    }
}
