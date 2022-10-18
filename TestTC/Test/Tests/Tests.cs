using NUnit.Framework;
using System.Windows.Automation;
using TestTC.Framework.App;
using TestTC.Framework.Base;
using TestTC.Framework.Utils;
using TestTC.Test.Screens;

namespace TestTC.Test
{
    [TestFixture]
    public class Tests: BaseTest
    {
        private readonly InfoWindow infoWindow = new InfoWindow();
        private readonly MainWindow mainWindow = new MainWindow();
        private readonly LeftWindow leftWindow = new LeftWindow();
        private readonly RightWindow rightWindow = new RightWindow();

        [Test]
        public void TestCase()
        {
            Application.Launch();
            Assert.IsNotNull(Application.window, "Info window isn't open");
            infoWindow.GetButtonNumber();
            infoWindow.ClickButtonNumber();
            mainWindow.GetMainWindow();
            Assert.IsNotNull(Application.window, "Main window isn't open");
            leftWindow.ClickRootFolder();
            leftWindow.ClickDir(GetData.TestData.GetValue<string>("DirD"));
            leftWindow.CLickTestFolder(GetData.TestData.GetValue<string>("Folder1"));
            rightWindow.ClickRootFolder();
            rightWindow.ClickDir(GetData.TestData.GetValue<string>("DirD"));
            rightWindow.CLickTestFolder(GetData.TestData.GetValue<string>("Folder2"));
            leftWindow.MoveFileToCopy(GetData.TestData.GetValue<string>("TestFile1"));
            mainWindow.ClickOKButton();
            Assert.IsNotNull(rightWindow.FileWasCopied(GetData.TestData.GetValue<string>("TestFile1")), "File isn't exist");
            rightWindow.FileCut(GetData.TestData.GetValue<string>("TestFile1"));
            leftWindow.FilePaste();
            mainWindow.GetConfirmationWindow();
            mainWindow.ButtonsExist();
            mainWindow.ClickReplaceButton();
            mainWindow.GetMainWindow();
            Assert.IsNull(rightWindow.FileWasCutted(GetData.TestData.GetValue<string>("TestFile1")), "File is exist");
            var lists = Application.GetElementsByControlType(ControlType.List);
            mainWindow.OpenSeparateTree();
            var listsAfterAddTheTree = Application.GetElementsByControlType(ControlType.List);
            Assert.IsTrue((listsAfterAddTheTree.Length > lists.Length), "Separate Tree isn't open");
            mainWindow.SwitchOffSeparateTrees();
            var listsAfterRemoveTheTree = mainWindow.GetWindowsListsCount().Length;
            Assert.IsTrue(listsAfterRemoveTheTree == 5, "There are more then two windows with folders view");
            leftWindow.ClickResearchOnLeftPanel();
            mainWindow.EnterFileNameInSearchForField(GetData.TestData.GetValue<string>("TestFile1"));
            mainWindow.CheckBoxClick();
            mainWindow.StartSearchClick();
            Assert.IsTrue(mainWindow.CheckSearchResults(), "Wrong result");
            mainWindow.CloseFindFilesWindow();
            Assert.IsTrue(mainWindow.IsFileSearchWindowClosed(), "FileSearch window is open");
            mainWindow.EditComment();
            mainWindow.CancelButtonClick();
            mainWindow.CloseAppWithMenuBar();
            Assert.IsEmpty(Application.app.GetWindows(), "Window isn't close");
        }
    }
}