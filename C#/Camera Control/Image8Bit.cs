using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
namespace ImageProc
{
   /// <summary>

   /// Class used for direct memory access to 8bit grayscale images
   /// </summary>

   public class Image8Bit : IDisposable
   {
      private BitmapData bmd;
      private Bitmap b;
      /// <summary>

      /// Locks an 8bit image in memory for fast get/set pixel functions.
      /// Remember to Dispose object to release memory.
      /// 

      /// Bitmap reference
      public Image8Bit (Bitmap bitmap)
      {
         if(bitmap.PixelFormat!=System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
            throw(new System.Exception("Invalid PixelFormat. 8 bit indexed required"));
         b = bitmap; //Store a private reference to the bitmap
         bmd = b.LockBits(new Rectangle(0, 0, b.Width, b.Height),
                          ImageLockMode.ReadWrite, b.PixelFormat);
      }
      
      /// <summary>

      /// Releases memory
      /// </summary>

      public void Dispose()
      {
         b.UnlockBits(bmd);
      }
      
      /// <summary>

      /// Gets color of an 8bit-pixel
      /// </summary>

      /// <param name="x">Row</param>
      /// <param name="y">Column</param>
      /// <returns>Color of pixel</returns>
      public unsafe System.Drawing.Color GetPixel(int x, int y)
      {
         byte* p = (byte *)bmd.Scan0.ToPointer();
         //always assumes 8 bit per pixels
         int offset=y*bmd.Stride+x;
         return GetColorFromIndex(p[offset]);
      }
      
      /// <summary>

      /// Sets color of an 8bit-pixel
      /// </summary>

      /// <param name="x">Row</param>
      /// <param name="y">Column</param>
      /// <param name="c">Color index</param>
      public unsafe void SetPixel(int x, int y, byte c)
      {
         byte* p = (byte *)bmd.Scan0.ToPointer();
         //always assumes 8 bit per pixels
         int offset=y*bmd.Stride+(x);
         p[offset] = c;
      }
      
      /// <summary>

      /// Sets the palette for the referenced image to Grayscale
      /// </summary>

      public void MakeGrayscale()
      {
         SetGrayscalePalette(this.b);
      }
      
      /// <summary>

      /// Sets the palette of an image to grayscales (0=black, 255=white)
      /// </summary>

      /// <param name="b">Bitmap to set palette on</param>
      public static void SetGrayscalePalette(Bitmap b)
      {
         ColorPalette pal = b.Palette;
         for(int i = 0; i < 256; i++)
            pal.Entries[i] = Color.FromArgb( 255, i, i, i );
         b.Palette = pal;
      }
      
      private System.Drawing.Color GetColorFromIndex(byte c)
      {
         return b.Palette.Entries[c];
      }
      public static Bitmap ResizeImage(Bitmap imgToResize, Size size)
      {
              /*
              Bitmap b = new Bitmap(size.Width, size.Height);
              using (Graphics g = Graphics.FromImage((Image)b))
              {
                  g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                  g.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
              }
              return b;
              */
          Bitmap b = new Bitmap(size.Width, size.Height);
          using (Graphics gr = Graphics.FromImage(b))
          {
              gr.SmoothingMode = SmoothingMode.HighQuality;
              //gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
              gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
              gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
              gr.DrawImage(imgToResize, new Rectangle(0, 0, size.Width, size.Height));
          }
          return b;
      }
   }

}


