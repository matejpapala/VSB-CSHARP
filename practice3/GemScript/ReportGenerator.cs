using System;

namespace GemScript;

public class ReportGenerator
{
    public static void UlozitReport(string path, IEnumerable<SkladovaPolozka> data) {
        using(FileStream fs = new FileStream(path, FileMode.Create)) {
            using(StreamWriter sr = new StreamWriter(fs)) {
                foreach(SkladovaPolozka item in data) {
                    sr.WriteLine(item.ToString());
                }
            }
        }
    }
}
