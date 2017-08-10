using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Enums
{
    public enum Regions
    {
        None = 0,
        Main = 1,
        Sub = 2,
    }

    public static class RegionsEx
    {
        public static string GetRegionName(this Regions regions)
        {
            switch (regions)
            {
                case Regions.Main:
                    return "MainRegion";
                case Regions.Sub:
                    return "SubRegion";
                default:
                    return string.Empty;
            }
        }
    }
}
