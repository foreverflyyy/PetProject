import { IUser } from "../models";
import '../styles/user.css'

interface ProductProps {
   user: IUser
}

export function User({ user }: ProductProps) {

   return (
      <div
         className="user"
      >
         <p className="">Name: {user.name}</p>
         <p className="">Age: {user.age}</p>
         <button
            className=""
         >
            Show Details
         </button>
      </div>
   )
}