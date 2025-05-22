using MusifyModel;

using System;
using System.Collections.Generic;
using System.Linq;

namespace MusifyBusiness
{
    public abstract class MusicaBase
    {
        public abstract string ObterDescricao(Musica musica);
    }

    public class MusicaService : MusicaBase
    {

        private readonly List<Musica> _musicas = new List<Musica>();

        
        public void AdicionarMusica(Musica musica)
        {
            if (musica == null) throw new ArgumentNullException(nameof(musica));
            if (string.IsNullOrWhiteSpace(musica.Titulo) || string.IsNullOrWhiteSpace(musica.Artista))
                throw new ArgumentException("Título e Artista são obrigatórios.");

            // Simula geração de Id incremental
            musica.Id = _musicas.Count > 0 ? _musicas.Max(m => m.Id) + 1 : 1;
            _musicas.Add(musica);
        }

        public List<Musica> ObterTodas()
        {
            return _musicas;
        }

        public override string ObterDescricao(Musica musica)
        {
            if (musica == null) return "Música não encontrada.";
            return $"{musica.Titulo} - {musica.Artista} [{musica.Genero}], duração: {musica.DuracaoSegundos} segundos.";
        }
    }
}
