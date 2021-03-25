﻿using AutoMapper;
using CookBook.Common.Enums;
using CookBook.Common.Extensions;
using CookBook.Common.Resources;
using CookBook.DAL.Entities;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;

namespace CookBook.BL.Api.Models.Recipe
{
    public class RecipeDetailModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public FoodType FoodType { get; set; }
        public IList<RecipeDetailIngredientModel> Ingredients { get; set; }
    }

    public class RecipeDetailModelMapperProfile : Profile
    {
        public RecipeDetailModelMapperProfile()
        {
            CreateMap<RecipeEntity, RecipeDetailModel>()
                .MapMember(dst => dst.Ingredients, src => src.IngredientAmounts);

            CreateMap<RecipeDetailModel, RecipeEntity>()
                .MapMember(dst => dst.IngredientAmounts, src => src.Ingredients);
        }
    }

    public class RecipeDetailModelValidator : AbstractValidator<RecipeDetailModel>
    {
        private const int nameMinimumLength = 3;
        private const int descriptionMinimumLength = 10;
        private const int durationMinimumMinutes = 1;

        public RecipeDetailModelValidator(IStringLocalizer<RecipeNewModelResources> recipeNewModeLocalizer)
        {
            RuleFor(recipe => recipe.Name)
                .NotEmpty()
                .MinimumLength(nameMinimumLength)
                .WithMessage(recipeNewModeLocalizer[nameof(RecipeNewModelResources.Name_ValidationMessage), nameMinimumLength].Value);

            RuleFor(recipe => recipe.Description)
                .NotEmpty()
                .MinimumLength(descriptionMinimumLength)
                .WithMessage(recipeNewModeLocalizer[nameof(RecipeNewModelResources.Description_ValidationMessage), descriptionMinimumLength].Value);

            RuleFor(recipe => recipe.FoodType)
                .NotEqual(FoodType.Unknown)
                .WithMessage(recipeNewModeLocalizer[nameof(RecipeNewModelResources.FoodType_ValidationMessage), FoodType.Unknown.ToString()].Value);

            RuleFor(recipe => recipe.Duration)
                .GreaterThan(TimeSpan.FromMinutes(durationMinimumMinutes))
                .WithMessage(recipeNewModeLocalizer[nameof(RecipeNewModelResources.Duration_ValidationMessage), durationMinimumMinutes]);

            RuleFor(recipe => recipe.Ingredients)
                .NotEmpty()
                .WithMessage(recipeNewModeLocalizer[nameof(RecipeNewModelResources.Ingredients_ValidationMessage)].Value);
        }
    }
}