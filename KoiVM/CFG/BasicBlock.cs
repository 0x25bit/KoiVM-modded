#region

using System;
using System.Collections.Generic;

#endregion

namespace KoiVM.CFG
{
    public class BasicBlock<TContent> : IBasicBlock
    {
        public BasicBlock(int id, TContent content)
        {
            Id = id;
            Content = content;
            Sources = new List<BasicBlock<TContent>>();
            Targets = new List<BasicBlock<TContent>>();
        }

        public TContent Content
        {
            get;
            set;
        }

        public IList<BasicBlock<TContent>> Sources
        {
            get;
        }

        public IList<BasicBlock<TContent>> Targets
        {
            get;
        }

        public int Id
        {
            get;
            set;
        }

        public BlockFlags Flags
        {
            get;
            set;
        }

        object IBasicBlock.Content => Content;

        IEnumerable<IBasicBlock> IBasicBlock.Sources => Sources;

        IEnumerable<IBasicBlock> IBasicBlock.Targets => Targets;

        public void LinkTo(BasicBlock<TContent> target)
        {
            Targets.Add(target);
            target.Sources.Add(this);
        }

        public override string ToString()
        {
            return string.Format("Block_{0:x2}:{1}{2}", Id, Environment.NewLine, Content);
        }
    }
}