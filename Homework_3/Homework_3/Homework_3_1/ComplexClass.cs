namespace Homework_3_1
{
    internal partial class Program
    {
        struct ComplexClass {

            private int re;
            private int im;

            public ComplexClass(int re, int im)
            {
                this.re = re;
                this.im = im;
            }

            public static ComplexClass Plus(ComplexClass a1, ComplexClass a2)
            {

                ComplexClass a3;
                a3.re = a1.re + a2.re;
                a3.im = a1.im + a2.im;

                return a3;
            }
            public static ComplexClass Minus(ComplexClass a1, ComplexClass a2)
            {

                ComplexClass a3;
                a3.re = a1.re - a2.re;
                a3.im = a1.im - a2.im;

                return a3;
            }
            public static ComplexClass Multy(ComplexClass a1, ComplexClass a2)
            {

                ComplexClass a3;
                a3.re = a1.re * a2.re;
                a3.im = a1.im * a2.im;

                return a3;
            }

            //public static Complex Divide(Complex a1, Complex a2)
            //{

            //    Complex a3;
            //    a3.re = a1.re / a2.re; // добавить обработку деления на 0
            //    a3.im = a1.im / a2.im; // добавить обработку деления на 0

            //    return a3;
            //}

            public override string ToString()
            {
                return $"{re} + {im}i";
            }

        }
    }
}
