// Developer Express Code Central Example:
// How to create a pop-up menu with all DockLayoutManager's panels
// 
// This example demonstrates how to create a pop-up menu with all
// DockLayoutManager's panels, which show the current active state of each
// panel.
// For this, we create a BarManager with a BarSubItem. After that, we
// subscribe to the BarSubItem's Popup event. When Popup is raised, we get a list
// of all DockLayoutManager's panels. We iterate through this list and add this
// BarCheckItem to the BarSubItem with a respective panel as a tag. We check the
// DockLayoutSource's ActiveLayoutItem. If the ActiveLayoutItem equals a panel from
// the list, we set the BarCheckItem's IsChecked property to True. Then, we
// subscribe to the BarCheckItem's CheckedChanged event. When CheckedChanged is
// raised, we get a panel from a current BarCheckItem's tag and activate this
// panel.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=T167144

using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("DockLayoutSelectExample")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("DockLayoutSelectExample")]
[assembly: AssemblyCopyright("Copyright ©  2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

//In order to begin building localizable applications, set 
//<UICulture>CultureYouAreCodingWith</UICulture> in your .csproj file
//inside a <PropertyGroup>.  For example, if you are using US english
//in your source files, set the <UICulture> to en-US.  Then uncomment
//the NeutralResourceLanguage attribute below.  Update the "en-US" in
//the line below to match the UICulture setting in the project file.

//[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)]


[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
    //(used if a resource is not found in the page, 
    // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
    //(used if a resource is not found in the page, 
    // app, or any theme specific resource dictionaries)
)]


// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
