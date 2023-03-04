using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Prism.Commands;
using RevitAPICreatingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPICreatingWPFProject
{
    public class MainViewViewModel
    {
        private ExternalCommandData _commandData;

        public DelegateCommand SelectCommand { get; }

        //создаем конструктор с помощью снипита ctor чтобы вызвать конструктор нажимаем tab два раза
        public MainViewViewModel(ExternalCommandData commandData)
        {
            //сохраняем в отдельное поле, для того чтобы потом вызвать Document, UIDocument; преобразовывать реферес в элементы и т.д.
            _commandData = commandData;

            SelectCommand = new DelegateCommand(OnSelectCommand);
        }

        public event EventHandler HideRequest;

        private void RaiseHideRequest()
        {
            HideRequest?.Invoke(this, EventArgs.Empty);
        }

       
        public event EventHandler ShowRequest;

        private void RaiseShowRequest() // при вызове RaiseShowRequest будет вызываться данный event
        {
           ShowRequest?.Invoke(this, EventArgs.Empty);
        }

        private void OnSelectCommand()
        {
            RaiseHideRequest();  //будем временно скрывать окно, когда запускается команда выбора элемента

            Element oElement = SelectionUtils.PickObject(_commandData);

            TaskDialog.Show("Сообщение", $"ID: {oElement.Id}"); //выводим идентификатор

            RaiseShowRequest();
        }

       
    }
}
