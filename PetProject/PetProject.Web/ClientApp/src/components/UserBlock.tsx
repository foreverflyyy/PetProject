import { IUser } from "../models";
import axios from 'axios';
import '../styles/user.css'

interface UserProps {
   user: IUser,
   updateUser: (product: IUser) => void
   deleteUser: (product: IUser) => void
}

export function User({ user, deleteUser, updateUser }: UserProps) {

   const deleteCurrentUser = async (event: React.FormEvent) => {
      event.preventDefault();

      await axios.post('https://localhost:7215/user/delete', user);
      deleteUser(user);
   }

   const updateCurrentUser = async (event: React.FormEvent) => {
      event.preventDefault();

      await axios.post('https://localhost:7215/user/update', user);
      updateUser(user);
   }

   return (
      <div
         className="user"
      >
         <p className="">Name: {user.name}</p>
         <p className="">Age: {user.age}</p>

         <button className="">
            Update data
         </button>
         <button className="" onClick={deleteCurrentUser}>
            Delete
         </button>
      </div>
   )
}