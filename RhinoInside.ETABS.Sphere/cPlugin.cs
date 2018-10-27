using ETABSv17;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RhinoInside.ETABS.Sphere
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class cPlugin
    {

        /// <summary>k
        /// plug-in data
        /// </summary>
        /// <param name="Model"></param>
        /// <param name="Isapplugin"></param>
        public void Main(ref cSapModel Model, ref cPluginCallback IsapPlugin)
        {

            try
            {
                //// do something
                //MessageBox.Show("hello world");
 
                var t = new Test1();
                t.Main(ref Model);

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
