using System.Windows.Automation;
using TestTC.Framework.App;
using TestTC.Framework.Actions;
using TestStack.White.UIItems.Finders;

namespace TestTC.Test.Screens
{
    public class LeftWindow
    {
        private string myComputerDir = "+";
        private string leftListName = "LEFT ";
        private string rightListName = "RIGHT ";
        private string menuBar = "MenuBar";
        public void ClickRootFolder()
        {
            var comboBox = Application.GetElementsByControlType(ControlType.ComboBox)[1];
            comboBox.Click();
            comboBox.Enter(myComputerDir);
        }
        public void ClickDir(string dir)
        {
            var leftListItems = Application.GetListBoxItems(leftListName);
            Application.GetListItemByName(dir, leftListItems).DoubleClick();
        }
        public void CLickTestFolder(string folder)
        {
            var leftListItems = Application.GetListBoxItems(leftListName);
            Application.GetListItemByName(folder, leftListItems).DoubleClick();
        }
        public void MoveFileToCopy(string fileName)
        {
            var file = Application.GetListItemByName(fileName, Application.GetListBoxItems(leftListName));
            MouseActions.DragAndDrop(file, Application.GetElementByText(rightListName));
        }
        public void FilePaste()
        {
            Application.GetElementByText(leftListName).Click();
            KeyboardActions.SpecialKeyControl("v");
        }
        public void ClickResearchOnLeftPanel()
        {
            Application.GetElementByText(leftListName).Click();
            var menu = Application.window.GetMenuBar(SearchCriteria.ByAutomationId(menuBar));
            menu.MenuItem("Commands", "Search...").Click();
        }  
    }
}
