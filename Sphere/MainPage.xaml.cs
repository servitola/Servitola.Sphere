using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Effects;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Sphere
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

	        InitComposition();

        }

		private void InitComposition()
		{
			var hostVisual = ElementCompositionPreview.GetElementVisual(top);
			var compositor = hostVisual.Compositor;
			var root = compositor.CreateContainerVisual();
			ElementCompositionPreview.SetElementChildVisual(top, root);

			var visual = compositor.CreateSpriteVisual();

			visual.Size = new Vector2(675, 248);
			visual.Offset = new Vector3(50, 50, 0);

			var sv = compositor.CreateSpriteVisual();
			sv.Size = new Vector2(150, 150);
			sv.Brush = compositor.CreateColorBrush(Color.FromArgb(100, 255, 0, 5));
			sv.CenterPoint = new Vector3(20, 20, 10);

			root.Children.InsertAtTop(sv);

			//this.top.Children.Add();
			//this.Content.

			// Can be found at https://github.com/robmikh/compositionimageloader
			//var imageLoader = ImageLoaderFactory.CreateImageLoader(compositor);

			//var surface = imageLoader.LoadImageFromUri(new Uri("http://ncmedia.azureedge.net/ncmedia/2014/10/MSFT_logo_rgb_C-Gray.png"));
			//var brush = compositor.CreateSurfaceBrush(surface);

			//IGraphicsEffect graphicsEffect = new InvertEffect
			//{
			//	Name = "invertEffect",
			//	Source = new CompositionEffectSourceParameter("image")
			//};
			//var effectFactory = compositor.CreateEffectFactory(graphicsEffect);

			//var effectBrush = effectFactory.CreateBrush();
			//effectBrush.SetSourceParameter("image", brush);

			//visual.Brush = effectBrush;

			//ElementCompositionPreview.SetElementChildVisual(this, visual);
		}
	}
}
