using System.Collections.Generic;
using System.Drawing;

namespace ContourSearch
{
    internal class ContourDetector
    {
        private Bitmap _img;
        private int[] _rgbArray;
        private RGB[] _rgbPixels;

        public ContourDetector(Bitmap picture)
        {
            _img = picture;

            CalculateImagePixels();
        }

        public ContourDetector(string pictureFile)
        {
            _img = new Bitmap(pictureFile);

            CalculateImagePixels();
        }

        private void CalculateImagePixels()
        {
            _rgbArray = new int[_img.Width * _img.Height];

            _img.getRGB(0, 0, _img.Width, _img.Height, ref _rgbArray, 0, _img.Width);

            _rgbPixels = new RGB[_rgbArray.Length];
            for (int i = 0; i < _rgbArray.Length; i++)
            {
                _rgbPixels[i] = new RGB();
                _rgbPixels[i].BytesToRGB(_rgbArray[i]);
            }
        }
        /*
        public bool[] FindContourInRGB(int uncertainty)
        {
            bool[] contour = new bool[_rgbPixels.Length];

            for (int i = 1; i < _img.Height-1; i++)
            {
                for (int j = 1; j < _img.Width-1; j++)
                {
                    int cPos = i * _img.Width + j;

                    contour[cPos - 1] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos - 1], uncertainty); // left
                    contour[cPos + 1] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos + 1], uncertainty); // right
                    
                    contour[cPos - _img.Width] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos - _img.Width], uncertainty); // up
                    contour[cPos + _img.Width] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos + _img.Width], uncertainty); // down
                    
                    contour[cPos - 1 - _img.Width] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos - 1 - _img.Width], uncertainty); // left up
                    contour[cPos + 1 - _img.Width] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos + 1 - _img.Width], uncertainty); // right up

                    contour[cPos - 1 + _img.Width] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos - 1 + _img.Width], uncertainty); // left down
                    contour[cPos + 1 + _img.Width] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos + 1 + _img.Width], uncertainty); // right down
                }
            }

            return contour;
        }*/

        public bool[] FindContourInRGB(int uncertainty)
        {
            List<int> objCount = new List<int>();
            List<RGB> obj = FindObjectsInRGB(ref objCount, uncertainty);

            int fonNum = 0;
            for (int i = 1; i < objCount.Count; i++)
            {
                if (objCount[i] > objCount[fonNum])
                {
                    fonNum = i;
                }
            }

            bool[] contour = new bool[_rgbPixels.Length];

            for (int i = 0; i < contour.Length; i++)
            {
                contour[i] = true;
            }

            for (int i = 0; i < _img.Height; i++)
            {
                for (int j = 0; j < _img.Width; j++)
                {
                    int cPos = i * _img.Width + j;

                    if (!_rgbPixels[cPos].IsRoughlyEqual(obj[fonNum], uncertainty))
                    {
                        continue;
                    }

                    if (j != 0)
                    { contour[cPos - 1] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos - 1], uncertainty); } // left
                    if (j + 1 < _img.Width)
                    { contour[cPos + 1] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos + 1], uncertainty); } // right

                    if (i != 0)
                    { contour[cPos - _img.Width] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos - _img.Width], uncertainty); } // up
                    if (i + 1 < _img.Height)
                    { contour[cPos + _img.Width] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos + _img.Width], uncertainty); } // down

                    if (j != 0 && i != 0)
                    { contour[cPos - 1 - _img.Width] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos - 1 - _img.Width], uncertainty); } // left up
                    if (j + 1 < _img.Width && i != 0)
                    { contour[cPos + 1 - _img.Width] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos + 1 - _img.Width], uncertainty); } // right up

                    if (i != 0 && i + 1 < _img.Height)
                    { contour[cPos - 1 + _img.Width] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos - 1 + _img.Width], uncertainty); } // left down
                    if (j + 1 < _img.Width && i + 1 < _img.Height)
                    { contour[cPos + 1 + _img.Width] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos + 1 + _img.Width], uncertainty); } // right down
                }
            }

            return contour;
        }

        public bool[] FindContourInRGB(int uncertainty, ref RGB fonColor)
        {
            List<int> objCount = new List<int>();
            List<RGB> obj = FindObjectsInRGB(ref objCount, uncertainty);

            int fonNum = 0;
            for (int i = 1; i < objCount.Count; i++)
            {
                if (objCount[i] > objCount[fonNum])
                {
                    fonNum = i;
                }
            }

            fonColor = obj[fonNum];

            bool[] contour = new bool[_rgbPixels.Length];

            for (int i = 0; i < contour.Length; i++)
            {
                contour[i] = true;
            }

            for (int i = 0; i < _img.Height; i++)
            {
                for (int j = 0; j < _img.Width; j++)
                {
                    int cPos = i * _img.Width + j;

                    if (!_rgbPixels[cPos].IsRoughlyEqual(obj[fonNum], uncertainty))
                    {
                        continue;
                    }

                    if (j != 0)
                    { contour[cPos - 1] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos - 1], uncertainty); } // left
                    if (j + 1 < _img.Width)
                    { contour[cPos + 1] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos + 1], uncertainty); } // right

                    if (i != 0)
                    { contour[cPos - _img.Width] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos - _img.Width], uncertainty); } // up
                    if (i + 1 < _img.Height)
                    { contour[cPos + _img.Width] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos + _img.Width], uncertainty); } // down

                    if (j != 0 && i != 0)
                    { contour[cPos - 1 - _img.Width] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos - 1 - _img.Width], uncertainty); } // left up
                    if (j + 1 < _img.Width && i != 0)
                    { contour[cPos + 1 - _img.Width] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos + 1 - _img.Width], uncertainty); } // right up

                    if (i != 0 && i + 1 < _img.Height)
                    { contour[cPos - 1 + _img.Width] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos - 1 + _img.Width], uncertainty); } // left down
                    if (j + 1 < _img.Width && i + 1 < _img.Height)
                    { contour[cPos + 1 + _img.Width] = _rgbPixels[cPos].IsRoughlyEqual(_rgbPixels[cPos + 1 + _img.Width], uncertainty); } // right down
                }
            }

            return contour;
        }

        public Bitmap TransformBoolArrayInImage(bool[] contour)
        {
            Bitmap bitmap = new Bitmap(_img.Width, _img.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            for (int i = 0; i < contour.Length; i++)
            {
                Color color;
                if (contour[i])
                {
                    color = System.Drawing.Color.LightGray;
                }
                else
                {
                    color = System.Drawing.Color.Black;
                }

                bitmap.SetPixel(i % _img.Width, i / _img.Width, color);
            }

            return bitmap;
        }

        public List<RGB> FindObjectsInRGB(ref List<int> objCount, int uncertainty)
        {
            List<RGB> objects = new List<RGB>();
            objCount = new List<int>();

            for (int i = 0; i < _rgbPixels.Length; i++)
            {
                bool isNew = true;
                for (int h = 0; h < objects.Count; h++)
                {
                    if (_rgbPixels[i].IsRoughlyEqual(objects[h], uncertainty))
                    {
                        objCount[h]++;
                        
                        isNew = false;
                        break;
                    }
                }

                if (isNew)
                {
                    objects.Add(_rgbPixels[i]);
                    objCount.Add(1);
                }
            }

            return objects;
        }
    }
}
