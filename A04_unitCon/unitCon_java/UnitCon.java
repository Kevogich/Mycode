public class UnitCon {
    public static void main(String[] args) {
        // Double Value1 = Double.Valueof(1.2003);

        UnitConvention uc = new UnitConvention();
        uc.i = Double.valueOf(1.2003);  //input value
        uc.Unit1 = "MPa(a)"; //unit of input value, here let's use MPa(a) as example;
        uc.Unit2 = "KPa(a)"; //unit of output value, here we use KPa(a)as example;
        // System.out.println(uc.i + " " + uc.Unit1 + " = "+ uc.Value2() + " " +uc.Unite2); //
        System.out.println(uc.Value2());
    }
}
