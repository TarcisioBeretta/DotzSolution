using AutoMapper;
using Dotz.Api.Resources.Auth;
using Dotz.Api.Resources.Troca;
using Dotz.Api.Resources.Produto;
using Dotz.Api.Resources.Usuario;
using Dotz.Core.Models;

namespace Dotz.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UsuarioToken, UsuarioTokenResource>();

            CreateMap<Usuario, UsuarioResource>();
            CreateMap<CreateUsuarioResource, Usuario>();
            CreateMap<UpdateUsuarioResource, Usuario>();

            CreateMap<Produto, ProdutoResource>();
            CreateMap<CreateProdutoResource, Produto>();
            CreateMap<UpdateProdutoResource, Produto>();

            CreateMap<Troca, TrocaResource>();
            CreateMap<TrocaProduto, TrocaProdutoResource>();

            CreateMap<CreateTrocaResource, Troca>();
            CreateMap<UpdateTrocaResource, Troca>();
            CreateMap<CreateTrocaProdutoResource, TrocaProduto>()
                .ForMember(destination => destination.TrocaId, opt => opt.MapFrom(source => source.ProdutoId))
                .ForMember(destination => destination.Quantidade, opt => opt.MapFrom(source => source.Quantidade));
        }
    }
}
