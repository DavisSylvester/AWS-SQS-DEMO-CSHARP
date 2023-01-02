using cdk = Amazon.CDK;
using SQS = Amazon.CDK.AWS.SQS;
using Constructs;
using Amazon.CDK;

namespace HelloCdk
{
    public class HelloCdkStack : cdk.Stack
    {
        internal HelloCdkStack(Construct scope, string id, cdk.IStackProps props = null) : base(scope, id, props)
        {


            // The code that defines your stack goes here
            var testQueue = new SQS.Queue(this, "CdkLabQueue", new SQS.QueueProps
            {
                VisibilityTimeout = Duration.Seconds(300),
                QueueName = "test-davis-one.fifo",
                Fifo = true,
                DeadLetterQueue = new SQS.DeadLetterQueue()
                {
                    MaxReceiveCount = 3,
                    Queue = new SQS.Queue(this, "dlqCdkLabQueue", new SQS.QueueProps
                    {
                        QueueName = "test-davis-one-dql.fifo",
                    })
                }
            });

            var testQueueTwo = new SQS.Queue(this, "CdkLabQueueTwo", new SQS.QueueProps
            {
                VisibilityTimeout = Duration.Seconds(300),
                QueueName = "test-davis-two"
            });

            // var producerLambda = new Lambda
        }
    }
}
