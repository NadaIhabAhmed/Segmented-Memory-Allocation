using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Allocation
{
    public class Hole
    {
        private int size;
        private int startingAddr;
        private int id;
        public List<int> hole_location = new List<int>();
        public List<int> hole_size = new List<int>();
        
        public Hole(int id, int size, int starting)
        {
            this.id = id;
            this.size = size;
            this.startingAddr = starting;
        }
        
        public int get_size(int i)
        {
            return hole_size[i];
        }
        public int get_location(int i)
        {
            return hole_location[i];
        }
        public void Add(int starting, int size)
        {
            hole_location.Add(starting);
            hole_size.Add(size);
        }
    }
}
