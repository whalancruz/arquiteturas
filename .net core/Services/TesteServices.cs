using Entitys;
using Interfaces.Services;
using Util.Generic;

namespace Services
{
    public class TesteServices : GenericServices<TesteEntity>, ITesteServices
    {

        public TesteServices(DbContexto dbContexto) : base(dbContexto)
        {

        }

        public override TesteEntity onPrevUpdate(TesteEntity entity)
        {
            // entity.Descricao = entity.Descricao ?? oldeEtity.Descricao;
            // entity.Nome = entity.Nome ?? oldeEtity.Nome;
            // entity.Observacao = entity.Observacao ?? oldeEtity.Observacao;
            return entity;
        }

    }
}