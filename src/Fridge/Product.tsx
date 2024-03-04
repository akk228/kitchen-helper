import React, {Component} from "react";
import Units from "../Entities/Units";
import { UpdateFridgeContent } from "./FridgeApi/UpdateProducts";

export interface IProduct {
    name: string;
    amount: number;
    measurmentUnit: Units;
}

export class Product extends Component<{callback: any, product: IProduct}, IProduct>{
   constructor(props:{callback: any, product: IProduct}){
    super(props)
   }

    static getDerivedStateFromProps(props: {callback: any, product: IProduct}, state: IProduct){
        return  props.product;
    }

    handleDelete(event: any){
        UpdateFridgeContent.deleteProduct(this.state, this.props.callback, undefined);
        
    }

    render(): React.ReactNode {
        return (
            <article key={this.state.name}>{this.state.name}: {this.state.amount} {this.state.measurmentUnit}
                <button onClick={this.handleDelete.bind(this)}>x</button>
            </article>
        );
    }
}