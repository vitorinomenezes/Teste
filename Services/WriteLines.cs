using System;

namespace Aplicacao
{
    public abstract class WriteLines
    {
        public string TextMenssage { get; set; }
        public  void WriteLine()
        {
            Console.WriteLine("-------------------------------------------------------------------- ");
        }
    }
}
