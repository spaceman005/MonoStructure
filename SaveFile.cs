using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStructure
{
    [Serializable]
    public class SaveFile
    {
        public List<Actor> Actors { get; set; }
        public SaveFile() { }
    }
}
