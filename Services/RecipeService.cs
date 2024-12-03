using System.Collections.Generic;  
using System.Linq;  

namespace RecipeOrganizer.Services  
{  
    public class RecipeService  
    {  
        private readonly List<Recipe> recipes = new List<Recipe>();  

        public IEnumerable<Recipe> GetAllRecipes()  
        {  
            return recipes; // Return the list of recipes  
        }  

        public void AddRecipe(Recipe recipe)  
        {  
            recipe.Id = recipes.Count > 0 ? recipes.Max(r => r.Id) + 1 : 1; // Simple ID assignment  
            recipes.Add(recipe);  
        }  

        public void DeleteRecipe(int id)  
        {  
            var recipeToRemove = recipes.FirstOrDefault(r => r.Id == id);  
            if (recipeToRemove != null)  
            {  
                recipes.Remove(recipeToRemove);  
            }  
        }  

        public void UpdateRecipe(Recipe recipe)  
        {  
            var existingRecipe = recipes.FirstOrDefault(r => r.Id == recipe.Id);  
            if (existingRecipe != null)  
            {  
                existingRecipe.Name = recipe.Name;  
                existingRecipe.Description = recipe.Description;  
                existingRecipe.UsedFor = recipe.UsedFor;  
            }  
        }  
    }  
}