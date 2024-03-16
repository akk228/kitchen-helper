import React, {Component} from "react";
import Units from "../Entities/Units";
import { UpdateFridgeContent } from "./FridgeApi/UpdateProducts";

export interface IProduct {
    name: string;
    amount: number;
    measurmentUnit: Units;
}

export class Product extends Component<{callback: any, product: IProduct, edit: boolean}, {product: IProduct, edit: boolean}>{
   constructor(props:{callback: any, product: IProduct, edit: boolean}){
    super(props)
   }

    static getDerivedStateFromProps(props: {callback: any, product: IProduct, edit: boolean}, state: {product: IProduct, edit: boolean}){
        return  {product: props.product, edit: props.edit};
    }

    handleDelete(event: any){
        UpdateFridgeContent.deleteProduct(this.state.product, this.props.callback, undefined);
        
    }

    render(): React.ReactNode {
        return (
            <tr>
                <td>{this.state.product.name}</td>
                <td>{this.state.product.amount}</td>
                <td>{this.state.product.measurmentUnit}</td>
                {
                    this.state.edit &&
                    <td>
                        <button onClick={this.handleDelete.bind(this)}>x</button>
                    </td>
                }
            </tr>
        );
    }
}