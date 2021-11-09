using System;

namespace UStart.Domain.Commands
{
    public class GrupoCommand
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string CodigoExterno { get; set; }
        
    }
}