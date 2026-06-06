using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GITHUB_B4
{
    public class B4
    {
        [CommandMethod("Hello Autocad")]
        public void SayHello()
        {
            // Khai báo Editor cho project
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            //Wrtie Message
            ed.WriteMessage("Hello AutoCAD");
        }
    }
}
