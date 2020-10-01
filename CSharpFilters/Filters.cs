using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms.DataVisualization.Charting;

namespace CSharpFilters
{

	public static class BitmapFilter
	{
		public static Bitmap Invert(Bitmap b)
		{
			Bitmap bSrc = (Bitmap)b.Clone();
			BitmapData bmData = bSrc.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

			int stride = bmData.Stride;
			System.IntPtr Scan0 = bmData.Scan0;

			unsafe
			{
				byte* p = (byte*)(void*)Scan0;

				int nOffset = stride - b.Width * 3;
				int nWidth = b.Width * 3;

				for (int y = 0; y < b.Height; ++y)
				{
					for (int x = 0; x < nWidth; ++x)
					{
						p[0] = (byte)(255 - p[0]);
						++p;
					}
					p += nOffset;
				}
			}

			bSrc.UnlockBits(bmData);

			return bSrc;
		}

		public static Bitmap GrayScale(Bitmap b)
		{
			Bitmap bSrc = (Bitmap)b.Clone();
			BitmapData bmData = bSrc.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

			int stride = bmData.Stride;
			System.IntPtr Scan0 = bmData.Scan0;

			unsafe
			{
				byte* p = (byte*)(void*)Scan0;

				int nOffset = stride - b.Width * 3;

				byte red, green, blue;

				for (int y = 0; y < b.Height; ++y)
				{
					for (int x = 0; x < b.Width; ++x)
					{
						blue = p[0];
						green = p[1];
						red = p[2];

						p[0] = p[1] = p[2] = (byte)(.299 * red + .587 * green + .114 * blue);

						p += 3;
					}
					p += nOffset;
				}
			}

			bSrc.UnlockBits(bmData);

			return bSrc;
		}




		public static Bitmap Gamma(Bitmap bmp, double gamma)
		{
			Bitmap bSrc = (Bitmap)bmp.Clone();
			BitmapData bmpData = bSrc.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

			unsafe
			{
				byte* ptr = (byte*)bmpData.Scan0.ToPointer();
				int stopAddress = (int)ptr + bmpData.Stride * bmpData.Height;

				while ((int)ptr != stopAddress)
				{
					ptr[0] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(ptr[0] / 255.0, 1.0 / gamma))));
					ptr[1] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(ptr[1] / 255.0, 1.0 / gamma))));
					ptr[2] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(ptr[2] / 255.0, 1.0 / gamma))));
					ptr += 3;
				}
			}

			bSrc.UnlockBits(bmpData);
			return bSrc;
		}

		public static Bitmap RobertsPic(Bitmap b, double threshold)
		{
			Bitmap bSrc = new Bitmap(b);			
			BitmapData bmSrcData = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

			int stride = bmSrcData.Stride;

			unsafe
			{
				byte* p = (byte*)(void*)bmSrcData.Scan0;
				byte* pSrc = (byte*)(void*)bmSrcData.Scan0;

				int nOffset = stride - b.Width * 3;
				int nWidth = b.Width - 1;
				int nHeight = b.Height - 1;

				for (int y = 0; y < nHeight; ++y)
				{
					for (int x = 0; x < nWidth; ++x)
					{
						var p0 = ToGray(pSrc);
						var p1 = ToGray(pSrc + 3);
						var p2 = ToGray(pSrc + 3 + stride);

						if (Math.Abs(p1 - p2) + Math.Abs(p1 - p0) > threshold)
							p[0] = p[1] = p[2] = 255;
						else
							p[0] = p[1] = p[2] = 0;

						p += 3;
						pSrc += 3;
					}
					p += nOffset;
					pSrc += nOffset;
				}
			}

			bSrc.UnlockBits(bmSrcData);
			return bSrc;
		}

		static unsafe float ToGray(byte* bgr)
		{
			return bgr[2] * 0.3f + bgr[1] * 0.59f + bgr[0] * 0.11f;
		}

		private static Bitmap ConvolutionFilter(Bitmap sourceBitmap,double[,] filterMatrix,double factor = 1, int bias = 0, bool grayscale = false)
		{
			BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
			byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];
			Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

			sourceBitmap.UnlockBits(sourceData);
			if (grayscale == true)
			{
				float rgb = 0;
				for (int k = 0; k < pixelBuffer.Length; k += 4)
				{
					rgb = pixelBuffer[k] * 0.11f;
					rgb += pixelBuffer[k + 1] * 0.59f;
					rgb += pixelBuffer[k + 2] * 0.3f;

					pixelBuffer[k] = (byte)rgb;
					pixelBuffer[k + 1] = pixelBuffer[k];
					pixelBuffer[k + 2] = pixelBuffer[k];
					pixelBuffer[k + 3] = 255;
				}
			}


			double blue = 0.0;
			double green = 0.0;
			double red = 0.0;

			int filterWidth = filterMatrix.GetLength(1);
			int filterHeight = filterMatrix.GetLength(0);

			int filterOffset = (filterWidth - 1) / 2;
			int calcOffset = 0;

			int byteOffset = 0;

			for (int offsetY = filterOffset; offsetY <
				sourceBitmap.Height - filterOffset; offsetY++)
			{
				for (int offsetX = filterOffset; offsetX <
					sourceBitmap.Width - filterOffset; offsetX++)
				{
					blue = 0;
					green = 0;
					red = 0;

					byteOffset = offsetY * sourceData.Stride + offsetX * 4;


					for (int filterY = -filterOffset;filterY <= filterOffset; filterY++)
					{
						for (int filterX = -filterOffset;filterX <= filterOffset; filterX++)
						{
							calcOffset = byteOffset + (filterX * 4) + (filterY * sourceData.Stride);
							blue += (double)(pixelBuffer[calcOffset]) *filterMatrix[filterY + filterOffset, filterX + filterOffset];
							green += (double)(pixelBuffer[calcOffset + 1]) * filterMatrix[filterY + filterOffset, filterX + filterOffset];
							red += (double)(pixelBuffer[calcOffset + 2]) * filterMatrix[filterY + filterOffset,filterX + filterOffset];
						}
					}

					blue = factor * blue + bias;
					green = factor * green + bias;
					red = factor * red + bias;

					if (blue > 255)
					{ blue = 255; }
					else if (blue < 0)
					{ blue = 0; }

					if (green > 255)
					{ green = 255; }
					else if (green < 0)
					{ green = 0; }

					if (red > 255)
					{ red = 255; }
					else if (red < 0)
					{ red = 0; }


					resultBuffer[byteOffset] = (byte)(blue);
					resultBuffer[byteOffset + 1] = (byte)(green);
					resultBuffer[byteOffset + 2] = (byte)(red);
					resultBuffer[byteOffset + 3] = 255;
				}
			}


			Bitmap resultBitmap = new Bitmap(sourceBitmap.Width,sourceBitmap.Height);


			BitmapData resultData =resultBitmap.LockBits(new Rectangle(0, 0,resultBitmap.Width, resultBitmap.Height),ImageLockMode.WriteOnly,PixelFormat.Format32bppArgb);

			Marshal.Copy(resultBuffer, 0, resultData.Scan0,resultBuffer.Length);
			resultBitmap.UnlockBits(resultData);
			return resultBitmap;
		}
		public static double[,] Laplacian3x3
		{
			get
			{
				return new double[,]
				{ { -1, -1, -1, },
		 { -1,  8, -1, },
		 { -1, -1, -1, }, };
			}
		}

		public static Bitmap Laplacian3x3Filter(this Bitmap sourceBitmap, bool grayscale = true)
		{
			Bitmap resultBitmap =
				   ConvolutionFilter(sourceBitmap,
										Laplacian3x3,
										  1.0, 0, grayscale);
			return resultBitmap;
		}

		public static int[] Histogramm(Bitmap image)
        {
			int[] result = new int[256];

			Bitmap bSrc = (Bitmap)image.Clone();
			BitmapData bmData = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

			int stride = bmData.Stride;
			System.IntPtr Scan0 = bmData.Scan0;

			unsafe
			{
				byte* p = (byte*)(void*)Scan0;

				int nOffset = stride - bSrc.Width * 3;

				byte red, green, blue;

				for (int y = 0; y < bSrc.Height; ++y)
				{
					for (int x = 0; x < bSrc.Width; ++x)
					{
						blue = p[0];
						green = p[1];
						red = p[2];

						p[0] = p[1] = p[2] = (byte)(.299 * red + .587 * green + .114 * blue);
						int i = (int)(p[0]);
						result[i]++;

						p += 3;
					}
					p += nOffset;
				}
			}

			bSrc.UnlockBits(bmData);
			bSrc.Dispose();
			return result;
		}

		public static Bitmap equalizing(Bitmap img)
		{
			Bitmap bmp = (Bitmap)img.Clone();
			Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
			System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
			IntPtr ptr = bmpData.Scan0;
			int bytes = bmpData.Stride * bmp.Height;
			byte[] grayValues = new byte[bytes];
			int[] R = new int[256];
			byte[] N = new byte[256];
			byte[] left = new byte[256];
			byte[] right = new byte[256];
			System.Runtime.InteropServices.Marshal.Copy(ptr, grayValues, 0, bytes);
			for (int i = 0; i < grayValues.Length; i++) ++R[grayValues[i]];
			int z = 0;
			int Hint = 0;
			int Havg = grayValues.Length / R.Length;
			for (int i = 0; i < N.Length - 1; i++)
			{
				N[i] = 0;
			}
			for (int j = 0; j < R.Length; j++)
			{
				if (z > 255) left[j] = 255;
				else left[j] = (byte)z;
				Hint += R[j];
				while (Hint > Havg)
				{
					Hint -= Havg;
					z++;
				}
				if (z > 255) right[j] = 255;
				else right[j] = (byte)z;

				N[j] = (byte)((left[j] + right[j]) / 2);
			}
			for (int i = 0; i < grayValues.Length; i++)
			{
				if (left[grayValues[i]] == right[grayValues[i]]) grayValues[i] = left[grayValues[i]];
				else grayValues[i] = N[grayValues[i]];
			}

			System.Runtime.InteropServices.Marshal.Copy(grayValues, 0, ptr, bytes);
			bmp.UnlockBits(bmpData);
			return bmp;
		}
		public static Bitmap TresholdFilter(Bitmap image,int treshold)
        {
			Bitmap bSrc = (Bitmap)image.Clone();
			BitmapData bmData = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

			int stride = bmData.Stride;
			System.IntPtr Scan0 = bmData.Scan0;

			unsafe
			{
				byte* p = (byte*)(void*)Scan0;

				int nOffset = stride - bSrc.Width * 3;

				byte red, green, blue;

				for (int y = 0; y < bSrc.Height; ++y)
				{
					for (int x = 0; x < bSrc.Width; ++x)
					{
						blue = p[0];
						green = p[1];
						red = p[2];

						p[0] = p[1] = p[2] = (byte)(.299 * red + .587 * green + .114 * blue);
						if (p[0] > treshold)
							p[0] = 255;
						else p[0] = 0;
						p[1]=p[0];
						p[2] = p[0];
						p += 3;
					}
					p += nOffset;
				}
			}

			bSrc.UnlockBits(bmData);
			return bSrc;
		}

		public static Bitmap Dilotation(Bitmap SrcImage)
        {
			byte[,] sElement = new byte[3, 3]
			{
				{0,0,0 },
				{0,1,0 },
				{ 0,0,0}
			};
			Bitmap tempbmp = new Bitmap(SrcImage.Width, SrcImage.Height);

			BitmapData SrcData = SrcImage.LockBits(new Rectangle(0, 0,
				SrcImage.Width, SrcImage.Height), ImageLockMode.ReadOnly,
				PixelFormat.Format24bppRgb);

			BitmapData DestData = tempbmp.LockBits(new Rectangle(0, 0, tempbmp.Width,
				tempbmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);


			int size = 3;
			byte max, clrValue;
			int radius = size / 2;
			int ir, jr;

			unsafe
			{

				for (int colm = radius; colm < DestData.Height - radius; colm++)
				{
					byte* ptr = (byte*)SrcData.Scan0 + (colm * SrcData.Stride);
					byte* dstPtr = (byte*)DestData.Scan0 + (colm * SrcData.Stride);

					for (int row = radius; row < DestData.Width - radius; row++)
					{
						max = 0;
						clrValue = 0;

						for (int eleColm = 0; eleColm < 3; eleColm++)
						{
							ir = eleColm - radius;
							byte* tempPtr = (byte*)SrcData.Scan0 +
								((colm + ir) * SrcData.Stride);

							for (int eleRow = 0; eleRow <3; eleRow++)
							{
								jr = eleRow - radius;

								clrValue = (byte)((tempPtr[row * 3 + jr] +
								tempPtr[row * 3 + jr + 1] + tempPtr[row * 3 + jr + 2]) / 3);

								if (max < clrValue)
								{
									if (sElement[eleColm, eleRow] != 0)
										max = clrValue;
								}
							}
						}

						dstPtr[0] = dstPtr[1] = dstPtr[2] = max;
						ptr += 3;
						dstPtr += 3;
					}
				}
			}

			SrcImage.UnlockBits(SrcData);
			tempbmp.UnlockBits(DestData);
			return tempbmp;
		}

		private static byte[,] shape
		{
			get
			{
				return new byte[,]
				{
					{ 0, 1, 0 },
					{ 1, 1, 1 },
					{ 0, 1, 0 }
				};
			}
		}


		public static Bitmap Errosion(Bitmap srcImg, int kernelSize)
		{

			//Create image dimension variables for convenience
			int width = srcImg.Width;
			int height = srcImg.Height;

			//Lock bits to system memory for fast processing
			Rectangle canvas = new Rectangle(0, 0, width, height);
			BitmapData srcData = srcImg.LockBits(canvas, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			int stride = srcData.Stride;
			int bytes = stride * srcData.Height;

			//Create byte arrays that will hold all pixel data, one for processing, one for output
			byte[] pixelBuffer = new byte[bytes];
			byte[] resultBuffer = new byte[bytes];

			//Write pixel data to array meant for processing
			Marshal.Copy(srcData.Scan0, pixelBuffer, 0, bytes);
			srcImg.UnlockBits(srcData);

			//Convert to grayscale
			float rgb = 0;
			for (int i = 0; i < bytes; i += 4)
			{
				rgb = pixelBuffer[i] * .071f;
				rgb += pixelBuffer[i + 1] * .71f;
				rgb += pixelBuffer[i + 2] * .21f;
				pixelBuffer[i] = (byte)rgb;
				pixelBuffer[i + 1] = pixelBuffer[i];
				pixelBuffer[i + 2] = pixelBuffer[i];
				pixelBuffer[i + 3] = 255;
			}


			int kernelDim = kernelSize;

			//This is the offset of center pixel from border of the kernel
			int kernelOffset = (kernelDim - 1) / 2;
			int calcOffset = 0;
			int byteOffset = 0;
			for (int y = kernelOffset; y < height - kernelOffset; y++)
			{
				for (int x = kernelOffset; x < width - kernelOffset; x++)
				{
					byte value = 0;
					byteOffset = y * stride + x * 4;

					//Apply dilation
					for (int ykernel = -kernelOffset; ykernel <= kernelOffset; ykernel++)
					{
						for (int xkernel = -kernelOffset; xkernel <= kernelOffset; xkernel++)
						{
							if (shape[ykernel + kernelOffset, xkernel + kernelOffset] == 1)
							{
								calcOffset = byteOffset + ykernel * stride + xkernel * 4;
								value = Math.Max(value, pixelBuffer[calcOffset]);
							}
							else
							{
								continue;
							}
						}
					}
					//Write processed data into the second array
					resultBuffer[byteOffset] = value;
					resultBuffer[byteOffset + 1] = value;
					resultBuffer[byteOffset + 2] = value;
					resultBuffer[byteOffset + 3] = 255;
				}
			}

			//Create output bitmap of this function
			Bitmap rsltImg = new Bitmap(width, height);
			BitmapData rsltData = rsltImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

			//Write processed data into bitmap form
			Marshal.Copy(resultBuffer, 0, rsltData.Scan0, bytes);
			rsltImg.UnlockBits(rsltData);
			return rsltImg;
		}

		public static Bitmap MedianFilter(this Bitmap sourceBitmap,int matrixSize,int bias = 0,bool grayscale = false)
		{
			BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

			byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
			byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];
			Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

			sourceBitmap.UnlockBits(sourceData);


			if (grayscale == true)
			{
				float rgb = 0;
				for (int k = 0; k < pixelBuffer.Length; k += 4)
				{
					rgb = pixelBuffer[k] * 0.11f;
					rgb += pixelBuffer[k + 1] * 0.59f;
					rgb += pixelBuffer[k + 2] * 0.3f;

					pixelBuffer[k] = (byte)rgb;
					pixelBuffer[k + 1] = pixelBuffer[k];
					pixelBuffer[k + 2] = pixelBuffer[k];
					pixelBuffer[k + 3] = 255;
				}
			}

			int filterOffset = (matrixSize - 1) / 2;
			int calcOffset = 0;
			int byteOffset = 0;

			List<int> neighbourPixels = new List<int>();
			byte[] middlePixel;

			for (int offsetY = filterOffset; offsetY <sourceBitmap.Height - filterOffset; offsetY++)
			{
				for (int offsetX = filterOffset; offsetX <sourceBitmap.Width - filterOffset; offsetX++)
				{
					byteOffset = offsetY * sourceData.Stride + offsetX * 4;neighbourPixels.Clear();

					for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
					{
						for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
						{
							calcOffset = byteOffset + (filterX * 4) + (filterY * sourceData.Stride);
							neighbourPixels.Add(BitConverter.ToInt32( pixelBuffer, calcOffset));
						}
					}

					neighbourPixels.Sort();
					middlePixel = BitConverter.GetBytes(neighbourPixels[filterOffset]);


					resultBuffer[byteOffset] = middlePixel[0];
					resultBuffer[byteOffset + 1] = middlePixel[1];
					resultBuffer[byteOffset + 2] = middlePixel[2];
					resultBuffer[byteOffset + 3] = middlePixel[3];
				}
			}
			Bitmap resultBitmap = new Bitmap(sourceBitmap.Width,sourceBitmap.Height);
			BitmapData resultData =resultBitmap.LockBits(new Rectangle(0, 0,resultBitmap.Width, resultBitmap.Height),ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

			Marshal.Copy(resultBuffer, 0, resultData.Scan0,resultBuffer.Length);
			resultBitmap.UnlockBits(resultData);
			return resultBitmap;
		}
	}
}
