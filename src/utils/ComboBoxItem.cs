using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom8_QLTV.src.utils
{
    internal class ComboBoxItem
    {
        public string Name { get; set; }
        public long Value { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
