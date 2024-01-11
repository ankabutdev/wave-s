using AutoMapper;
using ProductService.Application.DTOs.Categories;
using ProductService.Application.DTOs.Companies;
using ProductService.Application.DTOs.Products;
using ProductService.Application.UseCases.Categories.Commands.CreateCategory;
using ProductService.Application.UseCases.Categories.Commands.UpdateCategory;
using ProductService.Application.UseCases.Companies.Commands.CreateCompany;
using ProductService.Application.UseCases.Companies.Commands.UpdateCompany;
using ProductService.Application.UseCases.Products.Commands.CreateProduct;
using ProductService.Application.UseCases.Products.Commands.UpdateProduct;
using ProductService.Domain.Entities;

namespace ProductService.Application.Mappers;

public class MappingConfiguration : Profile
{
    public MappingConfiguration()
    {
        // Poducts
        CreateMap<Product, ProductCreateDto>().ReverseMap();
        CreateMap<Product, ProductUpdateDto>().ReverseMap();

        CreateMap<Product, ProductCreateCommand>().ReverseMap();
        CreateMap<Product, ProductUpdateCommand>().ReverseMap();

        CreateMap<ProductCreateDto, ProductCreateCommand>().ReverseMap();
        CreateMap<ProductUpdateDto, ProductUpdateCommand>().ReverseMap();

        // Categories
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        CreateMap<Category, CategoryUpdateDto>().ReverseMap();

        CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        CreateMap<Category, CategoryUpdateCommand>().ReverseMap();

        CreateMap<CategoryCreateDto, CreateCategoryCommand>().ReverseMap();
        CreateMap<CategoryUpdateDto, CategoryUpdateCommand>().ReverseMap();

        // Companies
        CreateMap<Company, CompanyCreateDto>().ReverseMap();
        CreateMap<Company, CompanyUpdateDto>().ReverseMap();

        CreateMap<Company, CompanyCreateCommand>().ReverseMap();
        CreateMap<Company, CompanyUpdateCommand>().ReverseMap();

        CreateMap<CompanyCreateDto, CompanyCreateCommand>().ReverseMap();
        CreateMap<CompanyUpdateDto, CompanyUpdateCommand>().ReverseMap();
    }
}
