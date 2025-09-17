
import type { Product } from "../../app/models/product"
import ProductList from "./ProductList";

type props ={
  products:Product[];

}


export default function Catalog({products}:props) {
  return (
    <>
     <ProductList products={products}/>  
    </>
  )
}