using System;
using System.Collections.Generic;
using System.IO;
using Android.Content;
using Android.Hardware;
using Android.Runtime;
using Android.Views;
using Java.IO;
using Xamarin.Forms;

namespace CustomRenderer.Droid
{
	public sealed class CameraPreview : ViewGroup, ISurfaceHolderCallback , Camera.IPictureCallback
	{
		SurfaceView surfaceView;
		ISurfaceHolder holder;
		Camera.Size previewSize;
		IList<Camera.Size> supportedPreviewSizes;
		Camera camera;
		IWindowManager windowManager;

		public bool IsPreviewing { get; set; }

		public Camera Preview {
			get { return camera; }
			set {
				camera = value;
				if (camera != null) {
					supportedPreviewSizes = Preview.GetParameters ().SupportedPreviewSizes;
					RequestLayout ();
				}
			}
		}

		public CameraPreview (Context context)
			: base (context)
		{
			surfaceView = new SurfaceView (context);
			AddView (surfaceView);

			windowManager = Context.GetSystemService (Context.WindowService).JavaCast<IWindowManager> ();

			IsPreviewing = false;
			holder = surfaceView.Holder;
			holder.AddCallback (this);

			MessagingCenter.Subscribe<object>(this, "A", (e) =>
			{
				camera.TakePicture(null,null,this);
			});
		}

		protected override void OnMeasure (int widthMeasureSpec, int heightMeasureSpec)
		{
			int width = ResolveSize (SuggestedMinimumWidth, widthMeasureSpec);
			int height = ResolveSize (SuggestedMinimumHeight, heightMeasureSpec);
			SetMeasuredDimension (width, height);

			if (supportedPreviewSizes != null) {
				previewSize = GetOptimalPreviewSize (supportedPreviewSizes, width, height);
			}
		}

		protected override void OnLayout (bool changed, int l, int t, int r, int b)
		{
			var msw = MeasureSpec.MakeMeasureSpec (r - l, MeasureSpecMode.Exactly);
			var msh = MeasureSpec.MakeMeasureSpec (b - t, MeasureSpecMode.Exactly);

			surfaceView.Measure (msw, msh);
			surfaceView.Layout (0, 0, r - l, b - t);
		}

		public void SurfaceCreated (ISurfaceHolder holder)
		{
			try {
				if (Preview != null) {
					Preview.SetPreviewDisplay (holder);
				}
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine (@"			ERROR: ", ex.Message);
			}
		}

		public void SurfaceDestroyed (ISurfaceHolder holder)
		{
			if (Preview != null) {
				Preview.StopPreview ();
			}
		}

		public void SurfaceChanged (ISurfaceHolder holder, Android.Graphics.Format format, int width, int height)
		{
			var parameters = Preview.GetParameters ();
			parameters.SetPreviewSize (previewSize.Width, previewSize.Height);
			RequestLayout ();

			switch (windowManager.DefaultDisplay.Rotation) {
			case SurfaceOrientation.Rotation0:
				camera.SetDisplayOrientation (90);
				break;
			case SurfaceOrientation.Rotation90:
				camera.SetDisplayOrientation (0);
				break;
			case SurfaceOrientation.Rotation270:
				camera.SetDisplayOrientation (180);
				break;
			}

			Preview.SetParameters (parameters);
			Preview.StartPreview ();
			IsPreviewing = true;
		}

		Camera.Size GetOptimalPreviewSize (IList<Camera.Size> sizes, int w, int h)
		{
			const double AspectTolerance = 0.1;
			double targetRatio = (double)w / h;

			if (sizes == null) {
				return null;
			}

			Camera.Size optimalSize = null;
			double minDiff = double.MaxValue;

			int targetHeight = h;
			foreach (Camera.Size size in sizes) {
				double ratio = (double)size.Width / size.Height;

				if (Math.Abs (ratio - targetRatio) > AspectTolerance)
					continue;
				if (Math.Abs (size.Height - targetHeight) < minDiff) {
					optimalSize = size;
					minDiff = Math.Abs (size.Height - targetHeight);
				}
			}

			if (optimalSize == null) {
				minDiff = double.MaxValue;
				foreach (Camera.Size size in sizes) {
					if (Math.Abs (size.Height - targetHeight) < minDiff) {
						optimalSize = size;
						minDiff = Math.Abs (size.Height - targetHeight);
					}
				}
			}

			return optimalSize;
		}

        public void OnPictureTaken(byte[] data, Camera camera)
        {
			camera.StopPreview();

            FileOutputStream outStream = null;
			Java.IO.File dataDir = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim);
            if (data != null)
            {
                try
                {

					TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
					var s = ts.TotalMilliseconds;
					outStream = new FileOutputStream(dataDir + "/" + s + ".jpg");
                    outStream.Write(data);
                    outStream.Close();
                }
                catch (Java.IO.FileNotFoundException e)
                {
                    System.Console.Out.WriteLine(e.Message);
                }
                catch (Java.IO.IOException ie)
                {
                    System.Console.Out.WriteLine(ie.Message);
                }
            }
            camera.StartPreview();
		}
    }
}
