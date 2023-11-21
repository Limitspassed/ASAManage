using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;

namespace ASAManager.Classes
{
    public class TabManager
    {
        private const string TabsFileName = "savedTabs.json";

        public static void SaveTabs(TabControl tabControl)
        {
            List<TabInfo> tabInfos = new List<TabInfo>();

            foreach (TabItem tabItem in tabControl.Items)
            {
                if (tabItem.Header != null)
                {
                    tabInfos.Add(new TabInfo(tabItem.Header.ToString()));
                }
            }

            string json = JsonConvert.SerializeObject(tabInfos);
            File.WriteAllText(TabsFileName, json);
        }

        public static void LoadTabs(TabControl tabControl)
        {
            tabControl.Items.Clear();

            List<TabInfo> tabInfos = new List<TabInfo>();

            if (File.Exists(TabsFileName))
            {
                string json = File.ReadAllText(TabsFileName);
                tabInfos = JsonConvert.DeserializeObject<List<TabInfo>>(json);
            }

            foreach (TabInfo tabInfo in tabInfos)
            {
                TabItem newTab = new TabItem
                {
                    Header = tabInfo.Header,
                    Content = new TabTemplate() // Assuming TabTemplate doesn't require additional parameters
                };

                tabControl.Items.Add(newTab);
            }
        }

        public static TabItem CreateNewTab(TabControl tabControl, TextBox txtServer)
        {
            string text = txtServer.Text;

            TabItem newTab = new TabItem
            {
                Header = text,
                Content = new TabTemplate() // Assuming TabTemplate doesn't require additional parameters
            };

            tabControl.Items.Add(newTab);
            tabControl.SelectedItem = newTab;

            return newTab;
        }

        public static string GetSelectedTabText(TabControl tabControl)
        {
            if (tabControl.SelectedItem is TabItem selectedTab && selectedTab.Header != null)
            {
                return selectedTab.Header.ToString();
            }

            return string.Empty;
        }
    }
}
