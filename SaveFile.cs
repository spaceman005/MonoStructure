using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStructure
{
    public class SaveFile
    {
        public Boolean empty = true;
        public String fileName;
        public DateTime rawDateTime;

        public void PrepareSavePreview()
        {
            // Use this to set your stats (score, experience, whatever). 
            // this.score = SaveData.score
        }
    }
}
