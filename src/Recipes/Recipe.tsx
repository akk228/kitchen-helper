import React from "react";
import { IProduct } from "../Fridge/Product";
import { Cooking } from "./Cooking";
import ProductTable from "../Fridge/ProductTable";
import UpdateRecipes from "./RecipesApi/UpdateRecipes";

interface IRecipeProps{
    recipe: IRecipe,
    onChange: () => void
}

export interface IRecipe {
    name: string,
    description: string | null | undefined,
    ingredients: IProduct[]
}

export class Recipe extends React.Component<IRecipeProps,IRecipe> {
    static getDerivedStateFromProps(props: IRecipeProps, state: IRecipe){
        return props.recipe;
    }

    handleDeleteRecipe(){
        const recipeName: string = this.state.name;
        UpdateRecipes.delete(recipeName, this.props.onChange)
    }

    render(): React.ReactNode {
        return (
            <article key={this.state?.name}>
                <h3>{this.state?.name}</h3>
                <h5>Ingredients</h5>
                <button onClick={this.handleDeleteRecipe.bind(this)}>Delete</button>
                    <ProductTable
                        products={this.state.ingredients}
                        onProductsChange={()=> {}}
                        edit={false}
                    />
                <Cooking 
                    recipe={ this.props.recipe}
                    callback={this.props.onChange}/>
            </article>
        );
    }
}