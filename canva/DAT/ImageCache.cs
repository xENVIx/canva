using canva.Classes;
using Cyotek.Windows.Forms;
using LibUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace canva.DAT
{

    [DataContract]
    public class ImageCache
    {
        #region PUBLIC

        #region VARIABLES

        #region STATIC

        public static ImageCache Instance { get { return _instance; } }

        #endregion

        public String FilePath { set { _filePath = $"{value}\\CachedImages"; } }


        #region DATAMEMBERS

        [DataMember] public List<String> ImageFiles { get { return _imageFiles; } set { _imageFiles = value; } }

        #endregion

        #endregion

        #region METHODS

        #region STATIC

        public static void OnInit()
        {

            try
            {

                object data;


                if (XML.DeserializeXML(out data, typeof(ImageCache)))
                {
                    _instance = (ImageCache)data;

                }
                else
                {


                    try
                    {
                        XML.SerializeXML(typeof(ImageCache), _instance);
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }



                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        #endregion

        public void ClearCache()
        {
            if (_imageFiles.Count > 0)
            {

                foreach (String file in _imageFiles)
                {
                    if (LibUtil.FileTools.Instance.DeleteFile(file))
                    {
                        Console.WriteLine("Deleted Files");
                    }
                    else Console.WriteLine("Couldn't Deleted Files");
                }
            }

            _imageFiles.Clear();
        }

        public void CacheImage(Image image)
        {
            if (_filePath == string.Empty) throw new Exception("No file path set");

            

            String fileName = $"{LibUtil.FileTools.Instance.RandomFileName}.png";

            String fullFilePath = Path.Combine(_filePath, fileName);

            if (LibUtil.DirectoryTools.Instance.CheckCreateDirectory(_filePath))
            {

                try
                {
                    image.Save(fullFilePath);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            else
            {
                throw new Exception($"Could not find or create directory {_filePath}");
            }


            _imageFiles.Add(fullFilePath);


            try
            {
                this.SaveData();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Image> LoadCachedImages()
        {
            List<Image> images = new List<Image>();
            if (_imageFiles.Count > 0)
            {
                for (int i = 0; i < _imageFiles.Count; i++)
                {
                    try
                    {
                        Image imgFile = Image.FromFile(_imageFiles[i]);
                        images.Add(imgFile);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }

            return images;
        }

        #endregion

        #region CONSTRUCTORS

        public ImageCache() { }

        #endregion

        #endregion

        #region PRIVATE

        #region VARIABLES

        #region STATIC

        private static ImageCache _instance = new ImageCache();

        #endregion

        private String _filePath = string.Empty;

        private List<String> _imageFiles = new List<string>();

        #endregion

        #region METHODS

        private void SaveData()
        {
            try
            {
                LibUtil.XML.SerializeXML(typeof(ImageCache), _instance);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
            

        #endregion

        #endregion
    }
}
