using System.Threading;
using TestStack.White.Configuration;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using System.Windows;
using TestStack.White.UIA;
using TestTC.Framework.App;

namespace TestTC.Framework.Actions
{
    public class MouseActions
    {
        public static void DragAndDrop(IUIItem draggedItem, IUIItem dropItem)
        {
            Point startPosition = draggedItem.Bounds.Center();
            Point endPosition = dropItem.Bounds.Center();
            Application.window.Mouse.Location = startPosition;
            Mouse.LeftDown();
            Thread.Sleep(1000);
            float num = (float)(1.0 / (double)CoreAppXmlConfiguration.Instance.DragStepCount);
            for (int i = 1; i <= CoreAppXmlConfiguration.Instance.DragStepCount; i++)
            {
                double num2 = startPosition.X + (endPosition.X - startPosition.X) * (double)(num * (float)i);
                double num3 = startPosition.Y + (endPosition.Y - startPosition.Y) * (double)(num * (float)i);
                Point point2 = (Application.window.Mouse.Location = new Point((int)num2, (int)num3));
                Thread.Sleep(100);
            }
            Mouse.LeftUp();
        }
    }
}
