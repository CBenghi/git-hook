Console.WriteLine("Preprocessing content.");
var changedTxt = ifcHook.GitInterop.GetStaged().Where(x=>x.Extension == ".txt").ToList();
foreach (var c in changedTxt)
{
    var res = ifcHook.TextChecker.Fix(c);
    if (res == ifcHook.TextChecker.Outcome.failure)
        return ConsoleInerop.ReportError($"Cancelling commit because of failed txt file fix {c.FullName}.");
}
return 0;