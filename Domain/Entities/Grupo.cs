using System;
using UStart.Domain.Commands;

namespace UStart.Domain.Entities
{
    public class Grupo
    {
        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public string CodigoExterno { get; private set; }

        public Grupo()
        {            
        }


        /// <summary>
        /// Inserir um grupo
        /// </summary>
        /// <param name="command"></param>
        public Grupo(GrupoCommand command)
        {
            this.Id = command.Id == Guid.Empty ? Guid.NewGuid() : command.Id;
            this.Descricao = command.Descricao;
            this.CodigoExterno = command.CodigoExterno;
        }

        /// <summary>
        /// Atualizar um grupo
        /// </summary>
        /// <param name="command"></param>
        public void Update(GrupoCommand command){
            this.Descricao = command.Descricao;
            this.CodigoExterno = command.CodigoExterno;
        }
    }
    
}