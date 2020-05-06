using System;
using System.Collections.Generic;
using System.Text;

namespace ControllizerDeckProject.Utils
{
    public static class MathHelper
    {

        public static decimal MapRange(this decimal value, decimal fromSource, decimal toSource, decimal fromTarget, decimal toTarget)
        {
            return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
        }
    }
}
