using System;
using System.Collections.Generic;
using System.Linq;

namespace Yals.JsonRpc.Parsers
{
    public class BufferedSeeker : IDisposable
    {
        private int _realIndex;
        private readonly IEnumerator<char> _enumerator;
        private readonly LinkedList<char> _buffer = new LinkedList<char>();

        public int CurrentIndex => BufferStartIndex;
        public int PeakIndex { get; private set; }

        private int BufferStartIndex => _realIndex - _buffer.Count;
        private int BufferEndIndex => _realIndex;

        public BufferedSeeker(IEnumerator<char> enumerator)
        {
            _enumerator = enumerator;
        }

        public void Seek(int count = 1)
        {
            for (var i = 0; i < count; i++)
            {
                if (_buffer.Count == 0)
                {
                    SeekBuffer();
                }
                _buffer.RemoveFirst();
            }

            PeakIndex = Math.Max(PeakIndex, CurrentIndex);
        }

        public void SeekToPeek()
        {
            Seek(PeakIndex - CurrentIndex);
        }

        public char Peek()
        {
            var possiblePeak = PeakIndex + 1;

            if (possiblePeak > BufferEndIndex)
            {
                SeekBuffer();
            }

            var c = _buffer.Skip(possiblePeak - BufferStartIndex - 1).First();
            PeakIndex = possiblePeak;

            return c;
        }

        private void SeekBuffer(int count = 1)
        {
            for (var i = 0; i < count; i++)
            {
                var success = TrySeekBuffer();
                if (!success)
                {
                    throw new Exception("Ran past of enumerator.");
                }
            }
        }

        private bool TrySeekBuffer()
        {
            var success = _enumerator.MoveNext();
            if (success)
            {
                _buffer.AddLast(_enumerator.Current);
                _realIndex++;
            }

            return success;
        }

        public void BacktrackPeek(int numberOfPlaces)
        {
            var possiblePeak = PeakIndex - numberOfPlaces;
            if (possiblePeak < CurrentIndex)
            {
                throw new ArgumentException("Cannot backtrack peek past current index.");
            }

            PeakIndex = possiblePeak;
        }

        public List<char> PeekUntil(Func<List<char>, bool> predicate)
        {
            var subBuffer = new List<char>();
            do
            {
                subBuffer.Add(Peek());
            } while (!predicate(subBuffer));

            return subBuffer;
        }

        public bool Peekable()
        {
            return TrySeekBuffer();
        }

        public void Dispose()
        {
            _enumerator?.Dispose();
        }
    }
}