using AutoMapper;
using CookBook.BL.Api.Models.Ingredient;
using CookBook.Common.Enums;
using CookBook.Common.Extensions;
using CookBook.Common.Resources;
using CookBook.DAL.Entities;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace CookBook.BL.Api.Models.Recipe
{
    public class RecipeDetailIngredientModel
    {
        public double Amount { get; set; }
        public Unit Unit { get; set; }
        public IngredientListModel Ingredient { get; set; } = new IngredientListModel();
    }

    public class RecipeDetailIngredientModelMapperProfile : Profile
    {
        public RecipeDetailIngredientModelMapperProfile()
        {
            CreateMap<IngredientAmountEntity, RecipeDetailIngredientModel>();

            CreateMap<RecipeDetailIngredientModel, IngredientAmountEntity>()
                .Ignore(dst => dst.Id)
                .Ignore(dst => dst.RecipeId)
                .Ignore(dst => dst.Recipe)
                .Ignore(dst => dst.Ingredient);
        }
    }

    public class RecipeDetailIngredientModelValidator : AbstractValidator<RecipeDetailIngredientModel>
    {
        private double amountMinimumValue = 0;

        public RecipeDetailIngredientModelValidator(IStringLocalizer<RecipeNewModelResources> recipeNewModeLocalizer)
        {
            RuleFor(item => item.Amount)
                .GreaterThan(amountMinimumValue)
                .WithMessage(recipeNewModeLocalizer[nameof(RecipeNewModelResources.Ingredients_Amount_ValidationMessage), amountMinimumValue]);

            RuleFor(item => item.Unit)
                .NotEqual(Unit.Unknown)
                .WithMessage(recipeNewModeLocalizer[nameof(RecipeNewModelResources.Ingredients_Unit_ValidationMessage)]);
        }
    }
}