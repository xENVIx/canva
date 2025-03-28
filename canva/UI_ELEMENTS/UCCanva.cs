
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

        }


        #endregion

        #endregion



    }


}
