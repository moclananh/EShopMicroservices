namespace BuildingBlocks.Messaging.Events
{
   public record IntergrationEvent
    {
        public Guid Guid => Guid.NewGuid();
        public DateTime OccurredOn => DateTime.UtcNow;
        public string EventType => GetType().AssemblyQualifiedName;
    }
}
