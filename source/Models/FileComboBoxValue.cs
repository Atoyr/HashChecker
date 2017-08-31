using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Models
{
    public class FileComboBoxValue
    {
        public int SortNo { get; set; } = 0;
        public string Value { get; set; } = string.Empty;
        public override string ToString()
        {
            return Value;
        }
    }
}
