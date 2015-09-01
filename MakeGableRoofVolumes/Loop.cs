using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino;
using Rhino.Geometry;

namespace MakeGableRoofVolumes
{
    class Loop : Rhino_Processing
    {
        List<AstroObject> astroobjs = new List<AstroObject>();

        public override void Setup() // this runs once in the beginning.
        {
            astroobjs.Add(new AstroObject(63.71, new Point3d(), 1496.0, 365.4 * 10));
            astroobjs.Add(new AstroObject(17.37, astroobjs[0].Center(), 384.0, 27.32 * 10));
            astroobjs.Add(new AstroObject(17.37, astroobjs[1].Center(), 384.0, 27.32 * 10));
        }

        public override void Draw() // this repeats until it ends
        {
            astroobjs[0].Rotate();

            for (int i = 1; i < astroobjs.Count; i++) {
                astroobjs[i].UpdateCenter(astroobjs[i - 1].Center());
                astroobjs[i].Rotate();

            }

            foreach(AstroObject astroobj in astroobjs){
                astroobj.Display(doc);
            }

        }
        
        }
    }

