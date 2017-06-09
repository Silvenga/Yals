﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Yals.JsonRpc
{
    public static class Parser
    {
        public static IEnumerable<char[]> StreamToBlocks(this StreamReader reader)
        {
            const int bufferSize = 1024;
            var buffer = new char[bufferSize];
            int blockLength;
            while ((blockLength = reader.ReadBlock(buffer, 0, buffer.Length)) > 0)
            {
                var workArea = new char[blockLength];
                Array.Copy(buffer, 0, workArea, 0, blockLength);
                yield return workArea;
            }
        }

        public static IEnumerable<string> StreamToLines(this IEnumerable<char[]> enumerable)
        {
            var reader = new StringBuilder();
            foreach (var block in enumerable)
            {
                foreach (var c in block)
                {
                    reader.Append(c);
                    if (c == '\n')
                    {
                        yield return reader.ToString();
                        reader.Clear();
                    }
                }
            }
        }
    }
}