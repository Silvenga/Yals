using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Yals.JsonRpc.Parsers.Tokens;

namespace Yals.JsonRpc.Parsers
{
    public class RpcHost : IDisposable
    {
        private readonly Stream _input;
        private readonly Stream _output;
        private Task _inputWorker;
        private Task _outputWorker;

        private readonly BlockingCollection<string> _inputBuffer = new BlockingCollection<string>();
        private readonly BlockingCollection<string> _outputBuffer = new BlockingCollection<string>();

        private bool _running;

        public RpcHost(Stream input, Stream output)
        {
            _input = input;
            _output = output;
        }

        public void Start()
        {
            if (_running)
            {
                throw new InvalidOperationException("Cannot start when already running.");
            }

            _running = true;

            // TODO Cancelation tokens.
            _inputWorker = Task.Run(() => InputWorkerLoop());
            _outputWorker = Task.Run(() => OutputWorkerLoop());
        }

        private void InputWorkerLoop()
        {
            var reader = new StreamReader(_input);
            var contentTokens = reader.StreamToBlocks().StreamToTokens().OfType<MessageBodyContent>();
            foreach (var content in contentTokens)
            {
                if (_inputBuffer.IsAddingCompleted || !_inputBuffer.TryAdd(content.Content))
                {
                    return;
                }
            }
        }

        private void OutputWorkerLoop()
        {
            while (!_outputBuffer.IsCompleted)
            {
                Task.Delay(10);
            }
        }

        public void Dispose()
        {
            _outputBuffer.CompleteAdding();
            _outputBuffer.CompleteAdding();
            _running = false;
        }
    }
}