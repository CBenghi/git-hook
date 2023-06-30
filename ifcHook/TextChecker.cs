namespace ifcHook;

public class TextChecker
{
    public enum Outcome
    {
        failure,
        modified,
        unmodified
    }


    public static Outcome Fix(FileInfo f)
    {
        var lines = File.ReadAllLines(f.FullName);
        var last = lines.LastOrDefault(x=>!string.IsNullOrEmpty(x));
        if (last is null)
        {
            using var mf = f.AppendText();
            mf.WriteLine($"{DateTime.Now:o}");
            return Outcome.modified;
        }
        if (last == "stamp")
        {
            Console.WriteLine("Adding timestamp.");
            using var ts = f.AppendText();
            ts.WriteLine($"{DateTime.Now:o}");
            return Outcome.modified ;
        }
        if (last == "no")
        {
            Console.WriteLine("Stopping becasue of explicit no clause.");
            return Outcome.failure;
        }
        var readOk = DateTime.TryParse(last, out var read);
        if (!readOk)
        {
            Console.WriteLine("Stopping becasue of parsing date problem.");
            return Outcome.failure;
        }
        var diff = DateTime.Now - read;
        if (diff < new TimeSpan(0,1,0))
        {
            Console.WriteLine($"unmodified becasue of diff: {diff}");
            return Outcome.unmodified;
        }
        Console.WriteLine($"Added timestamp.");
        using var t = f.AppendText();
        t.WriteLine($"{DateTime.Now:o}");
        return Outcome.modified;
    }
}