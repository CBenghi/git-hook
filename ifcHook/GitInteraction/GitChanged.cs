namespace ifcHook.GitInteraction;
public class CallGit
{
    public static string Run(string parameters)
    {
        if (string.IsNullOrEmpty(parameters))
            return string.Empty;
        
        System.Diagnostics.Process pProcess = new System.Diagnostics.Process();

        //strCommand is path and file name of command to run
        pProcess.StartInfo.FileName = "git";

        //strCommandParameters are parameters to pass to program
        pProcess.StartInfo.Arguments = parameters;

        pProcess.StartInfo.UseShellExecute = false;

        //Set output of program to be written to process output stream
        pProcess.StartInfo.RedirectStandardOutput = true;   



        //Start the process
        pProcess.Start();

        //Get program output
        string strOutput = pProcess.StandardOutput.ReadToEnd();

        //Wait for process to finish
        pProcess.WaitForExit();
        return strOutput;
    }
}
