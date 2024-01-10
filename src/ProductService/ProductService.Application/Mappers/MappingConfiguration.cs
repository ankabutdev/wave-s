using AutoMapper;
using ProductService.Application.DTOs.Categories;
using ProductService.Application.UseCases.Categories.Commands.CreateCategory;
using ProductService.Domain.Entities;

namespace ProductService.Application.Mappers;

public class MappingConfiguration : Profile
{
    public MappingConfiguration()
    {
        // Poducts

        // Categories
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        CreateMap<Category, CategoryUpdateDto>().ReverseMap();

        CreateMap<CategoryCreateDto, CreateCategoryCommand>().ReverseMap();

        CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        //CreateMap<Category, Update>().ReverseMap();

        CreateMap<CategoryCreateDto, CreateCategoryCommand>().ReverseMap();
        // CreateMap<CategoryUpdateDto, UpdateCategoryCommand>().ReverseMap();

        // Companies
    }
}
