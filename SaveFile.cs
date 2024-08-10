using GameStructure.Models;
using GameStructure.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GameStructure
{
    [Serializable]
    public class SaveFile
    {
        public List<Sprite> Actors { get; set; } = null;

        public List<Button> Buttons { get; set; } = null;

        [XmlArrayItem(IsNullable = true)]
        public List<Player> Players { get; set; } = null;

        public SaveFile() { }
    }
}
