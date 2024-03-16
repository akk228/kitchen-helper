import React from "react";
import { IProduct } from "../Fridge/Product";
import { Cooking } from "./Cooking";
import ProductTable from "../Fridge/ProductTable";

export interface IRecipe {
    name: string,
    description: string | null | undefined,
    ingredients: IProduct[]
}

export class Recipe extends React.Component<IRecipe,IRecipe> {
    static getDerivedStateFromProps(props: IRecipe, state: IRecipe){
        return props;
    }
    render(): React.ReactNode {
        return (
            <article key={this.state?.name}>
                <h3>{this.state?.name}</h3>
                <h5>Ingredients</h5>
                    <ProductTable
                        products={this.state.ingredients}
                        onProductsChange={()=> {}}
                        edit={false}
                    />
                <Cooking {...this.state}/>
            </article>
        );
    }
}