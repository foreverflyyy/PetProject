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
         <p className="">{user.name}</p>
         <button
            className=""
         >
            Show Details
         </button>
      </div>
   )
}