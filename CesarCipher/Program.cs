using System.Security.Cryptography;
using System.Text;

string input = @"Ibpê yrh fboer nf Pvsenf qr Péfne? Rfcreb dhr fvz! Fr ibpê purtbh ngé ndhv é cbedhr fbhor hfne b EBG13 pregvaub. Znf pnyzn crdhrab tnsnaubgb dhr nvaqn aãb npnobh. Ibpê cerpvfn ntben hgvyvmne hz nytbegvzb qr punir fvzégevpn cnen qrpevcgne n zrafntrz dhr rfgá ab nedhvib narkb! Dhr gny hgvyvmne hz nytbegvzb cnqeãb vagreanpvbany qr pevcgbtensvn cbe oybpbf qr 256 ovgf: b cnqeãb qr pevcgbtensvn ninaçnqn qr 256 ovgf. Pbzb ibpê aãb é ivqragr, ibh gr qne hzn pbyure qr puá, nabgn n punir nv: CSN_FvQv_20NABF (frz nf nfcnf).";
int rot13 = 13;

int upperFirstLetter = 65;
int upperLastLetter = 90;

int lowerFirstLetter = 97;
int lowerLastLetter = 122;

string output = string.Empty;

foreach(char l in input) {
    int ascii = (int)l;
    int rotted13 = 0;
    int t_rotted13 = ascii + rot13;
    if(ascii >= upperFirstLetter && ascii <= upperLastLetter) {
        rotted13 = t_rotted13 > upperLastLetter ? (t_rotted13 - upperLastLetter + upperFirstLetter - 1) : t_rotted13;
    } else if (ascii >= lowerFirstLetter && ascii <= lowerLastLetter) {
        rotted13 = t_rotted13 > lowerLastLetter ? (t_rotted13 - lowerLastLetter + lowerFirstLetter - 1) : t_rotted13;
    } else {
        rotted13 = ascii;
    }

    output += (char)rotted13;
}

Console.WriteLine(output);

string encoded = string.Empty;
string aesKey = string.Empty;
// string plaintext = string.Empty;

using(StreamReader st = new StreamReader("enc.txt", Encoding.UTF8)) {
    encoded = st.ReadToEnd();
    using(Aes aes = Aes.Create()) {
        aes.Key = Encoding.UTF8.GetBytes(aesKey);
        // aes.IV = Encoding.UTF8.GetBytes(encoded);

        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using (MemoryStream msDecrypt = new MemoryStream(Encoding.UTF8.GetBytes(encoded)))
        {
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    // plaintext = srDecrypt.ReadToEnd();
                    Console.WriteLine(srDecrypt.ReadToEnd());
                }
            }
        }
    }
}