using System;
using UStart.Domain.Commands;
using UStart.Domain.Contracts.Repositories;
using UStart.Domain.Entities;
using UStart.Domain.UoW;

namespace UStart.Domain.Workflows
{
    public class ObraWorkflow : WorkflowBase
    {
        private readonly IObraRepository _ObraRepository;
        private readonly IUnitOfWork _unitOfWork;
        private object _obraRepository;

        public ObraWorkflow(IObraRepository obraRepository, IUnitOfWork unitOfWork)
        {
            _ObraRepository = obraRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(ObraCommand command)
        {

            if (ValidarObra(command) == false){
                return;
            }

            var Obra = new Obra(command);
            _ObraRepository.Add(Obra);
            _unitOfWork.Commit();            
        }

        public void Update(Guid id, ObraCommand command){

            if (ValidarObra(command) == false){
                return;
            }
            
            var Obra = _ObraRepository.ConsultarPorId(id);
            if (Obra != null){
                Obra.Update(command);
                _ObraRepository.Update(Obra);
                _unitOfWork.Commit();
            }
            else{
                AddError("Obra", "Obra não pode ser encontrada", id);
            }

        }

        public void Delete(Guid id){

            var Obra = _ObraRepository.ConsultarPorId(id);
            if (Obra != null){
                _ObraRepository.Delete(Obra);
                _unitOfWork.Commit();                
            }else{
                AddError("Obra", "Obra não pode ser encontrada", id);
            }            
        }

        private bool ValidarObra(ObraCommand command){
            if (string.IsNullOrEmpty(command.Nome))
            {
                this.AddError("Nome", "Nome não informado");
            }
            if (command.GrupoId == Guid.Empty)
            {
                this.AddError("Grupo", "Grupo não informado");
            }

            return this.IsValid();
        }
    }
}