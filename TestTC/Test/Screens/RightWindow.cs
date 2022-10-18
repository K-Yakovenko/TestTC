using System.Windows.Automation;
using TestStack.White.UIItems.ListBoxItems;
using TestTC.Framework.Actions;
using TestTC.Framework.App;

namespace TestTC.Test.Screens
{
    public class RightWindow
    {
        private string myComputerDir = "+";
        private string rightListName = "RIGHT ";
        public void ClickRootFolder()
        {
            var comboBox = Application.GetElementsByControlType(ControlType.ComboBox)[2];
            comboBox.Click();
            comboBox.Enter(myComputerDir);
        }
        public void ClickDir(string dir)
        {
            var rightListItems = Application.GetListBoxItems(rightListName);
            Application.GetListItemByName(dir, rightListItems).DoubleClick();
        }
        public void CLickTestFolder(string folder)
        {
            var rightListItems = Application.GetListBoxItems(rightListName);
            Application.GetListItemByName(folder, rightListItems).DoubleClick();
        }
        public ListItem FileWasCopied(string file)
        {
            return Application.GetListItemByName(file, Application.GetListBoxItems(rightListName));
        }
        public ListItem FileWasCutted(string file)
        {
            return Application.CheckItemIsNotInList(file, Application.GetListBoxItems(rightListName));
        }
        public void FileCut(string file)
        {
            Application.GetListItemByName(file, Application.GetListBoxItems(rightListName)).Click();
            KeyboardActions.SpecialKeyControl("x");
        }
    }
}
