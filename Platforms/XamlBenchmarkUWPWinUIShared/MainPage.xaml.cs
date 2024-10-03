using System.Diagnostics;

#if WINDOWS_UWP
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls;
#else
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Controls;
#endif

using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Xaml;

using GraphicsTester.Scenarios;

namespace XamlBenchmark
{
    public sealed partial class MainPage : Page
    {
        private readonly XamlCanvas canvas = new XamlCanvas();
        private IDrawable drawable;
        const int TestIterations = GlobalVariables.TestCount;
        int testIncrement = -1;
        Stopwatch timer = new Stopwatch();

        public MainPage()
        {
            this.InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            canvas.Canvas = Canvas;

            foreach (var scenario in ScenarioList.Scenarios)
            {
                List.Items.Add(scenario);
            }

            List.SelectedIndex = 0;
            List.SelectionChanged += (source, args) => Drawable = List.SelectedItem as IDrawable;
            Drawable = List.SelectedItem as IDrawable;
            this.SizeChanged += (source, args) => Draw();

            CompositionTarget.Rendering += OnRendering;
        }

        public IDrawable Drawable
        {
            get => drawable;
            set
            {
                drawable = value;
                Draw();
            }
        }

        private void Draw()
        {
            if (drawable != null)
            {
                using (canvas.CreateSession())
                {
                    drawable.Draw(canvas, new RectangleF(0, 0, (float)Canvas.Width, (float)Canvas.Height));
                }
            }
        }

        private void OnRendering(object sender, object e)
        {
            if (testIncrement != -1)
            {
                int step = testIncrement++ % 3;

                switch (step)
                {
                    case 0:
                        List.SelectedIndex = ScenarioList.Scenarios.Count - 1;
                        break;
                    case 1:
                        List.SelectedIndex = 9;
                        break;

                    case 2:
                        List.SelectedIndex = 27;
                        break;
                }

                Drawable = List.SelectedItem as IDrawable;

                if (testIncrement >= TestIterations)
                {
                    timer.Stop();
                    GlobalVariables.TotalElapsedMM = timer.ElapsedMilliseconds;

                    Elapsed.Text = $"{GlobalVariables.TotalElapsedMM} ms";
                    Passes.Text = $"{GlobalVariables.TotalPasses}";

                    testIncrement = -1;
                }
            }
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            if (testIncrement == -1)
            {
                testIncrement = 0;
                GlobalVariables.TotalPasses = 0;
                GlobalVariables.TotalElapsedMM = 0;
                timer.Reset();
                timer.Start();
            }
            else
            {
                testIncrement = -1;
                timer.Stop();
            }
        }
    }
}
