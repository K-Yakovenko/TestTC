using System.Threading;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using TestTC.Framework.Utils;
using TestTC.Framework.Log;
using System.Windows.Automation;
using System.Linq;
using TestStack.White.UIItems.ListBoxItems;
using System;

namespace TestTC.Framework.App
{
    public static class Application
    {
        public static TestStack.White.Application app;
        public static Window window;

        public static void Launch()
        {
            app = TestStack.White.Application.Launch(GetData.Config.GetValue<string>("pathToApp"));
            Nlog.log.Info($"Launch application Total Commander");
            window = app.GetWindow("Total Commander");
            Nlog.log.Info($"Get Info Window of application Total Commander");
            window.WaitWhileBusy();
        }
        public static void CloseWindow() => window.Close();
        public static IUIItem GetElementByText(string text)
        {
            Nlog.log.Info($"Get element by text {text}");
            return window.Get(SearchCriteria.ByText(text));
        }
        public static IUIItem GetButtonByText(string text)
        {
            Nlog.log.Info($"Get button by text {text}");
            return window.Get<Button>(text);
        }
        public static IUIItem GetComboBoxByText(string text)
        {
            Nlog.log.Info($"Get ComboBox by text {text}");
            return window.Get<ComboBox>(text);
        }
        public static IUIItem GetCheckBoxByText(string text)
        {
            Nlog.log.Info($"Get CheckBox by text {text}");
            return window.Get<CheckBox>(text);
        }

        public static IUIItem GetElementById(string id)
        {
            Nlog.log.Info($"Get element by id {id}");
            return window.Get(SearchCriteria.ByAutomationId(id));
        }
        public static IUIItem[] GetElementsByControlType(ControlType controlType)
        {
            Nlog.log.Info($"Get elements by control type {controlType}");
            var elements =  window.GetMultiple(SearchCriteria.ByControlType(controlType)).ToArray();
            return elements;
        }
        public static ListItems GetListBoxItems(string name)
        {
            Nlog.log.Info($"Get list {name} items");
            return window.Get<ListBox>(name).Items;
        }
        public static ListItem GetListItemByName(string name,ListItems list, int timeout = 30)
        {
            Nlog.log.Info($"Get {name} item");
            for (int i = 0; i < timeout; i++)
            {
                foreach (var item in list)
                {
                    if (item.Name.StartsWith(name))
                    {
                        return item;
                    }
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            return null;
        }
        public static ListItem CheckItemIsNotInList(string name, ListItems list, int timeout = 30)
        {
            ListItem item = null;
            Nlog.log.Info($"Get {name} item");
            for (int i = 0; i < timeout; i++)
            {
                foreach (var element in list)
                {
                    if (element.Name.StartsWith(name))
                    {
                        item = element;
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                        continue;
                    }
                    item = null;
                    break;
                }
            }
            return item;
        }
    }
}
