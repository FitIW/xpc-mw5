using AutoMapper;
using CookBook.Common.Resources;
using CookBook.DAL.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace CookBook.BL.Api.Models.Ingredient
{
    public class IngredientDetailModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(IngredientNewModelResources), ErrorMessageResourceName = nameof(IngredientNewModelResources.Name_Required))]
        [StringLength(100, MinimumLength = 3, ErrorMessageResourceType = typeof(IngredientNewModelResources), ErrorMessageResourceName = nameof(IngredientNewModelResources.Name_StringLength))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(IngredientNewModelResources), ErrorMessageResourceName = nameof(IngredientNewModelResources.Description_Required))]
        [MinLength(10, ErrorMessageResourceType = typeof(IngredientNewModelResources), ErrorMessageResourceName = nameof(IngredientNewModelResources.Description_MinLength))]
        public string Description { get; set; }
    }

    public class IngredientDetailModelMapperProfile : Profile
    {
        public IngredientDetailModelMapperProfile()
        {
            CreateMap<IngredientEntity, IngredientDetailModel>();
            CreateMap<IngredientDetailModel, IngredientEntity>();
        }
    }
}