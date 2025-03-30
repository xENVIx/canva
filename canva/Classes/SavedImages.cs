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

        #region EVENTS

        public event EventHandler<SavedImageEventArgs>? ChangeImage;
        public event EventHandler<SavedImageEventArgs>? DeleteImageHistory;

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



        #endregion

        #region METHODS

        public void LoadNewImage(ImageSave imgSv)
        {

            if (imgSv.ImageFile == null) throw new ArgumentNullException("Image File in ImageSave class Cannot Be NULL");

            _images.Add(imgSv);
            _curInd = _images.Count - 1;

            ChangeImage?.Invoke(this, new SavedImageEventArgs());

        }

        public void LoadCurrentImage()
        {
            if (_images.Count > 0 && _curInd >= 0 && _curInd < _images.Count)
                ChangeImage?.Invoke(this, new SavedImageEventArgs());   
        }

        public void LoadNextImage()
        {
            if (_curInd + 1 >= _images.Count) return;
            else
            {
                _curInd++;
                ChangeImage?.Invoke(this, new SavedImageEventArgs());
            }
        }

        public void LoadPreviousImage()
        {
            if (_curInd - 1 < 0) return;
            else
            {
                _curInd--;
                ChangeImage?.Invoke(this, new SavedImageEventArgs());
            }
        }

        public void ClearMemory()
        {

            _curInd = 0;
            _images.Clear();
            DeleteImageHistory?.Invoke(this, new SavedImageEventArgs());

        }

        public void DeregisterEvents()
        {
            ChangeImage = null;
            DeleteImageHistory = null;
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

    public enum EPrevNext
    {
        PREVIOUS,
        NEXT,
        CURRENT,
    }

    public class SavedImageEventArgs : EventArgs
    {

        public SavedImageEventArgs() : base()
        {  }

    }
}
