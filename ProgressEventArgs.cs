namespace xModel_Gen
{
    public class ProgressEventArgs
    {
        public string Message { get; set; }
        public int Progress { get; set; }
        public Node NodeUpdated { get; set; }
    }
}