using System;

namespace PubSubZeroMQ.Shared.DTOs
{
    public record MessageDto
    {
        public MessageDto(string content,string firstName, string lastName)
        {
            Content = content;
            FirstName = firstName;
            LastName = lastName;
        }

        public Guid MessageId { get; init; } = Guid.NewGuid();
        public DateTimeOffset DateCreated { get; init; } = DateTimeOffset.Now;
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Content { get; init; }
    }
}
