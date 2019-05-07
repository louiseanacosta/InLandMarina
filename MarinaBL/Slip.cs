using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinaBL
{
    public class Slip
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int DockID { get; set; }

        public bool Selected { get; set; }
    }
}
