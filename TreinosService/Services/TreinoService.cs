using System;
using System.Collections.Generic;
using System.Linq;
using TreinosService.DTOs;
using TreinosService.Models;
using TreinosService.Repositories;

namespace TreinosService.Services
{
    public class TreinoService : ITreinoService
    {
        private readonly ITreinoRepository _treinoRepository;

        // Construtor da classe com injeção de dependência para o repositório
        public TreinoService(ITreinoRepository treinoRepository)
        {
            _treinoRepository = treinoRepository;
        }

        // Método para criar um treino
        public TreinoResponseDTO CriarTreino(TreinoRequestDTO request)
        {
            var treino = new Treino
            {
                Nome = request.Nome,
                Objetivo = request.Objetivo,
                DataCriacao = DateTime.Now
            };
            var treinoCriado = _treinoRepository.Adicionar(treino);
            return new TreinoResponseDTO
            {
                Id = treinoCriado.Id,
                Nome = treinoCriado.Nome,
                Objetivo = treinoCriado.Objetivo,
                DataCriacao = treinoCriado.DataCriacao
            };
        }

        // Método para listar todos os treinos
        public IEnumerable<TreinoResponseDTO> ListarTreinos()
        {
            var treinos = _treinoRepository.ObterTodos();
            return treinos.Select(t => new TreinoResponseDTO
            {
                Id = t.Id,
                Nome = t.Nome,
                Objetivo = t.Objetivo,
                DataCriacao = t.DataCriacao
            });
        }

        // Método para buscar um treino por ID
        public TreinoResponseDTO? BuscarTreino(int id)
        {
            var treino = _treinoRepository.ObterPorId(id);
            if (treino == null)
                return null;
            return new TreinoResponseDTO
            {
                Id = treino.Id,
                Nome = treino.Nome,
                Objetivo = treino.Objetivo,
                DataCriacao = treino.DataCriacao
            };
        }

        // Método para deletar um treino por ID
        public bool DeletarTreino(int id)
        {
            var treino = _treinoRepository.ObterPorId(id);
            if (treino == null)
            {
                // O treino não foi encontrado
                return false;
            }
            _treinoRepository.Remover(id);
            return true;  // Retorna verdadeiro se o treino foi deletado com sucesso
        }
    }
}