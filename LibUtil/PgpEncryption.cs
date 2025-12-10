using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Security;

using System.IO;

namespace LibUtil
{
    public class PgpEncryption
    {

        public static PgpEncryption Instance { get { return _instance; } }

        public string Decrypt(String encryptedMessage, String privateKeyArmored, String passphrase)
        {
            using var inputStream = new MemoryStream(Encoding.UTF8.GetBytes(encryptedMessage));
            using var keyIn = new MemoryStream(Encoding.UTF8.GetBytes(privateKeyArmored));

            var decoderStream = PgpUtilities.GetDecoderStream(inputStream);
            var pgpObjFactory = new PgpObjectFactory(decoderStream);
            var obj = pgpObjFactory.NextPgpObject();

            if (obj is not PgpEncryptedDataList encryptedDataList)
                encryptedDataList = (PgpEncryptedDataList)pgpObjFactory.NextPgpObject();

            var secretKeyRingBundle = new PgpSecretKeyRingBundle(PgpUtilities.GetDecoderStream(keyIn));
            PgpPrivateKey privateKey = null;
            PgpPublicKeyEncryptedData encryptedData = null;

            foreach (PgpPublicKeyEncryptedData pked in encryptedDataList.GetEncryptedDataObjects())
            {
                var secretKey = secretKeyRingBundle.GetSecretKey(pked.KeyId);
                if (secretKey != null)
                {
                    privateKey = secretKey.ExtractPrivateKey(passphrase.ToCharArray());
                    encryptedData = pked;
                    break;
                }
            }

            if (privateKey == null || encryptedData == null)
                throw new ArgumentException("Private key for message decryption not found");

            using var clearStream = encryptedData.GetDataStream(privateKey);
            var plainFactory = new PgpObjectFactory(clearStream);
            var message = plainFactory.NextPgpObject();

            if (message is PgpLiteralData literalData)
            {
                using var outputStream = new MemoryStream();
                var unc = literalData.GetInputStream();
                unc.CopyTo(outputStream);
                return Encoding.UTF8.GetString(outputStream.ToArray());
            }

            throw new Exception("Unexpected message type");
        }


        private PgpEncryption() { }

        private static PgpEncryption _instance = new PgpEncryption();

    }
}
