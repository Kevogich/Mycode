class UnitCon {
    internal double i; //input Value
    internal string Unit1 = ""; //input unit
    internal string Unit2 = ""; //output unit

    internal double Value2 (double i) {
        string Unit2Unit = Unit1 + "2" + Unit2; //remark of input unit convert to output unit
        double j;
        if (Unit1 == Unit2) {
            j = i;
            return j;
        } else if (Unit1 == "gpm(US)" || Unit1 == "m3/h" || Unit1 == "scfh") {
            switch (Unit2Unit) {
                //FlowRate
                case "gpm(US)2m3/h":
                    j = i * 0.2273;
                    break;
                case "gpm(US)2scfh":
                    j = i * 8.0208;
                    break;
                case "scfh2m3/h":
                    j = i * 0.0283168;
                    break;
                case "scfh2gpm(US)":
                    j = i * 0.1247;
                    break;
                case "m3/h2gpm(US)":
                    j = i * 4.403;
                    break;
                case "m3/h2scfh":
                    j = i * 35.31468;
                    break;
                default:
                    j = 0;
                    break;
            }
            return j;
        } else if (Unit1 == "C" || Unit1 == "F" || Unit1 == "K") {
            switch (Unit2Unit) {
                //FlowRate
                case "gpm(US)2gpm(US)":
                    j = i;
                    break;
                case "m3/h2m3/h":
                    j = i;
                    break;
                case "scfh2scfh":
                    j = i;
                    break;
                default:
                    j = 0;
                    break;
            }
            return j;
        } else if (Unit1 == "Bar" || Unit1 == "KPa" || Unit1 == "MPa" || Unit1 == "Psi") {
            switch (Unit2Unit) {
                //Pressure
                case "Bar2KPa":
                    j = i * 100;
                    break;
                case "Psi2KPa":
                    j = i * 6.8948;
                    break;
                case "MPa2KPa":
                    j = i * 1000;
                    break;
                case "KPa2KPa":
                    j = i;
                    break;
                default:
                    j = 0;
                    break;
            }
            return j;
        } else if (Unit1 == "Bar(a)" || Unit1 == "KPa(a)" || Unit1 == "MPa(a)" || Unit1 == "Psi(a)" || Unit1 == "Bar(g)" || Unit1 == "KPa(g)" || Unit1 == "MPa(g)" || Unit1 == "Psi(g)") {
            switch (Unit2Unit) {
                //Pressure
                case "Bar(a)2KPa(a)":
                    j = i * 100;
                    break;
                case "Psi(a)2KPa(a)":
                    j = i * 6.8948;
                    break;
                case "MPa(a)2KPa(a)":
                    j = i * 1000;
                    break;
                case "Bar(g)2KPa(a)":
                    j = i * 100 + 101.3;
                    break;
                case "Psi(g)2KPa(a)":
                    j = i * 6.8948 + 101.3;
                    break;
                case "MPa(g)2KPa(a)":
                    j = i * 1000 + 101.3;
                    break;
                case "KPa(g)2KPa(a)":
                    j = i + 101.3;
                    break;
                default:
                    j = 0;
                    break;
            }
            return j;
        } else if (Unit1 == "Kg/m3" || Unit1 == "Lb/gal(US)" || Unit1 == "SG(Liquid)"||Unit1=="SG(Gas)") {
            //Density
            switch (Unit2Unit) {
                case "SG(Liquid)2Kg/m3":
                    j = i * 1000;
                    break;
                    case "SG(Gas)2Kg/m3":
                    j = i*1.204;
                    break;
                case "Lb/gal(US)2Kg/m3":
                    j = i *119.826427;
                    break;
                default:
                    j = 0;
                    break;
            }
            return j;
        } else {
            return 0;
        }
    }
}