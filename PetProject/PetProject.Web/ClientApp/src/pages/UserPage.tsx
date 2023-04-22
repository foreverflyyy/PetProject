import { useContext } from 'react'
import { CreateUser } from '../components/CreateUser';
import { ErrorMessage } from '../components/ErrorMessage';
import { Loading } from '../components/Loading';
import { Modal } from '../components/Modal';
import { User } from '../components/UserBlock';
import { useUsers } from '../hooks/users';
import { IUser, IModalWindow } from '../models';
import '../styles/user.css'
import { ModalContext } from '../context/ModalContext';

export function UserPage() {

   const { error, loading, users, AddUser, DeleteUser, UpdateUser } = useUsers();

   const { modal, open, close } = useContext(ModalContext)

   const createHandler = (user: IUser) => {
      close();
      AddUser(user);
   }

   const deleteHandler = (user: IUser) => {
      DeleteUser(user);
   }

   const updateHandler = (user: IUser) => {
      open();
      UpdateUser(user);
   }

   return (
      <div className="ProductPage">
         <p> Hello everyone! </p>
         {error && <ErrorMessage message={error} />}
         {loading && <Loading />}
         {users.map(user => <User key={user.id} user={user} deleteUser={deleteHandler} updateUser={updateHandler} />)}

         {modal && <Modal modalWindow={ } onClose={close}>
            <CreateUser modalWindow={ } onCreate={createHandler} />
         </Modal>}

         <button className="button-create" onClick={open}>+</button>
      </div>
   );
}