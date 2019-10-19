using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json.Linq;
using ZonyLrcToolsX.MusicConverter.NcmToFlac.Exceptions;

// ReSharper disable IdentifierTypo

namespace ZonyLrcToolsX.MusicConverter.NcmToFlac
{
    /// <summary>
    /// 网易云音乐的 NCM 文件转 Flac 转换器。
    /// </summary>
    public class NcmToFlacConverter : IMusicConverter
    {
        // Bytes: "{ 0x68, 0x7A, 0x48, 0x52, 0x41, 0x6D, 0x73, 0x6F, 0x35, 0x6B, 0x49, 0x6E, 0x62, 0x61, 0x78, 0x57 }"
        private const string AesCoreKeyString = "hzHRAmso5kInbaxW";

        // Bytes: "{0x23, 0x31, 0x34, 0x6C, 0x6A, 0x6B, 0x5F, 0x21, 0x5C, 0x5D, 0x26, 0x30, 0x55, 0x3C, 0x27, 0x28}"
        private const string AesModifyKeyBytes = @"#14ljk_!\]&0U<'(";
        
        public MemoryStream Convert(MemoryStream srcStream)
        {
            var reader = new BinaryReader(srcStream);
            
            ValidNcmFileFormat(reader);
            var boxKeyBytes = GetKey(reader);
            var fileExtensions = GetMusicJson(reader).SelectToken("$.format").Value<string>();

            throw new NotImplementedException();
        }

        protected virtual void ValidNcmFileFormat(BinaryReader reader)
        {
            if (reader.ReadInt32() != 0x4e455443) throw new InvalidNcmFileException();
            if (reader.ReadInt32() != 0x4d414446) throw new InvalidNcmFileException();
        }

        protected virtual byte[] GetKey(BinaryReader reader)
        {
            // 跳过 2 个字节。
            reader.ReadBytes(2);

            var encryptedKeyDataLength = reader.ReadInt32();
            var encryptedKeyData = reader.ReadBytes(encryptedKeyDataLength);

            for (int i = 0; i < encryptedKeyDataLength; i++)
            {
                encryptedKeyData[i] ^= 0x64;
            }

            var deKeyDataBytes = DecryptAes128Ecb(Encoding.UTF8.GetBytes(AesCoreKeyString), encryptedKeyData);
            
            // 减去 "neteasecloudmusic" 字符串之后的数据即为密钥数据。
            return GetBytesWithOffset(deKeyDataBytes,17);
        }

        protected virtual JObject GetMusicJson(BinaryReader reader)
        {
            return null;
        }

        protected virtual byte[] BuildKeyBox(byte[] keyBytes)
        {
            return null;
        }

        protected virtual void SkipAlbumImageData(BinaryReader reader)
        {
            
        }

        private byte[] DecryptAes128Ecb(byte[] keyBytes,byte[] data)
        {
            var aes = Aes.Create();
            if(aes == null) throw new NullReferenceException("无法创建 Aes 工具类。");

            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.ECB;
            using (var decryptor = aes.CreateDecryptor(keyBytes, null))
            {
                return decryptor.TransformFinalBlock(data, 0, data.Length);
            }
        }

        private byte[] GetBytesWithOffset(byte[] sourceBytes, int offset = 0,int interceptLength=0)
        {
            if (interceptLength == 0)
            {
                var newBytes = new byte[sourceBytes.Length - offset];
                Array.Copy(sourceBytes,offset,newBytes,0,sourceBytes.Length - offset);
                return newBytes;
            }

            var resultBytesWithInterceptLength = new byte[interceptLength];
            Array.Copy(sourceBytes, 0, resultBytesWithInterceptLength, 0,interceptLength);
            return resultBytesWithInterceptLength;
        }
    }
}