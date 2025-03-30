using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace canva.Classes
{
    public class SavedImages
    {

        #region PUBLIC

        #region SUB-CLASSES

        public class ImageSave
        {

            #region PUBLIC

            #region VARIABLES

            public Image ImageFile
            {
                get
                {
                    if (_imageFile == null) throw new ArgumentNullException("Image File Is Empty"); return _imageFile;
                }
                set
                {
                    _imageFile = value;
                }
            }

            #endregion

            #region CONSTRUCTORS

            public ImageSave(Image img)
            {
                _imageFile = img;
            }

            #endregion

            #endregion

            #region PRIVATE

            #region VARIABLES

            private Image _imageFile;

            #endregion

            #endregion


        }

        #endregion

        #region VARIABLES

        #region STATIC

        public static SavedImages Instance { get { return _instance; } }

        #endregion

        public ImageSave GetCurrentImage 
        { 
            get 
            {
                if (_images.Count <= 0) throw new Exception("No images available");
                else if (_images.Count < _curInd)
                    return _images[_images.Count - 1];
                else if (_curInd < 0) return _images[0];
                return _images[_curInd]; 
            } 
        }

        public ImageSave GetNextImage
        {
            get
            {
                if (_curInd + 1 >= _images.Count) return GetCurrentImage;
                else
                {
                    _curInd++;
                    return GetCurrentImage;
                }

            }
        }

        public ImageSave GetPreviousImage
        {
            get
            {
                if (_curInd - 1 < 0) return GetCurrentImage;
                else
                {
                    _curInd--;
                    return GetCurrentImage;
                }
            }
        }


        #endregion

        #region METHODS

        public Image LoadNewImage(ImageSave imgSv)
        {

            if (imgSv.ImageFile == null) throw new ArgumentNullException("Image File in ImageSave class Cannot Be NULL");

            _images.Add(imgSv);
            _curInd = _images.Count - 1;

            return GetCurrentImage.ImageFile;

        }

        #endregion

        #endregion


        #region PRIVATE

        #region CONSTRUCTORS

        private SavedImages()
        {

        }

        #endregion

        #region VARIABLES

        #region STATIC

        private static SavedImages _instance = new SavedImages();

        #endregion

        private List<ImageSave> _images = new List<ImageSave>();
        int _curInd = 0;

        #endregion

        #endregion

    }
}
