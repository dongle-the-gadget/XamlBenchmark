#if WINDOWS_UWP
global using PlatformXaml = Windows.UI.Xaml;
global using Windows.UI.Xaml.Media;
global using Windows.UI.Xaml.Controls;
global using Windows.UI.Xaml.Shapes;
global using Windows.UI.Xaml;
global using Windows.UI.Input;

global using static Windows.UI.Colors;
#else
global using PlatformXaml = Microsoft.UI.Xaml;
global using Microsoft.UI.Xaml.Media;
global using Microsoft.UI.Xaml.Controls;
global using Microsoft.UI.Xaml.Shapes;
global using Microsoft.UI.Xaml;
global using Microsoft.UI.Input;
global using Microsoft.UI.Text;

global using static Microsoft.UI.Colors;
#endif

global using Windows.UI.Text;