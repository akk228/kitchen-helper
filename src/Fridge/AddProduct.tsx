import React, { Component } from "react";
import { IProduct } from "./Product";
import Units from "../Entities/Units";
import { UpdateFridgeContent } from "./FridgeApi/UpdateProducts";

export class AddProductForm extends Component<any, IProduct> {
  constructor(props: any) {
    super(props);
    this.state = { name: "", amount: 0, measurmentUnit: "gr" };
  }

  state: IProduct;

  handleSubmit(event: any) {
    event.preventDefault();
    UpdateFridgeContent.addProduct(this.state, this.props.onAdd, undefined);
  }

  render(): React.ReactNode {
    return (
      <div>
        <form onSubmit={this.handleSubmit.bind(this)}>
          <label>Name</label>
          <br />
          <input
            type="text"
            value={this.state.name}
            onChange={(e) => {
              e.preventDefault();
              this.setState({ name: e.target.value });
            }}
          />
          <br />
          <label>Amount</label>
          <br />
          <input
            type="number"
            value={this.state.amount}
            onChange={(e) => {
              e.preventDefault();
              this.setState({ amount: e.target.valueAsNumber });
            }}
          />
          <br />
          <label>
            <select
              value={this.state.measurmentUnit}
              onChange={(e) => {
                e.preventDefault();
                this.setState({ measurmentUnit: e.target.value as Units });
              }}
            >
              <option value={"gr"}>gr</option>
              <option value={"ml"}>ml</option>
              <option value={"unit"}>item</option>
            </select>
          </label>
          <button type="submit">Add</button>
        </form>
      </div>
    );
  }
}