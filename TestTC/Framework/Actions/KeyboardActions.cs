using System.Threading;
using TestStack.White.WindowsAPI;
using TestTC.Framework.App;

namespace TestTC.Framework.Actions
{
    public class KeyboardActions
    {
        public static void SpecialKeyControl(string button)
        {
            var keyboard = Application.window.Keyboard;
            keyboard.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            keyboard.Enter(button);
            keyboard.LeaveKey(KeyboardInput.SpecialKeys.CONTROL);
            Thread.Sleep(100);
        }
    }
}
