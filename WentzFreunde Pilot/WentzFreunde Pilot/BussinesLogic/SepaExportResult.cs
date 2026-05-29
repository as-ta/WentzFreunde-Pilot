public class SepaExportResult
{
    public int Exportiert { get; set; }
    public int Ausgelassen { get; set; }
    public List<string> Warnungen { get; set; } = new List<string>();
}