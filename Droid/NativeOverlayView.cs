using System;
using Android.Content;
using Android.Graphics;
using Android.Views;
using CustomRenderer;
using XEssentials = Xamarin.Essentials;
using XForms = Xamarin.Forms;

namespace CustomRenderer.Droid.Views
{
    public class NativeOverlayView : View
    {
        Bitmap windowFrame;


        float overlayOpacity = 0.5f;


        bool showOverlay = false;
        public bool ShowOverlay
        {
            get { return showOverlay; }
            set
            {
                bool repaint = !showOverlay;
                showOverlay = value;
                if (repaint)
                {
                    Redraw();
                }
            }
        }


        public float Opacity
        {
            get { return overlayOpacity; }
            set
            {
                overlayOpacity = value;
                Redraw();
            }
        }

        Color overlayColor = Color.Gray;
        public Color OverlayBackgroundColor
        {
            get { return overlayColor; }
            set
            {
                overlayColor = value;
                Redraw();

            }
        }

        OverlayShape overlayShape = OverlayShape.Oval;

        public OverlayShape Shape
        {
            get { return overlayShape; }
            set
            {
                overlayShape = value;
                Redraw();

            }
        }


        double shapeScale;
        public double ShapeScale
        {
            get { return shapeScale; }
            set
            {
                XForms.Device.BeginInvokeOnMainThread(async () =>
                {
                    var ShapeScale = await XEssentials.SecureStorage.GetAsync("ShapeScale");

                    if (ShapeScale == "0.5")
                    {
                        shapeScale = 0.5;
                    }

                    if (shapeScale != value)
                    {
                        Redraw();
                    }

                    shapeScale = value;
                });


            }
        }

        public NativeOverlayView(Context context, bool showOverlay = false) : base(context)
        {
            ShowOverlay = showOverlay;
            SetWillNotDraw(false);
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            if (ShowOverlay)
            {
                if (windowFrame == null)
                {
                    CreateWindowFrame();
                }
                canvas.DrawBitmap(windowFrame, 0, 0, null);
            }
        }
        void Redraw()
        {
            if (ShowOverlay)
            {
                windowFrame?.Recycle();
                windowFrame = null;
                Invalidate();
            }
        }
        void CreateWindowFrame()
        {
            float width = this.Width;
            float height = this.Height;

            windowFrame = Bitmap.CreateBitmap((int)width, (int)height, Bitmap.Config.Argb8888);
            Canvas osCanvas = new Canvas(windowFrame);
            Paint paint = new Paint(PaintFlags.AntiAlias)
            {
                Color = OverlayBackgroundColor,
                Alpha = (int)(255 * Opacity)
            };

            RectF outerRectangle = new RectF(0, 0, width, height);

            osCanvas.DrawRect(outerRectangle, paint);

            paint.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.Clear));

            XForms.Device.BeginInvokeOnMainThread(async () =>
            {
                var ShapeScale = await XEssentials.SecureStorage.GetAsync("ShapeScale");

                if (ShapeScale == "0.6")
                {
                    shapeScale = 0.6;

                    float shapeWidth = (float)(width * shapeScale);
                    float shapeHeight = (float)(height * shapeScale);

                    switch (Shape)
                    {
                        case OverlayShape.Circle:
                            float radius = (Math.Min(shapeWidth, shapeHeight) * 0.45f);
                            osCanvas.DrawCircle(width / 2, height / 2, radius, paint);

                            break;

                        case OverlayShape.Oval:

                            RectF rect = new RectF(width / 2 - shapeWidth / 2, height / 2 - shapeHeight / 2, shapeWidth / 2 + width / 2, shapeHeight / 2 + height / 2);
                            osCanvas.DrawOval(rect, paint);

                            break;

                        default:

                            Path path = new Path();
                            // Starting point
                            path.MoveTo(shapeWidth / 2, shapeHeight / 5);

                            // Upper left path
                            path.CubicTo(5 * shapeWidth / 14, 0,
                                    0, shapeHeight / 15,
                                    shapeWidth / 28, 2 * shapeHeight / 5);

                            // Lower left path
                            path.CubicTo(shapeWidth / 14, 2 * shapeHeight / 3,
                                    3 * shapeWidth / 7, 5 * shapeHeight / 6,
                                    shapeWidth / 2, shapeHeight);

                            // Lower right path
                            path.CubicTo(4 * shapeWidth / 7, 5 * shapeHeight / 6,
                                    13 * shapeWidth / 14, 2 * shapeHeight / 3,
                                    27 * shapeWidth / 28, 2 * shapeHeight / 5);

                            // Upper right path
                            path.CubicTo(shapeWidth, shapeHeight / 15,
                                    9 * shapeWidth / 14, 0,
                                    shapeWidth / 2, shapeHeight / 5);

                            path.Offset(width / 2 - shapeWidth / 2, height / 2 - shapeHeight / 2);

                            osCanvas.DrawPath(path, paint);
                            break;
                    }
                }
            });
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            windowFrame?.Recycle();
            windowFrame = null;
        }
    }
}