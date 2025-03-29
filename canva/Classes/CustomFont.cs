using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace canva.Classes
{
    internal class CustomFont
    {

        public Font? font;

        internal CustomFont()
        {


            Assembly asm = Assembly.GetExecutingAssembly();
            using (Stream fontStream = asm.GetManifestResourceStream("canva.ttf.stencilla.ttf"))
            {
                if (fontStream != null)
                {
                    byte[] fontData = new byte[fontStream.Length];
                    fontStream.Read(fontData, 0, (int)fontStream.Length);

                    // Allocate memory and copy the font data
                    IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
                    Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

                    // Create the font collection
                    PrivateFontCollection pfc = new PrivateFontCollection();
                    pfc.AddMemoryFont(fontPtr, fontData.Length);

                    // Free the memory
                    Marshal.FreeCoTaskMem(fontPtr);

                    // Use the font
                    font = new Font(pfc.Families[0], 12f, FontStyle.Bold, GraphicsUnit.Pixel); // Set your desired size

                }



            }

        }

    }
}
