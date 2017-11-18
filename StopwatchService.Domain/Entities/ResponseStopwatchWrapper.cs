namespace StopwatchService.Domain.Entities
{
    public class ResponseStopwatchWrapper
    {
        public ResponseStopwatchWrapper(string name, int elapsedTime)
        {
            this.Name = name;
            this.ElapsedTime = elapsedTime;
        }

        public string Name { get; set; }
        public int ElapsedTime { get; set; }
    }
}