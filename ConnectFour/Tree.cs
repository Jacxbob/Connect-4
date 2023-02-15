using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public class Tree<T>
    {
        public T Data { get; set; }
        public Tree<T> Parent { get; set; }
        public List<Tree<T>> Children { get; set; } 
        public int GetDepth()
        {
            int depth = 1;
            Tree<T> current = this;
            while (current.Parent != null)
            {
                depth++;
                current = current.Parent;
            }
            return depth;
        }
    }
}
