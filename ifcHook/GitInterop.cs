namespace ifcHook;
public class GitInterop
{
    public static IEnumerable<FileInfo> GetStaged()
    {
        var list = ifcHook.GitInterop.Run("diff --name-only --cached");
        // Console.WriteLine(list);
        var changed = list.Split(new char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
        foreach (var changedFile in changed)
        {
            var combined = Path.Combine(Environment.CurrentDirectory, changedFile);
            if (File.Exists(combined))
                yield return new FileInfo(combined);
        }
    }

    public static string Run(string parameters)
    {
        if (string.IsNullOrEmpty(parameters))
            return string.Empty;
        System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
        pProcess.StartInfo.FileName = "git"; //path and file name of command to run, if not in path
        pProcess.StartInfo.Arguments = parameters; // parameters to pass to program
        pProcess.StartInfo.UseShellExecute = false;
        pProcess.StartInfo.RedirectStandardOutput = true; // Set output of program to be written to process output stream
        pProcess.Start(); //Start the process
        string strOutput = pProcess.StandardOutput.ReadToEnd(); //Get program output       
        pProcess.WaitForExit(); //Wait for process to finish
        return strOutput;
    }
}
