using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3_3
{
    internal class Drob
    {
        private int chislitel;
        private int znamenatel;


        public Drob() { 
        }

        public Drob(int c, int z) {
       
            chislitel = c;
{
            if (z == 0)
                {
                    //знаменатель не может быть равен 0
                    throw new ArgumentException("0");
                }
                else
                {
                    znamenatel = z;
                }
            }  
        }

     

        public static Drob Sum(Drob d1, Drob d2)
        {

            int a = d1.chislitel;
            int b = d1.znamenatel;

            int c = d2.chislitel;
            int d = d2.znamenatel;

            Drob newDrob = new Drob();

            int ch = a * d + c * b;
            int zn = b * d;

            int nod = Nod(ch, zn);

            newDrob.chislitel = ch / nod;
            newDrob.znamenatel = zn / nod;

            return newDrob;
        }
        public static Drob Minus(Drob d1, Drob d2)
        {

            int a = d1.chislitel;
            int b = d1.znamenatel;

            int c = d2.chislitel;
            int d = d2.znamenatel;

            Drob newDrob = new Drob();

            int ch = a * d - c * b;
            int zn = b * d;

            int nod = Nod(ch,zn);

            newDrob.chislitel = ch / nod;
            newDrob.znamenatel = zn / nod;

            return newDrob;
        }

        public static Drob Multy(Drob d1, Drob d2)
        {

            int a = d1.chislitel;
            int b = d1.znamenatel;

            int c = d2.chislitel;
            int d = d2.znamenatel;

            Drob newDrob = new Drob();

            int ch = a * c;
            int zn = b * d;

            int nod = Nod(ch, zn);

            newDrob.chislitel = ch / nod;
            newDrob.znamenatel = zn / nod;

            return newDrob;
        }
       public static Drob Divide(Drob d1, Drob d2)
        {

            int a = d1.chislitel;
            int b = d1.znamenatel;

            int c = d2.chislitel;
            int d = d2.znamenatel;

            Drob newDrob = new Drob();

            int ch = a * d;
            int zn = b * c;

            int nod = Nod(ch, zn);

            newDrob.chislitel = ch / nod;
            newDrob.znamenatel = zn / nod;

            return newDrob;
        }

        public static int Nod(int k, int l)
        {
            int m, n;

            if (k >= l)
            {
                m = k;
                n = l;
            }
            else
            {
                m = l;
                n = k;
            }


            while (m != n)
            {
                if (m > n)
                {
                    m = m - n;
                }
                else
                {
                    n = n - m;
                }
            }

            int nod = n;

            return nod;
        }

        public static int Nod(Drob d)
        {

            int k = d.chislitel;
            int l = d.znamenatel;


            int m, n;

            if (k >= l)
            {
                m = k;
                n = l;
            }
            else
            {
                m = l;
                n = k;
            }


            while (m != n)
            {
                if (m > n)
                {
                    m = m - n;
                }
                else
                {
                    n = n - m;
                }
            }

            int nod = n;

            return nod;
        }

        public int Nod()
        {

            int k = chislitel;
            int l = znamenatel;


            int m, n;

            if (k >= l)
            {
                m = k;
                n = l;
            }
            else
            {
                m = l;
                n = k;
            }


            while (m != n)
            {
                if (m > n)
                {
                    m = m - n;
                }
                else
                {
                    n = n - m;
                }
            }

            int nod = n;

            return nod;
        }




        public override string ToString()
        {

            int c = this.chislitel;
            int z = this.znamenatel;
            int nod = Nod(c, z);

            this.chislitel = c / nod;
            this.znamenatel = z / nod;

            return $"{chislitel}/{znamenatel}";
        }
   

        public static string ToFloatString(Drob d)
        {

            float result = (float) d.chislitel / (float) d.znamenatel;


            return $"{result}";
        }

        public static string ToFloatString(int ch, int zn) {

            float result = (float) ch / (float) zn;


            return $"{result}";
        }

    }
}
