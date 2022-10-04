namespace Homework_3_1
{
    internal partial class Program
    {
        struct Complex {

            private int re;
            private int im;

            public Complex(int re, int im)
            {
                this.re = re;
                this.im = im;
            }

            public static Complex Plus(Complex a1, Complex a2)
            {

                Complex a3;
                a3.re = a1.re + a2.re;
                a3.im = a1.im + a2.im;

                return a3;
            }
            public static Complex Minus(Complex a1, Complex a2)
            {

                Complex a3;
                a3.re = a1.re - a2.re;
                a3.im = a1.im - a2.im;

                return a3;
            }


            public override string ToString()
            {
                return $"{re} + {im}i";
            }

        }
    }
}
