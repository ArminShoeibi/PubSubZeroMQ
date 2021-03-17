using System;
using System.Text.Json;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;
using PubSubZeroMQ.Shared;
using PubSubZeroMQ.Shared.DTOs;

namespace PubSubZeroMQ.Publisher
{
    class Program
    {
        static async Task Main (string[] args)
        {
            using PublisherSocket publisherSocket = new($"@{StaticDetails.TCPAddress}");

            MessageDto messageTemplate = new MessageDto("Hello Number:", "Armin", "Shoeibi");

            for (int i = 1; i <= 1000; i++)
            {
                await Task.Delay(TimeSpan.FromSeconds(2));

                MessageDto messageToPublish = messageTemplate with
                {
                    Content = $"{messageTemplate.Content} {i}",
                    MessageId = Guid.NewGuid(),
                    DateCreated = DateTimeOffset.Now
                };
                string messageToSendJson = JsonSerializer.Serialize(messageToPublish);

                // You should call SendFrame or other send methods aftet SendMoreFrame Method.
                publisherSocket.SendMoreFrame(StaticDetails.FirstChatRoomTopic).SendFrame(messageToSendJson);
                publisherSocket.SendMoreFrame(StaticDetails.SecondChatRoomTopic).SendFrame(messageToSendJson);
            }
        }
    }
}
