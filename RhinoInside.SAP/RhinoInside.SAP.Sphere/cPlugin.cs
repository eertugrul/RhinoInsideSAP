using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SAP2000v20;
using System.Windows.Forms;
using Rhino.Geometry;
using System.Reflection;
using System.IO;
using Rhino.Runtime.InProcess;

namespace RhinoInside.SAP.Sphere
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
