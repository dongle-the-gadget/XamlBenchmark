# XAML Framework Performance Comparison

Thanks to Microsoft's recent work on their MAUI cross-platform graphics library, creating a mostly apples to apples performance test has been made much easier.

Test cases were adjusted somewhat because MAUI is not yet equivalent in all drawing operations across the different XAML frameworks.  The work done on the Windows Community Toolkit demonstrates that it is possible to do equivalent drawing operations in UWP and WinUI, but those approaches are not yet reflected in the code of MAUI.

This is not an exaustive performance test, but it does touch on the core capabilities of the XAML frameworks being tested.

## Results

[Coming soon]

## License

[MIT License](LICENSE)

## Credits and Ideas

https://github.com/dotnet/Microsoft.Maui.Graphics

https://github.com/noemata/XamlBenchmark

## Caveats

A detailed analysis of whether this test is an exact 1:1 performance comparison has not been done.  It is assumed that Microsoft has done a good job of architecting the framework specific rendering code.

If you examine the code, you will see an almost equivalent test implementation for WPF, UWP and WinUI. UWP and WinUI are in fact 1:1 in every respect.

## Notes

[Coming soon]
