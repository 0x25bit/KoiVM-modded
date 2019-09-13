#region

using System;

#endregion

namespace KoiVM.RT
{
    public class BinaryChunk : IKoiChunk
    {
        public EventHandler<OffsetComputeEventArgs> OffsetComputed;

        public BinaryChunk(byte[] data)
        {
            Data = data;
        }

        public byte[] Data
        {
            get;
        }

        public uint Offset
        {
            get;
            private set;
        }

        uint IKoiChunk.Length => (uint) Data.Length;

        void IKoiChunk.OnOffsetComputed(uint offset)
        {
            if(OffsetComputed != null)
                OffsetComputed(this, new OffsetComputeEventArgs(offset));
            Offset = offset;
        }

        byte[] IKoiChunk.GetData()
        {
            return Data;
        }
    }

    public class OffsetComputeEventArgs : EventArgs
    {
        internal OffsetComputeEventArgs(uint offset)
        {
            Offset = offset;
        }

        public uint Offset
        {
            get;
        }
    }
}