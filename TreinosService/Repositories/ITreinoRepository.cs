using TreinosService.Models;

namespace TreinosService.Repositories
{
    public interface ITreinoRepository
    {
        // Métodos básicos do Repository (trabalham com a entidade Treino)
        Treino Adicionar(Treino treino);
        IEnumerable<Treino> ObterTodos();
        Treino? ObterPorId(int id);
        bool Remover(int id);
        Treino Atualizar(Treino treino);
    }
}