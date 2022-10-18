using System.Windows.Automation;
using Application = TestTC.Framework.App.Application;

namespace TestTC.Test.Screens
{
    public class InfoWindow
    {
        private string buttonNumber;
        public string GetButtonNumber()
        {
            var panes = Application.GetElementsByControlType(ControlType.Pane);
            for(int i=0; i<panes.Length; i++)
            {
                buttonNumber = panes[i].Name != null ? (buttonNumber = panes[i].Name.ToString()) : buttonNumber = buttonNumber;
            }
            return buttonNumber;
        }
        public void ClickButtonNumber() => Application.GetButtonByText(buttonNumber).Click();
    }
}
