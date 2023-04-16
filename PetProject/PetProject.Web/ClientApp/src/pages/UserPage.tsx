import { useContext } from 'react'
import { CreateUser } from '../components/CreateUser';
import { ErrorMessage } from '../components/ErrorMessage';
import { Loading } from '../components/Loading';
import { Modal } from '../components/Modal';
import { User } from '../components/Product';
import { useUsers } from '../hooks/products';
import { IUser } from '../models';
import '../styles/user.css'
import { ModalContext } from '../context/ModalContext';

export function UserPage() {

   const { error, loading, users, AddUser } = useUsers();

   const { modal, open, close } = useContext(ModalContext)

   const createHandler = (user: IUser) => {
      close();
      AddUser(user);
   }

   return (
      <div className="ProductPage">
         <p> Hello everyone! </p>
         {error && <ErrorMessage message={error} />}
         {loading && <Loading />}
         {users.map(user => <User key={user.id} user={user} />)}

         {modal && <Modal onClose={close}>
            <CreateUser onCreate={createHandler} />
         </Modal>}

         <button className="button-create" onClick={open}>+</button>
      </div>
   );
}