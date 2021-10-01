using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace Clock
{
    public partial class MainPage : ContentPage
    {

        static int border = 8;

        SKPaint lineStrokePaint = new SKPaint
        {
            Style = SKPaintStyle.StrokeAndFill,
            StrokeCap = SKStrokeCap.Round,
            Color = SKColors.Orange,
            StrokeWidth = border * 2
        };

        SKPaint dotsPaint = new SKPaint
        {
            Style = SKPaintStyle.StrokeAndFill,
            Color = SKColors.Orange,
        };

        SKPaint backgroundFillPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Black
        };
        void OnCanvasPaintNumber(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.DrawPaint(backgroundFillPaint);

            string name = "";
            var canvasInfo = (SKCanvasView)sender;
            var grid = canvasInfo.Parent;

            string[] canvasNames = { "canvasFirstHour", "canvasSecondHour", "canvasFirstMinute", 
                                     "canvasSecondMinute", "canvasFirstSecond", "canvasSecondSecond" };

            foreach(var canvasName in canvasNames)
            {
                var canvasElem = (SKCanvasView)grid.FindByName(canvasName);
                if (canvasElem.Id == canvasInfo.Id)
                {
                    name = canvasName;
                    break;
                }
            }

            int number;
            DateTime dateTime = DateTime.Now;
            switch (name)
            {
                case "canvasFirstHour":
                    number = dateTime.Hour / 10;
                    break;
                case "canvasSecondHour":
                    number = dateTime.Hour % 10;
                    break;
                case "canvasFirstMinute":
                    number = dateTime.Minute / 10;
                    break;
                case "canvasSecondMinute":
                    number = dateTime.Minute % 10;
                    break;
                case "canvasFirstSecond":
                    number = dateTime.Second / 10;
                    break;
                case "canvasSecondSecond":
                    number = dateTime.Second % 10;
                    break;
                default:
                    number = -1;
                    break;
            }

            DrawNumber(canvas, info.Width - border, info.Height - border, number);
        }

        void DrawNumber(SKCanvas canvas, int width, int height, int number)
        {
            switch (number)
            {
                case 0:
                    canvas.DrawLine(border, border, width, border, lineStrokePaint);
                    canvas.DrawLine(width, border, width, height, lineStrokePaint);
                    canvas.DrawLine(width, height, border, height, lineStrokePaint);
                    canvas.DrawLine(border, height, border, border, lineStrokePaint);
                    break;
                case 1:
                    canvas.DrawLine(width / 2, height / 2, width, border, lineStrokePaint);
                    canvas.DrawLine(width, border, width, height, lineStrokePaint);

                    break;
                case 2:
                    canvas.DrawLine(border, border, width, border, lineStrokePaint);
                    canvas.DrawLine(width, border, width, height / 2, lineStrokePaint);
                    canvas.DrawLine(width, height / 2, border, height / 2, lineStrokePaint);
                    canvas.DrawLine(border, height / 2, border, height, lineStrokePaint);
                    canvas.DrawLine(width, height, border, height, lineStrokePaint);
                    break;
                case 3:
                    canvas.DrawLine(border, border, width, border, lineStrokePaint);
                    canvas.DrawLine(width, border, width, height / 2, lineStrokePaint);
                    canvas.DrawLine(width, height / 2, border, height / 2, lineStrokePaint);
                    canvas.DrawLine(width, height / 2, width, height, lineStrokePaint);
                    canvas.DrawLine(width, height, border, height, lineStrokePaint);
                    break;
                case 4:
                    canvas.DrawLine(border, border, border, height / 2, lineStrokePaint);
                    canvas.DrawLine(border, height / 2, width, height / 2, lineStrokePaint);
                    canvas.DrawLine(width, border, width, height, lineStrokePaint);
                    break;
                case 5:
                    canvas.DrawLine(border, border, width, border, lineStrokePaint);
                    canvas.DrawLine(border, border, border, height / 2, lineStrokePaint);
                    canvas.DrawLine(border, height / 2, width, height / 2, lineStrokePaint);
                    canvas.DrawLine(width, height / 2, width, height, lineStrokePaint);
                    canvas.DrawLine(width, height, border, height, lineStrokePaint);
                    break;
                case 6:
                    canvas.DrawLine(border, border, width, border, lineStrokePaint);
                    canvas.DrawLine(border, border, border, height, lineStrokePaint);
                    canvas.DrawLine(border, height / 2, width, height / 2, lineStrokePaint);
                    canvas.DrawLine(width, height / 2, width, height, lineStrokePaint);
                    canvas.DrawLine(width, height, border, height, lineStrokePaint);
                    break;
                case 7:
                    canvas.DrawLine(border, border, width, border, lineStrokePaint);
                    canvas.DrawLine(width, border, width, height, lineStrokePaint);
                    break;
                case 8:
                    canvas.DrawLine(border, border, width, border, lineStrokePaint);
                    canvas.DrawLine(border, border, border, height, lineStrokePaint);
                    canvas.DrawLine(border, height / 2, width, height / 2, lineStrokePaint);
                    canvas.DrawLine(width, border, width, height, lineStrokePaint);
                    canvas.DrawLine(width, height, border, height, lineStrokePaint);
                    break;
                case 9:
                    canvas.DrawLine(border, border, width, border, lineStrokePaint);
                    canvas.DrawLine(border, border, border, height / 2, lineStrokePaint);
                    canvas.DrawLine(border, height / 2, width, height / 2, lineStrokePaint);
                    canvas.DrawLine(width, border, width, height, lineStrokePaint);
                    canvas.DrawLine(width, height, border, height, lineStrokePaint);
                    break;
            }
        }

        void OnCanvasPaintDots(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.DrawPaint(backgroundFillPaint);

            canvas.DrawCircle(args.Info.Width / 2, args.Info.Height / 3, 10, dotsPaint);
            canvas.DrawCircle(args.Info.Width / 2, args.Info.Height / 3 * 2, 10, dotsPaint);
        }

        public MainPage()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(1f / 60), () =>
            {
                canvasFirstHour.InvalidateSurface();
                canvasSecondHour.InvalidateSurface();
                canvasFirstMinute.InvalidateSurface();
                canvasSecondMinute.InvalidateSurface();
                canvasFirstSecond.InvalidateSurface();
                canvasSecondSecond.InvalidateSurface();
                return true;
            });
        }
    }
}
