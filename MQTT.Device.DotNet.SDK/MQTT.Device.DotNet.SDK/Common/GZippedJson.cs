using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT.Device.DotNet.SDK
{
    public class Compression
    {
        public static string CompressToBase64String( string rawString )
        {
            if ( string.IsNullOrEmpty( rawString ) || rawString.Length == 0 )
                return "";

            byte[] rawData = System.Text.Encoding.UTF8.GetBytes( rawString.ToString() );
            byte[] zippedData = Compress( rawData );
            return ( string ) ( Convert.ToBase64String( zippedData ) );
        }

        public static string DecompressFromBase64String( string zippedString )
        {
            if ( string.IsNullOrEmpty( zippedString ) || zippedString.Length == 0 )
                return "";

            byte[] zippedData = Convert.FromBase64String( zippedString.ToString() );
            return ( string ) ( System.Text.Encoding.UTF8.GetString( Decompress( zippedData ) ) );
        }

        private static byte[] Compress( byte[] rawData )
        {
            MemoryStream ms = new MemoryStream();
            using ( GZipStream compressedzipStream = new GZipStream( ms, CompressionMode.Compress, true ) )
            {
                compressedzipStream.Write( rawData, 0, rawData.Length );
                compressedzipStream.Close();
            }

            return ms.ToArray();
        }

        private static byte[] Decompress( byte[] zippedData )
        {
            MemoryStream outBuffer = new MemoryStream();
            using ( MemoryStream ms = new MemoryStream( zippedData ) )
            using ( GZipStream compressedzipStream = new GZipStream( ms, CompressionMode.Decompress ) )
            {
                byte[] block = new byte[1024];
                while ( true )
                {
                    int bytesRead = compressedzipStream.Read( block, 0, block.Length );
                    if ( bytesRead <= 0 )
                        break;
                    else
                        outBuffer.Write( block, 0, bytesRead );
                }
                compressedzipStream.Close();
            }

            return outBuffer.ToArray();
        }

    }
}
