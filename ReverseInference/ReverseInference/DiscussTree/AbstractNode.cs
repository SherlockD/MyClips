using System;
using System.Collections.Generic;

namespace ReverseInference.DiscussTree
{
    public abstract class AbstractNode
    {
        public AbstractNode Parent;
        protected List<AbstractNode> _references = new List<AbstractNode>();

        public void AddReference(AbstractNode node)
        {
            _references.Add(node);
        }
    }
}
