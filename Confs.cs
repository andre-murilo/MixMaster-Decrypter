using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixMaster_decrypter_ver_2
{
    public class Confs
    {
       private static int minhaCriptografia = -1;

       private static byte MixMasterUPPublicKey = 0x66;
       private static byte MixMasterUPPublicKey2 = 0xF5;

       private static byte MixMasternormalPublickey = 0x66;
       private static byte MixMasternormalPublickey2 = 0x55;

       private static byte MixMasterAU2009PublicKey = 0x0D;
       private static byte MixMasterAU2009PublicKey2 = 0x55;

       private static byte MixMasterFRPublicKey = 0x66;
       private static byte MixMasterFRPublicKey2 = 0x55;

       private static byte MixMaster77PBPublicKey = 0x66;
       private static byte MixMaster77PBPublicKey2 = 0x55;

       private static byte MixMasterWorldPublicKey = 0x66;
       private static byte MixMasterWorldPublicKey2 = 0x28;


       public int MinhaCriptografia
       {
           get { return minhaCriptografia; }
           set { minhaCriptografia = value; }
       }

       public byte[] GetMixMasterNormalPublicsKey
       {
           get { return new byte[] { MixMasternormalPublickey, MixMasternormalPublickey2 }; }
       }

       public byte[] GetMixMasterAU2009PublicsKey
       {
           get { return new byte[] { MixMasterAU2009PublicKey, MixMasterAU2009PublicKey2 }; }
       }

       public byte[] GetMixMasterFRPublicsKey
       {
           get { return new byte[] { MixMasterFRPublicKey, MixMasterFRPublicKey2 }; }
       }

       public byte[] GetMixMaster77PBPublicsKey
       {
           get { return new byte[] { MixMaster77PBPublicKey, MixMaster77PBPublicKey2 }; }
       }

       public byte[] GetMixMasterWorldPubicsKey
       {
           get { return new byte[] { MixMasterWorldPublicKey, MixMasterWorldPublicKey2 }; }
       }

     

       public byte[] GetMixMasterUpPublicsKey
       {
           get { return new byte[] { MixMasterUPPublicKey, MixMasterUPPublicKey2 }; }
       }



        //int MixMasternormal           = 0;
        //int MixMasterAU2009           = 1;
        //int MixMasterFR               = 2;
        //int MixMaster77PB             = 3;
        //int MixMasterWorld            = 4;
        //int MixMasterUP               = -1

    }
}
