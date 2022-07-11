﻿namespace ZebrunnerAgent.Config
{
    internal interface IConfigurationProvider
    {
        bool IsReportingEnabled();

        string GetServerHost();

        string GetAccessToken();

        string GetProjectKey();

        string GetEnvironment();

        string GetBuild();

        string GetRunContext();
    }
}