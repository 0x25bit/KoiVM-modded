#region

using System.Collections.Generic;
using System.IO;
using dnlib.DotNet.Writer;

#endregion

namespace KoiVM.RT
{
    internal class KoiHeap : HeapBase
    {
        private readonly List<byte[]> chunks = new List<byte[]>();
        private uint currentLen;

        public override string Name => "#DarksVM";

        public uint AddChunk(byte[] chunk)
        {
            var offset = currentLen;
            chunks.Add(chunk);
            currentLen += (uint) chunk.Length;
            return offset;
        }

        public override uint GetRawLength()
        {
            return currentLen;
        }

        protected override void WriteToImpl(BinaryWriter writer)
        {
            foreach(var chunk in chunks)
                writer.Write(chunk);
        }
    }
}