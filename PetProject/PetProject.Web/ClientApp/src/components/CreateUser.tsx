import React, { useState } from 'react';
import '../styles/user.css'
import { IModalWindow, IUser } from '../models';
import axios from 'axios';
import { ErrorMessage } from './ErrorMessage';

const userData: IUser = {
   name: '',
}

interface CreateUseProps {
   modalWindow: IModalWindow,
   onCreate: (product: IUser) => void
}

export function CreateUser({ modalWindow, onCreate }: CreateUseProps) {

   const [valueName, setValueName] = useState('');
   const [valueAge, setValueAge] = useState('');
   const [error, setError] = useState('');

   const submitHandler = async (event: React.FormEvent) => {
      event.preventDefault();
      setError('');

      if (valueName.trim().length === 0 || Number(valueAge) === 0) {
         setError('Please enter a valid name or age');
         return;
      }
      console.log(`Name: ${valueName}, Age: ${valueAge}`);

      userData.name = valueName;
      userData.age = Number(valueAge);
      const response = await axios.post('https://localhost:7215/user', userData);

      onCreate(response.data);
   }

   const changeName = async (event: React.ChangeEvent<HTMLInputElement>) => {
      setValueName(event.target.value);
   }

   const changeAge = async (event: React.ChangeEvent<HTMLInputElement>) => {
      setValueAge(event.target.value);
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
            type="text"
            className="form-create-user"
            placeholder="Enter user's age"
            value={valueAge}
            onChange={changeAge}
         />

         <ErrorMessage message={error} />
         <button type="submit" className="btn-create-user">{modalWindow.btnText}</button>
      </form>
   )
}