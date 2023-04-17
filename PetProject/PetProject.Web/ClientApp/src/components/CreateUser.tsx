import React, { useState } from 'react';
import '../styles/user.css'
import { IUser } from '../models';
import axios from 'axios';
import { ErrorMessage } from './ErrorMessage';

const userData: IUser = {
   name: '',
   age: 0,
}

interface CreateUseProps {
   onCreate: (product: IUser) => void
}

export function CreateUser({ onCreate }: CreateUseProps) {

   const [valueName, setValueName] = useState('');
   const [valueAge, setValueAge] = useState(0);
   const [error, setError] = useState('');

   const submitHandler = async (event: React.FormEvent) => {
      event.preventDefault();
      setError('');

      if (valueName.trim().length === 0 || valueAge === 0) {
         setError('Please enter a valid name pr age');
         return;
      }

      userData.name = valueName;
      userData.age = valueAge;
      const response = await axios.post('https://localhost:7215/users', userData);

      onCreate(response.data);
   }

   const changeName = async (event: React.ChangeEvent<HTMLInputElement>) => {
      setValueName(event.target.value);
   }

   const changeAge = async (event: React.ChangeEvent<HTMLInputElement>) => {

      if (typeof event.target.value !== 'number') {
         setError('Please enter a valid name pr age');
         return;
      }
      setError('');
      setValueAge(Number(event.target.value));
   }

   return (
      <form onSubmit={submitHandler}>
         <input
            type="text"
            className="form-create-user"
            placeholder="Enter your user name"
            value={valueName}
            onChange={changeName}
         />
         <input
            type="number"
            className="form-create-user"
            placeholder="Enter user's age"
            value={valueAge}
            onChange={changeAge}
         />

         <ErrorMessage message={error} />
         <button type="submit" className="btn-create-user">Create</button>
      </form>
   )
}