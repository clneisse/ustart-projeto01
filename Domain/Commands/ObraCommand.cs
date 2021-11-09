using System;

namespace UStart.Domain.Commands
{
    public class ObraCommand
    {
        public Guid Id { get; set; }
        public Guid GrupoId { get; set; }        
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Projetos { get; set; }
        public string Serviços { get; set; }
        public string CodigoExterno { get; set; }
    }
}