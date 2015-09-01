using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rhino;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Display;
using Rhino.DocObjects;

namespace MakeGableRoofVolumes
{
    class Loop : Rhino_Processing
    {
        Curve[] crv;

        public override void Setup() // this runs once in the beginning.
        {
            ObjectType.Curve;
            RhinoGet.GetMultipleObjects("select rectangle", true, , crv);

            for (int i = 0; i < crv.Length; i++)
            {
                crv[i].Z = 300;
            }
        }

        public override void Draw() // this repeats until it ends
        {
            for (int i = 0; i < crv.Length; i++)
            {
                doc.Objects.AddPoint(crv[i]);
            }
        }
    }
}
