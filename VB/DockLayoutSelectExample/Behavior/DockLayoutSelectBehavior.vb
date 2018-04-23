Imports Microsoft.VisualBasic
Imports DevExpress.Mvvm.UI.Interactivity
Imports DevExpress.Xpf.Bars
Imports DevExpress.Xpf.Docking
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Input
Imports System.Windows.Markup

Namespace DockLayoutSelectExample
	Friend Class DockLayoutSelectBehavior
		Inherits Behavior(Of UIElement)
		Public Shared ReadOnly DockLayoutSourceProperty As DependencyProperty = DependencyProperty.Register("DockLayoutSource", GetType(DockLayoutManager), GetType(DockLayoutSelectBehavior), New PropertyMetadata(Nothing))

		Public Property DockLayoutSource() As DockLayoutManager
			Get
				Return CType(GetValue(DockLayoutSourceProperty), DockLayoutManager)
			End Get
			Set(ByVal value As DockLayoutManager)
				SetValue(DockLayoutSourceProperty, value)
			End Set
		End Property

		Private SubItem As BarSubItem
		Private BarManager As BarManager

		Protected Overrides Sub OnAttached()
			MyBase.OnAttached()
			BarManager = TryCast(Me.AssociatedObject, BarManager)
			AddHandler BarManager.Loaded, AddressOf barManager_Loaded
		End Sub

		Private Sub barManager_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			DockLayoutSource = TryCast(BarManager.Child, DockLayoutManager)
			AddHandler DockLayoutSource.Loaded, AddressOf Manager_Loaded
		End Sub

		Private Sub Manager_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			CreateBar(BarManager)
		End Sub

		Public Sub CreateBar(ByVal bar As BarManager)
			SubItem = New BarSubItem()
			Dim subBar As New Bar()

			SubItem.Content = "Select focused panel"

			CreateSubItemLinks()

			bar.Items.Add(SubItem)
			subBar.ItemLinks.Add(SubItem)
			bar.Bars.Add(subBar)

			AddHandler SubItem.Popup, AddressOf subItem_Popup
		End Sub

		Private Sub checkItem_CheckedChanged(ByVal sender As Object, ByVal e As ItemClickEventArgs)
			Dim barItem = TryCast(sender, BarCheckItem)
			Dim panel = TryCast(barItem.Tag, BaseLayoutItem)
			DockLayoutSource.BringToFront(panel)
			DockLayoutSource.Activate(panel)
		End Sub

		Private Sub subItem_Popup(ByVal sender As Object, ByVal e As EventArgs)
			CreateSubItemLinks()
		End Sub

		Private Sub CreateSubItemLinks()
            Dim list = DockLayoutSource.GetItems().Where(Function(n) (n.ItemType = DevExpress.Xpf.Layout.Core.LayoutItemType.Document OrElse n.ItemType = DevExpress.Xpf.Layout.Core.LayoutItemType.Panel)).ToList()

			For Each linkItem As BarItemLinkBase In SubItem.ItemLinks
				Dim baseItem = TryCast(linkItem, BarCheckItemLink)
				If baseItem IsNot Nothing Then
					Dim checkItem = TryCast(baseItem.Item, BarCheckItem)
					RemoveHandler checkItem.CheckedChanged, AddressOf checkItem_CheckedChanged
				End If
			Next linkItem

			SubItem.ItemLinks.Clear()

			For Each item As BaseLayoutItem In list
				Dim checkItem = New BarCheckItem()
				checkItem.Content = item.Caption.ToString()
				checkItem.Tag = item

				If DockLayoutSource.ActiveLayoutItem Is item OrElse DockLayoutSource.ActiveDockItem Is item Then
					checkItem.IsChecked = True
				Else
					checkItem.IsChecked = False
				End If

				SubItem.ItemLinks.Add(checkItem)

				AddHandler checkItem.CheckedChanged, AddressOf checkItem_CheckedChanged
			Next item
		End Sub

		Protected Overrides Sub OnDetaching()
			MyBase.OnDetaching()
		End Sub
	End Class
End Namespace
