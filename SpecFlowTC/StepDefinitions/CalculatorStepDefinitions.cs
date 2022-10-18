using TechTalk.SpecFlow;
using TestTC.Framework.App;
using TestTC.Test.Screens;
using TestTC.Framework.Utils;
using NUnit.Framework;
using TestStack.White.UIItems;
using System.Windows.Automation;

namespace SpecFlowTC.StepDefinitions
{
    [Binding]
    public sealed class TCStepDefinitions
    {
        private readonly InfoWindow _infoWindow;
        private readonly MainWindow _mainWindow;
        private readonly LeftWindow _leftWindow;
        private readonly RightWindow _rightWindow;
        private IUIItem[] lists;
        private IUIItem[] listsAfterAddTheTree;
        private int listsAfterRemoveTheTree;
        public TCStepDefinitions(InfoWindow infoWindow, MainWindow mainWindow, LeftWindow leftWindow, RightWindow rightWindow)
        {
            _infoWindow = infoWindow;
            _mainWindow = mainWindow;
            _leftWindow = leftWindow;
            _rightWindow = rightWindow;
        }
        [Given(@"Total Commander was opened and the InfoWindow closed")]
        public void GivenTotalCommanderWasOpenedAndTheInfoWindowClosed()
        {
            Application.Launch();
            Assert.IsNotNull(Application.window, "Info window isn't open");
            _infoWindow.GetButtonNumber();
            _infoWindow.ClickButtonNumber();
            _mainWindow.GetMainWindow();
            Assert.IsNotNull(Application.window, "Main window isn't open");
        }
        [Given(@"Two folders were opened")]
        public void GivenTwoFoldersWereOpened()
        {
            _leftWindow.ClickRootFolder();
            _leftWindow.ClickDir(GetData.TestData.GetValue<string>("DirD"));
            _leftWindow.CLickTestFolder(GetData.TestData.GetValue<string>("Folder1"));
            _rightWindow.ClickRootFolder();
            _rightWindow.ClickDir(GetData.TestData.GetValue<string>("DirD"));
            _rightWindow.CLickTestFolder(GetData.TestData.GetValue<string>("Folder2"));
        }
        [When(@"The user drags the file from the first folder to the second")]
        public void WhenTheUserDragsTheFileFromTheFirstFolderToTheSecond()
        {
            _leftWindow.MoveFileToCopy(GetData.TestData.GetValue<string>("TestFile1"));
        }
        [When(@"The user confirm copying")]
        public void WhenTheUserConfirmCopying()
        {
            _mainWindow.ClickOKButton();
        }
        [Then(@"The file is in the second folder")]
        public void ThenTheFileIsInTheSecondFolder()
        {
            Assert.IsNotNull(_rightWindow.FileWasCopied(GetData.TestData.GetValue<string>("TestFile1")), "File isn't exist");
        }
        [When(@"The user cuts the file in the second folder")]
        public void WhenTheUserCutsTheFileInTheSecondFolder()
        {
            _rightWindow.FileCut(GetData.TestData.GetValue<string>("TestFile1"));
        }
        [When(@"The user pastes the file in the first folder")]
        public void WhenTheUserPastesTheFileInTheFirstFolder()
        {
            _leftWindow.FilePaste();
        }
        [When(@"The user chooses the <replace> option")]
        public void WhenTheUserChoosesTheReplaceOption()
        {
            _mainWindow.GetConfirmationWindow();
            _mainWindow.ButtonsExist();
            _mainWindow.ClickReplaceButton();
            _mainWindow.GetMainWindow();
        }
        [Then(@"The file is in the first folder and it isn't in the second")]
        public void ThenTheFileIsInFirstFolderAndItIsntInTheSecond()
        {
            Assert.IsNull(_rightWindow.FileWasCutted(GetData.TestData.GetValue<string>("TestFile1")), "File is exist");
        }
        [When(@"The user opens separate tree")]
        public void WhenTheUserOpensSeparateTree()
        {
            lists = Application.GetElementsByControlType(ControlType.List);
            _mainWindow.OpenSeparateTree();
            listsAfterAddTheTree = Application.GetElementsByControlType(ControlType.List);
            Assert.IsTrue((listsAfterAddTheTree.Length > lists.Length), "Separate Tree isn't open");
        }
        [When(@"The user does double click on <Switch through tree panel options> button")]
        public void WhenTheUserDoesDoubleClickOnSwitchThroughTreePanelOptionsButton()
        {
            _mainWindow.SwitchOffSeparateTrees();
            listsAfterRemoveTheTree = _mainWindow.GetWindowsListsCount().Length;
            Assert.IsTrue(listsAfterRemoveTheTree == 5, "There are more then two windows with folders view");
        }
        [When(@"The user selects the first panel and click <Search> button")]
        public void WhenTheUserSelectsTheFirstPanelAndClickSearchButton()
        {
            _leftWindow.ClickResearchOnLeftPanel();
        }
        [When(@"The user enters file name in field <Search for>")]
        public void WhenTheUserEntersFileNameInFieldSearchFor()
        {
            _mainWindow.EnterFileNameInSearchForField(GetData.TestData.GetValue<string>("TestFile1"));
        }
        [When(@"The user sets the <RegEx> checkbox and clicks <Start Search> button")]
        public void WhenTheUserSetsTheRegExCheckboxAndClicksStartSearchButton()
        {
            _mainWindow.CheckBoxClick();
            _mainWindow.StartSearchClick();
        }
        [Then(@"Only one file found")]
        public void ThenOnlyOneFileFound()
        {
            Assert.IsTrue(_mainWindow.CheckSearchResults(), "Wrong result");
        }
        [When(@"The user clicks on the cross")]
        public void WhenTheUserClicksOnTheCross()
        {
            _mainWindow.CloseFindFilesWindow();
        }
        [Then(@"The Search window is close")]
        public void ThenTheSearchWindowIsClose()
        {
            Assert.IsTrue(_mainWindow.IsFileSearchWindowClosed(), "FileSearch window is open");
        }
        [When(@"The user chooses from menu Edit Comment")]
        public void WhenTheUserChoosesFromMenuEditComment()
        {
            _mainWindow.EditComment();
        }
        [Then(@"A window appeared warning that no files were selected")]
        public void ThenAWindowAppearedWarningThatNoFilesWereSelected()
        {
            _mainWindow.CancelButtonClick();
        }
        [When(@"The user clicks OK and chooses from menu Quit")]
        public void WhenTheUserClicksOKAndChoosesFromMenuQuit()
        {
            _mainWindow.CloseAppWithMenuBar();
        }
        [Then(@"Total Сommander is close")]
        public void ThenTotalСommanderIsClose()
        {
            Assert.IsEmpty(Application.app.GetWindows(), "Window isn't close");
        }
    }
}