import React, { Component } from "react";
import { IProduct } from "./Product";
import Units from "../Entities/Units";

interface IAddProductFormProps {
  onAdd: (product: IProduct) => void
}
interface IAddProductFormState{
  product: IProduct,
  enabled: boolean
}

export class AddProductForm extends Component<IAddProductFormProps, IAddProductFormState> {
  constructor(props: any) {
    super(props);
    this.state = { product : {
      name: "",
      amount: 0,
      measurmentUnit: Units.gr },
    enabled: false};
  }


  handleEnableForm(event: any) {
    event.preventDefault();
    this.setState({enabled: !this.state.enabled})
  }

  handleSubmit(event: any) {
    event.preventDefault();
    this.props.onAdd(this.state.product);
  }

  render(): React.ReactNode {
    return (
      <>
      {!this.state.enabled && <button onClick={this.handleEnableForm.bind(this)}>Add product</button>}
      {this.state.enabled && <div className="overlay">
        <form onSubmit={this.handleSubmit.bind(this)}>
          <label>Name</label>
          <br />
          <input
            type="text"
            value={this.state.product.name}
            onChange={(e) => {
              e.preventDefault();
              this.setState({ product: {...this.state.product, name: e.target.value} });
            }}
          />
          <br />
          <label>Amount</label>
          <br />
          <input
            type="number"
            value={this.state.product.amount}
            onChange={(e) => {
              e.preventDefault();
              this.setState({ product: {...this.state.product,  amount: e.target.valueAsNumber} });
            }}
          />
          <br />
          <label>
            <select
              value={this.state.product.measurmentUnit}
              onChange={(e) => {
                e.preventDefault();
                this.setState({ product: {...this.state.product, measurmentUnit: e.target.value as unknown as Units} });
              }}
            >
              <option value={Units.gr}>gr</option>
              <option value={Units.ml}>ml</option>
              <option value={Units.unit}>item</option>
            </select>
          </label>
          <button type="submit">Add</button>
          <button onClick={this.handleEnableForm.bind(this)}>Cancel</button>
        </form>
      </div>}
      </>
    );
  }
}