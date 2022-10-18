using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestTC.Framework.App;
using TestTC.Framework.Utils;

namespace TestTC.Test.Screens
{
    public class MainWindow
    {
        private string mainWindow = "Total Commander (x64) 10.51 - NOT REGISTERED";
        private string OKButton = "OK";
        private string replaceButton = "IdTileKeepSource";
        private string skipButton = "IdTileKeepDest";
        private string menuBar = "MenuBar";
        private string searchForField = "Search for";
        private string checkBoxRegEx = "RegEx";
        private string startSearchButton = "Start search";
        private string searchResultList = "Search results";
        private string cancelButton = "Cancel";

        public void GetMainWindow() => Application.window = Application.app.GetWindow(mainWindow);
        public void ClickOKButton() => Application.GetButtonByText(OKButton).Click();
        public void GetConfirmationWindow() => Application.window = Application.app.GetWindow("Замена или пропуск файлов");
        public bool ButtonsExist()
        {
            var firstExist = Application.window.Exists<Button>(SearchCriteria.ByAutomationId(replaceButton));
            var secondExist = Application.window.Exists<Button>(SearchCriteria.ByAutomationId(skipButton));
            return firstExist && secondExist;
        }
        public void ClickReplaceButton() => Application.GetElementById(replaceButton).Click();
        public void OpenSeparateTree()
        {
            var menu = Application.window.GetMenuBar(SearchCriteria.ByAutomationId(menuBar));
            menu.MenuItem("Show", "Separate Tree", "1 (One For Both Panels)").Click();
        }
        public void SwitchOffSeparateTrees()
        {
            var menu = Application.window.GetMenuBar(SearchCriteria.ByAutomationId(menuBar));
            menu.MenuItem("Show", "Separate Tree", "0 (None)").Click();
        }
        public IUIItem[] GetWindowsListsCount() => Application.GetElementsByControlType(ControlType.List);
        public void EnterFileNameInSearchForField(string file) => Application.GetComboBoxByText(searchForField).Enter(file);
        public void CheckBoxClick() => Application.GetCheckBoxByText(checkBoxRegEx).Click();
        public void StartSearchClick() => Application.GetButtonByText(startSearchButton).Click();
        public bool CheckSearchResults()
        {
            var result = Application.GetListBoxItems(searchResultList);
            return (result.Count == 2) && (result[1].Name == GetData.TestData.GetValue<string>("SearchResult"));
        }
        public void CloseFindFilesWindow()
        {
            var windows = Application.window.ModalWindows();
            windows[0].TitleBar.CloseButton.Click();
        }
        public bool IsFileSearchWindowClosed()
        {
            var windows = Application.window.ModalWindows();
            return windows.Count == 0;
        }
        public void EditComment()
        {
            var menu = Application.window.GetMenuBar(SearchCriteria.ByAutomationId(menuBar));
            menu.MenuItem("Files", "Edit Comment...").Click();
        }
        public void CancelButtonClick() => Application.GetButtonByText(cancelButton).Click();
        public void CloseAppWithMenuBar()
        {
            var menu = Application.window.GetMenuBar(SearchCriteria.ByAutomationId(menuBar));
            menu.MenuItem("Files", "Quit").Click();
        }
    }
}
