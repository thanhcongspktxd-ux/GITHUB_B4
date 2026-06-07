using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Internal;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Runtime.ConstrainedExecution;
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
        [CommandMethod("DrawLine")]
        public void DrawLine()
        {
            // Khai báo document
            Document doc = Application.DocumentManager.MdiActiveDocument;
            //Khai báo Database
            Database db = doc.Database;
            //Khai báo Editor
            Editor ed = doc.Editor;
            //Chọn điểm đầu tiên
            Point3d startpoint = new Point3d(0, 0, 0);
            Point3d endpoint = new Point3d(100, 50, 0);

            //Tạo Line
            Line line = new Line(startpoint, endpoint);

            //Transaction
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                //Mở BlockTable
                BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);

                //Mở Modelspace
                BlockTableRecord btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace],OpenMode.ForWrite);

                //Thêm Line vào bản vẽ
                btr.AppendEntity(line);
                tr.AddNewlyCreatedDBObject(line, true);

                //Lưu thay đổi
                tr.Commit();

            }
            //Wrtie Message
            ed.WriteMessage("Line đã được vẽ");
        }
    }
}
