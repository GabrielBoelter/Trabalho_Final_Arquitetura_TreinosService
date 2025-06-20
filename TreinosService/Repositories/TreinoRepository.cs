using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TreinosService.Data;
using TreinosService.Models;
using TreinosService.Repositories;

namespace TreinosService.Repositories
{
    public class TreinoRepository : ITreinoRepository
    {
        private readonly AppDbContext _context;

        // Construtor com injeção de dependência do contexto
        public TreinoRepository(AppDbContext context)
        {
            _context = context;
        }

        // Método para adicionar um novo treino
        public Treino Adicionar(Treino treino)
        {
            try
            {
                _context.Treinos.Add(treino); // Adiciona o treino ao contexto
                _context.SaveChanges();  // Salva as mudanças no banco de dados
                return treino;  // Retorna o treino criado
            }
            catch (DbUpdateException ex)
            {
                // Trata erro de atualização do banco de dados, como problemas de chave primária duplicada
                throw new Exception("Erro ao adicionar treino, problema com o banco de dados.", ex);
            }
            catch (Exception ex)
            {
                // Erro genérico, quando não for possível adicionar o treino
                throw new Exception("Erro ao adicionar treino", ex);
            }
        }

        // Método para obter todos os treinos
        public IEnumerable<Treino> ObterTodos()
        {
            return _context.Treinos.AsNoTracking().ToList(); // Usando AsNoTracking para melhorar a performance em consultas de leitura
        }

        // Método para obter um treino por ID
        public Treino? ObterPorId(int id)
        {
            return _context.Treinos.Find(id); // 'Find' é eficiente para busca por chave primária
        }

        // Método para remover um treino
        public void Remover(int id)
        {
            var treino = _context.Treinos.Find(id); // Busca o treino pelo ID

            if (treino != null)
            {
                try
                {
                    _context.Treinos.Remove(treino); // Remove o treino encontrado
                    _context.SaveChanges();  // Salva as alterações no banco de dados
                }
                catch (DbUpdateException ex)
                {
                    // Caso haja erro ao remover, como problemas de integridade referencial
                    throw new Exception("Erro ao remover treino, problema com o banco de dados.", ex);
                }
                catch (Exception ex)
                {
                    // Erro genérico ao remover o treino
                    throw new Exception("Erro ao remover treino", ex);
                }
            }
            else
            {
                // Lança uma exceção se o treino não for encontrado
                throw new KeyNotFoundException($"Treino com o ID {id} não encontrado.");
            }
        }

        bool ITreinoRepository.Remover(int id)
        {
            throw new NotImplementedException();
        }

        public Treino Atualizar(Treino treino)
        {
            throw new NotImplementedException();
        }
    }
}
