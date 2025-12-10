using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using OpenAI;
using OpenAI.Chat;
using OpenAI.Images;

namespace LibUtil
{
    public class OpenAI_API
    {
        #region PUBLIC

        #region STATIC

        public static OpenAI_API Instance { get { return _instance; } }

        #endregion

        #region VARIABLES

        #endregion

        #region METHODS
















        #endregion

        #endregion

        #region PRIVATE

        private const String API_CRED_TARGET = "OpenAI_APIKEY";
        #region CONSTRUCTORS

        private OpenAI_API()
        {

            var cred = WindowsCredentialManager.GetCredential(API_CRED_TARGET);

            if (cred == null) throw new ArgumentNullException("API KEY NOT FOUND!");
            else if (cred.Value.Password == null) throw new ArgumentNullException("API KEY NOT FOUND!");
            

            _chatClient = new ChatClient(
                "gpt-4o",
                new ApiKeyCredential(cred.Value.Password)
                );

            _imageClient = new ImageClient(
                "dall-e-2",
                new ApiKeyCredential(cred.Value.Password)
                );

            _messages = new List<ChatMessage>();






        }




        

        #endregion

        #region VARIABLES

        private ChatClient _chatClient;
        private List<ChatMessage> _messages;

        private ImageClient _imageClient;

        #endregion

        #region STATIC

        private static OpenAI_API _instance = new OpenAI_API();

        #endregion

        #endregion

    }
}
