import React from "react";
import { IRecipe, Recipe} from "./Recipe";

import { GetRecipes } from "./RecipesApi/GetRecipes";

interface IRecipes {
    recipes: IRecipe[]
}
export class Recipes extends React.Component<{}, IRecipes>{

    render(): React.ReactNode {
        return (<>
            <h1>
                List of recipes
            </h1>
            <div>
                {this.state?.recipes?.map(recipe => {
                    return (
                        <Recipe {...recipe}/>
                        // <article key={recipe.name}>
                        //     <h3>{recipe.name}</h3>
                        //     <ol>
                        //         {recipe?.ingredients?.map((product) => {
                        //             return (
                        //                 <li key={product.name}>{product.name}</li>
                        //             );
                        //         })}
                        //     </ol>
                        // </article>
                        );
                })}
            </div>
        </>)
    }

    componentDidMount(): void {
        GetRecipes.getAllRecipes((content: IRecipe[]) => {
            this.setState({ recipes: content })
        })
    }
}