import React, { useEffect } from 'react';
import { IProduct } from './models';
import axios from 'axios';
import { Product } from './components/Product';

function App() {

   const [products, setProducts] = React.useState<IProduct[]>([]);

   async function GetResponse() {
      const response = await axios.get<IProduct[]>('https://fakestoreapi.com/products?limit=5');
      setProducts(response.data);
   }

   useEffect(() => {
      GetResponse();
   }, []);

   return (
      <div className="App">
         <p> Hello everyone! </p>
         {products.map(product => <Product key={product.id} product={product} />)}
      </div>
   );
}

export default App;
