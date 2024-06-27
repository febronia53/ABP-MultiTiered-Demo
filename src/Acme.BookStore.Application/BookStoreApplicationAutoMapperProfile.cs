using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Acme.BookStore.OrganizationUnits;
using Acme.BookStore.PermissionGroups;
using AutoMapper;
using Volo.Abp.Identity;

namespace Acme.BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Book, BookDto>();
       CreateMap<CreateUpdateBookDto, Book>();
        CreateMap<Author, AuthorDto>();
        CreateMap<Author, AuthorLookupDto>();


        CreateMap<OrganizationUnit, OrganizationUnitDto>();
        CreateMap<CreateOrganizationUnitDto, OrganizationUnitDto>();
        CreateMap<UpdateOrganizationUnitDto, OrganizationUnitDto>();


        CreateMap<PermissionGroup, PermissionGroupDto>();
    }
}
