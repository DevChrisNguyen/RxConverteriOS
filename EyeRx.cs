using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxConverteriOS
{
    public class EyeRx
    {
        public double rightSphere { get; set; }
        public double rightCyl { get; set; }
        public double leftSphere { get; set; }
        public double leftCyl { get; set; }
        public int rightAxis { get; set; }
        public int leftAxis { get; set; }
        public EyeRx() { }
        public EyeRx(double rSphere, double rCyl, int rAxis,
                        double lSphere, double lCyl, int lAxis)
        {
            this.rightSphere = rSphere;
            this.rightCyl = rCyl;
            this.rightAxis = rAxis;
            this.leftSphere = lSphere;
            this.leftCyl = lCyl;
            this.leftAxis = lAxis;

        }
    }
}
