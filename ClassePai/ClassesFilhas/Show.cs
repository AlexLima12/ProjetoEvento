using System;
using System.IO;
using System.Text;


namespace ProjetoEvento.ClassePai.ClassesFilhas
{
    public class Show : Evento
    {
        public string Artista { get; set; }

        public string GeneroMusical { get; set; }

        public Show()
        {
        }

        public Show(string titulo, string local, int lotacao, string duracao,  DateTime data, int classificacao, string artista, string generomusical)
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
             bool efetuado = false;
            StreamWriter arquivo = null;
            try
            {
                arquivo = new StreamWriter("show.csv", true);
                arquivo.WriteLine(Titulo + ";" + Local + ";" + Duracao + ";" + Data + ";" + Lotacao + ";" + Classificacao + ";" + Artista + ";" + GeneroMusical);
                efetuado = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar gravar o arquivo." + ex.Message);
            }
            finally
            {
                arquivo.Close();
            }
            return efetuado;
        }

        /// <summary>
        /// Pesquisa o título do show.
        /// </summary>
        /// <param name="Titulo">Utiliza o parâmetro do tipo string.</param>
        /// <returns>Retorna se encontrou ou não o título pesquisado.</returns>
        public override string Pesquisar(string Titulo)
        {
            string resultado = "";
            StreamReader ler = null;
            try
            {
                ler = new StreamReader("show.csv", Encoding.Default);
                string linha = "";
                while((linha = ler.ReadLine()) != null){
                    string[] dados = linha.Split(';');
                    if(dados[0] == Titulo){
                        resultado = linha;
                        break;
                    }
                }
            }
            catch(Exception ex){
                resultado = "Erro ao tentar ler o arquivo." + ex.Message;

            }
            finally{
                ler.Close();
            }
            return resultado;
        }

    }
}