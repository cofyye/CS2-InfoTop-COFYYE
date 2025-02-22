namespace InfoTop_COFYYE.Providers
{
    public class HudMessageProvider
    {
        public static InfoTopCOFYYE Instance => InfoTopCOFYYE.Instance;

        private Queue<Dictionary<string, string>> _messagesQueue = [];

        public HudMessageProvider()
        {
            ResetQueue();
        }

        public Dictionary<string, string> GetHudMessage()
        {
            if (_messagesQueue.Count == 0)
            {
                ResetQueue();
            }

            return _messagesQueue.Dequeue();
        }

        private void ResetQueue()
        {
            _messagesQueue = new Queue<Dictionary<string, string>>(
                Instance?.Config?.HudMessages.Select(m => m.Value) ?? []
            );
        }
    }
}