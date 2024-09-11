string input = @"Ibpê yrh fboer nf Pvsenf qr Péfne? Rfcreb dhr fvz! Fr ibpê purtbh ngé ndhv é cbedhr fbhor hfne b EBG13 pregvaub. Znf pnyzn crdhrab tnsnaubgb dhr nvaqn aãb npnobh. Ibpê cerpvfn ntben hgvyvmne hz nytbegvzb qr punir fvzégevpn cnen qrpevcgne n zrafntrz dhr rfgá ab nedhvib narkb! Dhr gny hgvyvmne hz nytbegvzb cnqeãb vagreanpvbany qr pevcgbtensvn cbe oybpbf qr 256 ovgf: b cnqeãb qr pevcgbtensvn ninaçnqn qr 256 ovgf. Pbzb ibpê aãb é ivqragr, ibh gr qne hzn pbyure qr puá, nabgn n punir nv: CSN_FvQv_20NABF (frz nf nfcnf).";
int rot13 = 13;
int upperFirstLetter = 65;
int upperLastLetter = 90;
int upperRange = upperLastLetter - upperFirstLetter;

int lowerFirstLetter = 97;
int lowerLastLetter = 122;
int lowerRange = lowerLastLetter - lowerFirstLetter;

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