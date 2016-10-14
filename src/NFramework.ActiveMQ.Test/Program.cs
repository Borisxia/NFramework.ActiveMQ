using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFramework.ActiveMQ.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiQueueTest();
            SingleQueueTest();

            Console.ReadLine();
        }

        static void MultiQueueTest()
        {
            TestMultiQueue queue = new TestMultiQueue();

            string queue1 = "TestQueue1";
            string queue2 = "TestQueue2";
            TestSendAndReceiveMessage(queue, queue1);
            TestSendAndReceiveMessage(queue, queue2);
        }

        static void SingleQueueTest()
        {
            TestSingleQueue queue = new TestSingleQueue();

            TestSendAndReceiveMessage(queue);
        }

        private static void TestSendAndReceiveMessage(TestMultiQueue queue, string queueName)
        {
            queue.SendTextMessage(queueName, "1", "2", "3", "4");

            while (true)
            {
                var msg = queue.ReceiveMessage(queueName);
                if (string.IsNullOrEmpty(msg))
                    break;
                Console.WriteLine("队列：{0} 收到消息：{1}", queueName, msg);
            }
        }

        private static void TestSendAndReceiveMessage(TestSingleQueue queue)
        {
            queue.SendTextMessage("1", "2", "3", "4");

            while (true)
            {
                var msg = queue.ReceiveMessage();
                if (string.IsNullOrEmpty(msg))
                    break;
                Console.WriteLine("队列：{0} 收到消息：{1}", queue.QueueName, msg);
            }
        }

        class TestMultiQueue : BaseMultiQueue
        {
            protected override string DbName
            {
                get { return "db1"; }
            }
        }

        class TestSingleQueue : BaseSingleQueue
        {
            public override string QueueName
            {
                get { return "TestSingleQueue"; }
            }

            protected override string DbName
            {
                get { return "db1"; }
            }
        }
    }
}
