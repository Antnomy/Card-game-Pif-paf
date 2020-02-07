using mesa;

namespace Pif_paf
{
    class Trinca
    {
        public Carta[] Vtr = new Carta[3];
        public Trinca(Carta[] vtr)
        {
            Vtr = vtr;
        }
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < Vtr.Length; i++)
            {
                str += " " + Vtr[i].ToString();
            }
            return str;
        }
    }
}
