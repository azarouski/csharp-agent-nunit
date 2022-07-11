using System;
using ZebrunnerAgent.Client;
using ZebrunnerAgent.Client.Responses;
using ZebrunnerAgent.Config;

namespace ZebrunnerAgent.Registrar
{
    public class RerunResolver
    {
        public static string CiRunId;
        public static bool CiIsRerun;

        public static void Resolve()
        {
            var runContext = Configuration.GetRunContext();
            if (runContext != null)
            {
                ProcessRerun(runContext);
            }
            else
            {
                CiIsRerun = false;
            }
        }

        private static string GetCiRunId()
        {
            return CiRunId;
        }

        public static bool IsRerun()
        {
            if (CiIsRerun == false)
            {
                Resolve();
            }

            return true;
        }
        
        private static void ProcessRerun(string rerunCondition)
        {
            ZebrunnerApiClient apiClient = ZebrunnerApiClient.Instance;
            ExchangeRunContextResponse response = apiClient.RerunTest(rerunCondition);

            if (response != null)
            {
                if (!response.RunExists && response.RerunOnlyFailedTests)
                {
                    throw new Exception(
                        "You cannot rerun failed tests because there is no test run with given ci run id in Zebrunner");
                }
                
                CiRunId = response.Id;
                // if (response.RunExists)
                // {
                //     List<SaveTestRunResponse> tests = response.GetTests();
                //     RerunContextHolder.SetTests(tests);
                //
                //     for (RerunListener listener :
                //     AgentListenerHolder.getRerunListeners()) {
                //         listener.onRerun(tests);
                //     }
                //
                //     isRerun = true;
                //     return;
                // }
            }

            CiIsRerun = false;
        }

    }
}