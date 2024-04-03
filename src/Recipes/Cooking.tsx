import React from "react";
import { IRecipe } from "./Recipe";
import { Cook } from "./RecipesApi/Cook";

interface ICooking{
    recipe: IRecipe
}

interface ICookingProps{
    recipe: IRecipe,
    callback: ()=>void
}

export class Cooking extends React.Component<ICookingProps, ICooking>{

    static getDerivedStateFromProps(props: ICookingProps, state: ICooking){
        return { recipe: props.recipe};
    }

    handleTakeIngredients(){
        Cook.takeProducts(this.state.recipe.ingredients, this.props.callback, undefined)
    }

    render(): React.ReactNode {
        return  <button onClick={this.handleTakeIngredients.bind(this)}>Take ingredients from fridge</button>;
    }
}