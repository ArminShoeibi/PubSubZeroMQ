using System;
using System.Text.Json;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;
using PubSubZeroMQ.Shared;
using PubSubZeroMQ.Shared.DTOs;

namespace PubSubZeroMQ.Subscriber
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using SubscriberSocket subscriberSocket = new($">{StaticDetails.TCPAddress}");

            subscriberSocket.Subscribe(StaticDetails.FirstChatRoomTopic);
            subscriberSocket.Subscribe(StaticDetails.SecondChatRoomTopic);
            while (true)
            {
                string firstFrame = subscriberSocket.ReceiveFrameString();
                string secondFrame = subscriberSocket.ReceiveFrameString();
                string thirdFrame = subscriberSocket.ReceiveFrameString();
                string fourthFrame = subscriberSocket.ReceiveFrameString();
                Console.WriteLine($"\t{firstFrame}\t{secondFrame}");

                Console.WriteLine($"\t{thirdFrame}\t{fourthFrame}");
            }

        }
    }
}
