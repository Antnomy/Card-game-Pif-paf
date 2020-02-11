using System;

namespace utilitarios
{
    class Tempo
    {
        public static void Timer(int segundos, bool mostraContagem)
        {
            TimeSpan t1 = new TimeSpan(100000000);                   
            long cont = 0;
            int seg = 0;
           
            while(seg != segundos)
            {
                cont++;
                if(cont == t1.Ticks)
                {
                    seg++;
                    cont = 0;
                    if (mostraContagem)
                    {
                        Console.Clear();
                        Console.Write(seg + " seg");
                    }
                                    
                }
                
                
            }
          
        }
    }
}
