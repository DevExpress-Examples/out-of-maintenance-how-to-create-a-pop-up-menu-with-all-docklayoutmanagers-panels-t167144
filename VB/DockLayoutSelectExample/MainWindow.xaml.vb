Imports Microsoft.VisualBasic
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
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace DockLayoutSelectExample
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim group = dock1.LayoutRoot
			Dim randomPanel As New LayoutPanel()
			randomPanel.Caption = "Random Panel " & New Random().Next(1, 100)
			group.Add(randomPanel)
		End Sub
	End Class
End Namespace
