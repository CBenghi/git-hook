Console.WriteLine("Preprocessing content.");
var changedTxt = ifcHook.GitInterop.GetStaged().Where(x=>x.Extension == ".txt").ToList();
if (changedTxt.Any())
{
    Console.WriteLine("Cancelling commit because of staged txt files.");
    return 1;
}
return 0;