using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibUI
{
    public static class MyMessageBox
    {

        public static void ShowError(Exception ex, String caption = "")
        {

            if (caption == "") caption = "Thrown Exception";

            ShowError($"Exception: {ex.Message}\n Details", caption);

        }

        public static void ShowError(String message, String caption = "")
        {
            if (caption == "") caption = "Error";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInfo(String message, String caption = "")
        {
            if (caption == "") caption = "Info Message";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public static DialogResult ShowAskQuestion(String question, String caption = "")
        {

            if (caption == "") caption = "Question";
            return MessageBox.Show(question, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        }
        public static DialogResult ShowAskQuestion(IWin32Window? owner, String question, String caption = "")
        {

            if (caption == "") caption = "Question";

            
            return MessageBox.Show(owner, question, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

        }


        public static void ShowWarning(String message, String caption = "")
        {
            if (caption == "") caption = "Warning";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }



    }
}
