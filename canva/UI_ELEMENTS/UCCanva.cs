
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

        }

        private void _cnva_ColorPicked(object? sender, ColorPickedEventArgs e)
        {
            ColorPicked?.Invoke(this, e);
        }


        #endregion

        #endregion



    }


}
