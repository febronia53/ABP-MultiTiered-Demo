using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Acme.BookStore.OrganizationUnits;
using AutoMapper;

namespace Acme.BookStore.Web;

public class BookStoreWebAutoMapperProfile : Profile
{
    public BookStoreWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<BookDto, CreateUpdateBookDto>();

      //  create
        CreateMap<Pages.Authors.CreateModalModel.CreateAuthorViewModel,
                   CreateAuthorDto>();
        //update
        CreateMap<AuthorDto, Pages.Authors.EditModalModel.EditAuthorViewModel>();
        CreateMap<Pages.Authors.EditModalModel.EditAuthorViewModel,
                    UpdateAuthorDto>();


        CreateMap<Pages.Books.CreateModalModel.CreateBookViewModel, CreateUpdateBookDto>();
        CreateMap<BookDto, Pages.Books.EditModalModel.EditBookViewModel>();
        CreateMap<Pages.Books.EditModalModel.EditBookViewModel, CreateUpdateBookDto>();




        CreateMap<OrganizationUnitDto, CreateOrganizationUnitDto>();
        CreateMap<OrganizationUnitDto, UpdateOrganizationUnitDto>();

    }
}
