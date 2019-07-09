using System;
using System.IO;
// Used for Gas flow sizing
namespace GasSizing
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Data Input
            double Qs = 169900; //Flow rate unit:m3/h
            double W = 0;//Qs*.04475*44.01; //Mass flow rate W=Qs*N8/N9*M unit:Kg/h

            double P1 = 1480; //Inlet Pressure unit:kPa;
            double P2 = 446; //Outlet pressure unit:kPa;
            double T1 = 289; //Inlet temperature, unit:K;
            double D1 = 200; //Inlet pipe size, unit:mm
            double D2 = 200; //Outlet pipe size, unit:mm

            string Fluid; //fluid type, incompressible or compressible
                          //double Density = 8.389; //Fluid density, unit kg/m3
                          //double DensitySTD = 1978; //fluid density at standard condition unit kg/m3
            double Z1 = .991; //Compressibility, unit kPa;
            double Zs = 0.994; //Standard compressibility, unit kPa;
            double Ts = 273; // unit K
            double Ps = 101.325; // unit kPa
            double v = .000002526; //Kinematic viscosity, unit: m2/s;
            double M = 17.38; //Molecular mass;
            double Gama = 1.31; //Specific heat ration

            string Manufacturer;
            string BodyStyle; //Globe is default;
            string ValveType; //5100 or 5400;
            string TrimCharacteristic;
            string Balance;
            string RestricedTrim;
            string FlowDriction; //Flow up or Flow down
            double d = 200; //Valve size unit:mm
            string Class;
            double PortSize; //unit mm
            double MaxTravel; //unit mm
            string Note;
            double Fl = .85; //Liquid pressure recovery factor
            double Fd = .42; //Valve style modifier
            double Xt = .137;
            double Kv = 2190; // Valve flow rate
            double Cv;

            double N2 = 0.0016;
            double N4 = 0.0707;
            double N5 = 0.0018;
            double N8 = 1.1;
            double N9 = 24.6;
            double N18 = 0.865;
            double n;//trim factor for non-turbulent flow;
            double N32 = 140;
            double N22 = 17.3;
            #endregion

            double C = Kv;//Valve rated flow rate

            #region Piping geometry factor, Fp
            double Fp; //Piping geometry factor
            double K1;
            double K2; //Head loss coefficient:
            double KB1;
            double KB2;
            double K;
            K1 = 0.5 * (1 - d * d / (D1 * D1)) * (1 - d * d / (D1 * D1)); //
            K2 = (1 - d * d / D2 / D2) * (1 - d * d / D2 / D2);
            KB1 = 1 - d * d * d * d / D1 / D1 / D1 / D1;
            KB2 = 1 - d * d * d * d / D2 / D2 / D2 / D2;
            K = K1 + K2 + KB1 - KB2;
            Console.WriteLine("K1 = {0}\nK2 = {1}\nKB1 = {2}\nKB2 = {3}", K1, K2, KB1, KB2);
            Fp = 1 / Math.Sqrt(1 + (K / N2) * (C / d / d) * (C / d / d));
            Console.WriteLine("Fp = " + Fp);
            #endregion

            #region combined liquid pressure recovery factor Flp
            double Flp = Fl / Math.Sqrt(1 + Fl * Fl / N2 * (K1 + KB1) * (C / d / d) * (C / d / d));
            Console.WriteLine("Fp = {0}\nFlp = {1}", Fp, Flp);
            #endregion

            #region Estimated pressure differential ratio factor with attached fittings, Xtp
            double Xtp = (Xt / Fp / Fp) / (1 + Xt * (K1 + KB1) / N5 * (C / d / d) * (C / d / d));
            Console.WriteLine("Xtp = {0}", Xtp);
            Console.WriteLine("Xt = " + Xt);
            #endregion

            #region Specific heat ratio factor, Fgama
            double Fgama = Gama / 1.4;
            Console.WriteLine("Fgama = {0}", Fgama);
            #endregion

            #region choked or not?
            double Xchocked;
            Xchocked = Fgama * Xtp;
            double DeltaP;
            DeltaP = P1 - P2;
            double X;
            X = DeltaP / P1;
            double Xsizing;
            Console.WriteLine("X = {0} kPa\nXChoked = {1} kPa", X, Xchocked);
            if (X < Xchocked)
            {
                Xsizing = X;
                Console.WriteLine("flow is not choked");
            }
            else
            {
                Xsizing = Xchocked;
                Console.WriteLine("Alarm!! flow choked");
            }
            Console.WriteLine("Xsizing = {0} kPa", Xsizing);
            #endregion

            #region Expansion factor, Y
            double Y1 = 1 - Xsizing / (3 * Xchocked);
            double Y2 = Xchocked * 2 / 3;
            double Y;

            if (Xsizing == Xchocked)
            {
                if (Y1 > Y2)
                {
                    Y = Y1;
                }
                else
                {
                    Y = Y2;
                }
            }
            else
            {
                Y = Y1;
            }
            Console.WriteLine("Y = {0}", Y);
            #endregion

            #region C calculation
            double Ccal;

            if (W == 0)
            {
                Ccal = Qs / N9 / Fp / P1 / Y * Math.Sqrt(M * T1 * Z1 / Xsizing);
            }
            else
            {
                Ccal = W / N8 / Fp / P1 / Y * Math.Sqrt(T1 * Z1 / M / Xsizing);
            }
            Console.WriteLine("Kv = " + Ccal + " m3/h");

            double Q;
            Q = Qs * (Ps / Zs / Ts) * (Z1 * T1 / P1);
            Console.WriteLine("Q = " + Q + "m3/h");
            if (Ccal < C)
            {
                Console.WriteLine("The calculated Cv is less than the Valve max Cv");
            }
            else
            {
                Console.WriteLine("Error! The calculated Cv is larger than the Valve max Cv, this valve should not be considered");
            }
            #endregion

            #region verify the result of the scop
            double result = Ccal / N18 / d / d;

            if (result < 0.047)
            {
                Console.WriteLine("result ={0} is in scope", result);
            }
            else
            {
                Console.WriteLine("Error! result={0} is not in scope", result);
            }
            #endregion

            #region Rev Reynolds Number
            double Rev = (N4 * Fd * Q) / (v * Math.Sqrt(Ccal * Fl)) * Math.Sqrt(Math.Sqrt(Fl * Fl * Ccal * Ccal / N2 / d / d / d / d + 1));
            Console.WriteLine("Rev = " + Rev);
            if (Rev >= 10000)
            {
                Console.WriteLine("Flow is turbulent");
                Console.WriteLine("Flow Rate Kv = {0} \nFlow Rate Cv = {1} ", Ccal, Ccal * 1.156);
            }
            else if (Rev >= 10)
            {
                Console.WriteLine("Alarm! Flow is transitional");

                #region calculate n
                if (C / d / d / N18 >= 0.016)
                {
                    n = N2 / (C / d / d) / (C / d / d);
                }
                else
                {
                    n = 1 + N32 * Math.Pow(C / d / d, 2 / 3);
                }
                #endregion

                #region calculate Fr
                double Fr1;
                double Fr2;
                Fr1 = 1 + (0.33 * Math.Sqrt(Fl) / Math.Pow(n, 1 / 4)) * Math.Log10(Rev / 10000);
                Fr2 = 0.026 / Fl * Math.Sqrt(n * Rev);
                double Fr;

                if (Fr1 < Fr2)
                {
                    Fr = Fr1;
                }
                else
                {
                    Fr = Fr2;
                }
                if (Fr > 1)
                {
                    Fr = 1;
                }
                else { }
                #endregion

                #region calculate Y
                if (Rev >= 1000 && Rev < 10000)
                {
                    Y = (Rev - 1000) / 9000 * (1 - Xsizing / 3 / Xchocked - Math.Sqrt(1 - X / 2)) + Math.Sqrt(1 - X / 2);
                }
                else
                {
                    Y = Math.Sqrt(1 - X / 2);
                }
                #endregion

                #region Calculated valve flow rate, CcalÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¯ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¼ÃƒÆ’Ã¢â‚¬Â¦ÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢unit : m3/h
                Ccal = Qs / N22 / Fr / Y * Math.Sqrt(M * T1 / (P1 + P2) / DeltaP);
                Console.WriteLine("Kv = " + Ccal);
                if (Ccal < C)
                {
                    Console.WriteLine("The calculated flow rate is less than the Valve rated flow rate");
                }
                else
                {
                    Console.WriteLine("Error! The calculated flow rate is larger than the Valve rated flow rate, this valve should not be considered");
                }
                #endregion
                Console.WriteLine("Flow Rate Kv = {0} m3/h\nFlow Rate Cv = {1} us gal/min", Ccal, Ccal * 1.156);
            }
            else
            {
                Console.WriteLine("Alarm! Flow is laminar");

                #region calculate n
                if (C / d / d / N18 >= 0.016)
                {
                    n = N2 / (C / d / d) / (C / d / d);
                }
                else
                {
                    n = 1 + N32 * Math.Pow(C / d / d, 2 / 3);
                }
                Console.WriteLine("n = " + n);
                #endregion

                #region calculate Fr
                double Fr2;
                Fr2 = 0.026 / Fl * Math.Sqrt(n * Rev);
                double Fr;

                if (Fr2 < 1)
                {
                    Fr = Fr2;
                }
                else
                {
                    Fr = 1;
                }
                Console.WriteLine("Fr = " + Fr);
                #endregion

                #region calculate Y
                if (Rev >= 1000 && Rev < 10000)
                {
                    Y = (Rev - 1000) / 9000 * (1 - Xsizing / 3 / Xchocked - Math.Sqrt(1 - X / 2)) + Math.Sqrt(1 - X / 2);
                }
                else
                {
                    Y = Math.Sqrt(1 - X / 2);
                }
                #endregion

                #region Calculated valve flow rate, CcalÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¯ÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â¼ÃƒÆ’Ã¢â‚¬Â¦ÃƒÂ¢Ã¢â€šÂ¬Ã¢â€žÂ¢unit : m3/h
                Ccal = Qs / N22 / Fr / Y * Math.Sqrt(M * T1 / (P1 + P2) / DeltaP);
                Console.WriteLine("Kv = " + Ccal);
                if (Ccal < C)
                {
                    Console.WriteLine("The calculated flow rate is less than the Valve rated flow rate");
                }
                else
                {
                    Console.WriteLine("Error! The calculated flow rate is larger than the Valve rated flow rate, this valve should not be considered");
                }
                #endregion
                Console.WriteLine("Flow Rate Kv = {0} m3/h\nFlow Rate Cv = {1} us gal/min", Ccal, Ccal * 1.156);
            }
            #endregion
            Console.WriteLine("----------END Gas Sizing----------");
        }
    }
}