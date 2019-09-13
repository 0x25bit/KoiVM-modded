#region

using System;
using KoiVM.AST.IL;

#endregion

namespace KoiVM.RT
{
    public class JumpTableChunk : IKoiChunk
    {
        internal DarksVMRuntime runtime;

        public JumpTableChunk(ILJumpTable table)
        {
            Table = table;
            if(table.Targets.Length > ushort.MaxValue)
                throw new NotSupportedException("Jump table too large.");
        }

        public ILJumpTable Table
        {
            get;
        }

        public uint Offset
        {
            get;
            private set;
        }

        uint IKoiChunk.Length => (uint) Table.Targets.Length * 4 + 2;

        void IKoiChunk.OnOffsetComputed(uint offset)
        {
            Offset = offset + 2;
        }

        byte[] IKoiChunk.GetData()
        {
            var data = new byte[Table.Targets.Length * 4 + 2];
            var len = (ushort) Table.Targets.Length;
            var ptr = 0;
            data[ptr++] = (byte) Table.Targets.Length;
            data[ptr++] = (byte) (Table.Targets.Length >> 8);

            var relBase = Table.RelativeBase.Offset;
            relBase += runtime.serializer.ComputeLength(Table.RelativeBase);
            for(var i = 0; i < Table.Targets.Length; i++)
            {
                var offset = ((ILBlock) Table.Targets[i]).Content[0].Offset;
                offset -= relBase;
                data[ptr++] = (byte) (offset >> 0);
                data[ptr++] = (byte) (offset >> 8);
                data[ptr++] = (byte) (offset >> 16);
                data[ptr++] = (byte) (offset >> 24);
            }
            return data;
        }
    }
}