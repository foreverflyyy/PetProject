import { Product } from './components/Product';
import { useProducts } from './hooks/products';

function App() {

   const { error, loading, products } = useProducts();

   return (
      <div className="App">
         <p> Hello everyone! </p>
         {error && <p className="product-serror">{error}</p>}
         {loading && <p className="product-loading"> Loading... </p>}
         {products.map(product => <Product key={product.id} product={product} />)}
      </div>
   );
}

export default App;
