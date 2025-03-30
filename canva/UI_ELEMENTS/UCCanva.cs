
using canva;
using canva.ENUM;
using System.Drawing.Text;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;


using canva.Classes;

namespace canva.UI_ELEMENTS
{
    public partial class UCCanva : UserControl
    {

        #region PUBLIC

        #region EVENTS

        public event EventHandler<ColorPickedEventArgs>? ColorPicked;

        #endregion

        #region METHODS

        public void PasteClipboard(Image clipboardImg)
        {
            _cnva.PasteImage(clipboardImg);
        }

        #endregion

        #region CONSTRUCTORS

        public UCCanva()
        {
            InitializeComponent();

            this._cnva.ColorPicked += _cnva_ColorPicked;

            this.Resize += UCCanva_Resize;

        }

        private void UCCanva_Resize(object? sender, EventArgs e)
        {
            SizeButtons();
        }

        private void SizeButtons()
        {

            _btnBack.Width = this.Width / 2;

        }

        private void _cnva_ColorPicked(object? sender, ColorPickedEventArgs e)
        {
            ColorPicked?.Invoke(this, e);
        }


        #endregion

        #endregion



        private void _btnForward_Click(object sender, EventArgs e)
        {
            SavedImages.Instance.LoadNextImage();
        }

        private void _btnBack_Click(object sender, EventArgs e)
        {
            SavedImages.Instance.LoadPreviousImage();
        }
    }


}
