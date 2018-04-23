using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Docking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;

namespace DockLayoutSelectExample
{
    class DockLayoutSelectBehavior : Behavior<UIElement>
    {
        public static readonly DependencyProperty DockLayoutSourceProperty = DependencyProperty.Register("DockLayoutSource", typeof(DockLayoutManager), typeof(DockLayoutSelectBehavior), new PropertyMetadata(null));

        public DockLayoutManager DockLayoutSource
        {
            get { return (DockLayoutManager)GetValue(DockLayoutSourceProperty); }
            set { SetValue(DockLayoutSourceProperty, value); }
        }

        BarSubItem SubItem;
        BarManager BarManager;

        protected override void OnAttached()
        {
            base.OnAttached();
            BarManager = this.AssociatedObject as BarManager;
            BarManager.Loaded += barManager_Loaded;
        }

        void barManager_Loaded(object sender, RoutedEventArgs e)
        {
            DockLayoutSource = BarManager.Child as DockLayoutManager;
            DockLayoutSource.Loaded += Manager_Loaded;
        }

        void Manager_Loaded(object sender, RoutedEventArgs e)
        {
            CreateBar(BarManager);
        }

        public void CreateBar(BarManager bar)
        {
            SubItem = new BarSubItem();
            Bar subBar = new Bar();

            SubItem.Content = "Select focused panel";

            CreateSubItemLinks();

            bar.Items.Add(SubItem);
            subBar.ItemLinks.Add(SubItem);
            bar.Bars.Add(subBar);

            SubItem.Popup += subItem_Popup;
        }

        void checkItem_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            var barItem = sender as BarCheckItem;
            var panel = barItem.Tag as BaseLayoutItem;
            DockLayoutSource.BringToFront(panel);
            DockLayoutSource.Activate(panel);
        }

        void subItem_Popup(object sender, EventArgs e)
        {
            CreateSubItemLinks();
        }

        void CreateSubItemLinks()
        {
            var list = DockLayoutSource.GetItems().Where(n => (n.ItemType == DevExpress.Xpf.Layout.Core.LayoutItemType.Document || n.ItemType == DevExpress.Xpf.Layout.Core.LayoutItemType.Panel)).ToList<BaseLayoutItem>();

            foreach(BarItemLinkBase linkItem in SubItem.ItemLinks)
            {
                var baseItem = linkItem as BarCheckItemLink;
                if (baseItem != null)
                {
                    var checkItem = baseItem.Item as BarCheckItem;
                    checkItem.CheckedChanged -= checkItem_CheckedChanged;
                }
            }

            SubItem.ItemLinks.Clear();

            foreach (BaseLayoutItem item in list)
            {
                var checkItem = new BarCheckItem();
                checkItem.Content = item.Caption.ToString();
                checkItem.Tag = item;

                if (DockLayoutSource.ActiveLayoutItem == item || DockLayoutSource.ActiveDockItem == item)
                {
                    checkItem.IsChecked = true;
                }
                else
                {
                    checkItem.IsChecked = false;
                }

                SubItem.ItemLinks.Add(checkItem);

                checkItem.CheckedChanged += checkItem_CheckedChanged;
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }
    }
}
