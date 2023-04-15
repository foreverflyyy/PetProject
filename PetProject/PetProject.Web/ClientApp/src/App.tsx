import { ErrorMessage } from './components/ErrorMessage';
import { Loading } from './components/Loading';
import { Product } from './components/Product';
import { useProducts } from './hooks/products';

function App() {

   const { error, loading, products } = useProducts();

   return (
      <div className="App">
         <p> Hello everyone! </p>
         {error && <ErrorMessage message={error} />}
         {loading && <Loading />}
         {products.map(product => <Product key={product.id} product={product} />)}
      </div>
   );
}

export default App;
