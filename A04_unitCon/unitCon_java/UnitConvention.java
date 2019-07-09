
public class UnitConvention {
    Double i = 1.0; // input Value
    String Unit1 = ""; // input unit
    String Unit2 = ""; // output unit

    Double Value2() {
        String Unit2Unit = Unit1 + "2" + Unit2; // remark of input unit convert to output unit
        Double j = 0.0;
        if (Unit1 == Unit2) {
            j = i;
            return j;
        } else if (Unit1 == "gpm(US)" || Unit1 == "m3/h" || Unit1 == "scfh") {
            switch (Unit2Unit) {
            // FlowRate
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
                j = i * 35.314;
                break;
            default:
                j = 0.0;
                break;
            }
            return j;
        } else if (Unit1 == "C" || Unit1 == "F" || Unit1 == "K") {
            switch (Unit2Unit) {
            // Temperature
            case "C2F":
                j = 32 + i * 9 / 5;
                break;
            case "C2K":
                j = i + 273.15;
                break;
            case "K2F":
                j = 32 + (i - 273.15) * 9 / 5;
                break;
            case "K2C":
                j = i - 273.15;
                break;
            case "F2C":
                j = (i - 32) * 5 / 9;
                break;
            case "F2K":
                j = (i - 32) * 5 / 9 + 273.15;
                break;
            default:
                j = 0.0;
                break;
            }
            return j;
        } else if (Unit1 == "Bar" || Unit1 == "KPa" || Unit1 == "MPa" || Unit1 == "Psi") {
            switch (Unit2Unit) {
            // Pressure 1
            case "Bar2KPa":
                j = i * 100;
                break;
            case "Bar2MPa":
                j = i * 0.1;
                break;
            case "Bar2Psi":
                j = i * 14.5;
                break;
            case "KPa2Bar":
                j = i / 100;
                break;
            case "KPa2MPa":
                j = i / 1000;
                break;
            case "KPa2Psi":
                j = i / 6.8948;
                break;
            case "MPa2Bar":
                j = i * 10;
                break;
            case "MPa2KPa":
                j = i * 1000;
                break;
            case "MPa2Psi":
                j = i * 145;
                break;
            case "Psi2Bar":
                j = i * 0.068948;
                break;
            case "Psi2KPa":
                j = i * 6.8948;
                break;
            case "Psi2MPa":
                j = i * 0.0068948;
                break;
            default:
                j = 0.0;
                break;
            }
            return j;
        } else if (Unit1 == "Bar(a)" || Unit1 == "KPa(a)" || Unit1 == "MPa(a)" || Unit1 == "Psi(a)" || Unit1 == "Bar(g)"
                || Unit1 == "KPa(g)" || Unit1 == "MPa(g)" || Unit1 == "Psi(g)") {
            switch (Unit2Unit) {
            // Pressure 2
            case "KPa(a)2Bar(a)":
                j = i / 100;
                break;
            case "MPa(a)2Bar(a)":
                j = i * 10;
                break;
            case "Psi(a)2Bar(a)":
                j = i * 6.894757;
                break;
            case "Bar(g)2Bar(a)":
                j = i + 1.01325;
                break;
            case "KPa(g)2Bar(a)":
                j = i / 100 + 1.01325;
                break;
            case "MPa(g)2Bar(a)":
                j = i * 10 + 1.01325;
                break;
            case "Psi(g)2Bar(a)":
                j = i * 6.894757 / 100 + 1.01325;
                break;

            case "Bar(a)2KPa(a)":
                j = i * 100;
                break;
            case "MPa(a)2KPa(a)":
                j = i * 1000;
                break;
            case "Psi(a)2KPa(a)":
                j = i * 6.894757;
                break;
            case "Bar(g)2KPa(a)":
                j = i * 100 + 101.325;
                break;
            case "KPa(g)2KPa(a)":
                j = i + 101.325;
                break;
            case "MPa(g)2KPa(a)":
                j = i * 1000 + 101.325;
                break;
            case "Psi(g)2KPa(a)":
                j = i * 6.894757 + 101.325;
                break;

            case "Bar(a)2MPa(a)":
                j = i * 0.1;
                break;
            case "KPa(a)2MPa(a)":
                j = i / 1000;
                break;
            case "Psi(a)2MPa(a)":
                j = i * 6.894757 / 1000;
                break;
            case "Bar(g)2MPa(a)":
                j = i * 0.1 + 0.101325;
                break;
            case "KPa(g)2MPa(a)":
                j = i / 1000 + 0.101325;
                break;
            case "MPa(g)2MPa(a)":
                j = i + 0.101325;
                break;
            case "Psi(g)2MPa(a)":
                j = i * 6.894757 / 1000 + 0.101325;
                break;

            case "Bar(a)2Psi(a)":
                j = i * 14.50377;
                break;
            case "KPa(a)2Psi(a)":
                j = i * 0.1450377;
                break;
            case "MPa(a)2Psi(a)":
                j = i * 145.0377;
                break;
            case "Bar(g)2Psi(a)":
                j = i * 14.50377 + 14.69595;
                break;
            case "KPa(g)2Psi(a)":
                j = i * .1450377 + 14.69595;
                break;
            case "MPa(g)2Psi(a)":
                j = i * 145.0377 + 14.69595;
                break;
            case "Psi(g)2Psi(a)":
                j = i + 14.69595;
                break;

            case "KPa(a)2Bar(g)":
                j = i / 100 - 1.01325;
                break;
            case "MPa(a)2Bar(g)":
                j = i * 10 - 1.01325;
                break;
            case "Psi(a)2Bar(g)":
                j = i * 0.06894757 - 1.01325;
                break;
            case "Bar(a)2Bar(g)":
                j = i - 1.01325;
                break;
            case "KPa(g)2Bar(g)":
                j = i / 100;
                break;
            case "MPa(g)2Bar(g)":
                j = i * 10;
                break;
            case "Psi(g)2Bar(g)":
                j = i * 0.06894757;
                break;

            case "Bar(a)2KPa(g)":
                j = i * 100 - 101.325;
                break;
            case "MPa(a)2KPa(g)":
                j = i * 1000 - 101.325;
                break;
            case "Psi(a)2KPa(g)":
                j = i * 6.894757 - 101.325;
                break;
            case "Bar(g)2KPa(g)":
                j = i * 100;
                break;
            case "KPa(a)2KPa(g)":
                j = i - 101.325;
                break;
            case "MPa(g)2KPa(g)":
                j = i * 1000;
                break;
            case "Psi(g)2KPa(g)":
                j = i * 6.894757;
                break;

            case "Bar(a)2MPa(g)":
                j = i * 0.1 - 0.101325;
                break;
            case "KPa(a)2MPa(g)":
                j = i / 1000 - 0.101325;
                break;
            case "Psi(a)2MPa(g)":
                j = i * 0.006894757 - 0.101325;
                break;
            case "Bar(g)2MPa(g)":
                j = i * 0.1;
                break;
            case "KPa(g)2MPa(g)":
                j = i / 1000;
                break;
            case "MPa(a)2MPa(g)":
                j = i - 0.101325;
                break;
            case "Psi(g)2MPa(g)":
                j = i * 0.006894757;
                break;

            case "Bar(a)2Psi(g)":
                j = i * 14.50377 - 14.69595;
                break;
            case "KPa(a)2Psi(g)":
                j = i * 0.1450377 - 14.69595;
                break;
            case "Psi(a)2Psi(g)":
                j = i - 14.69595;
                break;
            case "MPa(a)2Psi(g)":
                j = i * 145.0377 - 14.69595;
                break;
            case "Bar(g)2Psi(g)":
                j = i * 14.50377;
                break;
            case "KPa(g)2Psi(g)":
                j = i * 0.1450377;
                break;
            case "MPa(g)2Psi(g)":
                j = i * 145.0377;
                break;
            default:
                j = 0.0;
                break;
            }
            return j;
        } else if (Unit1 == "Kg/m3" || Unit1 == "Lb/gal(US)" || Unit1 == "SG(Liquid)" || Unit1 == "SG(Gas)"
                || Unit1 == "Lb/ft3" || Unit1 == "Lb/in3") {
            // Density
            switch (Unit2Unit) {
            case "Kg/m32Lb/gal(US)":
                j = i / 119.826427;
                break;
            case "Kg/m32SG(Liquid)":
                j = i / 1000;
                break;
            case "Kg/m32SG(Gas)":
                j = i / 1.204;
                break;
            case "Kg/m32Lb/ft3":
                j = i * 0.0624279655;// updated by zqy at 20:25PM, 20190709
                break;
            case "Kg/m32Lb/in3":
                j = i / 27675; // updated by zqy at 20:25PM, 20190709
                break;

            case "Lb/gal(US)2Kg/m3":
                j = i * 119.826427;
                break;
            case "Lb/gal(US)2SG(Liquid)":
                j = i / 1000 * 119.826427;
                break;
            case "Lb/gal(US)2SG(Gas)":
                j = i / 1.204 * 119.826427;
                break;
            case "Lb/gal(US)2Lb/ft3":
                j = i * 0.0624279655 * 119.826427; // updated by zqy at 20:25PM, 20190709
                break;
            case "Lb/gal(US)2Lb/in3":
                j = i / 27675 * 119.826427; // updated by zqy at 20:25PM, 20190709
                break;

            case "SG(Liquid)2Kg/m3":
                j = i * 1000;
                break;
            case "SG(Liquid)2Lb/gal(US)":
                j = i / 0.119826427;
                break;
            case "SG(Liquid)2SG(Gas)":
                j = i / 0.001204;
                break;
            case "SG(Liquid)2Lb/ft3":
                j = i * 62.4279655; // updated by zqy at 20:25PM, 20190709
                break;
            case "SG(Liquid)2Lb/in3":
                j = i / 27.675; // updated by zqy at 20:25PM, 20190709
                break;

            case "SG(Gas)2Kg/m3":
                j = i * 1000 * 0.001204;
                break;
            case "SG(Gas)2Lb/gal(US)":
                j = i / 0.119826427 * 0.001204;
                break;
            case "SG(Gas)2SG(Liquid)":
                j = i * 0.001204;
                break;
            case "SG(Gas)2Lb/ft3":
                j = i * 62.4279655 * 0.001204;// updated by zqy at 20:25PM, 20190709
                break;
            case "SG(Gas)2Lb/in3":
                j = i / 27.675 * 0.001204;// updated by zqy at 20:25PM, 20190709
                break;

            case "Lb/ft32Lb/gal(US)":
                j = i / 119.826427 / 0.0624279655;// updated by zqy at 20:25PM, 20190709
                break;
            case "Lb/ft32SG(Liquid)":
                j = i / 1000 / 0.0624279655;// updated by zqy at 20:25PM, 20190709
                break;
            case "Lb/ft32SG(Gas)":
                j = i / 1.204 / 0.0624279655;// updated by zqy at 20:25PM, 20190709
                break;
            case "Lb/ft32Kg/m3":
                j = i / 0.0624279655;// updated by zqy at 20:25PM, 20190709
                break;
            case "Lb/ft32Lb/in3":
                j = i / 1728;// updated by zqy at 20:25PM, 20190709
                break;

            case "Lb/in32Lb/gal(US)":
                j = i * 213;// updated by zqy at 20:25PM, 20190709
                break;
            case "Lb/in32SG(Liquid)":
                j = i / 27.675;// updated by zqy at 20:25PM, 20190709
                break;
            case "Lb/in32SG(Gas)":
                j = i / 22986;// updated by zqy at 20:25PM, 20190709
                break;
            case "Lb/in32Lb/ft3":
                j = i * 1728;// updated by zqy at 20:25PM, 20190709
                break;
            case "Lb/in32Kg/m3":
                j = i * 27675;// updated by zqy at 20:25PM, 20190709
                break;
            default:
                j = 0.0;
                break;
            }
            return j;
        } else {
            return 0.0;
        }
    }
}