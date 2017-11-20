namespace StopwatchService.Domain.Entities
{
    /// <summary>
    /// Responsible for receive only the stopwatch data that will be returned to the client.
    /// </summary>
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