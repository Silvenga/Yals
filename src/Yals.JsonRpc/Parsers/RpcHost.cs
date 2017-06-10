using System;
using System.IO;
using System.Threading.Tasks;

namespace Yals.JsonRpc.Parsers
{
    public class RpcHost : IDisposable
    {
        private readonly Stream _input;
        private readonly Stream _output;
        private Task _inputWorker;

        private bool _running;

        public RpcHost(Stream input, Stream output)
        {
            _input = input;
            _output = output;
        }

        public void Start()
        {
            _running = true;

            // TODO Cancelation tokens.
            _inputWorker = Task.Run(() => InputWorkerLoop());
        }

        private void InputWorkerLoop()
        {
            var reader = new StreamReader(_input);
            //var lines = reader.StreamToBlocks().StreamToLines();
            //foreach (var line in lines)
            //{
            //    if (!_running)
            //    {
            //        return;
            //    }


            //}
        }

        public void Dispose()
        {
            _running = false;
        }
    }
}