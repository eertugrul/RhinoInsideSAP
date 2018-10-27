using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SAP2000v20;
using System.Windows.Forms;
using Rhino.Geometry;

namespace RhinoInside.SAP.Sphere
{

    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class cPlugin
    {
        /// <summary>
        /// plug-in data
        /// </summary>
        /// <param name="Model"></param>
        /// <param name="Isapplugin"></param>
        public void Main(ref cSapModel Model, ref cPluginCallback IsapPlugin)
        {
            try
            {
                // do something
                MessageBox.Show("hello world");

                //// RhinoCommon code
                //var sphere = new Rhino.Geometry.Sphere(Point3d.Origin, 12);
                //var brep = sphere.ToBrep();
                //var mp = MeshingParameters.Default;
                //var meshes = Rhino.Geometry.Mesh.CreateFromBrep(brep, mp);

                //foreach (var mesh in meshes.ToList())
                //{
                //    for (int i = 0; i < mesh.Faces.Count; i++)
                //    {
                //        Point3f a;
                //        Point3f b;
                //        Point3f c;
                //        Point3f d;

                //        mesh.Faces.GetFaceVertices(i, out a, out b, out c, out d);
                //    }
                    
                //}


            }
            catch (Exception e)
            {
                IsapPlugin.Finish(0);
            }

            IsapPlugin.Finish(0);
        }

        /// <summary>
        /// Rhino Inside SAP simple sphere
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Info(ref String info)
        {
            info = "Rhino Inside SAP simple sphere plug-in \r\n Author : AEC Tech";
            return 0;
        }

    }
}
