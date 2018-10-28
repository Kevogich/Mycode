using System;
using System.IO;

namespace LiquidSizing {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("----------START Liquid Sizing----------");
            #region Data Input
            double Q = 360; //Flow rate unit:m3/h
            double P1 = 680; //Inlet Pressure unit:kPa;
            double P2 = 220; //Outlet pressure unit:kPa;
            double T1 = 363; //Inlet temperature, unit:K;
            double D1 = 150; //Inlet pipe size, unit:mm
            double D2 = 150; //Outlet pipe size, unit:mm

            string Fluid; //fluid type, incompressible or compressible
            double Density = 965.4; //Fluid density, unit kg/m3
            double Pv = 70.1; //Vapour pressure, unit kPa;
            double Pc = 22120; //Thermodynamic critical pressure, unit kPa;
            double v = .000000326; //Kinematic viscosity, unit: m2/s;
            v=.00000326;

            string Manufacturer = "Gulde"; //set Gulde brand as the default brand for sizing
            string BodyStyle = "Globe"; //Globe is default;
            string ValveType = "5100"; //5100 or 5400;
            string TrimCharacteristic;
            string Balance;
            string RestricedTrim;
            string FlowDriction; //Flow up or Flow down
            double d = 150; //Valve size unit:mm
            string Class;
            double PortSize; //unit mm
            double MaxTravel; //unit mm
            string Note;
            double Fl = .9; //Liquid pressure recovery factor
            double Fd = .46; //Valve style modifier
            double Xt = 0;
            double Kv = 180; // SI Valve flow rate, unit: m3/h
            double Cv; //Convention Valve flow rate, unit: us gal/min

            double N1 = 0.1;
            double N2 = .0016;
            double N4 = .0707;
            double N18 = .865;
            double Density0 = 999.099; //water density at 15 degree C, unit kg/m3;
            double n; //trim factor for non-turbulent flow;
            double N32 = 140;
            #endregion

            double C = Kv; //Valve rated flow rate

            #region Ff
            double Ff; //liquid critical pressure ratio factor
            Ff = 0.96 - 0.28 * Math.Sqrt (Pv / Pc);
            Console.WriteLine ("Ff = " + Ff);
            #endregion

            #region Piping geometry factor, Fp
            double Fp; //Piping geometry factor
            double K1;
            double K2;
            double KB1;
            double KB2;
            double K;
            K1 = 0.5 * (1 - d * d / (D1 * D1)) * (1 - d * d / (D1 * D1));
            K2 = (1 - d * d / D2 / D2) * (1 - d * d / D2 / D2);
            KB1 = 1 - d * d * d * d / D1 / D1 / D1 / D1;
            KB2 = 1 - d * d * d * d / D2 / D2 / D2 / D2;
            K = K1 + K2 + KB1 + KB2;
            Console.WriteLine ("K1 = {0}\nK2 = {1}\nKB1 = {2}\nKB2 = {3}", K1, K2, KB1, KB2);
            Fp = 1 / Math.Sqrt (1 + (K / N2) * (C / d / d) * (C / d / d));
            #endregion

            #region combined liquid pressure recovery factor Flp
            double Flp = Fl / Math.Sqrt (1 + Fl * Fl / N2 * (K1 + KB1) * (C / d / d) * (C / d / d));
            Console.WriteLine ("Fp = {0}\nFlp = {1}", Fp, Flp);
            #endregion

            #region choked or not?
            double DeltaPchocked;
            DeltaPchocked = (Flp / Fp) * (Flp / Fp) * (P1 - Ff * Pv);
            double DeltaP;
            DeltaP = P1 - P2;
            double DeltaPsizing;
            Console.WriteLine ("deltaP = {0} kPa\ndeltaPChoked = {1} kPa", DeltaP, DeltaPchocked);
            if (DeltaP < DeltaPchocked) {
                DeltaPsizing = DeltaP;
                Console.WriteLine ("flow is not choked");
            } else {
                DeltaPsizing = DeltaPchocked;
                Console.WriteLine ("Alarm!! flow choked");
                /// Cavitation / Flashing judgment
                if (P2 <= Pv) {
                    Console.WriteLine ("Alarm!! Flashing will occur");
                } else {
                    Console.WriteLine ("Alarm!! Cavitation will occur");
                }
            }
            Console.WriteLine ("DeltaPsizing = {0} kPa", DeltaPsizing);
            #endregion

            #region Calculated valve flow rate, Ccal，unit : m3/h
            double Ccal; //calculated valve flow rate
            Ccal = Q / N1 / Fp * Math.Sqrt (Density / Density0 / DeltaPsizing);
            Console.WriteLine ("Kv = " + Ccal);
            if (Ccal < C) {
                Console.WriteLine ("The calculated flow rate is less than the Valve rated flow rate");
            } else {
                Console.WriteLine ("Error! The calculated flow rate is larger than the Valve rated flow rate, this valve should not be considered");
            }
            #endregion

            #region verify the result of the scop
            double result = Ccal / N18 / d / d;
            if (result < .047) {
                Console.WriteLine ("result ={0} is in scope", result);
            } else {
                Console.WriteLine ("Error! result={0} is not in scope", result);
            }
            #endregion			

            #region Rev Reynolds Number
            double Rev = (N4 * Fd * Q) / (v * Math.Sqrt (Ccal * Fl)) * Math.Sqrt (Math.Sqrt (Fl * Fl * Ccal * Ccal / N2 / d / d / d / d + 1));
            Console.WriteLine ("Rev = " + Rev);
            if (Rev > 10000) {
                Console.WriteLine ("Flow is turbulent");
                Console.WriteLine ("Flow Rate Kv = {0} m3/h\nFlow Rate Cv = {1} us gal/min", Ccal, Ccal * 1.156);
            } else if (Rev >= 10) {
                Console.WriteLine ("Alarm! Flow is transitional");

                #region calculate n
                if (C / d / d / N18 >= 0.016) {
                    n = N2 / (C / d / d) / (C / d / d);
                } else {
                    n = 1 + N32 * Math.Pow (C / d / d, 2 / 3);
                }
                #endregion

                #region calculate Fr
                double Fr1;
                double Fr2;
                Fr1 = 1 + (0.33 * Math.Sqrt (Fl) / Math.Pow (n, 1 / 4)) * Math.Log10 (Rev / 10000);
                Fr2 = 0.026 / Fl * Math.Sqrt (n * Rev);
                double Fr;
                if (Fr1 < Fr2) {
                    Fr = Fr1;
                } else {
                    Fr = Fr2;
                }
                if (Fr > 1) {
                    Fr = 1;
                } else { }
                #endregion

                #region Calculated valve flow rate, Ccal，unit : m3/h
                Ccal = Q / N1 / Fr * Math.Sqrt (Density / Density0 / DeltaP);
                Console.WriteLine ("Kv = " + Ccal);
                if (Ccal < C) {
                    Console.WriteLine ("The calculated flow rate is less than the Valve rated flow rate");
                } else {
                    Console.WriteLine ("Error! The calculated flow rate is larger than the Valve rated flow rate, this valve should not be considered");
                }
                #endregion				
                Console.WriteLine ("Flow Rate Kv = {0} m3/h\nFlow Rate Cv = {1} us gal/min", Ccal, Ccal * 1.156);

            } else {
                Console.WriteLine ("Alarm! Flow is laminar");

                #region calculate n
                if (C / d / d / N18 >= 0.016) {
                    n = N2 / (C / d / d) / (C / d / d);
                } else {
                    n = 1 + N32 * Math.Pow (C / d / d, 2 / 3);
                }
                Console.WriteLine("n = "  +n);
                #endregion

                #region calculate Fr
                double Fr2;
                Fr2 = 0.026 / Fl * Math.Sqrt (n * Rev);
                double Fr;
                if (Fr2 < 1) {
                    Fr = Fr2;
                } else {
                    Fr = 1;
                }
                Console.WriteLine("Fr = "+ Fr);
                #endregion

                #region Calculated valve flow rate, Ccal，unit : m3/h
                Ccal = Q / N1 / Fr * Math.Sqrt (Density / Density0 / DeltaP);
                Console.WriteLine ("Kv = " + Ccal);
                if (Ccal < C) {
                    Console.WriteLine ("The calculated flow rate is less than the Valve rated flow rate");
                } else {
                    Console.WriteLine ("Error! The calculated flow rate is larger than the Valve rated flow rate, this valve should not be considered");
                }
                #endregion				
                Console.WriteLine ("Flow Rate Kv = {0} m3/h\nFlow Rate Cv = {1} us gal/min", Ccal, Ccal * 1.156);					
            }
            #endregion
            Console.WriteLine ("----------END Liquid Sizing----------");

        }
    }
}