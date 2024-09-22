using _5._2_FM.lojavirtual.Infra.Data.Context;
using Dapper;
using FM.lojavirtual.Domain.Entidades;
using FM.lojavirtual.Domain.Interfaces.Repository;
using System.Globalization;

namespace _5._2_FM.lojavirtual.Infra.Data.Repository
{
    public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
    {
        private readonly IVeiculoImagemRepository _veiculoImagemRepository;

        public VeiculoRepository(FMLojaVirtualDbContext context, IVeiculoImagemRepository veiculoImagemRepository) : base(context)
        {
            _veiculoImagemRepository = veiculoImagemRepository;
        }

        public async Task<IEnumerable<Veiculo>> Listar()
        {
            var cn = OpenConnectionDb();

            const string sql = @"SET ARITHABORT ON
                                     select v.Nome,
	                                        AnoFabricacao,
	                                        Modelo, Kilometragem,
	                                        Descricao,
	                                        Valor,
	                                        vi.Id As IdImagem,
	                                        vi.Nome As Nome,
	                                        vi.Tipo,
                                            tv.Id As IdTiposVeiculo,
                                            tv.Nome As Nome
                                       from Veiculos v  WITH (NOLOCK)
                                       join VeiculoImagem vi  WITH (NOLOCK)
                                         on v.Id = vi.IdVeiculo
                                        join TiposVeiculo tv WITH (NOLOCK)
                                          on tv.Id = v.IdTipoVeiculo
                                ";

            var veiculos = await cn.QueryAsync<Veiculo, VeiculoImagem, TiposVeiculo, Veiculo>(
                sql: sql,
                map: (veiculo, veiculoImagem, tiposVeiculo) =>
                    {
                        veiculo.VeiculoImagem = veiculoImagem;
                        veiculo.TiposVeiculo = tiposVeiculo;

                        return veiculo;
                    },
                null,
                splitOn: "IdImagem, IdTiposVeiculo",
                transaction: null);


            return veiculos;
        }

        public async Task<IEnumerable<Veiculo>> Listar(int idTipoVeiculo)
        {
            var cn = OpenConnectionDb();

            string sql = $@"SET ARITHABORT ON
                                     SELECT v.Nome,
	                                        AnoFabricacao,
	                                        Modelo, Kilometragem,
	                                        Descricao,
	                                        Valor,
	                                        vi.Id As IdImagem,
	                                        vi.Nome As Nome,
	                                        vi.Tipo,
                                            tv.Id As IdTiposVeiculo,
                                            tv.Nome As Nome
                                       FROM Veiculos v  WITH (NOLOCK)
                                       JOIN VeiculoImagem vi  WITH (NOLOCK)
                                         ON v.Id = vi.IdVeiculo
                                       JOIN TiposVeiculo tv WITH (NOLOCK)
                                         ON tv.Id = v.IdTipoVeiculo
                                      WHERE tv.Id = {idTipoVeiculo} ";

            var veiculos = await cn.QueryAsync<Veiculo, VeiculoImagem, TiposVeiculo, Veiculo>(
                sql: sql,
                map: (veiculo, veiculoImagem, tiposVeiculo) =>
                {
                    veiculo.VeiculoImagem = veiculoImagem;
                    veiculo.TiposVeiculo = tiposVeiculo;

                    return veiculo;
                },
                null,
                splitOn: "IdImagem, IdTiposVeiculo",
                transaction: null);


            return veiculos;
        }

        public async Task Adicionar(Veiculo veiculo)
        {
            var cn = OpenConnectionDb();

            string sql = $@"INSERT INTO Veiculos  (IdTipoVeiculo, Nome, 
                                                        AnoFabricacao, 
                                                        Modelo, 
                                                        Kilometragem, 
                                                        Descricao, 
                                                        Valor)
                                                VALUES (1,
                                                        '{veiculo.Nome}', 
                                                         {veiculo.AnoFabricacao}, 
                                                         {veiculo.Modelo}, 
                                                         {veiculo.Kilometragem}, 
                                                        '{veiculo.Descricao}', 
                                                         {veiculo.ObterValorVeiculoModeloBancoDados()}); ";

            await cn.QueryAsync(sql);

            await _veiculoImagemRepository.AdicionarSemImagemEmUltimoVeiculoAdd();

            //Estou criando um modo de criar uma imagem "sem imagem" para os veículos novos que foram criados...
            //    depois disso, será exibido na tela uma opção para que a pessoa possa inserir uma imagem

            //O nome da imagem está no nome do arquivo que está salvo no wwwroot

            //string sql = $@"insert into veiculoImagem values(13,'semimagem.jpeg', 'jpg',1, '2024-06-07', null);;

            //await cn.QueryAsync(sql);



            return;
        }

    }

    public class VeiculoImagemRepository : BaseRepository<VeiculoImagem>, IVeiculoImagemRepository
    {
        public VeiculoImagemRepository(FMLojaVirtualDbContext context) : base(context){}


        public async Task AdicionarSemImagemEmUltimoVeiculoAdd()
        {
            var cn = OpenConnectionDb();

            string sql = $@"INSERT INTO VeiculoImagem (IdVeiculo, 
Nome, 
Tipo,
Ativo,
DataCriacao,
DataAlteracao)
                                                VALUES (
(SELECT MAX(Id) as id from Veiculos),
                                                        'semimagem.jpeg', 
                                                         'jpeg', 
                                                         1, 
                                                         (select GETDATE()),
                                                         null)
                                                        ";

            await cn.QueryAsync(sql);


            //Estou criando um modo de criar uma imagem "sem imagem" para os veículos novos que foram criados...
            //    depois disso, será exibido na tela uma opção para que a pessoa possa inserir uma imagem

            //O nome da imagem está no nome do arquivo que está salvo no wwwroot

            //string sql = $@"insert into veiculoImagem values(13,'semimagem.jpeg', 'jpg',1, '2024-06-07', null);;

            await cn.QueryAsync(sql);



            return;
        }
    }
}
