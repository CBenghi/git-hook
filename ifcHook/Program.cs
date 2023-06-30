// See https://aka.ms/new-console-template for more information
Console.WriteLine("Preprocessing IFCs.");
Console.WriteLine($"- running in {Environment.CurrentDirectory}");
var list = ifcHook.GitInteraction.CallGit.Run("diff --name-only --cached");
Console.WriteLine(list);
Console.WriteLine("Cancelling commit");
return -1;