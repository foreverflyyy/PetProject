import { useContext } from 'react'
import { CreateUser } from '../components/CreateUser';
import { ErrorMessage } from '../components/ErrorMessage';
import { Loading } from '../components/Loading';
import { Modal } from '../components/Modal';
import { Product } from '../components/Product';
import { useProducts } from '../hooks/products';
import { IProduct } from '../models';
import '../styles/product.css'
import { ModalContext } from '../context/ModalContext';

export function ProductPage() {

   const { error, loading, products, AddProduct } = useProducts();

   const { modal, open, close } = useContext(ModalContext)

   const createHandler = (product: IProduct) => {
      close();
      AddProduct(product);
   }

   return (
      <div className="ProductPage">
         <p> Hello everyone! </p>
         {error && <ErrorMessage message={error} />}
         {loading && <Loading />}
         {products.map(product => <Product key={product.id} product={product} />)}

         {modal && <Modal onClose={close}>
            <CreateUser onCreate={createHandler} />
         </Modal>}

         <button className="button-create" onClick={open}>+</button>
      </div>
   );
}