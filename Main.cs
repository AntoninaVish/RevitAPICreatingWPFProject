using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPICreatingWPFProject
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand

    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            
            var window = new MainView(commandData); //вызываем окно
            window.ShowDialog(); //вызываем окно для того чтобы оно появилось
           
            return Result.Succeeded;
        }
    }
}
