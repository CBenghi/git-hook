Console.WriteLine("Preprocessing content.");
var changedTxt = ifcHook.GitInterop.GetStaged().Where(x=>x.Extension == ".txt").ToList();
if (changedTxt.Any())
    return ConsoleInerop.ReportError("Cancelling commit because of staged txt files.");
return 0;