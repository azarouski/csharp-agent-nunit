using System.Collections.Generic;

namespace ZebrunnerAgent.Client.Responses
{
    internal class ExchangeRunContextResponse
    {
        public string Id { get; set; }
        public bool RunExists { get; set; }
        public bool RerunOnlyFailedTests { get; set; }
    }
}