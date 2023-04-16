import { useEffect, useState } from 'react';
import { IUser } from '../models';
import axios, { AxiosError } from 'axios';
import '../styles/user.css'

export function useUsers() {

   const [users, setUsers] = useState<IUser[]>([]);
   const [loading, setLoading] = useState(false);
   const [error, setError] = useState('');

   function AddUser(user: IUser) {
      setUsers(prev => [...prev, user]);
   }

   async function GetResponse() {
      try {
         setError('');
         setLoading(true);
         const response = await axios.get<IUser[]>('https://localhost:5001/api/users');
         setUsers(response.data);
         setLoading(false);
      } catch (e: unknown) {
         const error = e as AxiosError;
         setLoading(false);
         setError(error.message);
      }
   }

   useEffect(() => {
      GetResponse();
   }, []);

   return { error, loading, users, AddUser }
}