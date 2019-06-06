using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
using System.Diagnostics;

namespace CDS.Shared.Exception
{
    public class ExceptionLibrary
    {
        public static void Initialise() 
        {
            var builder = new ConfigurationSourceBuilder();
            builder.ConfigureLogging()
                .WithOptions
                    .DoNotRevertImpersonation()
                .LogToCategoryNamed("General")
                    .WithOptions
                        .SetAsDefaultCategory()
                    .SendTo
                        .RollingFile("Rolling Flat File Trace Listener")
                            .ToFile(@"log\trace.log")
                            .WithHeader("----------------------")
                            .RollAfterSize(50)
                            .UseTimeStampPattern("MM_dd_yyyy")
                            .WhenRollFileExists(RollFileExistsBehavior.Increment)
                            .RollEvery(RollInterval.Day)
                            .WithTraceOptions(TraceOptions.Callstack | TraceOptions.DateTime | TraceOptions.LogicalOperationStack | TraceOptions.ProcessId | TraceOptions.ThreadId | TraceOptions.Timestamp)
                            .CleanUpArchivedFilesWhenMoreThan(5);

            var exceptionhandling = builder.ConfigureExceptionHandling();

            //exceptionhandling
            //    .GivenPolicyWithName("PassThroughPolicy")
            //    .ForExceptionType<System.Exception>()
            //        .ReplaceWith<PassThroughException>()
            //        .ThenNotifyRethrow();

            //exceptionhandling
            //    .GivenPolicyWithName("BusinessLogicPolicy")
            //    .ForExceptionType<System.Exception>()
            //        .LogToCategory("General")
            //            .WithSeverity(System.Diagnostics.TraceEventType.Error)
            //            .WithPriority(0)
            //            .UsingEventId(100)
            //        .ReplaceWith<UserInterfaceException>()
            //            .UsingMessage("A User Interface Error Happened.")
            //        .ThenThrowNewException();

            exceptionhandling
                .GivenPolicyWithName("UserInterfacePolicy")
                .ForExceptionType<System.Exception>()
                    .LogToCategory("General")
                        .WithSeverity(System.Diagnostics.TraceEventType.Error)
                        .WithPriority(0)
                        .UsingEventId(100)
                    .ReplaceWith<UserInterfaceException>()
                        .UsingMessage("A User Interface Error Happened.")

                    //Werner: Removed this so that it shows the Dialogue and restarts the system (2014-10-20)
                    //.ThenThrowNewException()
                    ;



            /*

            ConfigurationSourceBuilder formatBuilder = new ConfigurationSourceBuilder();

            ConfigurationSourceBuilder builder = new ConfigurationSourceBuilder();
            builder.ConfigureLogging().LogToCategoryNamed("General").
                SendTo.
                RollingFile("Rolling Flat File Trace Listener")
                .CleanUpArchivedFilesWhenMoreThan(2).WhenRollFileExists(RollFileExistsBehavior.Increment)
                .WithTraceOptions(TraceOptions.None)
                .RollEvery(RollInterval.Minute)
                .RollAfterSize(10)
                .UseTimeStampPattern("yyyy-MM-dd")
                .ToFile("log\trace.log")
                .FormatWith(new FormatterBuilder().TextFormatterNamed("textFormatter"));
            */

            var configSource = new DictionaryConfigurationSource();
            builder.UpdateConfigurationWithReplace(configSource);
            EnterpriseLibraryContainer.Current = EnterpriseLibraryContainer.CreateDefaultContainer(configSource);

            /*
            var writer = EnterpriseLibraryContainer.Current.GetInstance<Microsoft.Practices.EnterpriseLibrary.Logging.LogWriter>();

            DateTime stopWritingTime = DateTime.Now.AddMinutes(10);
            while (DateTime.Now < stopWritingTime)
            {
                writer.Write("test", "General");
            }
            */
        }
    }
}
