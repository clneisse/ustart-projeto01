using System;
using UStart.Domain.Commands;

namespace UStart.Domain.Entities
{
    public class Obra
    {
        public Guid Id { get; private set; }
        public Guid GrupoId { get; private set; }
        public Grupo Grupo { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Projetos { get; private set; }
        public string Serviços { get; private set; }
        public string CodigoExterno { get; private set; }

        public Obra()
        {

        }

        public Obra(ObraCommand command)
        {
            Id = command.Id == Guid.Empty ? Guid.NewGuid() : command.Id;
            AtualizarCampos(command);
        }

        public void Update(ObraCommand command)
        {
            AtualizarCampos(command);
        }

        private void AtualizarCampos(ObraCommand command)
        {
            Descricao = command.Descricao;
            GrupoId = command.GrupoId;
            Nome = command.Nome;            
            Projetos = command.Projetos;
            Serviços = command.Serviços;
            CodigoExterno = command.CodigoExterno;
        }
    }
}