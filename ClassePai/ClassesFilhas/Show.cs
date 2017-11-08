using System;

namespace ProjetoEvento.ClassePai.ClassesFilhas
{
    public class Show : Evento
    {
        public string Artista { get; set; }

        public string GeneroMusical { get; set; }

        public Show()
        {
        }

        public Show(string titulo, string local, int lotacao, string duracao, int classificacao, DateTime data, string artista, string generomusical)
        {
            base.Titulo = titulo;
            base.Local = local;
            base.Lotacao = lotacao;
            base.Duracao = duracao;
            base.Classificacao = classificacao;
            base.Data = data;

            //Argumento a seguir estão na classe filha, por isso usamos o "this"
            this.Artista = artista;
            this.GeneroMusical = generomusical;
        }

        public override bool Cadastrar(){
            return false;
        }

    }
}