using System;
using System.Threading;
using System.Threading.Tasks;

namespace Yaringa.ViewModels {
    /// <summary>
    /// This class provides message settings for all the action code when executed in ViewModel's command.
    /// See <see cref="ViewModel"/> for how to use this class.
    /// This class is renamed from class MessageSettings. 
    /// Search MessageSettings.cs if you want to read the whole class history.
    /// </summary>
    public class InvokingSettings {
        public string BusyMessage { get; set; } = "Loading...";
        public ConfirmationMessageSettings Confirmation { get; set; }
        public ErrorMessageSettings Error { get; set; }
        public InfoMessageSettings Info { get; set; }

        //Providing post-processing (i.e. page navigation) after an action is invoked successfully.
        public Func<Task> Callback { get; set; }
    }

    /// <summary>
    /// This class provides the settings for a confirmation message box before an action is going to be executed.
    /// </summary>
    public class ConfirmationMessageSettings {
        public string Message { get; set; }
        public string Title { get; set; }
        public string OkButtonLabel { get; set; } = "OK";
        public string CancelButtonLabel { get; set; } = "Cancel";
        public CancellationToken? CancellationToken { get; set; } = null;
    }

    /// <summary>
    /// This class provides the settings for an error message box after an action fails.
    /// </summary>
    public class ErrorMessageSettings {
        public string Message { get; set; }
        public string Title { get; set; } = "Error";
        public string ButtonLabel { get; set; } = "OK";
        public CancellationToken? CancellationToken { get; set; } = null;
    }

    /// <summary>
    /// This class provides the settings for an information message box after an action succeeds.
    /// </summary>
    public class InfoMessageSettings {
        public string Message { get; set; }
        public string Title { get; set; } = "";
        public string ButtonLabel { get; set; } = "OK";
        public CancellationToken? CancellationToken { get; set; } = null;
    }
}
