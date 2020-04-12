using System;
using System.Collections.Generic;
using System.Text;

namespace CTrue.Wbs.Core
{
    public interface IDice
    {
        int Roll();
    }

    public class Dice : IDice
    {
        public int Roll()
        {
            return new Random().Next(1, 6);
        }

        
    }
}
