using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CincCamins.MinMaxNamespace
{
    public class Tree<T> where T : GameStatus
    {
        public Tree<T> Parent { get; set; }
        public List<Tree<T>> Children { get; set; }
    }
}
