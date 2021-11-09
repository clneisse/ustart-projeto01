using System;
using UStart.Domain.Commands;
using UStart.Domain.Contracts.Repositories;
using UStart.Domain.Entities;
using UStart.Domain.UoW;

namespace UStart.Domain.Workflows
{
    public class GrupoWorkflow : WorkflowBase
    {
        private readonly IGrupoRepository _grupoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GrupoWorkflow(IGrupoRepository grupoReposotory, IUnitOfWork unitOfWork)
        {
            _grupoRepository = grupoReposotory;
            _unitOfWork = unitOfWork;
        }

        public Grupo Add(GrupoCommand command)
        {

            if (string.IsNullOrEmpty(command.Descricao))
            {
                this.AddError("Descricao", "Descrição não informada");
            }

            if (this.IsValid() == false)
            {
                return null;
            }

            var grupo = new Grupo(command);
            _grupoRepository.Add(grupo);
            _unitOfWork.Commit();

            return grupo;
        }

        public void Update(Guid id, GrupoCommand command){
            
            var grupo = _grupoRepository.ConsultarPorId(id);
            if (grupo != null){
                grupo.Update(command);
                _grupoRepository.Update(grupo);
                _unitOfWork.Commit();
            }
            else{
                AddError("Grupo", "Grupo não pode ser encontrado", id);
            }

        }

        public void Delete(Guid id){

            //GrupoProduto grupoProduto = _grupoProdutoRepository.ConsultarPorId(id);

            var grupo = _grupoRepository.ConsultarPorId(id);
            if (grupo != null){
                _grupoRepository.Delete(grupo);
                _unitOfWork.Commit();                
            }else{
                AddError("Grupo", "Grupo não pode ser encontrado", id);
            }            
        }
    }
}