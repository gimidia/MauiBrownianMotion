using SkiaSharp;
using SkiaSharp.Views.Maui;
using MauiBrownianMotion.ViewModels;

namespace MauiBrownianMotion.Views;

public partial class MainPage : ContentPage
{
    private BrownianViewModel VM => BindingContext as BrownianViewModel;

    public MainPage()
    {
        InitializeComponent();
        VM.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(VM.Prices))
                ChartCanvas.InvalidateSurface();
        };
    }

    private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
    {
        var canvas = e.Surface.Canvas;
        canvas.Clear(new SKColor(30, 30, 47)); // fundo escuro do gráfico

        if (VM.Prices == null || VM.Prices.Count == 0)
            return;

        float width = e.Info.Width;
        float height = e.Info.Height;

        double maxPrice = VM.Prices.Max();
        double minPrice = VM.Prices.Min();

        using var paint = new SKPaint
        {
            Color = new SKColor(150, 140, 255), // lilás
            StrokeWidth = 2,
            IsAntialias = true,
            Style = SKPaintStyle.Stroke
        };

        var path = new SKPath();
        for (int i = 0; i < VM.Prices.Count; i++)
        {
            float x = (float)i / (VM.Prices.Count - 1) * width;
            float y = height - (float)((VM.Prices[i] - minPrice) / (maxPrice - minPrice) * height);

            if (i == 0)
                path.MoveTo(x, y);
            else
                path.LineTo(x, y);
        }

        canvas.DrawPath(path, paint);
    }
}
