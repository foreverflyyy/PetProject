import { IProduct } from "../models";
import '../styles/product'

interface ProductProps {
   product: IProduct
}

export function Product({ product }: ProductProps) {

   return (
      <div
         className="product"
      >
         <img src={product.image} className="product-img" alt={product.title}></img>
         <p className="">{product.price}</p>
         <button
            className=""
         >
            Show Details
         </button>
      </div>
   )
}