import React, {Component} from "react";
import Units from "../Entities/Units";
import { UpdateFridgeContent } from "./FridgeApi/UpdateProducts";

export interface IProduct {
    name: string;
    amount: number;
    measurmentUnit: Units;
}

interface IProductProps {
    product: IProduct,
    edit: boolean,
    onProductChange: (product: IProduct) => void
}

export class Product extends Component<IProductProps, {product: IProduct, edit: boolean}>{

    static getDerivedStateFromProps(props: IProductProps, state: {product: IProduct, edit: boolean}){
        return  {product: props.product, edit: props.edit};
    }

    handleProductChange(){
        this.props.onProductChange(this.state.product);
        // UpdateFridgeContent.deleteProduct(this.state.product, this.props.callback, undefined);
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
                        <button onClick={this.handleProductChange.bind(this)}>x</button>
                    </td>
                }
            </tr>
        );
    }
}