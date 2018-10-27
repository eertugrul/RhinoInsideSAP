using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Rhino.Geometry;
using System.Reflection;

using System.IO;
using Rhino.Runtime.InProcess;
using System.Diagnostics;
using ETABSv17;

namespace RhinoInside.ETABS.Sphere
{
    public class Test1
    {
        static Test1()
        {
            ResolveEventHandler OnRhinoCommonResolve = null;
            AppDomain.CurrentDomain.AssemblyResolve += OnRhinoCommonResolve = (sender, args) =>
            {
                const string rhinoCommonAssemblyName = "RhinoCommon";
                var assemblyName = new AssemblyName(args.Name).Name;

                if (assemblyName != rhinoCommonAssemblyName)
                    return null;

                AppDomain.CurrentDomain.AssemblyResolve -= OnRhinoCommonResolve;

                string rhinoSystemDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Rhino WIP", "System");
                //string rhinoSystemDir = @"C:\Users\EErtugrul\Desktop\Rhino WIP\System";
                return Assembly.LoadFrom(Path.Combine(rhinoSystemDir, rhinoCommonAssemblyName + ".dll"));
            };
        }

        private static RhinoCore rhinoCore;

        public void Main(ref cSapModel Model)
        {
            if (rhinoCore == null)
            {             // Load Rhino
                try
                {
                    var schemeName = "ETABS";
                    rhinoCore = new RhinoCore(new string[] { $"/scheme={schemeName}", "/nosplash" }, WindowStyle.Normal, Process.GetCurrentProcess().MainWindowHandle);
                }
                catch (Exception e)
                {
                    Debug.Fail(e.Source, e.Message);
                    return;
                }
            }

            // RhinoCommon code
            var sphere = new Rhino.Geometry.Sphere(Point3d.Origin, 12000);
            var brep = sphere.ToBrep();
            var mp = MeshingParameters.Default;
            var meshes = Rhino.Geometry.Mesh.CreateFromBrep(brep, mp);

            foreach (var mesh in meshes.ToList())
            {
                for (int i = 0; i < mesh.Faces.Count; i++)
                {
                    Point3f a;
                    Point3f b;
                    Point3f c;
                    Point3f d;

                    mesh.Faces.GetFaceVertices(i, out a, out b, out c, out d);

                    List<Point3f> vertices = new List<Point3f>();
                    vertices.Add(a); vertices.Add(b); vertices.Add(c);
                    if (c != d) vertices.Add(d);

                    List<string> points = new List<string>();

                    foreach (var v in vertices)
                    {
                        string p = string.Empty;
                        Model.PointObj.AddCartesian(v.X, v.Y, v.Z, ref p);
                        points.Add(p);
                    }

                    string area = string.Empty;
                    string[] pts = points.ToArray();
                    Model.AreaObj.AddByPoint(points.Count, ref pts,ref area);
                    
                }

            }


        }




    }
}
