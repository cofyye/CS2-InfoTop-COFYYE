namespace InfoTop_COFYYE.Providers
{
    public class InfoTopTextProvider
    {
        public static InfoTopCOFYYE Instance => InfoTopCOFYYE.Instance;

        private readonly Queue<KeyValuePair<string, Dictionary<string, string>>> _messagesQueue;

        public InfoTopTextProvider()
        {
            _messagesQueue = new Queue<KeyValuePair<string, Dictionary<string, string>>>(
                Instance?.Config?.InfoTopTextMessages ?? []
            );
        }

        public string GetInfoTopTextMessage(string language)
        {
            if (_messagesQueue.Count == 0)
            {
                ResetQueue();
            }

            var messageEntry = _messagesQueue.Dequeue();
            return messageEntry.Value.TryGetValue(language, out var message) ? message : "";
        }

        private void ResetQueue()
        {
            foreach (var message in Instance?.Config.InfoTopTextMessages ?? [])
            {
                _messagesQueue.Enqueue(message);
            }
        }
    }
}
