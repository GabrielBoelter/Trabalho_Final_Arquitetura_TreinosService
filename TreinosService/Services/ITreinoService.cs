using TreinosService.DTOs;
using System.Collections.Generic;

namespace TreinosService.Services
{
    public interface ITreinoService
    {
        TreinoResponseDTO CriarTreino(TreinoRequestDTO request);
        IEnumerable<TreinoResponseDTO> ListarTreinos();
        TreinoResponseDTO? BuscarTreino(int id);
        bool DeletarTreino(int id);
    }
}
