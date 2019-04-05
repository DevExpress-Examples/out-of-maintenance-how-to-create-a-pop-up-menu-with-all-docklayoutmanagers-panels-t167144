<!-- default file list -->
*Files to look at*:

* [DockLayoutSelectBehavior.cs](./CS/DockLayoutSelectExample/Behavior/DockLayoutSelectBehavior.cs) (VB: [DockLayoutSelectBehavior.vb](./VB/DockLayoutSelectExample/Behavior/DockLayoutSelectBehavior.vb))
* [MainWindow.xaml](./CS/DockLayoutSelectExample/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/DockLayoutSelectExample/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/DockLayoutSelectExample/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/DockLayoutSelectExample/MainWindow.xaml.vb))
<!-- default file list end -->
# How to create a pop-up menu with all DockLayoutManager's panels


This example demonstrates how to create a pop-up menu with all DockLayoutManager's panels, which show the current active state of each panel.<br />For this, we create a BarManager with a BarSubItem. After that, we subscribe to the BarSubItem's Popup event. When Popup is raised, we get a list of all DockLayoutManager's panels. We iterate through this list and add this BarCheckItem to the BarSubItem with a respective panel as a tag. We check the DockLayoutSource's ActiveLayoutItem. If the ActiveLayoutItem equals a panel from the list, we set the BarCheckItem's IsChecked property to True. Then, we subscribe to the BarCheckItem's CheckedChanged event. When CheckedChanged is raised, we get a panel from a current BarCheckItem's tag and activate this panel.

<br/>


