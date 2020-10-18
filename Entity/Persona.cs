using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System;


namespace Entity
{
    public class Persona
    {
        public string identificacion { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string sexo { get; set; }
        public int  edad { get; set; }
        public string departamento { get; set; }
        public string ciudad { get; set; }
        public int Valorapoyo { get; set; }
        public string  modalidad { get; set; }
        public string fecha { get; set; }

     
      public int CalcularValorTotalApoyo(List <Persona> personas) {
        if   (personas!= null)
        {     int valorTotal = 0;
         foreach (var item in personas)
         {
                valorTotal += item.Valorapoyo;
         }
        
         return valorTotal;
        }
        return 0;
     }
    }
}
