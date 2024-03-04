import React from "react";
import { IProduct } from "../Fridge/Product";

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
                    <ol>
                        {this.state?.ingredients?.map((product) => {
                            return (
                                <li key={product.name}>{product.name}</li>
                            );
                        })}
                    </ol>
                    
            </article>
        );
    }
}